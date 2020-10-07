using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2012-2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

// Some documentation derived from the BMFont file format specification
// http://www.angelcode.com/products/bmfont/doc/file_format.html

namespace Cyotek.Drawing.BitmapFont
{
  /// <summary>
  /// A bitmap font.
  /// </summary>
  /// <seealso cref="T:System.Collections.Generic.IEnumerable{Cyotek.Drawing.BitmapFont.Character}"/>
  public class BitmapFont : IEnumerable<Character>
  {
    /// <summary>
    /// When used with <see cref="MeasureFont(string,double)"/>, specifies that no wrapping should occur.
    /// </summary>
    public const int NoMaxWidth = -1;

    private byte _alphaChannel;

    private short _baseHeight;

    private byte _blueChannel;

    private bool _bold;

    private IDictionary<char, Character> _characters;

    private string _charset;

    private string _familyName;

    private int _fontSize;

    private byte _greenChannel;

    private bool _italic;

    private IDictionary<Kerning, short> _kernings;

    private short _lineHeight;

    private byte _outlineSize;

    private bool _packed;

    private Padding _padding;

    private Page[] _pages;

    private byte _redChannel;

    private bool _smoothed;

    private Point _spacing;

    private short _stretchedHeight;

    private short _superSampling;

    private Size _textureSize;

    private bool _unicode;

    /// <summary>
    /// Gets or sets the alpha channel.
    /// </summary>
    /// <value>
    /// The alpha channel.
    /// </value>
    /// <remarks>Set to 0 if the channel holds the glyph data, 1 if it holds the outline, 2 if it holds the glyph and the outline, 3 if its set to zero, and 4 if its set to one.</remarks>
    public byte AlphaChannel
    {
      get { return _alphaChannel; }
      set { _alphaChannel = value; }
    }

    /// <summary>
    /// Gets or sets the number of pixels from the absolute top of the line to the base of the characters.
    /// </summary>
    /// <value>
    /// The number of pixels from the absolute top of the line to the base of the characters.
    /// </value>
    public short BaseHeight
    {
      get { return _baseHeight; }
      set { _baseHeight = value; }
    }

    /// <summary>
    /// Gets or sets the blue channel.
    /// </summary>
    /// <value>
    /// The blue channel.
    /// </value>
    /// <remarks>Set to 0 if the channel holds the glyph data, 1 if it holds the outline, 2 if it holds the glyph and the outline, 3 if its set to zero, and 4 if its set to one.</remarks>
    public byte BlueChannel
    {
      get { return _blueChannel; }
      set { _blueChannel = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the font is bold.
    /// </summary>
    /// <value>
    /// <c>true</c> if the font is bold, otherwise <c>false</c>.
    /// </value>
    public bool Bold
    {
      get { return _bold; }
      set { _bold = value; }
    }

    /// <summary>
    /// Gets or sets the characters that comprise the font.
    /// </summary>
    /// <value>
    /// The characters that comprise the font.
    /// </value>
    public IDictionary<char, Character> Characters
    {
      get { return _characters; }
      set { _characters = value; }
    }

    /// <summary>
    /// Gets or sets the name of the OEM charset used.
    /// </summary>
    /// <value>
    /// The name of the OEM charset used (when not unicode).
    /// </value>
    public string Charset
    {
      get { return _charset; }
      set { _charset = value; }
    }

    /// <summary>
    /// Gets or sets the name of the true type font.
    /// </summary>
    /// <value>
    /// The font family name.
    /// </value>
    public string FamilyName
    {
      get { return _familyName; }
      set { _familyName = value; }
    }

    /// <summary>
    /// Gets or sets the size of the font.
    /// </summary>
    /// <value>
    /// The size of the font.
    /// </value>
    public int FontSize
    {
      get { return _fontSize; }
      set { _fontSize = value; }
    }

    /// <summary>
    /// Gets or sets the green channel.
    /// </summary>
    /// <value>
    /// The green channel.
    /// </value>
    /// <remarks>Set to 0 if the channel holds the glyph data, 1 if it holds the outline, 2 if it holds the glyph and the outline, 3 if its set to zero, and 4 if its set to one.</remarks>
    public byte GreenChannel
    {
      get { return _greenChannel; }
      set { _greenChannel = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the font is italic.
    /// </summary>
    /// <value>
    /// <c>true</c> if the font is italic, otherwise <c>false</c>.
    /// </value>
    public bool Italic
    {
      get { return _italic; }
      set { _italic = value; }
    }

    /// <summary>
    /// Gets or sets the character kernings for the font.
    /// </summary>
    /// <value>
    /// The character kernings for the font.
    /// </value>
    public IDictionary<Kerning, short> Kernings
    {
      get { return _kernings; }
      set { _kernings = value; }
    }

    /// <summary>
    /// Gets or sets the distance in pixels between each line of text.
    /// </summary>
    /// <value>
    /// The distance in pixels between each line of text.
    /// </value>
    public short LineHeight
    {
      get { return _lineHeight; }
      set { _lineHeight = value; }
    }

    /// <summary>
    /// Gets or sets the outline thickness for the characters.
    /// </summary>
    /// <value>
    /// The outline thickness for the characters.
    /// </value>
    public byte OutlineSize
    {
      get { return _outlineSize; }
      set { _outlineSize = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the monochrome characters have been packed into each of the texture channels.
    /// </summary>
    /// <value>
    /// <c>true</c> if the characters are packed, otherwise <c>false</c>.
    /// </value>
    /// <remarks>
    /// When packed, the <see cref="AlphaChannel"/> property describes what is stored in each channel.
    /// </remarks>
    public bool Packed
    {
      get { return _packed; }
      set { _packed = value; }
    }

    /// <summary>
    /// Gets or sets the padding for each character.
    /// </summary>
    /// <value>
    /// The padding for each character.
    /// </value>
    public Padding Padding
    {
      get { return _padding; }
      set { _padding = value; }
    }

    /// <summary>
    /// Gets or sets the texture pages for the font.
    /// </summary>
    /// <value>
    /// The pages.
    /// </value>
    public Page[] Pages
    {
      get { return _pages; }
      set { _pages = value; }
    }

    /// <summary>
    /// Gets or sets the red channel.
    /// </summary>
    /// <value>
    /// The red channel.
    /// </value>
    /// <remarks>Set to 0 if the channel holds the glyph data, 1 if it holds the outline, 2 if it holds the glyph and the outline, 3 if its set to zero, and 4 if its set to one.</remarks>
    public byte RedChannel
    {
      get { return _redChannel; }
      set { _redChannel = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the font is smoothed.
    /// </summary>
    /// <value>
    /// <c>true</c> if the font is smoothed, otherwise <c>false</c>.
    /// </value>
    public bool Smoothed
    {
      get { return _smoothed; }
      set { _smoothed = value; }
    }

    /// <summary>
    /// Gets or sets the spacing for each character.
    /// </summary>
    /// <value>
    /// The spacing for each character.
    /// </value>
    public Point Spacing
    {
      get { return _spacing; }
      set { _spacing = value; }
    }

    /// <summary>
    /// Gets or sets the font height stretch.
    /// </summary>
    /// <value>
    /// The font height stretch.
    /// </value>
    /// <remarks>100% means no stretch.</remarks>
    public short StretchedHeight
    {
      get { return _stretchedHeight; }
      set { _stretchedHeight = value; }
    }

    /// <summary>
    /// Gets or sets the level of super sampling used by the font.
    /// </summary>
    /// <value>
    /// The super sampling level of the font.
    /// </value>
    /// <remarks>A value of 1 indicates no super sampling is in use.</remarks>
    public short SuperSampling
    {
      get { return _superSampling; }
      set { _superSampling = value; }
    }

    /// <summary>
    /// Gets or sets the size of the texture images used by the font.
    /// </summary>
    /// <value>
    /// The size of the texture.
    /// </value>
    public Size TextureSize
    {
      get { return _textureSize; }
      set { _textureSize = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the font is Unicode.
    /// </summary>
    /// <value>
    /// <c>true</c> if the font is Unicode, otherwise <c>false</c>.
    /// </value>
    public bool Unicode
    {
      get { return _unicode; }
      set { _unicode = value; }
    }

    /// <summary>
    /// Indexer to get items within this collection using array index syntax.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <returns>
    /// The indexed item.
    /// </returns>
    public Character this[char character]
    {
      get { return _characters[character]; }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through
    /// the collection.
    /// </returns>
    /// <seealso cref="M:System.Collections.Generic.IEnumerable{Cyotek.Drawing.BitmapFont.Character}.GetEnumerator()"/>
    public IEnumerator<Character> GetEnumerator()
    {
      foreach (KeyValuePair<char, Character> pair in _characters)
      {
        yield return pair.Value;
      }
    }

    /// <summary>
    /// Gets the kerning for the specified character combination.
    /// </summary>
    /// <param name="previous">The previous character.</param>
    /// <param name="current">The current character.</param>
    /// <returns>
    /// The spacing between the specified characters.
    /// </returns>
    public short GetKerning(char previous, char current)
    {
      Kerning key;

      key = new Kerning(previous, current, 0);

      if (!_kernings.TryGetValue(key, out short result))
      {
        result = 0;
      }

      return result;
    }

    /// <summary>
    /// Load font information from the specified <see cref="Stream"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
    /// <exception cref="ArgumentException">Thrown when one or more arguments have unsupported or
    /// illegal values.</exception>
    /// <exception cref="InvalidDataException">Thrown when an Invalid Data error condition occurs.</exception>
    /// <param name="stream">The stream to load.</param>
    public virtual void Load(Stream stream)
    {
      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      if (!stream.CanSeek)
      {
        throw new ArgumentException("Stream must be seekable in order to determine file format.", nameof(stream));
      }

      switch (BitmapFontLoader.GetFileFormat(stream))
      {
        case BitmapFontFormat.Binary:
          this.LoadBinary(stream);
          break;

        case BitmapFontFormat.Text:
          this.LoadText(stream);
          break;

        case BitmapFontFormat.Xml:
          this.LoadXml(stream);
          break;

        default:
          throw new InvalidDataException("Unknown file format.");
      }
    }

    /// <summary>
    /// Load font information from the specified file.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the requested file is not present.</exception>
    /// <param name="fileName">The file name to load.</param>
    public void Load(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
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

    /// <summary>
    /// Loads font information from the specified stream.
    /// </summary>
    /// <remarks>
    /// The source data must be in BMFont binary format.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
    /// <param name="stream">The stream containing the font to load.</param>
    public void LoadBinary(Stream stream)
    {
      byte[] buffer;

      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      buffer = new byte[1024];

      // The first three bytes are the file identifier and must always be 66, 77, 70, or "BMF". The fourth byte gives the format version, currently it must be 3.

      stream.Read(buffer, 0, 4);

      if (buffer[0] != 66 || buffer[1] != 77 || buffer[2] != 70)
      {
        throw new InvalidDataException("Source steam does not contain BMFont data.");
      }

      if (buffer[3] != 3)
      {
        throw new InvalidDataException("Only BMFont version 3 format data is supported.");
      }

      // Following the first four bytes is a series of blocks with information. Each block starts with a one byte block type identifier, followed by a 4 byte integer that gives the size of the block, not including the block type identifier and the size value.

      while (stream.Read(buffer, 0, 5) != 0)
      {
        byte blockType;
        int blockSize;

        blockType = buffer[0];

        blockSize = WordHelpers.MakeDWordLittleEndian(buffer, 1);
        if (blockSize > buffer.Length)
        {
          buffer = new byte[blockSize];
        }

        if (stream.Read(buffer, 0, blockSize) != blockSize)
        {
          throw new InvalidDataException("Failed to read enough data to fill block.");
        }

        switch (blockType)
        {
          case 1: // Block type 1: info
            this.LoadInfoBlock(buffer);
            break;

          case 2: // Block type 2: common
            this.LoadCommonBlock(buffer);
            break;

          case 3: // Block type 3: pages
            this.LoadPagesBlock(buffer);
            break;

          case 4: // Block type 4: chars
            this.LoadCharactersBlock(buffer, blockSize);
            break;

          case 5: // Block type 5: kerning pairs
            this.LoadKerningsBlock(buffer, blockSize);
            break;

          default: throw new InvalidDataException("Block type " + blockType + " is not a valid BMFont block");
        }
      }
    }

    /// <summary>
    /// Loads font information from the specified string.
    /// </summary>
    /// <param name="text">String containing the font to load.</param>
    /// <remarks>The source data must be in BMFont text format.</remarks>
    public void LoadText(string text)
    {
      using (StringReader reader = new StringReader(text))
      {
        this.LoadText(reader);
      }
    }

    /// <summary>
    /// Loads font information from the specified stream.
    /// </summary>
    /// <remarks>
    /// The source data must be in BMFont text format.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
    /// <param name="stream">The stream containing the font to load.</param>
    public void LoadText(Stream stream)
    {
      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      using (TextReader reader = new StreamReader(stream))
      {
        this.LoadText(reader);
      }
    }

    /// <summary>
    /// Loads font information from the specified <see cref="TextReader"/>.
    /// </summary>
    /// <remarks>
    /// The source data must be in BMFont text format.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
    /// <param name="reader">The <strong>TextReader</strong> used to feed the data into the font.</param>
    public virtual void LoadText(TextReader reader)
    {
      IDictionary<byte, Page> pageData;
      IDictionary<Kerning, short> kerningDictionary;
      IDictionary<char, Character> charDictionary;
      string line;
      string[] parts;

      if (reader == null)
      {
        throw new ArgumentNullException(nameof(reader));
      }

      pageData = new SortedDictionary<byte, Page>();
      kerningDictionary = new Dictionary<Kerning, short>();
      charDictionary = new Dictionary<char, Character>();
      parts = new string[13]; // the maximum number of fields on a single line;

      do
      {
        line = reader.ReadLine();

        if (line != null)
        {
          BitmapFontLoader.Split(line, parts);

          if (parts.Length != 0)
          {
            switch (parts[0])
            {
              case "info":
                _familyName = BitmapFontLoader.GetNamedString(parts, "face", 1);
                _fontSize = BitmapFontLoader.GetNamedInt(parts, "size", 2);
                _bold = BitmapFontLoader.GetNamedBool(parts, "bold", 3);
                _italic = BitmapFontLoader.GetNamedBool(parts, "italic", 4);
                _charset = BitmapFontLoader.GetNamedString(parts, "charset", 5);
                _unicode = BitmapFontLoader.GetNamedBool(parts, "unicode", 6);
                _stretchedHeight = BitmapFontLoader.GetNamedShort(parts, "stretchH", 7);
                _smoothed = BitmapFontLoader.GetNamedBool(parts, "smooth", 8);
                _superSampling = BitmapFontLoader.GetNamedShort(parts, "aa", 9);
                _padding = BitmapFontLoader.ParsePadding(BitmapFontLoader.GetNamedString(parts, "padding", 10));
                _spacing = BitmapFontLoader.ParsePoint(BitmapFontLoader.GetNamedString(parts, "spacing", 11));
                _outlineSize = BitmapFontLoader.GetNamedByte(parts, "outline", 12);
                break;

              case "common":
                _lineHeight = BitmapFontLoader.GetNamedShort(parts, "lineHeight", 1);
                _baseHeight = BitmapFontLoader.GetNamedShort(parts, "base", 2);
                _textureSize = new Size(BitmapFontLoader.GetNamedInt(parts, "scaleW", 3),
                                            BitmapFontLoader.GetNamedInt(parts, "scaleH", 4));
                // TODO: 5 is pages, which we currently don't directly read
                _packed = BitmapFontLoader.GetNamedBool(parts, "packed", 6);
                _alphaChannel = BitmapFontLoader.GetNamedByte(parts, "alphaChnl", 7);
                _redChannel = BitmapFontLoader.GetNamedByte(parts, "redChnl", 8);
                _greenChannel = BitmapFontLoader.GetNamedByte(parts, "greenChnl", 9);
                _blueChannel = BitmapFontLoader.GetNamedByte(parts, "blueChnl", 10);
                break;

              case "page":
                byte id;
                string name;

                id = BitmapFontLoader.GetNamedByte(parts, "id", 1);
                name = BitmapFontLoader.GetNamedString(parts, "file", 2);

                pageData.Add(id, new Page(id, name));
                break;

              case "char":
                Character charData;

                charData = new Character
                (
                  (char)BitmapFontLoader.GetNamedInt(parts, "id", 1),
                  BitmapFontLoader.GetNamedShort(parts, "x", 2),
                  BitmapFontLoader.GetNamedShort(parts, "y", 3),
                  BitmapFontLoader.GetNamedShort(parts, "width", 4),
                  BitmapFontLoader.GetNamedShort(parts, "height", 5),
                  BitmapFontLoader.GetNamedShort(parts, "xoffset", 6),
                  BitmapFontLoader.GetNamedShort(parts, "yoffset", 7),
                  BitmapFontLoader.GetNamedShort(parts, "xadvance", 8),
                  BitmapFontLoader.GetNamedByte(parts, "page", 9),
                  BitmapFontLoader.GetNamedByte(parts, "chnl", 10)
                );

                charDictionary.Add(charData.Char, charData);
                break;

              case "kerning":
                Kerning key;

                key = new Kerning((char)BitmapFontLoader.GetNamedInt(parts, "first", 1),
                                  (char)BitmapFontLoader.GetNamedInt(parts, "second", 2),
                                  BitmapFontLoader.GetNamedShort(parts, "amount", 3));

                if (!kerningDictionary.ContainsKey(key))
                {
                  kerningDictionary.Add(key, key.Amount);
                }
                break;
            }
          }
        }
      } while (line != null);

      _pages = BitmapFontLoader.ToArray(pageData.Values);
      _characters = charDictionary;
      _kernings = kerningDictionary;
    }

    /// <summary>
    /// Loads font information from the specified string.
    /// </summary>
    /// <param name="xml">String containing the font to load.</param>
    /// <remarks>The source data must be in BMFont XML format.</remarks>
    public void LoadXml(string xml)
    {
      using (StringReader reader = new StringReader(xml))
      {
        this.LoadXml(reader);
      }
    }

    /// <summary>
    /// Loads font information from the specified <see cref="TextReader"/>.
    /// </summary>
    /// <remarks>
    /// The source data must be in BMFont XML format.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
    /// <param name="reader">The <strong>TextReader</strong> used to feed the data into the font.</param>
    public virtual void LoadXml(TextReader reader)
    {
      XmlDocument document;
      IDictionary<byte, Page> pageData;
      IDictionary<Kerning, short> kerningDictionary;
      IDictionary<char, Character> charDictionary;
      XmlNode root;
      XmlNode properties;

      if (reader == null)
      {
        throw new ArgumentNullException(nameof(reader));
      }

      document = new XmlDocument();
      pageData = new SortedDictionary<byte, Page>();
      kerningDictionary = new Dictionary<Kerning, short>();
      charDictionary = new Dictionary<char, Character>();

      document.Load(reader);
      root = document.DocumentElement;

      // load the basic attributes
      properties = root.SelectSingleNode("info");
      _familyName = properties.Attributes["face"].Value;
      _fontSize = Convert.ToInt32(properties.Attributes["size"].Value);
      _bold = Convert.ToInt32(properties.Attributes["bold"].Value) != 0;
      _italic = Convert.ToInt32(properties.Attributes["italic"].Value) != 0;
      _unicode = Convert.ToInt32(properties.Attributes["unicode"].Value) != 0;
      _stretchedHeight = short.Parse(properties.Attributes["stretchH"].Value);
      _charset = properties.Attributes["charset"].Value;
      _smoothed = Convert.ToInt32(properties.Attributes["smooth"].Value) != 0;
      _superSampling = short.Parse(properties.Attributes["aa"].Value);
      _padding = BitmapFontLoader.ParsePadding(properties.Attributes["padding"].Value);
      _spacing = BitmapFontLoader.ParsePoint(properties.Attributes["spacing"].Value);
      _outlineSize = byte.Parse(properties.Attributes["outline"].Value);

      // common attributes
      properties = root.SelectSingleNode("common");
      _baseHeight = short.Parse(properties.Attributes["base"].Value);
      _lineHeight = short.Parse(properties.Attributes["lineHeight"].Value);
      _textureSize = new Size(Convert.ToInt32(properties.Attributes["scaleW"].Value),
                                  Convert.ToInt32(properties.Attributes["scaleH"].Value));
      _packed = Convert.ToInt32(properties.Attributes["packed"].Value) != 0;
      _alphaChannel = byte.Parse(properties.Attributes["alphaChnl"].Value);
      _redChannel = byte.Parse(properties.Attributes["redChnl"].Value);
      _greenChannel = byte.Parse(properties.Attributes["greenChnl"].Value);
      _blueChannel = byte.Parse(properties.Attributes["blueChnl"].Value);

      // load texture information
      foreach (XmlNode node in root.SelectNodes("pages/page"))
      {
        Page page;

        page = new Page(byte.Parse(node.Attributes["id"].Value), node.Attributes["file"].Value);

        pageData.Add(page.Id, page);
      }
      _pages = BitmapFontLoader.ToArray(pageData.Values);

      // load character information
      foreach (XmlNode node in root.SelectNodes("chars/char"))
      {
        Character character;

        character = new Character(
        (char)short.Parse(node.Attributes["id"].Value),
        short.Parse(node.Attributes["x"].Value),
        short.Parse(node.Attributes["y"].Value),
        short.Parse(node.Attributes["width"].Value),
        short.Parse(node.Attributes["height"].Value),
        short.Parse(node.Attributes["xoffset"].Value),
        short.Parse(node.Attributes["yoffset"].Value),
        short.Parse(node.Attributes["xadvance"].Value),
        byte.Parse(node.Attributes["page"].Value),
        byte.Parse(node.Attributes["chnl"].Value)
        );

        charDictionary.Add(character.Char, character);
      }
      _characters = charDictionary;

      // loading kerning information
      foreach (XmlNode node in root.SelectNodes("kernings/kerning"))
      {
        Kerning key;

        key = new Kerning((char)Convert.ToInt32(node.Attributes["first"].Value),
                          (char)Convert.ToInt32(node.Attributes["second"].Value),
                          short.Parse(node.Attributes["amount"].Value));

        if (!kerningDictionary.ContainsKey(key))
        {
          kerningDictionary.Add(key, key.Amount);
        }
      }
      _kernings = kerningDictionary;
    }

    /// <summary>
    /// Loads font information from the specified stream.
    /// </summary>
    /// <remarks>
    /// The source data must be in BMFont XML format.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
    /// <param name="stream">The stream containing the font to load.</param>
    public void LoadXml(Stream stream)
    {
      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      using (TextReader reader = new StreamReader(stream))
      {
        this.LoadXml(reader);
      }
    }

    /// <summary>
    /// Provides the size, in pixels, of the specified text when drawn with this font.
    /// </summary>
    /// <param name="text">The text to measure.</param>
    /// <returns>
    /// The <see cref="Size"/>, in pixels, of <paramref name="text"/> drawn with this font.
    /// </returns>
    public Size MeasureFont(string text)
    {
      return this.MeasureFont(text, NoMaxWidth);
    }

    /// <summary>
    /// Provides the size, in pixels, of the specified text when drawn with this font, automatically wrapping to keep within the specified with.
    /// </summary>
    /// <param name="text">The text to measure.</param>
    /// <param name="maxWidth">The maximum width.</param>
    /// <returns>
    /// The <see cref="Size"/>, in pixels, of <paramref name="text"/> drawn with this font.
    /// </returns>
    /// <remarks>The MeasureText method uses the <paramref name="maxWidth"/> parameter to automatically wrap when determining text size.</remarks>
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
        currentLineHeight = _lineHeight;
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
              currentLineHeight = _lineHeight;
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
              currentLineHeight = _lineHeight;
            }

            currentLineWidth += width;
            currentLineHeight = Math.Max(currentLineHeight, data.Height + data.YOffset);
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
          lineHeights[i] = _lineHeight;
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

    /// <summary>
    /// Gets the enumerator.
    /// </summary>
    /// <returns>
    /// The enumerator.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    private string GetString(byte[] buffer, int index)
    {
      StringBuilder sb;

      sb = new StringBuilder();

      for (int i = index; i < buffer.Length; i++)
      {
        byte chr;

        chr = buffer[i];

        if (chr == 0)
        {
          break;
        }

        sb.Append((char)chr);
      }

      return sb.ToString();
    }

    private void LoadCharactersBlock(byte[] buffer, int blockSize)
    {
      int charCount;
      IDictionary<char, Character> characters;

      charCount = blockSize / 20; // The number of characters in the file can be computed by taking the size of the block and dividing with the size of the charInfo structure, i.e.: numChars = charsBlock.blockSize/20.
      characters = new Dictionary<char, Character>(charCount);

      for (int i = 0; i < charCount; i++)
      {
        int start;
        Character chr;

        start = i * 20;

        chr = new Character
        (
          (char)WordHelpers.MakeDWordLittleEndian(buffer, start),
          WordHelpers.MakeWordLittleEndian(buffer, start + 4),
          WordHelpers.MakeWordLittleEndian(buffer, start + 6),
          WordHelpers.MakeWordLittleEndian(buffer, start + 8),
          WordHelpers.MakeWordLittleEndian(buffer, start + 10),
          WordHelpers.MakeWordLittleEndian(buffer, start + 12),
          WordHelpers.MakeWordLittleEndian(buffer, start + 14),
          WordHelpers.MakeWordLittleEndian(buffer, start + 16),
          buffer[start + 18],
          buffer[start + 19]
        );

        characters.Add(chr.Char, chr);
      }

      _characters = characters;
    }

    private void LoadCommonBlock(byte[] buffer)
    {
      _lineHeight = WordHelpers.MakeWordLittleEndian(buffer, 0);
      _baseHeight = WordHelpers.MakeWordLittleEndian(buffer, 2);
      _textureSize = new Size(WordHelpers.MakeWordLittleEndian(buffer, 4), WordHelpers.MakeWordLittleEndian(buffer, 6));
      _pages = new Page[WordHelpers.MakeWordLittleEndian(buffer, 8)];
      _alphaChannel = buffer[11];
      _redChannel = buffer[12];
      _greenChannel = buffer[13];
      _blueChannel = buffer[14];
    }

    private void LoadInfoBlock(byte[] buffer)
    {
      byte bits;

      _fontSize = WordHelpers.MakeWordLittleEndian(buffer, 0);
      bits = buffer[2]; // 	bit 0: smooth, bit 1: unicode, bit 2: italic, bit 3: bold, bit 4: fixedHeigth, bits 5-7: reserved
      _smoothed = (bits & (1 << 7)) != 0;
      _unicode = (bits & (1 << 6)) != 0;
      _italic = (bits & (1 << 5)) != 0;
      _bold = (bits & (1 << 4)) != 0;
      _charset = string.Empty; // TODO: buffer[3]
      _stretchedHeight = WordHelpers.MakeWordLittleEndian(buffer, 4);
      _superSampling = WordHelpers.MakeWordLittleEndian(buffer, 6);
      _padding = new Padding(buffer[10], buffer[7], buffer[8], buffer[9]);
      _spacing = new Point(buffer[11], buffer[12]);
      _outlineSize = buffer[13];
      _familyName = this.GetString(buffer, 14);
    }

    private void LoadKerningsBlock(byte[] buffer, int blockSize)
    {
      int pairCount;
      Dictionary<Kerning, short> kernings;

      pairCount = blockSize / 10;
      kernings = new Dictionary<Kerning, short>(pairCount);

      for (int i = 0; i < pairCount; i++)
      {
        int start;
        Kerning kerning;

        start = i * 10;

        kerning = new Kerning
        (
          (char)WordHelpers.MakeDWordLittleEndian(buffer, start),
          (char)WordHelpers.MakeDWordLittleEndian(buffer, start + 4),
          WordHelpers.MakeWordLittleEndian(buffer, start + 8)
        );

        kernings.Add(kerning, kerning.Amount);
      }

      _kernings = kernings;
    }

    private void LoadPagesBlock(byte[] buffer)
    {
      int nextStringStart;

      nextStringStart = 0;

      for (byte i = 0; i < _pages.Length; i++)
      {
        Page page;
        string name;

        page = _pages[i];

        name = this.GetString(buffer, nextStringStart);
        nextStringStart += name.Length;

        page.Id = i;
        page.FileName = name;

        _pages[i] = page;
      }
    }
  }
}
