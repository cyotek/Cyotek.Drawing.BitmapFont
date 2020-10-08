using NUnit.Framework;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Drawing.BitmapFont.Tests
{
  [TestFixture]
  public class CharacterTests : TestBase
  {
    #region Public Methods

    [Test]
    public void Empty_ReturnsEmptyInstance()
    {
      // arrange
      Character actual;

      // act
      actual = Character.Empty;

      // assert
      Assert.IsTrue(actual.IsEmpty);
    }

    [Test]
    public void IsEmpty_WithHeight_IsFalse()
    {
      // arrange
      Character target;

      target = new Character();

      // act
      target.Height = 10;

      // assert
      Assert.IsFalse(target.IsEmpty);
    }

    [Test]
    public void IsEmpty_WithWidth_IsFalse()
    {
      // arrange
      Character target;

      target = new Character();

      // act
      target.Width = 10;

      // assert
      Assert.IsFalse(target.IsEmpty);
    }

    #endregion Public Methods
  }
}
