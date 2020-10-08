# C# AngelCode bitmap font parsing

[![Build status][1]][2]
![CodeQL][11]
[![NuGet][3]][4]
[![Donate][5]][6]

![The font parser library was used by this OpenGL application
that renders text][20]

While writing bitmap font processing code for an OpenGL project,
I settled on using [AngelCode's BMFont][21] utility to generate
both the textures and the font definition.

This library is a generic parser for the BMFont format - it
doesn't include any rendering functionality or exotic references
and should be usable in any version of .NET from 2.0 upwards.
BMFont can generate fonts in three formats - binary, text and
XML. This library supports all three formats, although it can
only read version 3 binary fonts.

> Note: This library only provides parsing functionality for
> loading font meta data. It is up to you to provide
> functionality used to load textures and render characters.

## Getting the library

The easiest way of obtaining the library is via [NuGet][4].

> `Install-Package Cyotek.Drawing.BitmapFont`

If you don't use NuGet, pre-compiled binaries can be obtained
from the [GitHub Releases page][9].

Of course, you can always grab [the source][10] and build it
yourself!

## Overview of the library

There are four main classes used to describe a font:

* `BitmapFont` - the main class representing the font and its
  attributes
* `Character` - representing a single character
* `Kerning` - represents the kerning between a pair of
  characters
* `Page` - represents a texture page

There is also a support class, `Padding`, as I didn't want to
reference `System.Windows.Forms` in order to use its own and
using a `Rectangle` instead would be confusing.

## What format should I use

All 3 formats contain the same information so ultimately there
is no real different in the 3. However, the binary format is is
far more efficient in both storage space and load speed than the
other formats.

The following benchmarks were generated via
[BenchmarkDotNet][24], using a font with 424 characters. Loading
binary fonts is the clear winner, both in terms of speed and
allocations, followed by text and finally XML.

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1082 (1909/November2018Update/19H2)
AMD FX(tm)-6300, 1 CPU, 6 logical and 3 physical cores
.NET Core SDK=3.1.402
  [Host]     : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  DefaultJob : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
```

|         Method |       Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Gen 2 |  Allocated |
|--------------- |-----------:|---------:|---------:|---------:|--------:|------:|-----------:|
|     LoadBinary |   135.8 us |  1.41 us |  1.32 us |  10.0098 |       - |     - |   41.33 KB |
| LoadAutoBinary |   227.1 us |  3.60 us |  4.29 us |  10.9863 |  0.2441 |     - |   45.55 KB |
|       LoadText | 2,734.2 us |  6.06 us |  5.37 us | 164.0625 |  3.9063 |     - |  674.75 KB |
|   LoadAutoText | 2,778.5 us | 14.96 us | 13.26 us | 164.0625 |       - |     - |  678.98 KB |
|        LoadXml | 3,216.2 us | 18.86 us | 14.73 us | 144.5313 | 70.3125 |     - |  780.34 KB |
|    LoadAutoXml | 3,298.5 us | 26.18 us | 24.49 us | 152.3438 | 74.2188 |     - |  784.53 KB |

## Loading a font

To load a font, call `BitmapFontLoader.LoadFontFromFile`. This
will attempt to auto detect the file type and load a font.
Alternatively, if you already know the file type in advance,
then call the variations
`BitmapFontLoader.LoadFontFromBinaryFile`,
`BitmapFontLoader.LoadFontFromTextFile` or
`BitmapFontLoader.LoadFontFromXmlFile`.

Each of these functions returns a new `BitmapFont` object on
success.

Alternatively, you can create a `BitmapFont` instance yourself
and call one one of the following methods:

* `Load(string)` - attempts to auto-detect the format from the
  specified file
* `Load(Stream)` - attempts to auto-detect the format from the
  specified `Stream`
* `LoadBinary(Stream)` - loads a binary font from the given
  `Stream`
* `LoadText(string)` - loads a text font from the given string
* `LoadText(Stream)` - loads a text font from the given `Stream`
* `LoadText(TextReader)` - loads a text font from the given
  `TextReader`
* `LoadXml(string)` - loads a XML font from the given string
* `LoadXml(Stream)` - loads a XML font from the given `Stream`
* `LoadXml(TextReader)` - loads a XML font from the given
  `TextReader`

> Note: Load methods on the `BitmapFont` and `BitmapFontLoader`
> classes that take a string filename will fully qualify the
> `FileName` property of loaded `Page` instances. `Page`
> instances for all other load methods will have a relative
> filename and it is up to the calling application to fully
> qualify the path as appropriate when loading textures.

## Using a font

The `BitmapFont` class returns all the information specified in
the font file, such as the attributes used to create the font.
Most of these not directly used and are there only for if your
application needs to know how the font was generated (for
example if the textures are packed or not). The main things you
would be interested in are:

* `Characters` - this property contains all the characters
  defined in the font.
* `Kernings` - this property contains all kerning definitions.
  However, mostly you should use the `GetKerning` method to get
  the kerning for a pair of characters.
* `Pages` -this property contains the filenames of the textures
  used by the font. You'll need to manually load the relevant
  textures.
* `LineHeight` - this property returns the line height. When
  rending text across multiple lines, use this property for
  incrementing the vertical coordinate - don't just use the
  largest character height or you'll end up with inconsistent
  line heights.

The `Character` class describes a single character. Your
rendering functionality will probably need to use all of the
properties it contains:

* `Bounds` - the location and size of the character in the
  source texture.
* `TexturePage` - the index of the page containing the source
  texture.
* `Offset` - an offset to use when rendering the character so it
  lines up correctly with other characters.
* `XAdvance` - the value to increment the horizontal coordinate
  by. Don't forgot to combine this value with the result of a
  call to `GetKerning`.

## Example rendering using GDI

> The sample project shows a very basic way of rending using
> GDI; however this is just for demonstration purposes and you
> should probably come up with something more efficient in a
> real application!

![Example rendering using the bitmap font viewer][22]

```csharp
    private void DrawCharacter(Graphics g, Character character, int x, int y)
    {
      g.DrawImage(_textures[character.TexturePage], new RectangleF(x, y, character.Bounds.Width, character.Bounds.Height), character.Bounds, GraphicsUnit.Pixel);
    }

    private void DrawPreview()
    {
      Size size;
      Bitmap image;
      string normalizedText;
      int x;
      int y;
      char previousCharacter;

      previousCharacter = ' ';
      normalizedText = _font.NormalizeLineBreaks(previewTextBox.Text);
      size = _font.MeasureFont(normalizedText);

      if (size.Height != 0 && size.Width != 0)
      {
        image = new Bitmap(size.Width, size.Height);
        x = 0;
        y = 0;

        using (Graphics g = Graphics.FromImage(image))
        {
          foreach (char character in normalizedText)
          {
            switch (character)
            {
              case '\n':
                x = 0;
                y += _font.LineHeight;
                break;
              default:
                Character data;
                int kerning;

                data = _font[character];
                kerning = _font.GetKerning(previousCharacter, character);

                this.DrawCharacter(g, data, x + data.Offset.X + kerning, y + data.Offset.Y);

                x += data.XAdvance + kerning;
                break;
            }

            previousCharacter = character;
          }
        }

        previewImageBox.Image = image;
      }
    }
```

## The Bitmap Font Viewer application

![This sample application loads and previews bitmap fonts][23]

Included in this repository is a sample WinForms application for
viewing BMFont font definitions.

> Note: All of the fonts I have created and tested were
> unpacked. The font viewer does not support packed textures,
> and while it will still load the font, it will not draw glyphs
> properly as it isn't able to do any of the magic with channels
> that the packed texture requires. In addition, as .NET doesn't
> support the TGA format by default, neither does this sample
> project.

## Requirements

.NET Framework 2.0 or later.

Pre-built binaries are available via a signed [NuGet package][4]
containing the following targets.

* .NET 3.5
* .NET 4.0
* .NET 4.5.2
* .NET 4.6.2
* .NET 4.7.2
* .NET 4.8
* .NET Standard 1.3
* .NET Standard 2.0
* .NET Standard 2.1
* .NET Core 2.1
* .NET Core 2.2
* .NET Core 3.1

Is there a target not on this list you'd like to see? Raise an
[issue][7], or even better, a [pull request][8].

## Acknowledgements

See `CONTRIBUTORS.md` for details of contributions to this
library.

* [EightBit Atari-Regula font][26] by MrRobot
* [Marediv font][25] by Pixel Kitchen

## License

This source is licensed under the MIT license. See `LICENSE.txt`
for the full text.

[1]: https://ci.appveyor.com/api/projects/status/pb7dnev46i9dwg1j?svg=true
[2]: https://ci.appveyor.com/project/cyotek/cyotek-drawing-bitmapfont/
[3]: https://img.shields.io/nuget/v/Cyotek.Drawing.BitmapFont.svg
[4]: https://www.nuget.org/packages/Cyotek.Drawing.BitmapFont/
[5]: https://www.paypalobjects.com/en_US/i/btn/btn_donate_SM.gif
[6]: https://paypal.me/cyotek
[7]: https://github.com/cyotek/Cyotek.Drawing.BitmapFont/issues
[8]: https://github.com/cyotek/Cyotek.Drawing.BitmapFont/pulls
[9]: https://github.com/cyotek/Cyotek.Drawing.BitmapFont/releases
[10]: https://github.com/cyotek/Cyotek.Drawing.BitmapFont
[11]: https://github.com/cyotek/Cyotek.Drawing.BitmapFont/workflows/CodeQL/badge.svg

[20]: https://www.cyotek.com/files/articleimages/bitmapfont1.png
[21]: https://www.angelcode.com/products/bmfont/
[22]: https://www.cyotek.com/files/articleimages/bitmapfont3.png
[23]: https://www.cyotek.com/files/articleimages/bitmapfont2.png
[24]: https://benchmarkdotnet.org/
[25]: https://www.fontspace.com/marediv-font-f32318
[26]: https://github.com/TheRobotFactory/EightBit-Atari-Fonts
