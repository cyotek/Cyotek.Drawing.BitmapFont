/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2017 Cyotek Ltd.
 *
 * Licensed under the MIT License. See LICENSE.txt for the full text.
 */

 using NUnit.Framework;

namespace Cyotek.Drawing.BitmapFont.Tests
{
  public class BitmapFontTests : TestBase
  {
    #region Methods

    [Test]
    public void Kerning_can_be_retreived()
    {
      // arrange
      BitmapFont target;
      char first;
      char second;
      int expected;
      int actual;

      target = this.Simple;

      first = 'f';
      second = 'f';

      expected = -1;

      // act
      actual = target.GetKerning(first, second);

      // assert
      Assert.AreEqual(expected, actual);
    }

    #endregion
  }
}
