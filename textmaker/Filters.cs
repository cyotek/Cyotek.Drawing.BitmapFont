// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.TextMaker
{
  internal static class Filters
  {
    #region Public Fields

    public static readonly string AllFiles = "All Files (*.*)|*.*";

    public static readonly string Config = "Config Files (*.ctm)|*.ctm|" + AllFiles;

    public static readonly string Font = "Bitmap Font Files (*.fnt)|*.fnt|" + AllFiles;

    #endregion Public Fields
  }
}
