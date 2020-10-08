namespace Cyotek.Demo.Windows.Forms
{
  partial class FilePane
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.filesListListBox = new System.Windows.Forms.ListBox();
      this.pathTextBox = new System.Windows.Forms.TextBox();
      this.pathBrowseButton = new System.Windows.Forms.Button();
      this.pathChangeTimer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // filesListListBox
      // 
      this.filesListListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.filesListListBox.FormattingEnabled = true;
      this.filesListListBox.IntegralHeight = false;
      this.filesListListBox.Location = new System.Drawing.Point(0, 26);
      this.filesListListBox.Name = "filesListListBox";
      this.filesListListBox.Size = new System.Drawing.Size(208, 329);
      this.filesListListBox.TabIndex = 0;
      this.filesListListBox.SelectedIndexChanged += new System.EventHandler(this.FilesListListBox_SelectedIndexChanged);
      // 
      // pathTextBox
      // 
      this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.pathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
      this.pathTextBox.Location = new System.Drawing.Point(0, 0);
      this.pathTextBox.Name = "pathTextBox";
      this.pathTextBox.Size = new System.Drawing.Size(175, 20);
      this.pathTextBox.TabIndex = 1;
      this.pathTextBox.TextChanged += new System.EventHandler(this.PathTextBox_TextChanged);
      // 
      // pathBrowseButton
      // 
      this.pathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pathBrowseButton.Location = new System.Drawing.Point(181, 0);
      this.pathBrowseButton.Name = "pathBrowseButton";
      this.pathBrowseButton.Size = new System.Drawing.Size(27, 20);
      this.pathBrowseButton.TabIndex = 2;
      this.pathBrowseButton.Text = "...";
      this.pathBrowseButton.UseVisualStyleBackColor = true;
      this.pathBrowseButton.Click += new System.EventHandler(this.PathBrowseButton_Click);
      // 
      // pathChangeTimer
      // 
      this.pathChangeTimer.Tick += new System.EventHandler(this.PathChangeTimer_Tick);
      // 
      // FilePane
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pathBrowseButton);
      this.Controls.Add(this.pathTextBox);
      this.Controls.Add(this.filesListListBox);
      this.Name = "FilePane";
      this.Size = new System.Drawing.Size(208, 355);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox filesListListBox;
    private System.Windows.Forms.TextBox pathTextBox;
    private System.Windows.Forms.Button pathBrowseButton;
    private System.Windows.Forms.Timer pathChangeTimer;
  }
}
