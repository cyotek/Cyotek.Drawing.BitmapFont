AngelCode bitmap font parsing using C#
======================================

> This has been copied from the [original article](http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp). Aside from fixing the screenshot links, I haven't reviewed this for errors, or had time to look at the code properly. Updates will follow!

[![The font parser library was used by this OpenGL application that renders text](http://www.cyotek.com/files/articleimages/bitmapfont1-thumbnail.png)](http://www.cyotek.com/files/articleimages/bitmapfont1.png)

While writing some bitmap font processing for an OpenGL project, I settled on using [AngelCode's BMFont](http://www.angelcode.com/products/bmfont/) utility to generate both the textures and the font definition. However, this means I then needed to write a parser in order to use this in my OpenGL solution.

This library is a generic parser for the BMFont format - it doesn't include any rendering functionality or exotic references and should be usable in any version of .NET from 2.0 upwards. BMFont can generate fonts in three formats - binary, text and XML. The library currently supports text and XML, I may add binary support at another time; but currently I'm happy using the text format.

> Note: This library only provides parsing functionality for loading BMFont data. It is up to you to provide functionality used to load textures and render characters

#### Overview of the library

There are four main classes used to describe a font:

* [`BitmapFont`](/downloads/view/BitmapFontParser.zip/BitmapFontParser/BitmapFont.cs) - the main class representing the font and its attributes
* [`Character`](/downloads/view/BitmapFontParser.zip/BitmapFontParser/Character.cs) - representing a single character
* [`Kerning`](/downloads/view/BitmapFontParser.zip/BitmapFontParser/Kerning.cs) - represents the kerning between a pair of characters
* [`Page`](/downloads/view/BitmapFontParser.zip/BitmapFontParser/Page.cs) - represents a texture page

There is also a support class, `Padding`, as I didn't want to reference `System.Windows.Forms` in order to use its own and using a `Rectangle` instead would be confusing. You can replace with this `System.Windows.Forms` version if you want.

Finally, the [`BitmapFontLoader`](/downloads/view/BitmapFontParser.zip/BitmapFontParser/BitmapFontLoader.cs) class is a static class that will handle the loading of your fonts.

#### Loading a font

To load a font, call `BitmapFontLoader.LoadFontFromFile`. This will attempt to auto detect the file type and load a font. Alternatively, if you already know the file type in advance, then call the variations `BitmapFontLoader.LoadFontFromTextFile` or  `BitmapFontLoader.LoadFontFromXmlFile`.

Each of these functions returns a new `BitmapFont` object on success.

#### Using a font

The `BitmapFont` class returns all the information specified in the font file, such as the attributes used to create the font. Most of these not directly used and are there only for if your application needs to know how the font was generated (for example if the textures are packed or not). The main things you would be interested in are:

* `Characters` - this property contains all the characters defined in the font.
* `Kernings` - this property contains all kerning definitions. However, mostly you should use the `GetKerning` method to get the kerning for a pair of characters.
* `Pages` -this property contains the filenames of the textures used by the font. You'll need to manually load the relevant textures.
* `LineHeight` - this property returns the line height. When rending text across multiple lines, use this property for incrementing the vertical coordinate - don't just use the largest character height or you'll end up with inconsistent line heights.

The `Character` class describes a single character. Your rendering functionality will probably need to use all of the properties it contains:

* `Bounds` - the location and size of the character in the source texture.
* `TexturePage` - the index of the page containing the source texture.
* `Offset` - an offset to use when rendering the character so it lines up correctly with other characters.
* `XAdvance` - the value to increment the horizontal coordinate by. Don't forgot to combine this value with the result of a call to `GetKerning`.

#### Example rendering using GDI

> The sample project which accompanies this article shows a very basic way of rending using GDI; however this is just for demonstration purposes and you should probably come up with something more efficient in a real application!

[![Example rendering using the bitmap font viewer](http://www.cyotek.com/files/articleimages/bitmapfont3-thumbnail.png)](http://www.cyotek.com/files/articleimages/bitmapfont3.png)

<pre class="brush: c#">
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
</pre>

#### The Bitmap Font Viewer application

[![This sample application loads and previews bitmap fonts](http://www.cyotek.com/files/articleimages/bitmapfont2-thumbnail.png)](http://www.cyotek.com/files/articleimages/bitmapfont2.png)

Also included in the download for this article is a simple Windows Forms application for viewing a bitmap font.

> Note: All of the fonts I have created and tested were unpacked. The font viewer does not support packed textures, and while it will still load the font, it will not draw glyphs properly as it isn't able to do any of the magic with channels that the packed texture requires. In addition, as .NET doesn't support the TGA format by default, neither does this sample project.

#### Final Thoughts

Unlike my other articles, I haven't really gone into the source code or pointed out how it works, however it should all be simple to understand and use (despite having virtually no documentation) - please let me know if you think otherwise!

As mentioned above, I'm currently not using packed textures. The font parser will give you all the information you need regarding channels for extracting the information, but could probably be nicer done, such as using enums instead of magic ints - I may address this in a future update, along side implementing the binary file format.

Ideally the best way to use this code would be to inherit or extend the `BitmapFont` class. Therefore it would probably be better directly embedding the source code into your application, change the namespaces to match your own solution, then build from there.

I haven't tested with many fancy fonts - it's probable that the `MeasureFont` method doesn't handle cases of fonts with have a larger draw area than their basic box size.
