using NUnit.Framework;
using System.IO;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2012-2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Drawing.BitmapFont.Tests
{
  public class BitmapFontLoaderTests : TestBase
  {
    #region Public Methods

    [Test]
    public void Binary_is_supported()
    {
      // arrange
      BitmapFont actual;
      BitmapFont expected;
      string fileName;

      fileName = this.SimpleBinaryFileName;

      expected = this.Simple;

      // act
      actual = BitmapFontLoader.LoadFontFromBinaryFile(fileName);

      // assert
      BitmapFontAssert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase("simple.fnt")]
    [TestCase("simple-xml.fnt")]
    [TestCase("simple-bin.fnt")]
    public void LoadFontFromFileTestCases(string baseFileName)
    {
      // arrange
      BitmapFont expected;
      BitmapFont actual;
      string fileName;

      expected = this.Simple;

      fileName = Path.Combine(this.DataPath, baseFileName);

      // act
      actual = BitmapFontLoader.LoadFontFromFile(fileName);

      // assert
      BitmapFontAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Text_is_supported()
    {
      // arrange
      BitmapFont actual;
      BitmapFont expected;
      string fileName;

      fileName = this.SimpleTextFileName;

      expected = this.Simple;

      // act
      actual = BitmapFontLoader.LoadFontFromTextFile(fileName);

      // assert
      BitmapFontAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Xml_is_supported()
    {
      // arrange
      BitmapFont actual;
      BitmapFont expected;
      string fileName;

      fileName = this.SimpleXmlFileName;

      expected = this.Simple;

      // act
      actual = BitmapFontLoader.LoadFontFromXmlFile(fileName);

      // assert
      BitmapFontAssert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}
