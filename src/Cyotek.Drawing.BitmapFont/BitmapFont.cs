/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2015 Cyotek Ltd.
 *
 * Licensed under the MIT License. See license.txt for the full text.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace Cyotek.Drawing.BitmapFont
{
  public class BitmapFont : IEnumerable<Character>
  {
    #region Constants

    public const int NoMaxWidth = -1;

    #endregion

    #region Properties

    public int AlphaChannel { get; set; }

    public int BaseHeight { get; set; }

    public int BlueChannel { get; set; }

    public bool Bold { get; set; }

    public IDictionary<char, Character> Characters { get; set; }

    public string Charset { get; set; }

    public string FamilyName { get; set; }

    public int FontSize { get; set; }

    public int GreenChannel { get; set; }

    public bool Italic { get; set; }

    public Character this[char character]
    {
      get { return this.Characters[character]; }
    }

    public IDictionary<Kerning, int> Kernings { get; set; }

    public int LineHeight { get; set; }

    public int OutlineSize { get; set; }

    public bool Packed { get; set; }

    public Padding Padding { get; set; }

    public Page[] Pages { get; set; }

    public int RedChannel { get; set; }

    public bool Smoothed { get; set; }

    public Point Spacing { get; set; }

    public int StretchedHeight { get; set; }

    public int SuperSampling { get; set; }

    public Size TextureSize { get; set; }

    public bool Unicode { get; set; }

    #endregion

    #region Methods

    public int GetKerning(char previous, char current)
    {
      Kerning key;
      int result;

      key = new Kerning(previous, current, 0);
      if (!this.Kernings.TryGetValue(key, out result))
      {
        result = 0;
      }

      return result;
    }

    public virtual void Load(Stream stream)
    {
      byte[] buffer;
      string header;

      if (stream == null)
      {
        throw new ArgumentNullException("stream");
      }

      if (!stream.CanSeek)
      {
        throw new ArgumentException("Stream must be seekable in order to determine file format.", "stream");
      }

      // read the first five bytes so we can try and work out what the format is
      // then reset the position so the format loaders can work
      buffer = new byte[5];
      stream.Read(buffer, 0, 5);
      stream.Seek(0, SeekOrigin.Begin);
      header = Encoding.ASCII.GetString(buffer);

      switch (header)
      {
        case "info ":
          this.LoadText(stream);
          break;
        case "<?xml":
          this.LoadXml(stream);
          break;
        default:
          throw new InvalidDataException("Unknown file format.");
      }
    }

    public void Load(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException("fileName");
      }

      if (!File.Exists(fileName))
      {
        throw new FileNotFoundException(string.Format("Cannot find file '{0}'.", fileName), fileName);
      }

      using (Stream stream = File.OpenRead(fileName))
      {
        this.Load(stream);
      }

      BitmapFontLoader.QualifyResourcePaths(this, Path.GetDirectoryName(fileName));
    }

    public void LoadText(string text)
    {
      using (StringReader reader = new StringReader(text))
      {
        this.LoadText(reader);
      }
    }

    public void LoadText(Stream stream)
    {
      if (stream == null)
      {
        throw new ArgumentNullException("stream");
      }

      using (TextReader reader = new StreamReader(stream))
      {
        this.LoadText(reader);
      }
    }

    public virtual void LoadText(TextReader reader)
    {
      IDictionary<int, Page> pageData;
      IDictionary<Kerning, int> kerningDictionary;
      IDictionary<char, Character> charDictionary;
      string line;

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

          parts = BitmapFontLoader.Split(line, ' ');

          if (parts.Length != 0)
          {
            switch (parts[0])
            {
              case "info":
                this.FamilyName = BitmapFontLoader.GetNamedString(parts, "face");
                this.FontSize = BitmapFontLoader.GetNamedInt(parts, "size");
                this.Bold = BitmapFontLoader.GetNamedBool(parts, "bold");
                this.Italic = BitmapFontLoader.GetNamedBool(parts, "italic");
                this.Charset = BitmapFontLoader.GetNamedString(parts, "charset");
                this.Unicode = BitmapFontLoader.GetNamedBool(parts, "unicode");
                this.StretchedHeight = BitmapFontLoader.GetNamedInt(parts, "stretchH");
                this.Smoothed = BitmapFontLoader.GetNamedBool(parts, "smooth");
                this.SuperSampling = BitmapFontLoader.GetNamedInt(parts, "aa");
                this.Padding = BitmapFontLoader.ParsePadding(BitmapFontLoader.GetNamedString(parts, "padding"));
                this.Spacing = BitmapFontLoader.ParsePoint(BitmapFontLoader.GetNamedString(parts, "spacing"));
                this.OutlineSize = BitmapFontLoader.GetNamedInt(parts, "outline");
                break;
              case "common":
                this.LineHeight = BitmapFontLoader.GetNamedInt(parts, "lineHeight");
                this.BaseHeight = BitmapFontLoader.GetNamedInt(parts, "base");
                this.TextureSize = new Size(BitmapFontLoader.GetNamedInt(parts, "scaleW"), BitmapFontLoader.GetNamedInt(parts, "scaleH"));
                this.Packed = BitmapFontLoader.GetNamedBool(parts, "packed");
                this.AlphaChannel = BitmapFontLoader.GetNamedInt(parts, "alphaChnl");
                this.RedChannel = BitmapFontLoader.GetNamedInt(parts, "redChnl");
                this.GreenChannel = BitmapFontLoader.GetNamedInt(parts, "greenChnl");
                this.BlueChannel = BitmapFontLoader.GetNamedInt(parts, "blueChnl");
                break;
              case "page":
                int id;
                string name;

                id = BitmapFontLoader.GetNamedInt(parts, "id");
                name = BitmapFontLoader.GetNamedString(parts, "file");

                pageData.Add(id, new Page(id, name));
                break;
              case "char":
                Character charData;

                charData = new Character
                           {
                             Char = (char)BitmapFontLoader.GetNamedInt(parts, "id"),
                             Bounds = new Rectangle(BitmapFontLoader.GetNamedInt(parts, "x"), BitmapFontLoader.GetNamedInt(parts, "y"), BitmapFontLoader.GetNamedInt(parts, "width"), BitmapFontLoader.GetNamedInt(parts, "height")),
                             Offset = new Point(BitmapFontLoader.GetNamedInt(parts, "xoffset"), BitmapFontLoader.GetNamedInt(parts, "yoffset")),
                             XAdvance = BitmapFontLoader.GetNamedInt(parts, "xadvance"),
                             TexturePage = BitmapFontLoader.GetNamedInt(parts, "page"),
                             Channel = BitmapFontLoader.GetNamedInt(parts, "chnl")
                           };
                charDictionary.Add(charData.Char, charData);
                break;
              case "kerning":
                Kerning key;

                key = new Kerning((char)BitmapFontLoader.GetNamedInt(parts, "first"), (char)BitmapFontLoader.GetNamedInt(parts, "second"), BitmapFontLoader.GetNamedInt(parts, "amount"));

                if (!kerningDictionary.ContainsKey(key))
                {
                  kerningDictionary.Add(key, key.Amount);
                }
                break;
            }
          }
        }
      } while (line != null);

      this.Pages = BitmapFontLoader.ToArray(pageData.Values);
      this.Characters = charDictionary;
      this.Kernings = kerningDictionary;
    }

    public void LoadXml(string xml)
    {
      using (StringReader reader = new StringReader(xml))
      {
        this.LoadXml(reader);
      }
    }

    public virtual void LoadXml(TextReader reader)
    {
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
      this.FamilyName = properties.Attributes["face"].Value;
      this.FontSize = Convert.ToInt32(properties.Attributes["size"].Value);
      this.Bold = Convert.ToInt32(properties.Attributes["bold"].Value) != 0;
      this.Italic = Convert.ToInt32(properties.Attributes["italic"].Value) != 0;
      this.Unicode = Convert.ToInt32(properties.Attributes["unicode"].Value) != 0;
      this.StretchedHeight = Convert.ToInt32(properties.Attributes["stretchH"].Value);
      this.Charset = properties.Attributes["charset"].Value;
      this.Smoothed = Convert.ToInt32(properties.Attributes["smooth"].Value) != 0;
      this.SuperSampling = Convert.ToInt32(properties.Attributes["aa"].Value);
      this.Padding = BitmapFontLoader.ParsePadding(properties.Attributes["padding"].Value);
      this.Spacing = BitmapFontLoader.ParsePoint(properties.Attributes["spacing"].Value);
      this.OutlineSize = Convert.ToInt32(properties.Attributes["outline"].Value);

      // common attributes
      properties = root.SelectSingleNode("common");
      this.BaseHeight = Convert.ToInt32(properties.Attributes["lineHeight"].Value);
      this.LineHeight = Convert.ToInt32(properties.Attributes["base"].Value);
      this.TextureSize = new Size(Convert.ToInt32(properties.Attributes["scaleW"].Value), Convert.ToInt32(properties.Attributes["scaleH"].Value));
      this.Packed = Convert.ToInt32(properties.Attributes["packed"].Value) != 0;
      this.AlphaChannel = Convert.ToInt32(properties.Attributes["alphaChnl"].Value);
      this.RedChannel = Convert.ToInt32(properties.Attributes["redChnl"].Value);
      this.GreenChannel = Convert.ToInt32(properties.Attributes["greenChnl"].Value);
      this.BlueChannel = Convert.ToInt32(properties.Attributes["blueChnl"].Value);

      // load texture information
      foreach (XmlNode node in root.SelectNodes("pages/page"))
      {
        Page page;

        page = new Page();
        page.Id = Convert.ToInt32(node.Attributes["id"].Value);
        page.FileName = node.Attributes["file"].Value;

        pageData.Add(page.Id, page);
      }
      this.Pages = BitmapFontLoader.ToArray(pageData.Values);

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
      this.Characters = charDictionary;

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
      this.Kernings = kerningDictionary;
    }

    public void LoadXml(Stream stream)
    {
      if (stream == null)
      {
        throw new ArgumentNullException("stream");
      }

      using (TextReader reader = new StreamReader(stream))
      {
        this.LoadXml(reader);
      }
    }

    public Size MeasureFont(string text)
    {
      return this.MeasureFont(text, NoMaxWidth);
    }

    public Size MeasureFont(string text, double maxWidth)
    {
      Size result;

      if (!string.IsNullOrEmpty(text))
      {
        char previousCharacter;
        int currentLineWidth;
        int currentLineHeight;
        int blockWidth;
        int blockHeight;
        int length;
        List<int> lineHeights;

        length = text.Length;
        previousCharacter = ' ';
        currentLineWidth = 0;
        currentLineHeight = this.LineHeight;
        blockWidth = 0;
        blockHeight = 0;
        lineHeights = new List<int>();

        for (int i = 0; i < length; i++)
        {
          char character;

          character = text[i];

          if (character == '\n' || character == '\r')
          {
            if (character == '\n' || i + 1 == length || text[i + 1] != '\n')
            {
              lineHeights.Add(currentLineHeight);
              blockWidth = Math.Max(blockWidth, currentLineWidth);
              currentLineWidth = 0;
              currentLineHeight = this.LineHeight;
            }
          }
          else
          {
            Character data;
            int width;

            data = this[character];
            width = data.XAdvance + this.GetKerning(previousCharacter, character);

            if (maxWidth != NoMaxWidth && currentLineWidth + width >= maxWidth)
            {
              lineHeights.Add(currentLineHeight);
              blockWidth = Math.Max(blockWidth, currentLineWidth);
              currentLineWidth = 0;
              currentLineHeight = this.LineHeight;
            }

            currentLineWidth += width;
            currentLineHeight = Math.Max(currentLineHeight, data.Bounds.Height + data.Offset.Y);
            previousCharacter = character;
          }
        }

        // finish off the current line if required
        if (currentLineHeight != 0)
        {
          lineHeights.Add(currentLineHeight);
        }

        // reduce any lines other than the last back to the base
        for (int i = 0; i < lineHeights.Count - 1; i++)
        {
          lineHeights[i] = this.LineHeight;
        }

        // calculate the final block height
        foreach (int lineHeight in lineHeights)
        {
          blockHeight += lineHeight;
        }

        result = new Size(Math.Max(currentLineWidth, blockWidth), blockHeight);
      }
      else
      {
        result = Size.Empty;
      }

      return result;
    }

    public string NormalizeLineBreaks(string s)
    {
      // TODO: Apart from the fact this isn't effecient, why is it public? Really doesn't belong here
      return s.Replace("\r\n", "\n").Replace("\r", "\n");
    }

    #endregion

    #region IEnumerable<Character> Interface

    public IEnumerator<Character> GetEnumerator()
    {
      foreach (KeyValuePair<char, Character> pair in this.Characters)
      {
        yield return pair.Value;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    #endregion
  }
}
