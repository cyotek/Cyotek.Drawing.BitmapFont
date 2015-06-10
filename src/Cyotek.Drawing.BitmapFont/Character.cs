/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2015 Cyotek Ltd.
 *
 * Licensed under the MIT License. See license.txt for the full text.
 */

using System.Drawing;

namespace Cyotek.Drawing.BitmapFont
{
  public struct Character
  {
    #region Properties

    public Rectangle Bounds { get; set; }

    public int Channel { get; set; }

    public char Char { get; set; }

    public Point Offset { get; set; }

    public int TexturePage { get; set; }

    public int XAdvance { get; set; }

    #endregion

    #region Methods

    public override string ToString()
    {
      return this.Char.ToString();
    }

    #endregion
  }
}
