using System.Drawing;
using System.Globalization;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo
{
  internal static class ColorExtensions
  {
    #region Public Methods

    public static Color FromHtml(string htmlColor)
    {
      return htmlColor[0] == '#' && htmlColor.Length == 9
        ? Color.FromArgb(
          int.Parse(htmlColor.Substring(7, 2), NumberStyles.HexNumber),
          int.Parse(htmlColor.Substring(1, 2), NumberStyles.HexNumber),
          int.Parse(htmlColor.Substring(3, 2), NumberStyles.HexNumber),
          int.Parse(htmlColor.Substring(5, 2), NumberStyles.HexNumber)
          )
        : ColorTranslator.FromHtml(htmlColor);
    }

    public static string ToHtml(this Color color)
    {
      return color.A != 255
        ? string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.R, color.G, color.B, color.A)
        : ColorTranslator.ToHtml(color);
    }

    #endregion Public Methods
  }
}
