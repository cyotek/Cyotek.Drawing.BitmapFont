namespace Cyotek.Demo.Windows.Forms
{
  partial class AboutDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.nameLabel = new System.Windows.Forms.Label();
      this.copyrightLabel = new System.Windows.Forms.Label();
      this.closeButton = new System.Windows.Forms.Button();
      this.iconPictureBox = new System.Windows.Forms.PictureBox();
      this.webLinkLabel = new System.Windows.Forms.LinkLabel();
      this.versionLabel = new System.Windows.Forms.Label();
      this.infoLinkLabel = new System.Windows.Forms.LinkLabel();
      ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // nameLabel
      // 
      this.nameLabel.AutoSize = true;
      this.nameLabel.Location = new System.Drawing.Point(50, 12);
      this.nameLabel.Name = "nameLabel";
      this.nameLabel.Size = new System.Drawing.Size(27, 13);
      this.nameLabel.TabIndex = 1;
      this.nameLabel.Text = "Title";
      // 
      // copyrightLabel
      // 
      this.copyrightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.copyrightLabel.Location = new System.Drawing.Point(50, 44);
      this.copyrightLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.copyrightLabel.Name = "copyrightLabel";
      this.copyrightLabel.Size = new System.Drawing.Size(402, 34);
      this.copyrightLabel.TabIndex = 3;
      this.copyrightLabel.Text = "Copyright";
      // 
      // closeButton
      // 
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(377, 246);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 0;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // iconPictureBox
      // 
      this.iconPictureBox.Location = new System.Drawing.Point(12, 12);
      this.iconPictureBox.Name = "iconPictureBox";
      this.iconPictureBox.Size = new System.Drawing.Size(32, 32);
      this.iconPictureBox.TabIndex = 4;
      this.iconPictureBox.TabStop = false;
      // 
      // webLinkLabel
      // 
      this.webLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.webLinkLabel.AutoSize = true;
      this.webLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.webLinkLabel.Location = new System.Drawing.Point(12, 251);
      this.webLinkLabel.Name = "webLinkLabel";
      this.webLinkLabel.Size = new System.Drawing.Size(89, 13);
      this.webLinkLabel.TabIndex = 5;
      this.webLinkLabel.TabStop = true;
      this.webLinkLabel.Text = "www.cyotek.com";
      this.webLinkLabel.Click += new System.EventHandler(this.WebLinkLabel_LinkClicked);
      // 
      // versionLabel
      // 
      this.versionLabel.AutoSize = true;
      this.versionLabel.Location = new System.Drawing.Point(50, 25);
      this.versionLabel.Name = "versionLabel";
      this.versionLabel.Size = new System.Drawing.Size(42, 13);
      this.versionLabel.TabIndex = 2;
      this.versionLabel.Text = "Version";
      // 
      // infoLinkLabel
      // 
      this.infoLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.infoLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.infoLinkLabel.Location = new System.Drawing.Point(53, 78);
      this.infoLinkLabel.Name = "infoLinkLabel";
      this.infoLinkLabel.Size = new System.Drawing.Size(399, 165);
      this.infoLinkLabel.TabIndex = 4;
      this.infoLinkLabel.UseMnemonic = false;
      this.infoLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InfoLinkLabel_LinkClicked);
      // 
      // AboutDialog
      // 
      this.AcceptButton = this.closeButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(464, 281);
      this.Controls.Add(this.infoLinkLabel);
      this.Controls.Add(this.versionLabel);
      this.Controls.Add(this.iconPictureBox);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.webLinkLabel);
      this.Controls.Add(this.copyrightLabel);
      this.Controls.Add(this.nameLabel);
      this.Name = "AboutDialog";
      this.Text = "About";
      ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label nameLabel;
    private System.Windows.Forms.Label copyrightLabel;
    private System.Windows.Forms.LinkLabel webLinkLabel;
    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.PictureBox iconPictureBox;
    private System.Windows.Forms.Label versionLabel;
    private System.Windows.Forms.LinkLabel infoLinkLabel;
  }
}