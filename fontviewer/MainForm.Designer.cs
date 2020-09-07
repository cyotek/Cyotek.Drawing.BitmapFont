namespace BitmapFontViewer
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.rootSplitContainer = new System.Windows.Forms.SplitContainer();
      this.fontSplitContainer = new System.Windows.Forms.SplitContainer();
      this.charListBox = new System.Windows.Forms.ListBox();
      this.fontPropertyGrid = new BitmapFontViewer.PropertyGrid();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.glyphsTabPage = new System.Windows.Forms.TabPage();
      this.imageSplitContainer = new System.Windows.Forms.SplitContainer();
      this.characterSplitContainer = new System.Windows.Forms.SplitContainer();
      this.characterImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.characterPropertyGrid = new BitmapFontViewer.PropertyGrid();
      this.pageImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.previewTabPage = new System.Windows.Forms.TabPage();
      this.textSplitContainer = new System.Windows.Forms.SplitContainer();
      this.previewTextBox = new System.Windows.Forms.TextBox();
      this.previewImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.menuStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.rootSplitContainer.Panel1.SuspendLayout();
      this.rootSplitContainer.Panel2.SuspendLayout();
      this.rootSplitContainer.SuspendLayout();
      this.fontSplitContainer.Panel1.SuspendLayout();
      this.fontSplitContainer.Panel2.SuspendLayout();
      this.fontSplitContainer.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.glyphsTabPage.SuspendLayout();
      this.imageSplitContainer.Panel1.SuspendLayout();
      this.imageSplitContainer.Panel2.SuspendLayout();
      this.imageSplitContainer.SuspendLayout();
      this.characterSplitContainer.Panel1.SuspendLayout();
      this.characterSplitContainer.Panel2.SuspendLayout();
      this.characterSplitContainer.SuspendLayout();
      this.previewTabPage.SuspendLayout();
      this.textSplitContainer.Panel1.SuspendLayout();
      this.textSplitContainer.Panel2.SuspendLayout();
      this.textSplitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(826, 24);
      this.menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Image = global::BitmapFontViewer.Properties.Resources.Open;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.openToolStripMenuItem.Text = "&Open...";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // toolStrip
      // 
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton});
      this.toolStrip.Location = new System.Drawing.Point(0, 24);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(826, 25);
      this.toolStrip.TabIndex = 1;
      // 
      // openToolStripButton
      // 
      this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.openToolStripButton.Image = global::BitmapFontViewer.Properties.Resources.Open;
      this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripButton.Name = "openToolStripButton";
      this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.openToolStripButton.Text = "Open";
      this.openToolStripButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Location = new System.Drawing.Point(0, 498);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(826, 22);
      this.statusStrip.TabIndex = 3;
      // 
      // rootSplitContainer
      // 
      this.rootSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rootSplitContainer.Location = new System.Drawing.Point(0, 49);
      this.rootSplitContainer.Name = "rootSplitContainer";
      // 
      // rootSplitContainer.Panel1
      // 
      this.rootSplitContainer.Panel1.Controls.Add(this.fontSplitContainer);
      // 
      // rootSplitContainer.Panel2
      // 
      this.rootSplitContainer.Panel2.Controls.Add(this.tabControl);
      this.rootSplitContainer.Size = new System.Drawing.Size(826, 449);
      this.rootSplitContainer.SplitterDistance = 275;
      this.rootSplitContainer.TabIndex = 2;
      // 
      // fontSplitContainer
      // 
      this.fontSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fontSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.fontSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.fontSplitContainer.Name = "fontSplitContainer";
      this.fontSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // fontSplitContainer.Panel1
      // 
      this.fontSplitContainer.Panel1.Controls.Add(this.charListBox);
      // 
      // fontSplitContainer.Panel2
      // 
      this.fontSplitContainer.Panel2.Controls.Add(this.fontPropertyGrid);
      this.fontSplitContainer.Size = new System.Drawing.Size(275, 449);
      this.fontSplitContainer.SplitterDistance = 289;
      this.fontSplitContainer.TabIndex = 0;
      // 
      // charListBox
      // 
      this.charListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.charListBox.FormattingEnabled = true;
      this.charListBox.IntegralHeight = false;
      this.charListBox.Location = new System.Drawing.Point(0, 0);
      this.charListBox.Name = "charListBox";
      this.charListBox.Size = new System.Drawing.Size(275, 289);
      this.charListBox.TabIndex = 0;
      this.charListBox.SelectedIndexChanged += new System.EventHandler(this.charListBox_SelectedIndexChanged);
      // 
      // fontPropertyGrid
      // 
      this.fontPropertyGrid.CommandsVisibleIfAvailable = false;
      this.fontPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fontPropertyGrid.HelpVisible = false;
      this.fontPropertyGrid.Location = new System.Drawing.Point(0, 0);
      this.fontPropertyGrid.Name = "fontPropertyGrid";
      this.fontPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
      this.fontPropertyGrid.ReadOnly = true;
      this.fontPropertyGrid.Size = new System.Drawing.Size(275, 156);
      this.fontPropertyGrid.TabIndex = 0;
      this.fontPropertyGrid.ToolbarVisible = false;
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.glyphsTabPage);
      this.tabControl.Controls.Add(this.previewTabPage);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(547, 449);
      this.tabControl.TabIndex = 0;
      // 
      // glyphsTabPage
      // 
      this.glyphsTabPage.Controls.Add(this.imageSplitContainer);
      this.glyphsTabPage.Location = new System.Drawing.Point(4, 22);
      this.glyphsTabPage.Name = "glyphsTabPage";
      this.glyphsTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.glyphsTabPage.Size = new System.Drawing.Size(539, 423);
      this.glyphsTabPage.TabIndex = 0;
      this.glyphsTabPage.Text = "Glyphs";
      this.glyphsTabPage.UseVisualStyleBackColor = true;
      // 
      // imageSplitContainer
      // 
      this.imageSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.imageSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.imageSplitContainer.Location = new System.Drawing.Point(3, 3);
      this.imageSplitContainer.Name = "imageSplitContainer";
      this.imageSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // imageSplitContainer.Panel1
      // 
      this.imageSplitContainer.Panel1.Controls.Add(this.characterSplitContainer);
      // 
      // imageSplitContainer.Panel2
      // 
      this.imageSplitContainer.Panel2.Controls.Add(this.pageImageBox);
      this.imageSplitContainer.Size = new System.Drawing.Size(533, 417);
      this.imageSplitContainer.SplitterDistance = 249;
      this.imageSplitContainer.TabIndex = 0;
      // 
      // characterSplitContainer
      // 
      this.characterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.characterSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.characterSplitContainer.Name = "characterSplitContainer";
      // 
      // characterSplitContainer.Panel1
      // 
      this.characterSplitContainer.Panel1.Controls.Add(this.characterImageBox);
      // 
      // characterSplitContainer.Panel2
      // 
      this.characterSplitContainer.Panel2.Controls.Add(this.characterPropertyGrid);
      this.characterSplitContainer.Size = new System.Drawing.Size(533, 249);
      this.characterSplitContainer.SplitterDistance = 266;
      this.characterSplitContainer.TabIndex = 0;
      // 
      // characterImageBox
      // 
      this.characterImageBox.BackColor = System.Drawing.Color.LightSlateGray;
      this.characterImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.characterImageBox.ForeColor = System.Drawing.SystemColors.ControlText;
      this.characterImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.characterImageBox.Location = new System.Drawing.Point(0, 0);
      this.characterImageBox.Name = "characterImageBox";
      this.characterImageBox.Size = new System.Drawing.Size(266, 249);
      this.characterImageBox.TabIndex = 0;
      // 
      // characterPropertyGrid
      // 
      this.characterPropertyGrid.CommandsVisibleIfAvailable = false;
      this.characterPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.characterPropertyGrid.HelpVisible = false;
      this.characterPropertyGrid.Location = new System.Drawing.Point(0, 0);
      this.characterPropertyGrid.Name = "characterPropertyGrid";
      this.characterPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
      this.characterPropertyGrid.ReadOnly = true;
      this.characterPropertyGrid.Size = new System.Drawing.Size(263, 249);
      this.characterPropertyGrid.TabIndex = 0;
      this.characterPropertyGrid.ToolbarVisible = false;
      // 
      // pageImageBox
      // 
      this.pageImageBox.BackColor = System.Drawing.Color.LightSlateGray;
      this.pageImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pageImageBox.ForeColor = System.Drawing.SystemColors.ControlText;
      this.pageImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.pageImageBox.Location = new System.Drawing.Point(0, 0);
      this.pageImageBox.Name = "pageImageBox";
      this.pageImageBox.Size = new System.Drawing.Size(533, 164);
      this.pageImageBox.TabIndex = 0;
      this.pageImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pageImageBox_Paint);
      // 
      // previewTabPage
      // 
      this.previewTabPage.Controls.Add(this.textSplitContainer);
      this.previewTabPage.Location = new System.Drawing.Point(4, 22);
      this.previewTabPage.Name = "previewTabPage";
      this.previewTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.previewTabPage.Size = new System.Drawing.Size(539, 423);
      this.previewTabPage.TabIndex = 1;
      this.previewTabPage.Text = "Text";
      this.previewTabPage.UseVisualStyleBackColor = true;
      // 
      // textSplitContainer
      // 
      this.textSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.textSplitContainer.Location = new System.Drawing.Point(3, 3);
      this.textSplitContainer.Name = "textSplitContainer";
      this.textSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // textSplitContainer.Panel1
      // 
      this.textSplitContainer.Panel1.Controls.Add(this.previewTextBox);
      // 
      // textSplitContainer.Panel2
      // 
      this.textSplitContainer.Panel2.Controls.Add(this.previewImageBox);
      this.textSplitContainer.Size = new System.Drawing.Size(533, 417);
      this.textSplitContainer.SplitterDistance = 100;
      this.textSplitContainer.TabIndex = 1;
      // 
      // previewTextBox
      // 
      this.previewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.previewTextBox.Location = new System.Drawing.Point(0, 0);
      this.previewTextBox.Multiline = true;
      this.previewTextBox.Name = "previewTextBox";
      this.previewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.previewTextBox.Size = new System.Drawing.Size(533, 100);
      this.previewTextBox.TabIndex = 0;
      this.previewTextBox.TextChanged += new System.EventHandler(this.previewTextBox_TextChanged);
      // 
      // previewImageBox
      // 
      this.previewImageBox.BackColor = System.Drawing.Color.LightSlateGray;
      this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.previewImageBox.ForeColor = System.Drawing.SystemColors.ControlText;
      this.previewImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.previewImageBox.Location = new System.Drawing.Point(0, 0);
      this.previewImageBox.Name = "previewImageBox";
      this.previewImageBox.Size = new System.Drawing.Size(533, 313);
      this.previewImageBox.TabIndex = 0;
      // 
      // openFileDialog
      // 
      this.openFileDialog.DefaultExt = "fnt";
      this.openFileDialog.Filter = "Bitmap Font Files (*.fnt)|*.fnt|All Files (*.*)|*.*";
      this.openFileDialog.Title = "Open Font";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(826, 520);
      this.Controls.Add(this.rootSplitContainer);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.menuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Bitmap Font Viewer";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.rootSplitContainer.Panel1.ResumeLayout(false);
      this.rootSplitContainer.Panel2.ResumeLayout(false);
      this.rootSplitContainer.ResumeLayout(false);
      this.fontSplitContainer.Panel1.ResumeLayout(false);
      this.fontSplitContainer.Panel2.ResumeLayout(false);
      this.fontSplitContainer.ResumeLayout(false);
      this.tabControl.ResumeLayout(false);
      this.glyphsTabPage.ResumeLayout(false);
      this.imageSplitContainer.Panel1.ResumeLayout(false);
      this.imageSplitContainer.Panel2.ResumeLayout(false);
      this.imageSplitContainer.ResumeLayout(false);
      this.characterSplitContainer.Panel1.ResumeLayout(false);
      this.characterSplitContainer.Panel2.ResumeLayout(false);
      this.characterSplitContainer.ResumeLayout(false);
      this.previewTabPage.ResumeLayout(false);
      this.textSplitContainer.Panel1.ResumeLayout(false);
      this.textSplitContainer.Panel1.PerformLayout();
      this.textSplitContainer.Panel2.ResumeLayout(false);
      this.textSplitContainer.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.SplitContainer rootSplitContainer;
    private System.Windows.Forms.SplitContainer imageSplitContainer;
    private System.Windows.Forms.SplitContainer characterSplitContainer;
    private Cyotek.Windows.Forms.ImageBox characterImageBox;
    private Cyotek.Windows.Forms.ImageBox pageImageBox;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton openToolStripButton;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private PropertyGrid characterPropertyGrid;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SplitContainer fontSplitContainer;
    private System.Windows.Forms.ListBox charListBox;
    private PropertyGrid fontPropertyGrid;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage glyphsTabPage;
    private System.Windows.Forms.TabPage previewTabPage;
    private System.Windows.Forms.SplitContainer textSplitContainer;
    private System.Windows.Forms.TextBox previewTextBox;
    private Cyotek.Windows.Forms.ImageBox previewImageBox;
  }
}

