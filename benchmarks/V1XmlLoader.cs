using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;
using Cyotek.Drawing.BitmapFont;

namespace Benchmarks
{
  internal sealed class V1XmlLoader
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

      result = new BitmapFont();

      XmlDocument document;
      IDictionary<int, Page> pageData;
      IDictionary<Kerning, int> kerningDictionary;
      IDictionary<char, Character> charDictionary;
      XmlNode root;
      XmlNode properties;

      if (reader == null)
      {
        throw new ArgumentNullException("reader");
      }

      document = new XmlDocument();
      pageData = new SortedDictionary<int, Page>();
      kerningDictionary = new Dictionary<Kerning, int>();
      charDictionary = new Dictionary<char, Character>();

      document.Load(reader);
      root = document.DocumentElement;

      // load the basic attributes
      properties = root.SelectSingleNode("info");
      result.FamilyName = properties.Attributes["face"].Value;
      result.FontSize = Convert.ToInt32(properties.Attributes["size"].Value);
      result.Bold = Convert.ToInt32(properties.Attributes["bold"].Value) != 0;
      result.Italic = Convert.ToInt32(properties.Attributes["italic"].Value) != 0;
      result.Unicode = Convert.ToInt32(properties.Attributes["unicode"].Value) != 0;
      result.StretchedHeight = Convert.ToInt32(properties.Attributes["stretchH"].Value);
      result.Charset = properties.Attributes["charset"].Value;
      result.Smoothed = Convert.ToInt32(properties.Attributes["smooth"].Value) != 0;
      result.SuperSampling = Convert.ToInt32(properties.Attributes["aa"].Value);
      result.Padding = this.ParsePadding(properties.Attributes["padding"].Value);
      result.Spacing = this.ParsePoint(properties.Attributes["spacing"].Value);
      result.OutlineSize = Convert.ToInt32(properties.Attributes["outline"].Value);

      // common attributes
      properties = root.SelectSingleNode("common");
      result.BaseHeight = Convert.ToInt32(properties.Attributes["base"].Value);
      result.LineHeight = Convert.ToInt32(properties.Attributes["lineHeight"].Value);
      result.TextureSize = new Size(Convert.ToInt32(properties.Attributes["scaleW"].Value), Convert.ToInt32(properties.Attributes["scaleH"].Value));
      result.Packed = Convert.ToInt32(properties.Attributes["packed"].Value) != 0;
      result.AlphaChannel = Convert.ToInt32(properties.Attributes["alphaChnl"].Value);
      result.RedChannel = Convert.ToInt32(properties.Attributes["redChnl"].Value);
      result.GreenChannel = Convert.ToInt32(properties.Attributes["greenChnl"].Value);
      result.BlueChannel = Convert.ToInt32(properties.Attributes["blueChnl"].Value);

      // load texture information
      foreach (XmlNode node in root.SelectNodes("pages/page"))
      {
        Page page;

        page = new Page();
        page.Id = Convert.ToInt32(node.Attributes["id"].Value);
        page.FileName = node.Attributes["file"].Value;

        pageData.Add(page.Id, page);
      }
      result.Pages = this.ToArray(pageData.Values);

      // load character information
      foreach (XmlNode node in root.SelectNodes("chars/char"))
      {
        Character character;

        character = new Character();
        character.Char = (char)Convert.ToInt32(node.Attributes["id"].Value);
        character.Bounds = new Rectangle(Convert.ToInt32(node.Attributes["x"].Value), Convert.ToInt32(node.Attributes["y"].Value), Convert.ToInt32(node.Attributes["width"].Value), Convert.ToInt32(node.Attributes["height"].Value));
        character.Offset = new Point(Convert.ToInt32(node.Attributes["xoffset"].Value), Convert.ToInt32(node.Attributes["yoffset"].Value));
        character.XAdvance = Convert.ToInt32(node.Attributes["xadvance"].Value);
        character.TexturePage = Convert.ToInt32(node.Attributes["page"].Value);
        character.Channel = Convert.ToInt32(node.Attributes["chnl"].Value);

        charDictionary.Add(character.Char, character);
      }
      result.Characters = charDictionary;

      // loading kerning information
      foreach (XmlNode node in root.SelectNodes("kernings/kerning"))
      {
        Kerning key;

        key = new Kerning((char)Convert.ToInt32(node.Attributes["first"].Value), (char)Convert.ToInt32(node.Attributes["second"].Value), Convert.ToInt32(node.Attributes["amount"].Value));

        if (!kerningDictionary.ContainsKey(key))
        {
          kerningDictionary.Add(key, key.Amount);
        }
      }
      result.Kernings = kerningDictionary;

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
