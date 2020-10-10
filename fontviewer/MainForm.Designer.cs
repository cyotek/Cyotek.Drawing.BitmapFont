namespace Cyotek.Demo.Windows.Forms
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
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.generateCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.cyotekLinkToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.rootSplitContainer = new System.Windows.Forms.SplitContainer();
      this.filePane = new Cyotek.Demo.Windows.Forms.FilePane();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.previewTabPage = new System.Windows.Forms.TabPage();
      this.textSplitContainer = new System.Windows.Forms.SplitContainer();
      this.previewTextBox = new System.Windows.Forms.TextBox();
      this.previewImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.fontTabPage = new System.Windows.Forms.TabPage();
      this.fontPropertyGrid = new Cyotek.Demo.BitmapFontViewer.PropertyGrid();
      this.texturePagesTabPage = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.texturePagesListBox = new System.Windows.Forms.ListBox();
      this.texturePageImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.charactersTabPage = new System.Windows.Forms.TabPage();
      this.imageSplitContainer = new System.Windows.Forms.SplitContainer();
      this.charactersSplitContainer = new System.Windows.Forms.SplitContainer();
      this.charListBox = new System.Windows.Forms.ListBox();
      this.characterSplitContainer = new System.Windows.Forms.SplitContainer();
      this.characterImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.characterPropertyGrid = new Cyotek.Demo.BitmapFontViewer.PropertyGrid();
      this.pageImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.kerningsTabPage = new System.Windows.Forms.TabPage();
      this.kerningsListBox = new System.Windows.Forms.ListBox();
      this.menuStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.statusStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.rootSplitContainer)).BeginInit();
      this.rootSplitContainer.Panel1.SuspendLayout();
      this.rootSplitContainer.Panel2.SuspendLayout();
      this.rootSplitContainer.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.previewTabPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.textSplitContainer)).BeginInit();
      this.textSplitContainer.Panel1.SuspendLayout();
      this.textSplitContainer.Panel2.SuspendLayout();
      this.textSplitContainer.SuspendLayout();
      this.fontTabPage.SuspendLayout();
      this.texturePagesTabPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.charactersTabPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.imageSplitContainer)).BeginInit();
      this.imageSplitContainer.Panel1.SuspendLayout();
      this.imageSplitContainer.Panel2.SuspendLayout();
      this.imageSplitContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.charactersSplitContainer)).BeginInit();
      this.charactersSplitContainer.Panel1.SuspendLayout();
      this.charactersSplitContainer.Panel2.SuspendLayout();
      this.charactersSplitContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.characterSplitContainer)).BeginInit();
      this.characterSplitContainer.Panel1.SuspendLayout();
      this.characterSplitContainer.Panel2.SuspendLayout();
      this.characterSplitContainer.SuspendLayout();
      this.kerningsTabPage.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(826, 24);
      this.menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Image = global::Cyotek.Demo.BitmapFontViewer.Properties.Resources.Open;
      this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.openToolStripMenuItem.Text = "&Open";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateCodeToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      // 
      // generateCodeToolStripMenuItem
      // 
      this.generateCodeToolStripMenuItem.Name = "generateCodeToolStripMenuItem";
      this.generateCodeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.generateCodeToolStripMenuItem.Text = "&Generate Code";
      this.generateCodeToolStripMenuItem.Click += new System.EventHandler(this.GenerateCodeToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
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
      this.openToolStripButton.Image = global::Cyotek.Demo.BitmapFontViewer.Properties.Resources.Open;
      this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripButton.Name = "openToolStripButton";
      this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.openToolStripButton.Text = "&Open";
      this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.cyotekLinkToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 498);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(826, 22);
      this.statusStrip.TabIndex = 3;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(712, 17);
      this.statusToolStripStatusLabel.Spring = true;
      this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cyotekLinkToolStripStatusLabel
      // 
      this.cyotekLinkToolStripStatusLabel.IsLink = true;
      this.cyotekLinkToolStripStatusLabel.Name = "cyotekLinkToolStripStatusLabel";
      this.cyotekLinkToolStripStatusLabel.Size = new System.Drawing.Size(99, 17);
      this.cyotekLinkToolStripStatusLabel.Text = "www.cyotek.com";
      this.cyotekLinkToolStripStatusLabel.Click += new System.EventHandler(this.CyotekLinkToolStripStatusLabel_Click);
      // 
      // rootSplitContainer
      // 
      this.rootSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rootSplitContainer.Location = new System.Drawing.Point(0, 49);
      this.rootSplitContainer.Name = "rootSplitContainer";
      // 
      // rootSplitContainer.Panel1
      // 
      this.rootSplitContainer.Panel1.Controls.Add(this.filePane);
      // 
      // rootSplitContainer.Panel2
      // 
      this.rootSplitContainer.Panel2.Controls.Add(this.tabControl);
      this.rootSplitContainer.Size = new System.Drawing.Size(826, 449);
      this.rootSplitContainer.SplitterDistance = 275;
      this.rootSplitContainer.TabIndex = 2;
      // 
      // filePane
      // 
      this.filePane.Dock = System.Windows.Forms.DockStyle.Fill;
      this.filePane.Location = new System.Drawing.Point(0, 0);
      this.filePane.Name = "filePane";
      this.filePane.SearchPattern = "*.fnt";
      this.filePane.Size = new System.Drawing.Size(275, 449);
      this.filePane.TabIndex = 0;
      this.filePane.SelectedFileChanged += new System.EventHandler(this.FilePane_SelectedFileChanged);
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.previewTabPage);
      this.tabControl.Controls.Add(this.fontTabPage);
      this.tabControl.Controls.Add(this.texturePagesTabPage);
      this.tabControl.Controls.Add(this.charactersTabPage);
      this.tabControl.Controls.Add(this.kerningsTabPage);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(547, 449);
      this.tabControl.TabIndex = 0;
      // 
      // previewTabPage
      // 
      this.previewTabPage.Controls.Add(this.textSplitContainer);
      this.previewTabPage.Location = new System.Drawing.Point(4, 22);
      this.previewTabPage.Name = "previewTabPage";
      this.previewTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.previewTabPage.Size = new System.Drawing.Size(539, 423);
      this.previewTabPage.TabIndex = 4;
      this.previewTabPage.Text = "Preview";
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
      this.textSplitContainer.TabIndex = 2;
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
      this.previewTextBox.TextChanged += new System.EventHandler(this.PreviewTextBox_TextChanged);
      // 
      // previewImageBox
      // 
      this.previewImageBox.BackColor = System.Drawing.SystemColors.Window;
      this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.previewImageBox.ForeColor = System.Drawing.SystemColors.WindowText;
      this.previewImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.previewImageBox.Location = new System.Drawing.Point(0, 0);
      this.previewImageBox.Name = "previewImageBox";
      this.previewImageBox.Size = new System.Drawing.Size(533, 313);
      this.previewImageBox.TabIndex = 0;
      // 
      // fontTabPage
      // 
      this.fontTabPage.Controls.Add(this.fontPropertyGrid);
      this.fontTabPage.Location = new System.Drawing.Point(4, 22);
      this.fontTabPage.Name = "fontTabPage";
      this.fontTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.fontTabPage.Size = new System.Drawing.Size(539, 423);
      this.fontTabPage.TabIndex = 1;
      this.fontTabPage.Text = "Font";
      this.fontTabPage.UseVisualStyleBackColor = true;
      // 
      // fontPropertyGrid
      // 
      this.fontPropertyGrid.CommandsVisibleIfAvailable = false;
      this.fontPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fontPropertyGrid.HelpVisible = false;
      this.fontPropertyGrid.Location = new System.Drawing.Point(3, 3);
      this.fontPropertyGrid.Name = "fontPropertyGrid";
      this.fontPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
      this.fontPropertyGrid.ReadOnly = true;
      this.fontPropertyGrid.Size = new System.Drawing.Size(533, 417);
      this.fontPropertyGrid.TabIndex = 0;
      this.fontPropertyGrid.ToolbarVisible = false;
      // 
      // texturePagesTabPage
      // 
      this.texturePagesTabPage.Controls.Add(this.splitContainer1);
      this.texturePagesTabPage.Location = new System.Drawing.Point(4, 22);
      this.texturePagesTabPage.Name = "texturePagesTabPage";
      this.texturePagesTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.texturePagesTabPage.Size = new System.Drawing.Size(539, 423);
      this.texturePagesTabPage.TabIndex = 2;
      this.texturePagesTabPage.Text = "Texture Pages";
      this.texturePagesTabPage.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(3, 3);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.texturePagesListBox);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.texturePageImageBox);
      this.splitContainer1.Size = new System.Drawing.Size(533, 417);
      this.splitContainer1.SplitterDistance = 263;
      this.splitContainer1.TabIndex = 1;
      // 
      // texturePagesListBox
      // 
      this.texturePagesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.texturePagesListBox.FormattingEnabled = true;
      this.texturePagesListBox.IntegralHeight = false;
      this.texturePagesListBox.Location = new System.Drawing.Point(0, 0);
      this.texturePagesListBox.Name = "texturePagesListBox";
      this.texturePagesListBox.Size = new System.Drawing.Size(263, 417);
      this.texturePagesListBox.TabIndex = 0;
      this.texturePagesListBox.SelectedIndexChanged += new System.EventHandler(this.TexturePagesListBox_SelectedIndexChanged);
      // 
      // texturePageImageBox
      // 
      this.texturePageImageBox.BackColor = System.Drawing.SystemColors.ControlDark;
      this.texturePageImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.texturePageImageBox.ForeColor = System.Drawing.SystemColors.ControlText;
      this.texturePageImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.texturePageImageBox.Location = new System.Drawing.Point(0, 0);
      this.texturePageImageBox.Name = "texturePageImageBox";
      this.texturePageImageBox.Size = new System.Drawing.Size(266, 417);
      this.texturePageImageBox.TabIndex = 1;
      // 
      // charactersTabPage
      // 
      this.charactersTabPage.Controls.Add(this.imageSplitContainer);
      this.charactersTabPage.Location = new System.Drawing.Point(4, 22);
      this.charactersTabPage.Name = "charactersTabPage";
      this.charactersTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.charactersTabPage.Size = new System.Drawing.Size(539, 423);
      this.charactersTabPage.TabIndex = 0;
      this.charactersTabPage.Text = "Characters";
      this.charactersTabPage.UseVisualStyleBackColor = true;
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
      this.imageSplitContainer.Panel1.Controls.Add(this.charactersSplitContainer);
      // 
      // imageSplitContainer.Panel2
      // 
      this.imageSplitContainer.Panel2.Controls.Add(this.pageImageBox);
      this.imageSplitContainer.Size = new System.Drawing.Size(533, 417);
      this.imageSplitContainer.SplitterDistance = 249;
      this.imageSplitContainer.TabIndex = 0;
      // 
      // charactersSplitContainer
      // 
      this.charactersSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.charactersSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.charactersSplitContainer.Name = "charactersSplitContainer";
      // 
      // charactersSplitContainer.Panel1
      // 
      this.charactersSplitContainer.Panel1.Controls.Add(this.charListBox);
      // 
      // charactersSplitContainer.Panel2
      // 
      this.charactersSplitContainer.Panel2.Controls.Add(this.characterSplitContainer);
      this.charactersSplitContainer.Size = new System.Drawing.Size(533, 249);
      this.charactersSplitContainer.SplitterDistance = 264;
      this.charactersSplitContainer.TabIndex = 0;
      // 
      // charListBox
      // 
      this.charListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.charListBox.FormattingEnabled = true;
      this.charListBox.IntegralHeight = false;
      this.charListBox.Location = new System.Drawing.Point(0, 0);
      this.charListBox.Name = "charListBox";
      this.charListBox.Size = new System.Drawing.Size(264, 249);
      this.charListBox.TabIndex = 0;
      this.charListBox.SelectedIndexChanged += new System.EventHandler(this.CharListBox_SelectedIndexChanged);
      // 
      // characterSplitContainer
      // 
      this.characterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.characterSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.characterSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.characterSplitContainer.Name = "characterSplitContainer";
      this.characterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // characterSplitContainer.Panel1
      // 
      this.characterSplitContainer.Panel1.Controls.Add(this.characterImageBox);
      // 
      // characterSplitContainer.Panel2
      // 
      this.characterSplitContainer.Panel2.Controls.Add(this.characterPropertyGrid);
      this.characterSplitContainer.Size = new System.Drawing.Size(265, 249);
      this.characterSplitContainer.SplitterDistance = 98;
      this.characterSplitContainer.TabIndex = 0;
      // 
      // characterImageBox
      // 
      this.characterImageBox.BackColor = System.Drawing.SystemColors.ControlDark;
      this.characterImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.characterImageBox.ForeColor = System.Drawing.SystemColors.ControlText;
      this.characterImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.characterImageBox.Location = new System.Drawing.Point(0, 0);
      this.characterImageBox.Name = "characterImageBox";
      this.characterImageBox.Size = new System.Drawing.Size(265, 98);
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
      this.characterPropertyGrid.Size = new System.Drawing.Size(265, 147);
      this.characterPropertyGrid.TabIndex = 0;
      this.characterPropertyGrid.ToolbarVisible = false;
      // 
      // pageImageBox
      // 
      this.pageImageBox.BackColor = System.Drawing.SystemColors.ControlDark;
      this.pageImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pageImageBox.ForeColor = System.Drawing.SystemColors.ControlText;
      this.pageImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
      this.pageImageBox.Location = new System.Drawing.Point(0, 0);
      this.pageImageBox.Name = "pageImageBox";
      this.pageImageBox.Size = new System.Drawing.Size(533, 164);
      this.pageImageBox.TabIndex = 0;
      this.pageImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PageImageBox_Paint);
      // 
      // kerningsTabPage
      // 
      this.kerningsTabPage.Controls.Add(this.kerningsListBox);
      this.kerningsTabPage.Location = new System.Drawing.Point(4, 22);
      this.kerningsTabPage.Name = "kerningsTabPage";
      this.kerningsTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.kerningsTabPage.Size = new System.Drawing.Size(539, 423);
      this.kerningsTabPage.TabIndex = 3;
      this.kerningsTabPage.Text = "Kernings";
      this.kerningsTabPage.UseVisualStyleBackColor = true;
      // 
      // kerningsListBox
      // 
      this.kerningsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.kerningsListBox.FormattingEnabled = true;
      this.kerningsListBox.IntegralHeight = false;
      this.kerningsListBox.Location = new System.Drawing.Point(3, 3);
      this.kerningsListBox.Name = "kerningsListBox";
      this.kerningsListBox.Size = new System.Drawing.Size(533, 417);
      this.kerningsListBox.TabIndex = 1;
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
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip;
      this.MaximizeBox = true;
      this.MinimizeBox = true;
      this.Name = "MainForm";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.Text = "Cyotek Bitmap Font Viewer";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.rootSplitContainer.Panel1.ResumeLayout(false);
      this.rootSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.rootSplitContainer)).EndInit();
      this.rootSplitContainer.ResumeLayout(false);
      this.tabControl.ResumeLayout(false);
      this.previewTabPage.ResumeLayout(false);
      this.textSplitContainer.Panel1.ResumeLayout(false);
      this.textSplitContainer.Panel1.PerformLayout();
      this.textSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.textSplitContainer)).EndInit();
      this.textSplitContainer.ResumeLayout(false);
      this.fontTabPage.ResumeLayout(false);
      this.texturePagesTabPage.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.charactersTabPage.ResumeLayout(false);
      this.imageSplitContainer.Panel1.ResumeLayout(false);
      this.imageSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.imageSplitContainer)).EndInit();
      this.imageSplitContainer.ResumeLayout(false);
      this.charactersSplitContainer.Panel1.ResumeLayout(false);
      this.charactersSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.charactersSplitContainer)).EndInit();
      this.charactersSplitContainer.ResumeLayout(false);
      this.characterSplitContainer.Panel1.ResumeLayout(false);
      this.characterSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.characterSplitContainer)).EndInit();
      this.characterSplitContainer.ResumeLayout(false);
      this.kerningsTabPage.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.SplitContainer rootSplitContainer;
    private System.Windows.Forms.SplitContainer imageSplitContainer;
    private System.Windows.Forms.SplitContainer characterSplitContainer;
    private Cyotek.Windows.Forms.ImageBox characterImageBox;
    private Cyotek.Windows.Forms.ImageBox pageImageBox;
    private Cyotek.Demo.BitmapFontViewer.PropertyGrid characterPropertyGrid;
    private System.Windows.Forms.ListBox charListBox;
    private Cyotek.Demo.BitmapFontViewer.PropertyGrid fontPropertyGrid;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage charactersTabPage;
    private System.Windows.Forms.TabPage fontTabPage;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton openToolStripButton;
    private FilePane filePane;
    private System.Windows.Forms.SplitContainer charactersSplitContainer;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel cyotekLinkToolStripStatusLabel;
    private System.Windows.Forms.TabPage texturePagesTabPage;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ListBox texturePagesListBox;
    private Cyotek.Windows.Forms.ImageBox texturePageImageBox;
    private System.Windows.Forms.TabPage kerningsTabPage;
    private System.Windows.Forms.ListBox kerningsListBox;
    private System.Windows.Forms.TabPage previewTabPage;
    private System.Windows.Forms.SplitContainer textSplitContainer;
    private System.Windows.Forms.TextBox previewTextBox;
    private Cyotek.Windows.Forms.ImageBox previewImageBox;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem generateCodeToolStripMenuItem;
  }
}

