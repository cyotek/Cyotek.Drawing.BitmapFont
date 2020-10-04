using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Cyotek.Drawing.BitmapFont;

namespace Benchmarks
{
  internal sealed class V1TextLoader
  {
    #region Methods

    public BitmapFont Load(string fileName)
    {
      using (Stream stream = File.OpenRead(fileName))
      {
        return this.Load(stream);
      }
    }

    public BitmapFont Load(Stream stream)
    {
      using (TextReader reader = new StreamReader(stream))
      {
        return this.Load(reader);
      }
    }

    public BitmapFont Load(TextReader reader)
    {
      BitmapFont result;
      IDictionary<int, Page> pageData;
      IDictionary<Kerning, int> kerningDictionary;
      IDictionary<char, Character> charDictionary;
      string line;

      result = new BitmapFont();

      if (reader == null)
      {
        throw new ArgumentNullException("reader");
      }

      pageData = new SortedDictionary<int, Page>();
      kerningDictionary = new Dictionary<Kerning, int>();
      charDictionary = new Dictionary<char, Character>();

      do
      {
        line = reader.ReadLine();

        if (line != null)
        {
          string[] parts;

          parts = this.Split(line, ' ');

          if (parts.Length != 0)
          {
            switch (parts[0])
            {
              case "info":
                result.FamilyName = this.GetNamedString(parts, "face");
                result.FontSize = this.GetNamedInt(parts, "size");
                result.Bold = this.GetNamedBool(parts, "bold");
                result.Italic = this.GetNamedBool(parts, "italic");
                result.Charset = this.GetNamedString(parts, "charset");
                result.Unicode = this.GetNamedBool(parts, "unicode");
                result.StretchedHeight = this.GetNamedInt(parts, "stretchH");
                result.Smoothed = this.GetNamedBool(parts, "smooth");
                result.SuperSampling = this.GetNamedInt(parts, "aa");
                result.Padding = this.ParsePadding(this.GetNamedString(parts, "padding"));
                result.Spacing = this.ParsePoint(this.GetNamedString(parts, "spacing"));
                result.OutlineSize = this.GetNamedInt(parts, "outline");
                break;
              case "common":
                result.LineHeight = this.GetNamedInt(parts, "lineHeight");
                result.BaseHeight = this.GetNamedInt(parts, "base");
                result.TextureSize = new Size(this.GetNamedInt(parts, "scaleW"), this.GetNamedInt(parts, "scaleH"));
                result.Packed = this.GetNamedBool(parts, "packed");
                result.AlphaChannel = this.GetNamedInt(parts, "alphaChnl");
                result.RedChannel = this.GetNamedInt(parts, "redChnl");
                result.GreenChannel = this.GetNamedInt(parts, "greenChnl");
                result.BlueChannel = this.GetNamedInt(parts, "blueChnl");
                break;
              case "page":
                int id;
                string name;

                id = this.GetNamedInt(parts, "id");
                name = this.GetNamedString(parts, "file");

                pageData.Add(id, new Page(id, name));
                break;
              case "char":
                Character charData;

                charData = new Character
                           {
                             Char = (char)this.GetNamedInt(parts, "id"),
                             Bounds = new Rectangle(this.GetNamedInt(parts, "x"), this.GetNamedInt(parts, "y"), this.GetNamedInt(parts, "width"), this.GetNamedInt(parts, "height")),
                             Offset = new Point(this.GetNamedInt(parts, "xoffset"), this.GetNamedInt(parts, "yoffset")),
                             XAdvance = this.GetNamedInt(parts, "xadvance"),
                             TexturePage = this.GetNamedInt(parts, "page"),
                             Channel = this.GetNamedInt(parts, "chnl")
                           };
                charDictionary.Add(charData.Char, charData);
                break;
              case "kerning":
                Kerning key;

                key = new Kerning((char)this.GetNamedInt(parts, "first"), (char)this.GetNamedInt(parts, "second"), this.GetNamedInt(parts, "amount"));

                if (!kerningDictionary.ContainsKey(key))
                {
                  kerningDictionary.Add(key, key.Amount);
                }
                break;
            }
          }
        }
      } while (line != null);

      result.Pages = this.ToArray(pageData.Values);
      result.Characters = charDictionary;
      result.Kernings = kerningDictionary;

      return result;
    }

    /// <summary>
    /// Returns a boolean from an array of name/value pairs.
    /// </summary>
    /// <param name="parts">The array of parts.</param>
    /// <param name="name">The name of the value to return.</param>
    /// <param name="defaultValue">Default value(if the key doesnt exist or can't be parsed)</param>
    /// <returns></returns>
    internal bool GetNamedBool(string[] parts, string name, bool defaultValue = false)
    {
      string s = this.GetNamedString(parts, name);

      bool result;
      int v;
      if (int.TryParse(s, out v))
      {
        result = v > 0;
      }
      else
      {
        result = defaultValue;
      }

      return result;
    }

    /// <summary>
    /// Returns an integer from an array of name/value pairs.
    /// </summary>
    /// <param name="parts">The array of parts.</param>
    /// <param name="name">The name of the value to return.</param>
    /// <param name="defaultValue">Default value(if the key doesnt exist or can't be parsed)</param>
    /// <returns></returns>
    internal int GetNamedInt(string[] parts, string name, int defaultValue = 0)
    {
      string s = this.GetNamedString(parts, name);

      int result;
      if (!int.TryParse(s, out result))
      {
        result = defaultValue;
      }

      return result;
    }

    /// <summary>
    /// Returns a string from an array of name/value pairs.
    /// </summary>
    /// <param name="parts">The array of parts.</param>
    /// <param name="name">The name of the value to return.</param>
    /// <returns></returns>
    internal string GetNamedString(string[] parts, string name)
    {
      string result;

      result = string.Empty;

      foreach (string part in parts)
      {
        int nameEndIndex;

        nameEndIndex = part.IndexOf('=');
        if (nameEndIndex != -1)
        {
          string namePart;
          string valuePart;

          namePart = part.Substring(0, nameEndIndex);
          valuePart = part.Substring(nameEndIndex + 1);

          if (string.Equals(name, namePart, StringComparison.InvariantCultureIgnoreCase))
          {
            int length;

            length = valuePart.Length;

            if (length > 1 && valuePart[0] == '"' && valuePart[length - 1] == '"')
            {
              valuePart = valuePart.Substring(1, length - 2);
            }

            result = valuePart;
            break;
          }
        }
      }

      return result;
    }

    /// <summary>
    /// Creates a Padding object from a string representation
    /// </summary>
    /// <param name="s">The string.</param>
    /// <returns></returns>
    internal Padding ParsePadding(string s)
    {
      string[] parts;

      parts = s.Split(',');

      return new Padding()
             {
               Left = Convert.ToInt32(parts[3].Trim()),
               Top = Convert.ToInt32(parts[0].Trim()),
               Right = Convert.ToInt32(parts[1].Trim()),
               Bottom = Convert.ToInt32(parts[2].Trim())
             };
    }

    /// <summary>
    /// Creates a Point object from a string representation
    /// </summary>
    /// <param name="s">The string.</param>
    /// <returns></returns>
    internal Point ParsePoint(string s)
    {
      string[] parts;

      parts = s.Split(',');

      return new Point()
             {
               X = Convert.ToInt32(parts[0].Trim()),
               Y = Convert.ToInt32(parts[1].Trim())
             };
    }

    /// <summary>
    /// Splits the specified string using a given delimiter, ignoring any instances of the delimiter as part of a quoted string.
    /// </summary>
    /// <param name="s">The string to split.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns></returns>
    internal string[] Split(string s, char delimiter)
    {
      string[] results;

      if (s.IndexOf('"') != -1)
      {
        List<string> parts;
        int partStart;

        partStart = -1;
        parts = new List<string>();

        do
        {
          int partEnd;
          int quoteStart;
          int quoteEnd;
          bool hasQuotes;

          quoteStart = s.IndexOf('"', partStart + 1);
          quoteEnd = s.IndexOf('"', quoteStart + 1);
          partEnd = s.IndexOf(delimiter, partStart + 1);

          if (partEnd == -1)
          {
            partEnd = s.Length;
          }

          hasQuotes = quoteStart != -1 && partEnd > quoteStart && partEnd < quoteEnd;
          if (hasQuotes)
          {
            partEnd = s.IndexOf(delimiter, quoteEnd + 1);
          }

          parts.Add(s.Substring(partStart + 1, partEnd - partStart - 1));

          if (hasQuotes)
          {
            partStart = partEnd - 1;
          }

          partStart = s.IndexOf(delimiter, partStart + 1);
        } while (partStart != -1);

        results = parts.ToArray();
      }
      else
      {
        results = s.Split(new char[]
                          {
                            delimiter
                          }, StringSplitOptions.RemoveEmptyEntries);
      }

      return results;
    }

    /// <summary>
    /// Converts the given collection into an array
    /// </summary>
    /// <typeparam name="T">Type of the items in the array</typeparam>
    /// <param name="values">The values.</param>
    /// <returns></returns>
    internal T[] ToArray<T>(ICollection<T> values)
    {
      T[] result;

      // avoid a forced .NET 3 dependency just for one call to Linq

      result = new T[values.Count];
      values.CopyTo(result, 0);

      return result;
    }

    #endregion
  }
}
