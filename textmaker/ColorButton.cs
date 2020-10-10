using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Windows.Forms
{
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  [Designer("System.Windows.Forms.Design.ButtonBaseDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  public class ColorButton : Button
  {
    #region Constants

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventDialogTitleChanged = new object();

    private static readonly object _eventDisplayTextChanged = new object();

    private static readonly object _eventIgnoreAlphaChannelChanged = new object();

    private static readonly object _eventSelectingColor = new object();

    private static readonly object _eventShowTextChanged = new object();

    #endregion

    #region Fields

    private Color _color;

    private string _dialogTitle;

    private string _displayText;

    private bool _ignoreAlphaChannel;

    private bool _showText;

    //private Bitmap _transparentBitmap;

    //private Brush _transparentBitmapBrush;

    #endregion

    #region Constructors

    public ColorButton()
    {
      _color = Color.White;
      _showText = true;
    }

    #endregion

    #region Events

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add { this.Events.AddHandler(_eventColorChanged, value); }
      remove { this.Events.RemoveHandler(_eventColorChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler DialogTitleChanged
    {
      add { this.Events.AddHandler(_eventDialogTitleChanged, value); }
      remove { this.Events.RemoveHandler(_eventDialogTitleChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler DisplayTextChanged
    {
      add { this.Events.AddHandler(_eventDisplayTextChanged, value); }
      remove { this.Events.RemoveHandler(_eventDisplayTextChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler IgnoreAlphaChannelChanged
    {
      add { this.Events.AddHandler(_eventIgnoreAlphaChannelChanged, value); }
      remove { this.Events.RemoveHandler(_eventIgnoreAlphaChannelChanged, value); }
    }

    [Category("Action")]
    public event CancelEventHandler SelectingColor
    {
      add { this.Events.AddHandler(_eventSelectingColor, value); }
      remove { this.Events.RemoveHandler(_eventSelectingColor, value); }
    }

    [Category("Property Changed")]
    public event EventHandler ShowTextChanged
    {
      add { this.Events.AddHandler(_eventShowTextChanged, value); }
      remove { this.Events.RemoveHandler(_eventShowTextChanged, value); }
    }

    #endregion

    #region Properties

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "White")]
    public Color Color
    {
      get { return _color; }
      set
      {
        if (_ignoreAlphaChannel && value.A != 255)
        {
          value = Color.FromArgb(255, value);
        }

        if (!_color.Equals(value))
        {
          _color = value;
          this.OnColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(null)]
    public virtual string DialogTitle
    {
      get { return _dialogTitle; }
      set
      {
        if (_dialogTitle != value)
        {
          _dialogTitle = value;

          this.OnDialogTitleChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(null)]
    public virtual string DisplayText
    {
      get { return _displayText; }
      set
      {
        if (_displayText != value)
        {
          _displayText = value;

          this.OnDisplayTextChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    public virtual bool IgnoreAlphaChannel
    {
      get { return _ignoreAlphaChannel; }
      set
      {
        if (_ignoreAlphaChannel != value)
        {
          _ignoreAlphaChannel = value;

          this.OnIgnoreAlphaChannelChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public virtual bool ShowText
    {
      get { return _showText; }
      set
      {
        if (_showText != value)
        {
          _showText = value;

          this.OnShowTextChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
      get { return string.Empty; }
      set { base.Text = value; }
    }

    #endregion

    #region Methods

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        //_transparentBitmapBrush?.Dispose();
        //_transparentBitmap?.Dispose();
      }

      base.Dispose(disposing);
    }

    protected override void OnClick(EventArgs e)
    {
      CancelEventArgs args;

      base.OnClick(e);

      args = new CancelEventArgs();

      this.OnSelectingColor(args);

      if (!args.Cancel)
      {
        using (ColorPickerDialog dialog = new ColorPickerDialog())
        {
          if (!string.IsNullOrEmpty(_dialogTitle))
          {
            dialog.Text = _dialogTitle;
          }

          dialog.Font = this.Font;
          dialog.Color = _color;
          dialog.ShowAlphaChannel = !_ignoreAlphaChannel;

          if (dialog.ShowDialog(this) == DialogResult.OK)
          {
            this.Color = dialog.Color;
          }
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="DialogTitleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnDialogTitleChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventDialogTitleChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="DisplayTextChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnDisplayTextChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventDisplayTextChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="IgnoreAlphaChannelChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnIgnoreAlphaChannelChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventIgnoreAlphaChannelChanged];

      handler?.Invoke(this, e);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
      int margin;
      Rectangle colorBounds;
      Rectangle textBounds;
      string text;
      Color foreColor;
      Size clientSize;
      Graphics g;

      base.OnPaint(pevent);

      g = pevent.Graphics;
      margin = 6;
      clientSize = this.ClientSize;

      if (_showText)
      {
        colorBounds = new Rectangle(margin, margin, clientSize.Height - margin * 2, clientSize.Height - margin * 2);
      }
      else
      {
        colorBounds = new Rectangle(margin, margin, clientSize.Width - margin * 2, clientSize.Height - margin * 2);
      }

      textBounds = new Rectangle(colorBounds.Right + margin, margin, clientSize.Width - (colorBounds.Right + margin * 2), colorBounds.Height);

      if (_showText)
      {
        if (string.IsNullOrEmpty(_displayText))
        {
          text = _color.IsEmpty ? "None" : _color.IsNamedColor ? _color.Name/*.ParseByCapitalLetters()*/ : _color.Name.ToUpper();
        }
        else
        {
          text = string.Format(_displayText, _color.A, _color.R, _color.G, _color.B);
        }
      }
      else
      {
        text = string.Empty;
      }

      if (_color.A != 255)
      {
        this.PaintTransparentBox(g, colorBounds);
      }

      using (Brush brush = new SolidBrush(_color))
      {
        g.FillRectangle(brush, colorBounds);
      }

      foreColor = this.Enabled ? this.ForeColor : SystemColors.GrayText;

      using (Pen pen = new Pen(foreColor))
      {
        g.DrawRectangle(pen, colorBounds);
      }

      if (_showText)
      {
        //using (GdiContext textRenderer = new GdiContext(g))
        //{
        //  textRenderer.DrawString(text, this.Font, textBounds, foreColor, DrawTextFlags.EndEllipsis | DrawTextFlags.VerticalCenter | DrawTextFlags.SingleLine | DrawTextFlags.NoPrefix);
        //}
        TextRenderer.DrawText(g, text, this.Font, textBounds, foreColor, TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
      }
    }

    /// <summary>
    /// Raises the <see cref="SelectingColor" /> event.
    /// </summary>
    /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
    protected virtual void OnSelectingColor(CancelEventArgs e)
    {
      CancelEventHandler handler;

      handler = (CancelEventHandler)this.Events[_eventSelectingColor];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowTextChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowTextChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventShowTextChanged];

      handler?.Invoke(this, e);
    }

    private void PaintTransparentBox(Graphics g, Rectangle bounds)
    {
      //if (_transparentBitmapBrush == null)
      {
        //_transparentBitmap = RenderSupport.CreateCheckerBoxBitmap(4);
        //_transparentBitmapBrush = new TextureBrush(_transparentBitmap, WrapMode.Tile);
      }

      //g.FillRectangle(_transparentBitmapBrush, bounds);
    }

    #endregion
  }
}
