using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
  internal partial class AboutDialog : BaseForm
  {
    #region Public Constructors

    public AboutDialog()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Methods

    public static DialogResult ShowAboutDialog()
    {
      using (AboutDialog dialog = new AboutDialog())
      {
        return dialog.ShowDialog();
      }
    }

    #endregion Public Methods

    #region Internal Methods

    internal static void OpenCyotekHomePage()
    {
      AboutDialog.OpenUrl("https://www.cyotek.com");
    }

    internal static void OpenUrl(string url)
    {
      try
      {
        Process.Start(url);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.GetBaseException().Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion Internal Methods

    #region Protected Methods

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      nameLabel.Font = new Font(this.Font, FontStyle.Bold);
    }

    protected override void OnLoad(EventArgs e)
    {
      FileVersionInfo versionInfo;
      int x;
      int w;

      if (!this.DesignMode)
      {
        this.Font = SystemFonts.DialogFont;
      }

      versionInfo = FileVersionInfo.GetVersionInfo(typeof(MainForm).Assembly.Location);
      nameLabel.Text = versionInfo.ProductName;
      versionLabel.Text = "Version " + versionInfo.ProductVersion;
      copyrightLabel.Text = versionInfo.LegalCopyright;

      iconPictureBox.Size = SystemInformation.IconSize;
      iconPictureBox.Image = GetIconBitmap();

      x = iconPictureBox.Right + iconPictureBox.Margin.Right + nameLabel.Margin.Left;
      w = this.ClientSize.Width - (iconPictureBox.Left + x);

      nameLabel.SetBounds(x, 0, w, 0, BoundsSpecified.X | BoundsSpecified.Width);
      versionLabel.SetBounds(x, 0, w, 0, BoundsSpecified.X | BoundsSpecified.Width);
      copyrightLabel.SetBounds(x, 0, w, 0, BoundsSpecified.X | BoundsSpecified.Width);
      infoLinkLabel.SetBounds(x, 0, w, 0, BoundsSpecified.X | BoundsSpecified.Width);

      this.LoadAboutText();

      base.OnLoad(e);
    }

    #endregion Protected Methods

    #region Private Methods

    private static Bitmap GetIconBitmap()
    {
      Bitmap result;
      FormCollection forms;

      result = null;
      forms = Application.OpenForms;

      for (int i = 0; i < forms.Count; i++)
      {
        if (forms[i] is MainForm form)
        {
          result = form.Icon.ToBitmap();
          break;
        }
      }

      return result;
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void InfoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      AboutDialog.OpenUrl((string)e.Link.LinkData);
    }

    private void LoadAboutText()
    {
      string fileName;

      fileName = Path.Combine(Application.StartupPath, "about.txt");

      if (File.Exists(fileName))
      {
        string text;
        int linkStart;

        text = File.ReadAllText(fileName);

        infoLinkLabel.Text = text;
        linkStart = -1;

        do
        {
          linkStart = text.IndexOf('<', linkStart + 1);

          if (linkStart != -1)
          {
            int linkEnd;

            linkEnd = text.IndexOf('>', linkStart);

            if (linkEnd != -1)
            {
              int length;
              string link;

              length = linkEnd - linkStart;
              link = text.Substring(linkStart + 1, length - 1);

              infoLinkLabel.Links.Add(linkStart + 1, length - 1, link);
            }
          }
        } while (linkStart != -1);
      }
    }

    private void WebLinkLabel_LinkClicked(object sender, EventArgs e)
    {
      AboutDialog.OpenCyotekHomePage();
    }

    #endregion Private Methods
  }
}