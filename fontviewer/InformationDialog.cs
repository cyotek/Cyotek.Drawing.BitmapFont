using System;
using System.Drawing;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.Windows.Forms
{
  internal partial class InformationDialog : BaseForm
  {
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="InformationDialog"/> class.
    /// </summary>
    public InformationDialog()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InformationDialog"/> class.
    /// </summary>
    /// <param name="font">The display font.</param>
    /// <param name="text">The text.</param>
    /// <param name="promptText">The prompt text.</param>
    /// <param name="data">The data.</param>
    public InformationDialog(Font font, string text, string promptText, string data)
      : this()
    {
      //if (font == null)
      //{
      //  SettingsKey.DefaultSettings != null ? SettingsKey.DefaultSettings.GetFont("fixedfont", SettingsKey.DefaultFixedFont) : SettingsKey.DefaultFixedFont;
      //}

      //informationTextBox.Font = font;
      this.Text = text;
      this.PromptText = promptText;
      this.Data = data;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InformationDialog"/> class.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="promptText">The prompt text.</param>
    /// <param name="data">The data.</param>
    public InformationDialog(string text, string promptText, string data)
      : this(null, text, promptText, data)
    { }
    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>The data.</value>
    public string Data
    {
      get { return informationTextBox.Text; }
      set { informationTextBox.Text = value; }
    }

    /// <summary>
    /// Gets or sets the prompt text.
    /// </summary>
    /// <value>The prompt text.</value>
    public string PromptText
    {
      get { return informationLabel.Text; }
      set { informationLabel.Text = value; }
    }

    #endregion Public Properties

    #region Public Methods

    public static void ShowDialog(string text, string promptText, string data)
    {
      ShowDialog(null, text, promptText, data);
    }

    public static void ShowDialog(Font font, string text, string promptText, string data)
    {
      using (InformationDialog dialog = new InformationDialog(font, text, promptText, data))
      {
        dialog.ShowDialog();
      }
    }

    public static void ShowDialog(string data)
    {
      ShowDialog("View", "&Data:", data);
    }

    #endregion Public Methods

    //protected override void OnLoad(EventArgs e)
    //{
    //  base.OnLoad(e);

    //  if (!this.IsDesignTime() && TranslationProvider.LanguageFoldersPresent)
    //  {
    //    closeButton.TranslateText("Dialog.CloseButton");
    //  }
    //}

    #region Private Methods

    /// <summary>
    /// Handles the Click event of the closeButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void CloseButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    #endregion Private Methods
  }
}