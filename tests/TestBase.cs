/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2017 Cyotek Ltd.
 *
 * Licensed under the MIT License. See LICENSE.txt for the full text.
 */

 using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Cyotek.Drawing.BitmapFont.Tests
{
  public abstract class TestBase
  {
    #region Properties

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
                 Kernings = new Dictionary<Kerning, int>
                            {
                              {
                                new Kerning('f', 'f', -1), -1
                              }
                            },
                 Characters = new Dictionary<char, Character>
                              {
                                {
                                  'a', new Character
                                       {
                                         Char = 'a',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(0, 26, 14, 15)
                                       }
                                },
                                {
                                  'b', new Character
                                       {
                                         Char = 'b',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(1, 6),
                                         Bounds = new Rectangle(8, 0, 14, 20)
                                       }
                                },
                                {
                                  'c', new Character
                                       {
                                         Char = 'c',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 14,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(30, 21, 13, 15)
                                       }
                                },
                                {
                                  'd', new Character
                                       {
                                         Char = 'd',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(0, 6),
                                         Bounds = new Rectangle(23, 0, 14, 20)
                                       }
                                },
                                {
                                  'e', new Character
                                       {
                                         Char = 'e',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(198, 0, 15, 15)
                                       }
                                },
                                {
                                  'f', new Character
                                       {
                                         Char = 'f',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 7,
                                         Offset = new Point(-1, 6),
                                         Bounds = new Rectangle(126, 0, 10, 20)
                                       }
                                },
                                {
                                  'g', new Character
                                       {
                                         Char = 'g',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(38, 0, 14, 20)
                                       }
                                },
                                {
                                  'h', new Character
                                       {
                                         Char = 'h',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(1, 6),
                                         Bounds = new Rectangle(98, 0, 13, 20)
                                       }
                                },
                                {
                                  'i', new Character
                                       {
                                         Char = 'i',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 6,
                                         Offset = new Point(1, 6),
                                         Bounds = new Rectangle(146, 0, 4, 20)
                                       }
                                },
                                {
                                  'j', new Character
                                       {
                                         Char = 'j',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 6,
                                         Offset = new Point(-2, 6),
                                         Bounds = new Rectangle(0, 0, 7, 25)
                                       }
                                },
                                {
                                  'k', new Character
                                       {
                                         Char = 'k',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 14,
                                         Offset = new Point(1, 6),
                                         Bounds = new Rectangle(112, 0, 13, 20)
                                       }
                                },
                                {
                                  'l', new Character
                                       {
                                         Char = 'l',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 6,
                                         Offset = new Point(1, 6),
                                         Bounds = new Rectangle(151, 0, 4, 20)
                                       }
                                },
                                {
                                  'm', new Character
                                       {
                                         Char = 'm',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 22,
                                         Offset = new Point(1, 11),
                                         Bounds = new Rectangle(156, 0, 20, 15)
                                       }
                                },
                                {
                                  'n', new Character
                                       {
                                         Char = 'n',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(1, 11),
                                         Bounds = new Rectangle(44, 21, 13, 15)
                                       }
                                },
                                {
                                  'o', new Character
                                       {
                                         Char = 'o',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(214, 0, 15, 15)
                                       }
                                },
                                {
                                  'p', new Character
                                       {
                                         Char = 'p',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(1, 11),
                                         Bounds = new Rectangle(53, 0, 14, 20)
                                       }
                                },
                                {
                                  'q', new Character
                                       {
                                         Char = 'q',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(68, 0, 14, 20)
                                       }
                                },
                                {
                                  'r', new Character
                                       {
                                         Char = 'r',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 9,
                                         Offset = new Point(1, 11),
                                         Bounds = new Rectangle(246, 0, 9, 15)
                                       }
                                },
                                {
                                  's', new Character
                                       {
                                         Char = 's',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 14,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(15, 21, 14, 15)
                                       }
                                },
                                {
                                  't', new Character
                                       {
                                         Char = 't',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 8,
                                         Offset = new Point(0, 6),
                                         Bounds = new Rectangle(137, 0, 8, 20)
                                       }
                                },
                                {
                                  'u', new Character
                                       {
                                         Char = 'u',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 15,
                                         Offset = new Point(1, 11),
                                         Bounds = new Rectangle(58, 21, 13, 15)
                                       }
                                },
                                {
                                  'v', new Character
                                       {
                                         Char = 'v',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 13,
                                         Offset = new Point(-1, 11),
                                         Bounds = new Rectangle(230, 0, 15, 15)
                                       }
                                },
                                {
                                  'w', new Character
                                       {
                                         Char = 'w',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 19,
                                         Offset = new Point(-1, 11),
                                         Bounds = new Rectangle(177, 0, 20, 15)
                                       }
                                },
                                {
                                  'x', new Character
                                       {
                                         Char = 'x',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 12,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(86, 21, 12, 15)
                                       }
                                },
                                {
                                  'y', new Character
                                       {
                                         Char = 'y',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 14,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(83, 0, 14, 20)
                                       }
                                },
                                {
                                  'z', new Character
                                       {
                                         Char = 'z',
                                         Channel = 15,
                                         TexturePage = 0,
                                         XAdvance = 13,
                                         Offset = new Point(0, 11),
                                         Bounds = new Rectangle(72, 21, 13, 15)
                                       }
                                }
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

    #endregion
  }
}
