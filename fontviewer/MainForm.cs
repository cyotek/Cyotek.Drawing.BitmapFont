using Cyotek.Drawing.BitmapFont;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2012-2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.Windows.Forms
{
  internal partial class MainForm : BaseForm
  {
    #region Private Fields

    private Character _currentCharacter;

    private int _currentPage;

    private BitmapFont _font;

    private Dictionary<int, Image> _textures;

    #endregion Private Fields

    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnShown(EventArgs e)
    {
      string path;

      base.OnShown(e);

      path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples");
      openFileDialog.InitialDirectory = path;

      _textures = new Dictionary<int, Image>();
      previewTextBox.Text = Application.ProductName;

      filePane.Path = path;
      filePane.EnsureSelection();
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
    }

    private void CharListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      Character character;

      character = _font[Convert.ToChar(charListBox.SelectedItem)];

      if (character.TexturePage != _currentPage)
      {
        _currentPage = character.TexturePage;
        pageImageBox.Image = _textures[_currentPage];
        pageImageBox.ActualSize();
      }

      this.SetCharacterImage(character);
      characterPropertyGrid.SelectedObject = character;

      _currentCharacter = character;
    }

    private void CyotekLinkToolStripStatusLabel_Click(object sender, EventArgs e)
    {
      AboutDialog.OpenCyotekHomePage();

      cyotekLinkToolStripStatusLabel.LinkVisited = true;
    }

    private void DrawCharacter(Graphics g, Character character, int x, int y)
    {
      g.DrawImage(_textures[character.TexturePage],
                  new RectangleF(x, y, character.Width, character.Height),
                  new Rectangle(character.X, character.Y, character.Width, character.Height),
                  GraphicsUnit.Pixel);
    }

    private void DrawPreview()
    {
      if (_font != null)
      {
        Size size;
        string text;

        text = previewTextBox.Text;
        size = _font.MeasureFont(text);

        if (size.Height != 0 && size.Width != 0)
        {
          Bitmap image;
          int x;
          int y;
          char previousCharacter;

          image = new Bitmap(size.Width, size.Height);
          x = 0;
          y = 0;
          previousCharacter = ' ';

          using (Graphics g = Graphics.FromImage(image))
          {
            foreach (char character in text)
            {
              switch (character)
              {
                case '\n':
                  x = 0;
                  y += _font.LineHeight;
                  break;

                case '\r':
                  break;

                default:
                  Character data;
                  int kerning;

                  data = _font[character];
                  kerning = _font.GetKerning(previousCharacter, character);

                  this.DrawCharacter(g, data, x + data.XOffset + kerning, y + data.YOffset);

                  x += data.XAdvance + kerning;
                  break;
              }

              previousCharacter = character;
            }
          }

          previewImageBox.Image = image;
          previewImageBox.ActualSize();
        }
      }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FilePane_SelectedFileChanged(object sender, EventArgs e)
    {
      this.OpenFont(filePane.SelectedFile.FullPath);
    }

    private void ListCharacters()
    {
      // list the characters
      charListBox.BeginUpdate();
      charListBox.Items.Clear();
      foreach (Character character in _font)
      {
        charListBox.Items.Add(character.ToString());
      }
      charListBox.EndUpdate();

      if (charListBox.Items.Count != 0)
      {
        charListBox.SelectedIndex = 0;
      }
    }

    private void ListKernings()
    {
      kerningsListBox.BeginUpdate();
      kerningsListBox.Items.Clear();
      foreach (Kerning kerning in _font.Kernings.Keys)
      {
        kerningsListBox.Items.Add(kerning);
      }
      kerningsListBox.EndUpdate();

      if (kerningsListBox.Items.Count != 0)
      {
        kerningsListBox.SelectedIndex = 0;
      }
    }

    private void ListTextures()
    {
      texturePagesListBox.BeginUpdate();
      texturePagesListBox.Items.Clear();
      foreach (Page texturePage in _font.Pages)
      {
        texturePagesListBox.Items.Add(Path.GetFileName(texturePage.FileName));
      }
      texturePagesListBox.EndUpdate();

      if (texturePagesListBox.Items.Count != 0)
      {
        texturePagesListBox.SelectedIndex = 0;
      }
    }

    private void LoadTextures()
    {
      // load the textures
      _textures.Clear();
      foreach (Page page in _font.Pages)
      {
        _textures.Add(page.Id, Image.FromFile(page.FileName));
      }
    }

    private void OpenFont(string fileName)
    {
      this.Reset();

      //  try
      {
        _font = BitmapFontLoader.LoadFontFromFile(fileName);

        this.Text = string.Format("{0} - {1}", Path.GetFileName(fileName), Application.ProductName);

        fontPropertyGrid.SelectedObject = _font;
        this.LoadTextures();
        this.ListTextures();
        this.ListCharacters();
        this.ListKernings();
        this.DrawPreview();
      }
      try { }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to load font. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog(this) == DialogResult.OK)
      {
        this.OpenFont(openFileDialog.FileName);
      }
    }

    private void PageImageBox_Paint(object sender, PaintEventArgs e)
    {
      if (_currentCharacter.Width > 0 && _currentCharacter.Height > 0)
      {
        using (Pen pen = new Pen(Color.Red))
        {
          e.Graphics.DrawRectangle(pen, pageImageBox.GetOffsetRectangle(_currentCharacter.X, _currentCharacter.Y, _currentCharacter.Width, _currentCharacter.Height));
        }
      }
    }

    private void PreviewTextBox_TextChanged(object sender, EventArgs e)
    {
      this.ResetPreview();
      this.DrawPreview();
    }

    private void Reset()
    {
      // clean up
      this.ResetPreview();
      texturePagesListBox.Items.Clear();
      charListBox.Items.Clear();
      kerningsListBox.Items.Clear();
      texturePageImageBox.Image = null;
      pageImageBox.Image = null;
      characterImageBox.Image = null;
      characterPropertyGrid.SelectedObject = null;
      fontPropertyGrid.SelectedObject = null;
      foreach (KeyValuePair<int, Image> pair in _textures)
      {
        pair.Value.Dispose();
      }
      _currentPage = -1;
      _currentCharacter = new Character();
    }

    private void ResetPreview()
    {
      if (previewImageBox.Image != null)
      {
        previewImageBox.Image.Dispose();
        previewImageBox.Image = null;
      }
    }

    private void SetCharacterImage(Character character)
    {
      Bitmap image;

      if (characterImageBox.Image != null)
      {
        characterImageBox.Image.Dispose();
        characterImageBox.Image = null;
      }

      image = new Bitmap(character.Width, character.Height);

      using (Graphics g = Graphics.FromImage(image))
      {
        this.DrawCharacter(g, character, 0, 0);
      }

      characterImageBox.Image = image;
      characterImageBox.ActualSize();

      pageImageBox.Invalidate();
    }

    private void TexturePagesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (texturePagesListBox.SelectedIndex != -1)
      {
        texturePageImageBox.Image = _textures[texturePagesListBox.SelectedIndex];
        texturePageImageBox.ActualSize();
      }
    }

    #endregion Private Methods

    private void GenerateCodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (_font != null)
      {
        StringBuilder sb;
        string indent;

        sb = new StringBuilder(2048);
        indent = new string(' ', 4);

        sb.AppendLine("BitmapFont font;");
        sb.AppendLine();
        sb.AppendLine("font = new BitmapFont");
        sb.AppendLine("{");
        sb.Append(indent).AppendFormat("FamilyName = \"{0}\",", _font.FamilyName).AppendLine();
        sb.Append(indent).AppendFormat("FontSize = {0},", _font.FontSize).AppendLine();
        sb.Append(indent).AppendFormat("Bold = {0},", _font.Bold).AppendLine();
        sb.Append(indent).AppendFormat("Italic = {0},", _font.Italic).AppendLine();
        sb.Append(indent).AppendFormat("CharSet = \"{0}\",", _font.Charset).AppendLine();
        sb.Append(indent).AppendFormat("Unicode = {0},", _font.Unicode).AppendLine();
        sb.Append(indent).AppendFormat("StretchedHeight = {0},", _font.StretchedHeight).AppendLine();
        sb.Append(indent).AppendFormat("Smoothed = {0},", _font.Smoothed).AppendLine();
        sb.Append(indent).AppendFormat("Padding = new Padding({0}, {1}, {2}, {3}),", _font.Padding.Left, _font.Padding.Top, _font.Padding.Right, _font.Padding.Bottom).AppendLine();
        sb.Append(indent).AppendFormat("Spacing = new Point({0}, {1}),", _font.Spacing.X, _font.Spacing.Y).AppendLine();
        sb.Append(indent).AppendFormat("SuperSampling = {0},", _font.SuperSampling).AppendLine();
        sb.Append(indent).AppendFormat("Outline = {0},", _font.OutlineSize).AppendLine();

        sb.Append(indent).AppendFormat("LineHeight = {0},", _font.LineHeight).AppendLine();
        sb.Append(indent).AppendFormat("BaseHeight = {0},", _font.BaseHeight).AppendLine();
        sb.Append(indent).AppendFormat("TextureSize = new Size({0}, {1}),", _font.TextureSize.Width, _font.TextureSize.Height).AppendLine();
        sb.Append(indent).AppendFormat("Packed = {0},", _font.Packed).AppendLine();
        sb.Append(indent).AppendFormat("AlphaChannel = {0},", _font.AlphaChannel).AppendLine();
        sb.Append(indent).AppendFormat("RedChannel = {0},", _font.RedChannel).AppendLine();
        sb.Append(indent).AppendFormat("GreenChannel = {0},", _font.GreenChannel).AppendLine();
        sb.Append(indent).AppendFormat("BlueChannel = {0},", _font.BlueChannel).AppendLine();

        sb.Append(indent).AppendLine("Pages = new[]");
        sb.Append(indent).AppendLine("{");
        foreach (Page page in _font.Pages)
        {
          sb.Append(' ', indent.Length * 2).AppendFormat("new Page({0}, \"{1}\",", page.Id, Path.GetFileName(page.FileName)).AppendLine();
        }
        sb.Append(indent).AppendLine("},");

        sb.Append(indent).AppendLine("Kernings = new Dictionary<Kerning, int>");
        sb.Append(indent).AppendLine("{");
        foreach (Kerning kerning in _font.Kernings.Keys)
        {
          sb.Append(' ', indent.Length * 2).AppendFormat("{{ new Kerning('{0}', '{1}', {2}), {2} }},", kerning.FirstCharacter, kerning.SecondCharacter, kerning.Amount).AppendLine();
        }
        sb.Append(indent).AppendLine("},");

        sb.Append(indent).AppendLine("Characters = new Dictionary<char, Character>");
        sb.Append(indent).AppendLine("{");
        foreach (Character chr in _font.Characters.Values)
        {
          sb.Append(' ', indent.Length * 2).AppendFormat("{{ '{0}', new Character('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}) }},", chr.Char, chr.X, chr.Y, chr.Width, chr.Height, chr.XOffset, chr.YOffset, chr.XAdvance, chr.TexturePage, chr.Channel).AppendLine();
        }
        sb.Append(indent).AppendLine("},");

        sb.AppendLine("};");

        InformationDialog.ShowDialog(Application.ProductName, "Generated &code:", sb.ToString());
      }
      else
      {
        MessageBox.Show("No font loaded.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }
}
