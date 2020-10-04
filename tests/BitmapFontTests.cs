using NUnit.Framework;
using System.IO;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2017-2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Drawing.BitmapFont.Tests
{
  public class BitmapFontTests : TestBase
  {
    #region Public Methods

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

    [Test]
    [TestCase("simple.fnt")]
    [TestCase("simple-xml.fnt")]
    [TestCase("simple-bin.fnt")]
    public void LoadTestCases(string baseFileName)
    {
      // arrange
      BitmapFont expected;
      BitmapFont actual;
      string fileName;

      expected = this.Simple;

      actual = new BitmapFont();

      fileName = Path.Combine(this.DataPath, baseFileName);

      // act
      actual.Load(fileName);

      // assert
      BitmapFontAssert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}
