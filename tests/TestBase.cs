using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2012-2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Drawing.BitmapFont.Tests
{
  public abstract class TestBase
  {
    #region Protected Properties

    protected string DataPath
    {
      get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data"); }
    }

    protected BitmapFont Simple
    {
      get
      {
        BitmapFont font;

        font = new BitmapFont
        {
          FamilyName = "Arial",
          FontSize = 32,
          Padding = new Padding(0, 0, 0, 0),
          Unicode = true,
          StretchedHeight = 100,
          Smoothed = true,
          Spacing = new Point(1, 1),
          LineHeight = 32,
          BaseHeight = 26,
          AlphaChannel = 1,
          SuperSampling = 1,
          TextureSize = new Size(256, 256),
          Pages = new[]
                         {
                           new Page(0, Path.Combine(this.DataPath, "simple_0.png"))
                         },
          Kernings = new Dictionary<Kerning, short>
                            {
                              {
                                new Kerning('f', 'f', -1), -1
                              }
                            },
          Characters = new Dictionary<char, Character>
                              {
                                { 'a', new Character('a', 0, 26, 14, 15, 0, 11, 15, 0, 15) },
                                { 'b', new Character('b', 8, 0, 14, 20, 1, 6, 15, 0, 15) },
                                { 'c', new Character('c', 30, 21, 13, 15, 0, 11, 14, 0, 15) },
                                { 'd', new Character('d', 23, 0, 14, 20, 0, 6, 15, 0, 15) },
                                { 'e', new Character('e', 198, 0, 15, 15, 0, 11, 15, 0, 15) },
                                { 'f', new Character('f', 126, 0, 10, 20, -1, 6, 7, 0, 15) },
                                { 'g', new Character('g', 38, 0, 14, 20, 0, 11, 15, 0, 15) },
                                { 'h', new Character('h', 98, 0, 13, 20, 1, 6, 15, 0, 15) },
                                { 'i', new Character('i', 146, 0, 4, 20, 1, 6, 6, 0, 15) },
                                { 'j', new Character('j', 0, 0, 7, 25, -2, 6, 6, 0, 15) },
                                { 'k', new Character('k', 112, 0, 13, 20, 1, 6, 14, 0, 15) },
                                { 'l', new Character('l', 151, 0, 4, 20, 1, 6, 6, 0, 15) },
                                { 'm', new Character('m', 156, 0, 20, 15, 1, 11, 22, 0, 15) },
                                { 'n', new Character('n', 44, 21, 13, 15, 1, 11, 15, 0, 15) },
                                { 'o', new Character('o', 214, 0, 15, 15, 0, 11, 15, 0, 15) },
                                { 'p', new Character('p', 53, 0, 14, 20, 1, 11, 15, 0, 15) },
                                { 'q', new Character('q', 68, 0, 14, 20, 0, 11, 15, 0, 15) },
                                { 'r', new Character('r', 246, 0, 9, 15, 1, 11, 9, 0, 15) },
                                { 's', new Character('s', 15, 21, 14, 15, 0, 11, 14, 0, 15) },
                                { 't', new Character('t', 137, 0, 8, 20, 0, 6, 8, 0, 15) },
                                { 'u', new Character('u', 58, 21, 13, 15, 1, 11, 15, 0, 15) },
                                { 'v', new Character('v', 230, 0, 15, 15, -1, 11, 13, 0, 15) },
                                { 'w', new Character('w', 177, 0, 20, 15, -1, 11, 19, 0, 15) },
                                { 'x', new Character('x', 86, 21, 12, 15, 0, 11, 12, 0, 15) },
                                { 'y', new Character('y', 83, 0, 14, 20, 0, 11, 14, 0, 15) },
                                { 'z', new Character('z', 72, 21, 13, 15, 0, 11, 13, 0, 15) }
                              },
          Charset = string.Empty
        };

        return font;
      }
    }

    protected string SimpleBinaryFileName
    {
      get { return Path.Combine(this.DataPath, "simple-bin.fnt"); }
    }

    protected string SimpleTextFileName
    {
      get { return Path.Combine(this.DataPath, "simple.fnt"); }
    }

    protected string SimpleXmlFileName
    {
      get { return Path.Combine(this.DataPath, "simple-xml.fnt"); }
    }

    #endregion Protected Properties
  }
}
