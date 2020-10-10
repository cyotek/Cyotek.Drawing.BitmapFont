using Cyotek.Drawing.BitmapFont;
using System.Collections.Generic;
using System.Drawing;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.TextMaker
{
  internal class TextBitmapConfiguration
  {
    #region Private Fields

    private readonly Dictionary<int, Image> _textures;

    private Color _backgroundColor;

    private BitmapFont _font;

    private Padding _padding;

    private string _text;

    private Color _textColor;

    #endregion Private Fields

    #region Public Constructors

    public TextBitmapConfiguration()
    {
      _textColor = Color.Black;
      _backgroundColor = Color.White;
      _textures = new Dictionary<int, Image>();
    }

    #endregion Public Constructors

    #region Public Properties

    public Color BackgroundColor
    {
      get { return _backgroundColor; }
      set { _backgroundColor = value; }
    }

    public BitmapFont Font
    {
      get { return _font; }
      set
      {
        if (!object.ReferenceEquals(_font, value))
        {
          _font = value;
          this.LoadTextures();
        }
      }
    }

    public Padding Padding
    {
      get { return _padding; }
      set { _padding = value; }
    }

    public string Text
    {
      get { return _text; }
      set { _text = value; }
    }

    public Color TextColor
    {
      get { return _textColor; }
      set { _textColor = value; }
    }

    #endregion Public Properties

    #region Internal Properties

    internal Dictionary<int, Image> Textures
    {
      get { return _textures; }
    }

    #endregion Internal Properties

    #region Private Methods

    private void LoadTextures()
    {
      _textures.Clear();

      if (_font != null)
      {
        foreach (Page page in _font.Pages)
        {
          _textures.Add(page.Id, Image.FromFile(page.FileName));
        }
      }
    }

    #endregion Private Methods
  }
}
