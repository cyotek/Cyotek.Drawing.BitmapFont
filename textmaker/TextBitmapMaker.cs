using Cyotek.Drawing.BitmapFont;
using System.Drawing;
using System.Drawing.Imaging;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.TextMaker
{
  internal static class TextBitmapMaker
  {
    #region Public Methods

    public static Bitmap Create(TextBitmapConfiguration config)
    {
      Bitmap image;
      BitmapFont font;
      string text;
      Size size;

      text = config.Text;
      font = config.Font;
      size = font.MeasureFont(text);

      if (size.Height != 0 && size.Width != 0)
      {
        int defaultX;
        int x;
        int y;
        char previousCharacter;
        ImageAttributes imageAttributes;

        size.Width += config.Padding.Left + config.Padding.Right;
        size.Height += config.Padding.Top + config.Padding.Bottom;

        image = new Bitmap(size.Width, size.Height);

        defaultX = config.Padding.Left;
        x = defaultX;
        y = config.Padding.Top;

        previousCharacter = '\0';

        imageAttributes = TextBitmapMaker.CreateImageAttributes(config.TextColor);

        using (Graphics g = Graphics.FromImage(image))
        {
          g.Clear(config.BackgroundColor);

          foreach (char character in text)
          {
            if (character == '\n')
            {
              x = defaultX;
              y += font.LineHeight;
            }
            else if (character != '\r')
            {
              Character data;

              data = font[character];

              if (!data.IsEmpty)
              {
                int kerning;

                kerning = font.GetKerning(previousCharacter, character);

                TextBitmapMaker.DrawCharacter(config, g, imageAttributes, data, x + data.XOffset + kerning, y + data.YOffset);

                x += data.XAdvance + kerning;
              }
            }

            previousCharacter = character;
          }
        }
      }
      else
      {
        image = null;
      }

      return image;
    }

    #endregion Public Methods

    #region Private Methods

    private static ColorMatrix CreateColorMatrix(Color textColor)
    {
      float r;
      float g;
      float b;

      r = 1.0F / 255 * textColor.R;
      g = 1.0F / 255 * textColor.G;
      b = 1.0F / 255 * textColor.B;

      return new ColorMatrix(new float[][]
                              {
                                new float[] {1, 0, 0, 0, 0},
                                new float[] {0, 1, 0, 0, 0},
                                new float[] {0, 0, 1, 0, 0},
                                new float[] {0, 0, 0, 1, 0},
                                new float[] {r, g, b, 0, 1} // TODO: Can't add alpha as it screws up entire cell
                              });
    }

    private static ImageAttributes CreateImageAttributes(Color textColor)
    {
      ColorMatrix colorMatrix;
      ImageAttributes imageAttributes;

      colorMatrix = TextBitmapMaker.CreateColorMatrix(textColor);

      imageAttributes = new ImageAttributes();
      imageAttributes.SetColorMatrix(colorMatrix);

      return imageAttributes;
    }

    private static void DrawCharacter(TextBitmapConfiguration config, Graphics g, ImageAttributes imageAttributes, Character character, int x, int y)
    {
      g.DrawImage(config.Textures[character.TexturePage],
                  new Rectangle(x, y, character.Width, character.Height),
                  character.X, character.Y, character.Width, character.Height,
                  GraphicsUnit.Pixel, imageAttributes);
    }

    #endregion Private Methods
  }
}
