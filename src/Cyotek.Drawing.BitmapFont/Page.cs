/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2015 Cyotek Ltd.
 *
 * Licensed under the MIT License. See license.txt for the full text.
 */

using System.IO;

namespace Cyotek.Drawing.BitmapFont
{
  public struct Page
  {
    #region Constructors

    public Page(int id, string fileName)
      : this()
    {
      this.FileName = fileName;
      this.Id = id;
    }

    #endregion

    #region Properties

    public string FileName { get; set; }

    public int Id { get; set; }

    #endregion

    #region Methods

    public override string ToString()
    {
      return string.Format("{0} ({1})", this.Id, Path.GetFileName(this.FileName));
    }

    #endregion
  }
}
