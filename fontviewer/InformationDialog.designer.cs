namespace Cyotek.Demo.Windows.Forms
{
  partial class InformationDialog
  {
    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.informationLabel = new System.Windows.Forms.Label();
      this.informationTextBox = new System.Windows.Forms.TextBox();
      this.closeButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // informationLabel
      // 
      this.informationLabel.AutoSize = true;
      this.informationLabel.Location = new System.Drawing.Point(9, 9);
      this.informationLabel.Name = "informationLabel";
      this.informationLabel.Size = new System.Drawing.Size(74, 13);
      this.informationLabel.TabIndex = 0;
      this.informationLabel.Text = "{Information}";
      // 
      // informationTextBox
      // 
      this.informationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.informationTextBox.Location = new System.Drawing.Point(12, 25);
      this.informationTextBox.Multiline = true;
      this.informationTextBox.Name = "informationTextBox";
      this.informationTextBox.ReadOnly = true;
      this.informationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.informationTextBox.Size = new System.Drawing.Size(660, 380);
      this.informationTextBox.TabIndex = 1;
      this.informationTextBox.WordWrap = false;
      // 
      // closeButton
      // 
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(597, 411);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 2;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // InformationDialog
      // 
      this.AcceptButton = this.closeButton;
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(684, 446);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.informationTextBox);
      this.Controls.Add(this.informationLabel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.MaximizeBox = true;
      this.Name = "InformationDialog";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Text = "Information";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label informationLabel;
    private System.Windows.Forms.TextBox informationTextBox;
    private System.Windows.Forms.Button closeButton;
  }
}
