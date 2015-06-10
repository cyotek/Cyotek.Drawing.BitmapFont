/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2015 Cyotek Ltd.
 *
 * Licensed under the MIT License. See license.txt for the full text.
 */

namespace Cyotek.Drawing.BitmapFont
{
  public struct Padding
  {
    #region Constructors

    public Padding(int left, int top, int right, int bottom)
      : this()
    {
      this.Top = top;
      this.Left = left;
      this.Right = right;
      this.Bottom = bottom;
    }

    #endregion

    #region Properties

    public int Bottom { get; set; }

    public int Left { get; set; }

    public int Right { get; set; }

    public int Top { get; set; }

    #endregion

    #region Methods

    public override string ToString()
    {
      return string.Format("{0}, {1}, {2}, {3}", this.Left, this.Top, this.Right, this.Bottom);
    }

    #endregion
  }
}
