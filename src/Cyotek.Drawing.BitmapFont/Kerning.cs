/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2015 Cyotek Ltd.
 *
 * Licensed under the MIT License. See license.txt for the full text.
 */

namespace Cyotek.Drawing.BitmapFont
{
  public struct Kerning
  {
    #region Constructors

    public Kerning(char firstCharacter, char secondCharacter, int amount)
      : this()
    {
      this.FirstCharacter = firstCharacter;
      this.SecondCharacter = secondCharacter;
      this.Amount = amount;
    }

    #endregion

    #region Properties

    public int Amount { get; set; }

    public char FirstCharacter { get; set; }

    public char SecondCharacter { get; set; }

    #endregion

    #region Methods

    public override string ToString()
    {
      return string.Format("{0} to {1} = {2}", this.FirstCharacter, this.SecondCharacter, this.Amount);
    }

    #endregion
  }
}
