using NUnit.Framework;
using System.Drawing;
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
    public void Indexer_WithMissingCharacter_ReturnsFallback()
    {
      // arrange
      BitmapFont target;
      Character expected;
      Character actual;

      target = this.Simple;

      expected = Character.Empty;

      // act
      actual = target['\n'];

      // assert
      Assert.AreEqual(expected, actual);
    }

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
    public void Load_HandlesHieroFonts()
    {
      // arrange
      BitmapFont target;
      string fileName;
      string expectedName;

      target = new BitmapFont();

      fileName = Path.Combine(this.DataPath, "hiero-sample.fnt");

      expectedName = "Arial";

      // act
      target.Load(fileName);

      // assert
      Assert.AreEqual(expectedName, target.FamilyName);
      // TODO: Full validation of font?
    }

    [Test]
    [TestCase("trebuchet-invalid-bin.fnt")]
    [TestCase("trebuchet-invalid-text.fnt")]
    [TestCase("trebuchet-invalid-xml.fnt")]
    public void Load_WithInvalidChar_IsSuccessful(string baseName)
    {
      // arrange
      BitmapFont target;
      string fileName;
      Character actual;

      target = new BitmapFont();

      fileName = Path.Combine(this.DataPath, baseName);

      // act
      target.Load(fileName);

      // assert
      actual = target.InvalidChar;
      Assert.IsFalse(actual.IsEmpty);
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

    [Test]
    [TestCase(null, 0, 0)]
    [TestCase("", 0, 0)]
    [TestCase("abcde", 52, 12)] // variable character width
    [TestCase("abc de", 57, 12)] // whitespace
    [TestCase("bad", 36, 12)] // positive kerning
    [TestCase("caed", 39, 12)] // negative kerning
    [TestCase("a\nb\nc\nd\ne", 12, 60)] // unix linebreaks
    [TestCase("a\r\nb\r\nc\r\nd\r\ne", 12, 60)] // windows linebreaks
    [TestCase("a\nb\r\nc\nd\r\ne", 12, 60)] // mixed linebreaks
    public void MeasureFontTestCases(string value, int expectedW, int expectedH)
    {
      // arrange2
      BitmapFont target;
      Size actual;

      target = this.FakeFont;

      // act
      actual = target.MeasureFont(value);

      // assert
      Assert.AreEqual(expectedW, actual.Width, "Width mismatch.");
      Assert.AreEqual(expectedH, actual.Height, "Height mismatch.");
    }

    [Test]
    [TestCase(null, 0, 0)]
    [TestCase("", 0, 0)]
    [TestCase("bitmap font", 60, 24)]
    [TestCase("bitmap font\ntest", 60, 36)]
    public void MeasureFontWithMaximumWidthTestCases(string value, int expectedW, int expectedH)
    {
      // arrange2
      BitmapFont target;
      Size actual;

      target = this.FakeFont;

      // act
      actual = target.MeasureFont(value, 61); // TODO: MaxWidth condition is current >=, for v3 change to >

      // assert
      Assert.AreEqual(expectedW, actual.Width, "Width mismatch.");
      Assert.AreEqual(expectedH, actual.Height, "Height mismatch.");
    }

    [Test]
    [TestCase("trebuchet-ms-text.fnt")]
    [TestCase("trebuchet-ms-xml.fnt")]
    [TestCase("trebuchet-ms-bin.fnt")]
    public void MultiTextureLoadTestCases(string baseFileName)
    {
      // arrange
      BitmapFont expected;
      BitmapFont actual;
      string fileName;
      string path;

      expected = this.ExtendedFont;

      path = this.DataPath;

      for (int i = 0; i < expected.Pages.Length; i++)
      {
        Page page;

        page = expected.Pages[i];
        page.FileName = Path.Combine(path, page.FileName);
        expected.Pages[i] = page;
      }

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
