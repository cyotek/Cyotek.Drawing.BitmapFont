/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2015 Cyotek Ltd.
 *
 * Licensed under the MIT License. See license.txt for the full text.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Cyotek.Drawing.BitmapFont;

namespace BitmapFontViewer
{
  // Icon from http://www.iconfinder.com/icondetails/18377/32/bitmap_font_icon

  public partial class MainForm : Form
  {
    #region  Private Member Declarations

    private Character _currentCharacter;
    private int _currentPage;
    private BitmapFont _font;
    private Dictionary<int, Image> _textures;

    #endregion  Private Member Declarations

    #region  Public Constructors

    public MainForm()
    {
      InitializeComponent();
    }

    #endregion  Public Constructors

    #region  Event Handlers

    private void charListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      Character character;
      Page page;

      character = _font[Convert.ToChar(charListBox.SelectedItem)];
      page = _font.Pages[character.TexturePage];

      if (character.TexturePage != _currentPage)
      {
        _currentPage = character.TexturePage;
        pageImageBox.Image = _textures[_currentPage];
      }

      this.SetCharacterImage(character);
      characterPropertyGrid.SelectedObject = character;

      _currentCharacter = character;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      string path;

      path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples");
      openFileDialog.InitialDirectory = path;

      _textures = new Dictionary<int, Image>();
      previewTextBox.Text = "Bitmap Font\r\nRendering Example";

      this.OpenFont(Path.Combine(path, "treasuremap-48b.xml.fnt"));
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        this.OpenFont(openFileDialog.FileName);
    }

    private void pageImageBox_Paint(object sender, PaintEventArgs e)
    {
      if (!_currentCharacter.Bounds.IsEmpty)
      {
        using (Pen pen = new Pen(Color.Red))
          e.Graphics.DrawRectangle(pen, pageImageBox.GetOffsetRectangle(_currentCharacter.Bounds));
      }
    }

    private void previewTextBox_TextChanged(object sender, EventArgs e)
    {
      if (previewImageBox.Image != null)
      {
        previewImageBox.Image.Dispose();
        previewImageBox.Image = null;
      }

      if (_font != null)
        this.DrawPreview();
    }

    #endregion  Event Handlers

    #region  Private Methods

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

    private void OpenFont(string fileName)
    {
      _font = BitmapFontLoader.LoadFontFromFile(fileName);

      this.Text = string.Format("{0} - {1}", Path.GetFileName(fileName), ((AssemblyTitleAttribute)Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title);

      // clean up
      foreach (KeyValuePair<int, Image> pair in _textures)
        pair.Value.Dispose();
      pageImageBox.Image = null;
      characterImageBox.Image = null;
      characterPropertyGrid.SelectedObject = null;
      previewImageBox.Image = null;
      fontPropertyGrid.SelectedObject = _font;
      _currentPage = -1;

      // load the textures
      _textures.Clear();
      foreach (Page page in _font.Pages)
        _textures.Add(page.Id, Image.FromFile(page.FileName));

      // list the characters
      charListBox.BeginUpdate();
      charListBox.Items.Clear();
      foreach (Character character in _font)
        charListBox.Items.Add(character.ToString());
      charListBox.EndUpdate();

      if (charListBox.Items.Count != 0)
        charListBox.SelectedIndex = 0;

      // force any preview text to update
      previewTextBox_TextChanged(previewTextBox, EventArgs.Empty);
    }

    private void SetCharacterImage(Character character)
    {
      Bitmap image;

      if (characterImageBox.Image != null)
      {
        characterImageBox.Image.Dispose();
        characterImageBox.Image = null;
      }

      image = new Bitmap(character.Bounds.Width, character.Bounds.Height);
      using (Graphics g = Graphics.FromImage(image))
        this.DrawCharacter(g, character, 0, 0);

      characterImageBox.Image = image;
      pageImageBox.Invalidate();
    }

    #endregion  Private Methods
  }
}
