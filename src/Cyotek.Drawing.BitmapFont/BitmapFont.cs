/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2015 Cyotek Ltd.
 *
 * Licensed under the MIT License. See license.txt for the full text.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Cyotek.Drawing.BitmapFont
{
  public class BitmapFont : IEnumerable<Character>
  {
    #region Constants

    public const int NoMaxWidth = -1;

    #endregion

    #region Constructors

    public BitmapFont()
    { }

    #endregion

    #region Properties

    public int AlphaChannel { get; set; }

    public int BaseHeight { get; set; }

    public int BlueChannel { get; set; }

    public bool Bold { get; set; }

    public IDictionary<char, Character> Characters { get; set; }

    public string Charset { get; set; }

    public string FamilyName { get; set; }

    public int FontSize { get; set; }

    public int GreenChannel { get; set; }

    public bool Italic { get; set; }

    public Character this[char character]
    {
      get { return this.Characters[character]; }
    }

    public IDictionary<Kerning, int> Kernings { get; set; }

    public int LineHeight { get; set; }

    public int OutlineSize { get; set; }

    public bool Packed { get; set; }

    public Padding Padding { get; set; }

    public Page[] Pages { get; set; }

    public int RedChannel { get; set; }

    public bool Smoothed { get; set; }

    public Point Spacing { get; set; }

    public int StretchedHeight { get; set; }

    public int SuperSampling { get; set; }

    public Size TextureSize { get; set; }

    public bool Unicode { get; set; }

    #endregion

    #region Methods

    public int GetKerning(char previous, char current)
    {
      Kerning key;
      int result;

      key = new Kerning(previous, current, 0);
      if (!this.Kernings.TryGetValue(key, out result))
      {
        result = 0;
      }

      return result;
    }

    public Size MeasureFont(string text)
    {
      return this.MeasureFont(text, NoMaxWidth);
    }

    public Size MeasureFont(string text, double maxWidth)
    {
      char previousCharacter;
      string normalizedText;
      int currentLineWidth;
      int currentLineHeight;
      int blockWidth;
      int blockHeight;
      List<int> lineHeights;

      previousCharacter = ' ';
      normalizedText = this.NormalizeLineBreaks(text);
      currentLineWidth = 0;
      currentLineHeight = this.LineHeight;
      blockWidth = 0;
      blockHeight = 0;
      lineHeights = new List<int>();

      foreach (char character in normalizedText)
      {
        switch (character)
        {
          case '\n':
            lineHeights.Add(currentLineHeight);
            blockWidth = Math.Max(blockWidth, currentLineWidth);
            currentLineWidth = 0;
            currentLineHeight = this.LineHeight;
            break;
          default:
            Character data;
            int width;

            data = this[character];
            width = data.XAdvance + this.GetKerning(previousCharacter, character);

            if (maxWidth != NoMaxWidth && currentLineWidth + width >= maxWidth)
            {
              lineHeights.Add(currentLineHeight);
              blockWidth = Math.Max(blockWidth, currentLineWidth);
              currentLineWidth = 0;
              currentLineHeight = this.LineHeight;
            }

            currentLineWidth += width;
            currentLineHeight = Math.Max(currentLineHeight, data.Bounds.Height + data.Offset.Y);
            previousCharacter = character;
            break;
        }
      }

      // finish off the current line if required
      if (currentLineHeight != 0)
      {
        lineHeights.Add(currentLineHeight);
      }

      // reduce any lines other than the last back to the base
      for (int i = 0; i < lineHeights.Count - 1; i++)
      {
        lineHeights[i] = this.LineHeight;
      }

      // calculate the final block height
      foreach (int lineHeight in lineHeights)
      {
        blockHeight += lineHeight;
      }

      return new Size(Math.Max(currentLineWidth, blockWidth), blockHeight);
    }

    public string NormalizeLineBreaks(string s)
    {
      return s.Replace("\r\n", "\n").Replace("\r", "\n");
    }

    #endregion

    #region IEnumerable<Character> Interface

    public IEnumerator<Character> GetEnumerator()
    {
      foreach (KeyValuePair<char, Character> pair in this.Characters)
      {
        yield return pair.Value;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    #endregion
  }
}
