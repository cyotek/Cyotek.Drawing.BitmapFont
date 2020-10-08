using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.Windows.Forms
{
  [DefaultEvent(nameof(SelectedFileChanged))]
  internal partial class FilePane : UserControl
  {
    #region Private Fields

    private static readonly object _eventMultiSelectChanged = new object();

    private static readonly object _eventPathChanged = new object();

    private static readonly object _eventSearchPatternChanged = new object();

    private static readonly object _eventSelectedFileChanged = new object();

    private bool _multiSelect;

    private string _path;

    private string _searchPattern;

    private FileInfo _selectedFile;

    private bool _skipSelectionEvents;

    #endregion Private Fields

    #region Public Constructors

    public FilePane()
    {
      this.InitializeComponent();

      _searchPattern = "*";
    }

    #endregion Public Constructors

    #region Public Events

    /// <summary>
    /// Occurs when the MultiSelect property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler MultiSelectChanged
    {
      add
      {
        this.Events.AddHandler(_eventMultiSelectChanged, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventMultiSelectChanged, value);
      }
    }

    /// <summary>
    /// Occurs when the Path property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler PathChanged
    {
      add
      {
        this.Events.AddHandler(_eventPathChanged, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventPathChanged, value);
      }
    }

    /// <summary>
    /// Occurs when the SearchPattern property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SearchPatternChanged
    {
      add
      {
        this.Events.AddHandler(_eventSearchPatternChanged, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventSearchPatternChanged, value);
      }
    }

    /// <summary>
    /// Occurs when the SelectedFile property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SelectedFileChanged
    {
      add
      {
        this.Events.AddHandler(_eventSelectedFileChanged, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventSelectedFileChanged, value);
      }
    }

    #endregion Public Events

    #region Public Properties

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool MultiSelect
    {
      get { return _multiSelect; }
      set
      {
        if (_multiSelect != value)
        {
          _multiSelect = value;

          this.OnMultiSelectChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Path
    {
      get { return _path; }
      set
      {
        if (_path != value)
        {
          _path = value;

          this.OnPathChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue("*")]
    public string SearchPattern
    {
      get { return _searchPattern; }
      set
      {
        if (_searchPattern != value)
        {
          _searchPattern = value;

          this.OnSearchPatternChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public FileInfo SelectedFile
    {
      get { return _selectedFile; }
      set
      {
        if (_selectedFile != value)
        {
          _selectedFile = value;

          this.OnSelectedFileChanged(EventArgs.Empty);
        }
      }
    }

    #endregion Public Properties

    #region Public Methods

    public void EnsureSelection()
    {
      if (filesListListBox.Items.Count > 0)
      {
        filesListListBox.SelectedIndex = 0;
      }
    }

    public void SelectFile(string fileName)
    {
      _skipSelectionEvents = true;

      if (_multiSelect)
      {
        filesListListBox.SelectedItems.Clear();
      }

      if (!string.IsNullOrEmpty(fileName))
      {
        for (int i = 0; i < filesListListBox.Items.Count; i++)
        {
          if (filesListListBox.Items[i] is FileInfo info && string.Equals(info.FullPath, fileName, StringComparison.OrdinalIgnoreCase))
          {
            filesListListBox.SelectedIndex = i;
            break;
          }
        }
      }

      _skipSelectionEvents = false;
    }

    #endregion Public Methods

    #region Protected Methods

    /// <summary>
    /// Raises the <see cref="MultiSelectChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnMultiSelectChanged(EventArgs e)
    {
      EventHandler handler;

      filesListListBox.SelectionMode = _multiSelect ? SelectionMode.MultiExtended : SelectionMode.One;

      handler = (EventHandler)this.Events[_eventMultiSelectChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="PathChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnPathChanged(EventArgs e)
    {
      EventHandler handler;

      this.LoadFiles();
      pathTextBox.Text = _path;

      handler = (EventHandler)this.Events[_eventPathChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="SearchPatternChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSearchPatternChanged(EventArgs e)
    {
      EventHandler handler;

      this.LoadFiles();

      handler = (EventHandler)this.Events[_eventSearchPatternChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="SelectedFileChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSelectedFileChanged(EventArgs e)
    {
      EventHandler handler;

      this.SelectFile(_selectedFile?.FullPath);

      handler = (EventHandler)this.Events[_eventSelectedFileChanged];

      handler?.Invoke(this, e);
    }

    #endregion Protected Methods

    #region Private Methods

    private void FilesListListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!_skipSelectionEvents)
      {
        this.SelectedFile = filesListListBox.SelectedItem as FileInfo;
      }
    }

    private void LoadFiles()
    {
      filesListListBox.BeginUpdate();
      filesListListBox.Items.Clear();

      try
      {
        if (!string.IsNullOrEmpty(_path) && Directory.Exists(_path))
        {
          foreach (string fileName in Directory.EnumerateFiles(_path, _searchPattern))
          {
            filesListListBox.Items.Add(new FileInfo(fileName));
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to obtain folder listing. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      filesListListBox.EndUpdate();
    }

    private void PathBrowseButton_Click(object sender, EventArgs e)
    {
      string path;

      path = FileDialogHelper.GetFolderName("Select &path to browse:", _path);

      if (!string.IsNullOrEmpty(path))
      {
        this.Path = path;
      }
    }

    private void PathChangeTimer_Tick(object sender, EventArgs e)
    {
      pathChangeTimer.Stop();

      this.Path = pathTextBox.Text;
    }

    private void PathTextBox_TextChanged(object sender, EventArgs e)
    {
      pathChangeTimer.Stop();
      pathChangeTimer.Start();
    }

    #endregion Private Methods
  }
}