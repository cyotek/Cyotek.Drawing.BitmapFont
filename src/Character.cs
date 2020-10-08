using System;
using System.Drawing;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2012-2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Drawing.BitmapFont
{
  /// <summary>
  /// Represents the definition of a single character in a <see cref="BitmapFont"/>
  /// </summary>
  public struct Character
  {
    #region Public Fields

    /// <summary>
    /// Gets a <see cref="Character"/> structure that has a Height and Width value of 0.
    /// </summary>
    public static readonly Character Empty = new Character();

    #endregion Public Fields

    #region Private Fields

    private int _channel;

    private char _char;

    private int _height;

    private int _texturePage;

    private int _width;

    private int _x;

    private int _xAdvance;

    private int _xOffset;

    private int _y;

    private int _yOffset;

    #endregion Private Fields

    #region Public Constructors

    /// <summary> Constructor. </summary>
    /// <param name="character">  The character. </param>
    /// <param name="x">  The X-coordinate. </param>
    /// <param name="y">  The Y-coordinate. </param>
    /// <param name="width">  The character width. </param>
    /// <param name="height"> The character height. </param>
    /// <param name="xOffset">  The X offset. </param>
    /// <param name="yOffset">  The Y offset. </param>
    /// <param name="xAdvance"> How much the current position should be advanced after drawing the
    ///  character. </param>
    /// <param name="texturePage">  The texture page where the character image is found. </param>
    /// <param name="channel">  The texture channel where the character image is found. </param>
    public Character(char character, int x, int y, int width, int height, int xOffset, int yOffset, int xAdvance, int texturePage, int channel)
    {
      _char = character;
      _x = x;
      _y = y;
      _width = width;
      _height = height;
      _xAdvance = xAdvance;
      _texturePage = texturePage;
      _channel = channel;
      _xOffset = xOffset;
      _yOffset = yOffset;
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets the bounds of the character image in the source texture.
    /// </summary>
    /// <value>
    /// The bounds of the character image in the source texture.
    /// </value>
    [Obsolete("This property will be removed in a future update to the library. Please use the X, Y, Width and Height properties instead.")]
    public Rectangle Bounds
    {
      get { return new Rectangle(_x, _y, _width, _height); }
      set
      {
        _x = value.X;
        _y = value.Y;
        _width = value.Width;
        _height = value.Height;
      }
    }

    /// <summary>
    /// Gets or sets the texture channel where the character image is found.
    /// </summary>
    /// <value>
    /// The texture channel where the character image is found.
    /// </value>
    /// <remarks>
    /// 1 = blue, 2 = green, 4 = red, 8 = alpha, 15 = all channels
    /// </remarks>
    public int Channel
    {
      get { return _channel; }
      set { _channel = value; }
    }

    /// <summary>
    /// Gets or sets the character.
    /// </summary>
    /// <value>
    /// The character.
    /// </value>
    public char Char
    {
      get { return _char; }
      set { _char = value; }
    }

    /// <summary> Gets or sets the character height. </summary>
    /// <value> The height. </value>
    public int Height
    {
      get { return _height; }
      set { _height = value; }
    }

    /// <summary>
    /// Tests whether this <see cref="Character"/> structure has width and height of 0.
    /// </summary>
    /// <value>
    /// This property returns <c>true</c> when this <see cref="Character"/> structure has both a width
    /// and height of 0; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty
    {
      get { return _width == 0 && _height == 0; }
    }

    /// <summary>
    /// Gets or sets the offset when copying the image from the texture to the screen.
    /// </summary>
    /// <value>
    /// The offset when copying the image from the texture to the screen.
    /// </value>
    [Obsolete("This property will be removed in a future update to the library. Please use the XOffset and YOffset properties instead.")]
    public Point Offset
    {
      get { return new Point(_xOffset, _yOffset); }
      set
      {
        _xOffset = value.X;
        _yOffset = value.Y;
      }
    }

    /// <summary>
    /// Gets or sets the texture page where the character image is found.
    /// </summary>
    /// <value>
    /// The texture page where the character image is found.
    /// </value>
    public int TexturePage
    {
      get { return _texturePage; }
      set { _texturePage = value; }
    }

    /// <summary> Gets or sets the character width. </summary>
    /// <value> The width. </value>
    public int Width
    {
      get { return _width; }
      set { _width = value; }
    }

    /// <summary> Gets or sets the X-coordinate. </summary>
    /// <value> The X-coordinate. </value>
    public int X
    {
      get { return _x; }
      set { _x = value; }
    }

    /// <summary>
    /// Gets or sets the value used to advance the current position after drawing the character.
    /// </summary>
    /// <value>
    /// How much the current position should be advanced after drawing the character.
    /// </value>
    public int XAdvance
    {
      get { return _xAdvance; }
      set { _xAdvance = value; }
    }

    /// <summary> Gets or sets the X offset. </summary>
    /// <value> The X-coordinate offset. </value>
    public int XOffset
    {
      get { return _xOffset; }
      set { _xOffset = value; }
    }

    /// <summary> Gets or sets the Y-coordinate. </summary>
    /// <value> The Y-coordinate. </value>
    public int Y
    {
      get { return _y; }
      set { _y = value; }
    }

    /// <summary> Gets or sets the Y offset. </summary>
    /// <value> The Y-coordinate offset. </value>
    public int YOffset
    {
      get { return _yOffset; }
      set { _yOffset = value; }
    }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Returns the fully qualified type name of this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> containing a fully qualified type name.
    /// </returns>
    /// <seealso cref="M:System.ValueType.ToString()"/>
    public override string ToString()
    {
      return _char.ToString();
    }

    #endregion Public Methods
  }
}
