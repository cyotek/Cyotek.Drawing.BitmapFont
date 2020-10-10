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
      System.Windows.Forms.GroupBox addingGroupBox;
      System.Windows.Forms.Label bottomLabel;
      System.Windows.Forms.Label topLabel;
      System.Windows.Forms.Label rightLabel;
      System.Windows.Forms.Label leftLabel;
      System.Windows.Forms.SplitContainer editSplitContainer;
      System.Windows.Forms.GroupBox fontGroupBox;
      System.Windows.Forms.Label fontLabel;
      System.Windows.Forms.GroupBox colorGroupBox;
      System.Windows.Forms.Label backgroundColorLabel;
      System.Windows.Forms.Label textColorLabel;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
      System.Windows.Forms.ToolStripButton pasteToolStripButton;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.bottomNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.topNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.rightNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.leftNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.textSplitContainer = new System.Windows.Forms.SplitContainer();
      this.previewTextBox = new System.Windows.Forms.TextBox();
      this.previewImageBox = new Cyotek.Windows.Forms.ImageBox();
      this.fontComboBox = new System.Windows.Forms.ComboBox();
      this.backgroundColorButton = new Cyotek.Windows.Forms.ColorButton();
      this.textColorButton = new Cyotek.Windows.Forms.ColorButton();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.cyotekLinkToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      addingGroupBox = new System.Windows.Forms.GroupBox();
      bottomLabel = new System.Windows.Forms.Label();
      topLabel = new System.Windows.Forms.Label();
      rightLabel = new System.Windows.Forms.Label();
      leftLabel = new System.Windows.Forms.Label();
      editSplitContainer = new System.Windows.Forms.SplitContainer();
      fontGroupBox = new System.Windows.Forms.GroupBox();
      fontLabel = new System.Windows.Forms.Label();
      colorGroupBox = new System.Windows.Forms.GroupBox();
      backgroundColorLabel = new System.Windows.Forms.Label();
      textColorLabel = new System.Windows.Forms.Label();
      toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
      addingGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bottomNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.topNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.rightNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.leftNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(editSplitContainer)).BeginInit();
      editSplitContainer.Panel1.SuspendLayout();
      editSplitContainer.Panel2.SuspendLayout();
      editSplitContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.textSplitContainer)).BeginInit();
      this.textSplitContainer.Panel1.SuspendLayout();
      this.textSplitContainer.Panel2.SuspendLayout();
      this.textSplitContainer.SuspendLayout();
      fontGroupBox.SuspendLayout();
      colorGroupBox.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // addingGroupBox
      // 
      addingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      addingGroupBox.Controls.Add(this.bottomNumericUpDown);
      addingGroupBox.Controls.Add(bottomLabel);
      addingGroupBox.Controls.Add(this.topNumericUpDown);
      addingGroupBox.Controls.Add(topLabel);
      addingGroupBox.Controls.Add(this.rightNumericUpDown);
      addingGroupBox.Controls.Add(rightLabel);
      addingGroupBox.Controls.Add(this.leftNumericUpDown);
      addingGroupBox.Controls.Add(leftLabel);
      addingGroupBox.Location = new System.Drawing.Point(3, 3);
      addingGroupBox.Name = "addingGroupBox";
      addingGroupBox.Size = new System.Drawing.Size(240, 128);
      addingGroupBox.TabIndex = 0;
      addingGroupBox.TabStop = false;
      addingGroupBox.Text = "Padding";
      // 
      // bottomNumericUpDown
      // 
      this.bottomNumericUpDown.Location = new System.Drawing.Point(55, 97);
      this.bottomNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.bottomNumericUpDown.Name = "bottomNumericUpDown";
      this.bottomNumericUpDown.Size = new System.Drawing.Size(52, 20);
      this.bottomNumericUpDown.TabIndex = 7;
      this.bottomNumericUpDown.ValueChanged += new System.EventHandler(this.LeftNumericUpDown_ValueChanged);
      // 
      // bottomLabel
      // 
      bottomLabel.AutoSize = true;
      bottomLabel.Location = new System.Drawing.Point(6, 99);
      bottomLabel.Name = "bottomLabel";
      bottomLabel.Size = new System.Drawing.Size(43, 13);
      bottomLabel.TabIndex = 6;
      bottomLabel.Text = "&Bottom:";
      // 
      // topNumericUpDown
      // 
      this.topNumericUpDown.Location = new System.Drawing.Point(55, 71);
      this.topNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.topNumericUpDown.Name = "topNumericUpDown";
      this.topNumericUpDown.Size = new System.Drawing.Size(52, 20);
      this.topNumericUpDown.TabIndex = 5;
      this.topNumericUpDown.ValueChanged += new System.EventHandler(this.LeftNumericUpDown_ValueChanged);
      // 
      // topLabel
      // 
      topLabel.AutoSize = true;
      topLabel.Location = new System.Drawing.Point(6, 73);
      topLabel.Name = "topLabel";
      topLabel.Size = new System.Drawing.Size(29, 13);
      topLabel.TabIndex = 4;
      topLabel.Text = "&Top:";
      // 
      // rightNumericUpDown
      // 
      this.rightNumericUpDown.Location = new System.Drawing.Point(55, 45);
      this.rightNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.rightNumericUpDown.Name = "rightNumericUpDown";
      this.rightNumericUpDown.Size = new System.Drawing.Size(52, 20);
      this.rightNumericUpDown.TabIndex = 3;
      this.rightNumericUpDown.ValueChanged += new System.EventHandler(this.LeftNumericUpDown_ValueChanged);
      // 
      // rightLabel
      // 
      rightLabel.AutoSize = true;
      rightLabel.Location = new System.Drawing.Point(6, 47);
      rightLabel.Name = "rightLabel";
      rightLabel.Size = new System.Drawing.Size(35, 13);
      rightLabel.TabIndex = 2;
      rightLabel.Text = "&Right:";
      // 
      // leftNumericUpDown
      // 
      this.leftNumericUpDown.Location = new System.Drawing.Point(55, 19);
      this.leftNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.leftNumericUpDown.Name = "leftNumericUpDown";
      this.leftNumericUpDown.Size = new System.Drawing.Size(52, 20);
      this.leftNumericUpDown.TabIndex = 1;
      this.leftNumericUpDown.ValueChanged += new System.EventHandler(this.LeftNumericUpDown_ValueChanged);
      // 
      // leftLabel
      // 
      leftLabel.AutoSize = true;
      leftLabel.Location = new System.Drawing.Point(6, 21);
      leftLabel.Name = "leftLabel";
      leftLabel.Size = new System.Drawing.Size(28, 13);
      leftLabel.TabIndex = 0;
      leftLabel.Text = "&Left:";
      // 
      // editSplitContainer
      // 
      editSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      editSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      editSplitContainer.Location = new System.Drawing.Point(0, 49);
      editSplitContainer.Name = "editSplitContainer";
      // 
      // editSplitContainer.Panel1
      // 
      editSplitContainer.Panel1.Controls.Add(this.textSplitContainer);
      // 
      // editSplitContainer.Panel2
      // 
      editSplitContainer.Panel2.Controls.Add(fontGroupBox);
      editSplitContainer.Panel2.Controls.Add(colorGroupBox);
      editSplitContainer.Panel2.Controls.Add(addingGroupBox);
      editSplitContainer.Size = new System.Drawing.Size(784, 490);
      editSplitContainer.SplitterDistance = 534;
      editSplitContainer.TabIndex = 2;
      // 
      // textSplitContainer
      // 
      this.textSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.textSplitContainer.Location = new System.Drawing.Point(0, 0);
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
      this.textSplitContainer.Size = new System.Drawing.Size(534, 490);
      this.textSplitContainer.SplitterDistance = 100;
      this.textSplitContainer.TabIndex = 0;
      // 
      // previewTextBox
      // 
      this.previewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.previewTextBox.Location = new System.Drawing.Point(0, 0);
      this.previewTextBox.Multiline = true;
      this.previewTextBox.Name = "previewTextBox";
      this.previewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.previewTextBox.Size = new System.Drawing.Size(534, 100);
      this.previewTextBox.TabIndex = 0;
      this.previewTextBox.TextChanged += new System.EventHandler(this.PreviewTextBox_TextChanged);
      // 
      // previewImageBox
      // 
      this.previewImageBox.BackColor = System.Drawing.SystemColors.Control;
      this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.previewImageBox.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.Image;
      this.previewImageBox.ImageBorderStyle = Cyotek.Windows.Forms.ImageBoxBorderStyle.FixedSingleGlowShadow;
      this.previewImageBox.Location = new System.Drawing.Point(0, 0);
      this.previewImageBox.Name = "previewImageBox";
      this.previewImageBox.ShowPixelGrid = true;
      this.previewImageBox.Size = new System.Drawing.Size(534, 386);
      this.previewImageBox.TabIndex = 0;
      // 
      // fontGroupBox
      // 
      fontGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      fontGroupBox.Controls.Add(this.fontComboBox);
      fontGroupBox.Controls.Add(fontLabel);
      fontGroupBox.Location = new System.Drawing.Point(3, 224);
      fontGroupBox.Name = "fontGroupBox";
      fontGroupBox.Size = new System.Drawing.Size(240, 53);
      fontGroupBox.TabIndex = 2;
      fontGroupBox.TabStop = false;
      fontGroupBox.Text = "Font";
      // 
      // fontComboBox
      // 
      this.fontComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.fontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.fontComboBox.FormattingEnabled = true;
      this.fontComboBox.Location = new System.Drawing.Point(43, 19);
      this.fontComboBox.Name = "fontComboBox";
      this.fontComboBox.Size = new System.Drawing.Size(188, 21);
      this.fontComboBox.TabIndex = 1;
      this.fontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontComboBox_SelectedIndexChanged);
      // 
      // fontLabel
      // 
      fontLabel.AutoSize = true;
      fontLabel.Location = new System.Drawing.Point(6, 22);
      fontLabel.Name = "fontLabel";
      fontLabel.Size = new System.Drawing.Size(31, 13);
      fontLabel.TabIndex = 0;
      fontLabel.Text = "F&ont:";
      // 
      // colorGroupBox
      // 
      colorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      colorGroupBox.Controls.Add(this.backgroundColorButton);
      colorGroupBox.Controls.Add(backgroundColorLabel);
      colorGroupBox.Controls.Add(this.textColorButton);
      colorGroupBox.Controls.Add(textColorLabel);
      colorGroupBox.Location = new System.Drawing.Point(3, 137);
      colorGroupBox.Name = "colorGroupBox";
      colorGroupBox.Size = new System.Drawing.Size(240, 81);
      colorGroupBox.TabIndex = 1;
      colorGroupBox.TabStop = false;
      colorGroupBox.Text = "Colors";
      // 
      // backgroundColorButton
      // 
      this.backgroundColorButton.DialogTitle = "Background Color";
      this.backgroundColorButton.Location = new System.Drawing.Point(80, 48);
      this.backgroundColorButton.Name = "backgroundColorButton";
      this.backgroundColorButton.Size = new System.Drawing.Size(99, 23);
      this.backgroundColorButton.TabIndex = 3;
      this.backgroundColorButton.UseVisualStyleBackColor = true;
      this.backgroundColorButton.ColorChanged += new System.EventHandler(this.BackgroundColorButton_ColorChanged);
      // 
      // backgroundColorLabel
      // 
      backgroundColorLabel.AutoSize = true;
      backgroundColorLabel.Location = new System.Drawing.Point(6, 53);
      backgroundColorLabel.Name = "backgroundColorLabel";
      backgroundColorLabel.Size = new System.Drawing.Size(68, 13);
      backgroundColorLabel.TabIndex = 2;
      backgroundColorLabel.Text = "Back&ground:";
      // 
      // textColorButton
      // 
      this.textColorButton.DialogTitle = "Text Color";
      this.textColorButton.IgnoreAlphaChannel = true;
      this.textColorButton.Location = new System.Drawing.Point(80, 19);
      this.textColorButton.Name = "textColorButton";
      this.textColorButton.Size = new System.Drawing.Size(99, 23);
      this.textColorButton.TabIndex = 1;
      this.textColorButton.UseVisualStyleBackColor = true;
      this.textColorButton.ColorChanged += new System.EventHandler(this.TextColorButton_ColorChanged);
      // 
      // textColorLabel
      // 
      textColorLabel.AutoSize = true;
      textColorLabel.Location = new System.Drawing.Point(6, 24);
      textColorLabel.Name = "textColorLabel";
      textColorLabel.Size = new System.Drawing.Size(31, 13);
      textColorLabel.TabIndex = 0;
      textColorLabel.Text = "Te&xt:";
      // 
      // toolStripSeparator
      // 
      toolStripSeparator.Name = "toolStripSeparator";
      toolStripSeparator.Size = new System.Drawing.Size(143, 6);
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
      // 
      // toolStripSeparator4
      // 
      toolStripSeparator4.Name = "toolStripSeparator4";
      toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
      // 
      // toolStripSeparator6
      // 
      toolStripSeparator6.Name = "toolStripSeparator6";
      toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
      // 
      // pasteToolStripButton
      // 
      pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
      pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      pasteToolStripButton.Name = "pasteToolStripButton";
      pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
      pasteToolStripButton.Text = "&Paste";
      pasteToolStripButton.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(784, 24);
      this.menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            toolStripSeparator1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
      this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.newToolStripMenuItem.Text = "&New";
      this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
      this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.openToolStripMenuItem.Text = "&Open";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
      this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.saveAsToolStripMenuItem.Text = "Save &As";
      this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            toolStripSeparator4,
            this.selectAllToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
      this.editToolStripMenuItem.Text = "&Edit";
      // 
      // cutToolStripMenuItem
      // 
      this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
      this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
      this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.cutToolStripMenuItem.Text = "Cu&t";
      this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
      // 
      // copyToolStripMenuItem
      // 
      this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
      this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.copyToolStripMenuItem.Text = "&Copy";
      this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
      // 
      // pasteToolStripMenuItem
      // 
      this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
      this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
      this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.pasteToolStripMenuItem.Text = "&Paste";
      this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
      // 
      // selectAllToolStripMenuItem
      // 
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
      this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.selectAllToolStripMenuItem.Text = "Select &All";
      this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
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
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            toolStripSeparator6,
            this.cutToolStripButton,
            this.copyToolStripButton,
            pasteToolStripButton});
      this.toolStrip.Location = new System.Drawing.Point(0, 24);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(784, 25);
      this.toolStrip.TabIndex = 1;
      // 
      // newToolStripButton
      // 
      this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
      this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripButton.Name = "newToolStripButton";
      this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.newToolStripButton.Text = "&New";
      this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
      // 
      // openToolStripButton
      // 
      this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
      this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripButton.Name = "openToolStripButton";
      this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.openToolStripButton.Text = "&Open";
      this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // saveToolStripButton
      // 
      this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
      this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripButton.Name = "saveToolStripButton";
      this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.saveToolStripButton.Text = "&Save";
      this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
      // 
      // cutToolStripButton
      // 
      this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
      this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cutToolStripButton.Name = "cutToolStripButton";
      this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.cutToolStripButton.Text = "C&ut";
      this.cutToolStripButton.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
      // 
      // copyToolStripButton
      // 
      this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
      this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripButton.Name = "copyToolStripButton";
      this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.copyToolStripButton.Text = "&Copy";
      this.copyToolStripButton.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.cyotekLinkToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 539);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(784, 22);
      this.statusStrip.TabIndex = 3;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(670, 17);
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
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 561);
      this.Controls.Add(editSplitContainer);
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
      this.Text = "Cyotek Text Maker";
      addingGroupBox.ResumeLayout(false);
      addingGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bottomNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.topNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.rightNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.leftNumericUpDown)).EndInit();
      editSplitContainer.Panel1.ResumeLayout(false);
      editSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(editSplitContainer)).EndInit();
      editSplitContainer.ResumeLayout(false);
      this.textSplitContainer.Panel1.ResumeLayout(false);
      this.textSplitContainer.Panel1.PerformLayout();
      this.textSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.textSplitContainer)).EndInit();
      this.textSplitContainer.ResumeLayout(false);
      fontGroupBox.ResumeLayout(false);
      fontGroupBox.PerformLayout();
      colorGroupBox.ResumeLayout(false);
      colorGroupBox.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel cyotekLinkToolStripStatusLabel;
    private System.Windows.Forms.SplitContainer textSplitContainer;
    private System.Windows.Forms.TextBox previewTextBox;
    private Cyotek.Windows.Forms.ImageBox previewImageBox;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton newToolStripButton;
    private System.Windows.Forms.ToolStripButton openToolStripButton;
    private System.Windows.Forms.ToolStripButton saveToolStripButton;
    private System.Windows.Forms.ToolStripButton cutToolStripButton;
    private System.Windows.Forms.ToolStripButton copyToolStripButton;
    private System.Windows.Forms.NumericUpDown bottomNumericUpDown;
    private System.Windows.Forms.NumericUpDown topNumericUpDown;
    private System.Windows.Forms.NumericUpDown rightNumericUpDown;
    private System.Windows.Forms.NumericUpDown leftNumericUpDown;
    private Cyotek.Windows.Forms.ColorButton backgroundColorButton;
    private Cyotek.Windows.Forms.ColorButton textColorButton;
    private System.Windows.Forms.ComboBox fontComboBox;
  }
}

