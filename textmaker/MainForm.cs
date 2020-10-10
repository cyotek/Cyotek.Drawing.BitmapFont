using Cyotek.Demo.TextMaker;
using Cyotek.Drawing.BitmapFont;
using SimpleJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.Windows.Forms
{
  internal partial class MainForm : BaseForm
  {
    #region Private Fields

    private TextBitmapConfiguration _config;

    private string _fileName;

    private List<BitmapFont> _fonts;

    private bool _skipUiUpdates;

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
      string[] args;

      base.OnShown(e);

      this.LoadFonts();
      this.ListFonts();
      this.NewFile();

      args = Environment.GetCommandLineArgs();

      if (args.Length > 1)
      {
        this.OpenFile(args[1]);
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
    }

    private void BackgroundColorButton_ColorChanged(object sender, EventArgs e)
    {
      if (!_skipUiUpdates && _config != null)
      {
        _config.BackgroundColor = backgroundColorButton.Color;
        this.UpdatePreview();
      }
    }

    private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ClipboardHelper.TryCopy(this);
    }

    private void CutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ClipboardHelper.TryCut(this);
    }

    private void CyotekLinkToolStripStatusLabel_Click(object sender, EventArgs e)
    {
      AboutDialog.OpenCyotekHomePage();

      cyotekLinkToolStripStatusLabel.LinkVisited = true;
    }

    private void DrawPreview()
    {
      if (_config != null)
      {
        previewImageBox.Image = TextBitmapMaker.Create(_config);
        previewImageBox.ActualSize();
      }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FontComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateFont();
      this.UpdatePreview();
    }

    private string GetExtendedFontName(BitmapFont font)
    {
      StringBuilder sb;

      sb = new StringBuilder(128);

      sb.Append(font.FamilyName);
      sb.Append(' ');
      sb.Append('(');
      sb.Append(font.FontSize);
      sb.Append("px");
      if (font.Bold)
      {
        sb.Append(',');
        sb.Append(' ');
        sb.Append("Bold");
      }
      if (font.Italic)
      {
        sb.Append(',');
        sb.Append(' ');
        sb.Append("Italic");
      }
      sb.Append(')');

      return sb.ToString();
    }

    private void LeftNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      if (!_skipUiUpdates && _config != null)
      {
        _config.Padding = new Drawing.BitmapFont.Padding(
          (int)leftNumericUpDown.Value,
          (int)topNumericUpDown.Value,
          (int)rightNumericUpDown.Value,
          (int)bottomNumericUpDown.Value
          );
        this.UpdatePreview();
      }
    }

    private void ListFonts()
    {
      fontComboBox.BeginUpdate();
      fontComboBox.Items.Clear();
      for (int i = 0; i < _fonts.Count; i++)
      {
        fontComboBox.Items.Add(_fonts[i].FamilyName);
      }
      fontComboBox.EndUpdate();

      if (fontComboBox.Items.Count > 0)
      {
        fontComboBox.SelectedIndex = 0;
      }
    }

    private void LoadFonts()
    {
      string path;

      _fonts = new List<BitmapFont>();

      path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples");

      foreach (string fileName in Directory.EnumerateFiles(path, "*.fnt"))
      {
        BitmapFont font;

        font = BitmapFontLoader.LoadFontFromFile(fileName);

        font.FamilyName = this.GetExtendedFontName(font);

        if (_fonts.FindIndex(f => string.Equals(f.FamilyName, font.FamilyName)) == -1)
        {
          _fonts.Add(font);
        }
      }

      _fonts.Sort((x, y) => string.Compare(x.FamilyName, y.FamilyName));
    }

    private void NewFile()
    {
      _config = new TextBitmapConfiguration();

      _fileName = null;

      this.UpdateFont();
      this.UpdateUi();
    }

    private void NewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.NewFile();
    }

    private void OpenFile(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        fileName = FileDialogHelper.GetOpenFileName("Open Configuration", Filters.Config, "ctm", _fileName);
      }

      if (!string.IsNullOrEmpty(fileName))
      {
        try
        {
          string data;
          JSONObject root;
          TextBitmapConfiguration configuration;

          data = File.ReadAllText(fileName);
          root = (JSONObject)JSON.Parse(data);

          configuration = new TextBitmapConfiguration
          {
            Font = _fonts.Find(f => string.Equals(f.FamilyName, root["font"].Value)),
            BackgroundColor = ColorExtensions.FromHtml(root["backgroundColor"].Value),
            TextColor = ColorExtensions.FromHtml(root["textColor"].Value),
            Text = root["text"].Value,
            Padding = new Drawing.BitmapFont.Padding(
              root["padding"][0].AsInt,
              root["padding"][1].AsInt,
              root["padding"][2].AsInt,
              root["padding"][3].AsInt
              )
          };

          _config = configuration;
          _fileName = fileName;

          this.UpdateUi();
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to load configuration file. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.OpenFile(string.Empty);
    }

    private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ClipboardHelper.TryPaste(this);
    }

    private void PreviewTextBox_TextChanged(object sender, EventArgs e)
    {
      if (!_skipUiUpdates && _config != null)
      {
        _config.Text = previewTextBox.Text;
        this.UpdatePreview();
      }
    }

    private void ResetPreview()
    {
      if (previewImageBox.Image != null)
      {
        previewImageBox.Image.Dispose();
        previewImageBox.Image = null;
      }
    }

    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SaveFile(null);
    }

    private void SaveFile(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        fileName = FileDialogHelper.GetSaveFileName("Save Configuration As", Filters.Config, "ctm", _fileName);
      }

      if (!string.IsNullOrEmpty(fileName))
      {
        try
        {
          JSONObject root;
          string data;

          root = new JSONObject();
          root.Add("font", new JSONString(_config.Font.FamilyName));
          root.Add("backgroundColor", new JSONString(_config.BackgroundColor.ToHtml()));
          root.Add("textColor", new JSONString(_config.TextColor.ToHtml()));
          root.Add("text", new JSONString(_config.Text));
          root.Add("padding", new JSONArray
          {
            { null, new JSONNumber(_config.Padding.Left) },
            { null, new JSONNumber(_config.Padding.Top) },
            { null, new JSONNumber(_config.Padding.Right) },
            { null, new JSONNumber(_config.Padding.Bottom) }
          });

          data = root.ToString(2);

          File.WriteAllText(fileName, data);

          _fileName = fileName;

          this.UpdateWindowTitle();
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Failed to save configuration file. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SaveFile(_fileName);
    }

    private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      previewTextBox.SelectAll();
    }

    private void TextColorButton_ColorChanged(object sender, EventArgs e)
    {
      if (!_skipUiUpdates && _config != null)
      {
        _config.TextColor = textColorButton.Color;
        this.UpdatePreview();
      }
    }

    private void UpdateFont()
    {
      if (!_skipUiUpdates && _config != null && fontComboBox.SelectedIndex != -1)
      {
        _config.Font = _fonts[fontComboBox.SelectedIndex];
      }
    }

    private void UpdatePreview()
    {
      this.ResetPreview();
      this.DrawPreview();
    }

    private void UpdateUi()
    {
      try
      {
        _skipUiUpdates = true;
        textColorButton.Color = _config.TextColor;
        backgroundColorButton.Color = _config.BackgroundColor;
        previewTextBox.Text = _config.Text;
        leftNumericUpDown.Value = _config.Padding.Left;
        rightNumericUpDown.Value = _config.Padding.Right;
        topNumericUpDown.Value = _config.Padding.Top;
        bottomNumericUpDown.Value = _config.Padding.Bottom;

        if (_config.Font == null)
        {
          fontComboBox.SelectedIndex = -1;
        }
        else
        {
          for (int i = 0; i < fontComboBox.Items.Count; i++)
          {
            if (string.Equals(_config.Font.FamilyName, (string)fontComboBox.Items[i]))
            {
              fontComboBox.SelectedIndex = i;
              break;
            }
          }
        }
      }
      finally
      {
        _skipUiUpdates = false;
      }

      this.UpdatePreview();
      this.UpdateWindowTitle();
    }

    private void UpdateWindowTitle()
    {
      this.Text = string.Format("{0} - {1}", string.IsNullOrEmpty(_fileName) ? "Untitled" : Path.GetFileName(_fileName), Application.ProductName);
    }

    #endregion Private Methods
  }
}
