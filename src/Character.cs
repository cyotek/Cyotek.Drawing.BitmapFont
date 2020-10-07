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
    #region Private Fields

    private byte _channel;

    private char _char;

    private short _height;

    private byte _texturePage;

    private short _width;

    private short _x;

    private short _xAdvance;

    private short _xOffset;

    private short _y;

    private short _yOffset;

    #endregion Private Fields

    #region Public Constructors

    public Character(char character, short x, short y, short width, short height, short xOffset, short yOffset, short xAdvance, byte texturePage, byte channel)
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
        _x =(short) value.X;
        _y = (short)value.Y;
        _width = (short)value.Width;
        _height = (short)value.Height;
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
    public byte Channel
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

    public short Height
    {
      get { return _height; }
      set { _height = value; }
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
        _xOffset = (short)value.X;
        _yOffset = (short)value.Y;
      }
    }

    /// <summary>
    /// Gets or sets the texture page where the character image is found.
    /// </summary>
    /// <value>
    /// The texture page where the character image is found.
    /// </value>
    public byte TexturePage
    {
      get { return _texturePage; }
      set { _texturePage = value; }
    }

    public short Width
    {
      get { return _width; }
      set { _width = value; }
    }

    public short X
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
    public short XAdvance
    {
      get { return _xAdvance; }
      set { _xAdvance = value; }
    }

    public short XOffset
    {
      get { return _xOffset; }
      set { _xOffset = value; }
    }

    public short Y
    {
      get { return _y; }
      set { _y = value; }
    }

    public short YOffset
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
