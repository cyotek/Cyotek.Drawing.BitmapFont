using Cyotek.Windows.Forms;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Windows.Forms;

// Decoding DOOM Picture Files
// https://www.cyotek.com/blog/decoding-doom-picture-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo
{
  internal static class ClipboardHelper
  {
    #region Public Methods

    public static bool CopyImage(Image image)
    {
      bool result;

      // http://csharphelper.com/blog/2014/09/copy-an-irregular-area-from-one-picture-to-another-in-c/

      try
      {
        IDataObject data;
        Bitmap opaqueBitmap;
        Bitmap transparentBitmap;
        MemoryStream transparentBitmapStream;

        data = new DataObject();
        opaqueBitmap = null;
        transparentBitmap = null;
        transparentBitmapStream = null;

        try
        {
          opaqueBitmap = image.Copy(Color.White);
          transparentBitmap = image.Copy(Color.Transparent);

          transparentBitmapStream = new MemoryStream();
          transparentBitmap.Save(transparentBitmapStream, ImageFormat.Png);

          data.SetData(DataFormats.Bitmap, opaqueBitmap);
          data.SetData("PNG", false, transparentBitmapStream);

          Clipboard.Clear();
          Clipboard.SetDataObject(data, true);
        }
        finally
        {
          opaqueBitmap?.Dispose();
          transparentBitmapStream?.Dispose();
          transparentBitmap?.Dispose();
        }

        result = true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to copy image. {0}", ex.GetBaseException().Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        result = false;
      }

      return result;
    }

    public static void TryCopy(Control container)
    {
      if (ClipboardHelper.GetActiveControl(container) is ImageBox imageBox && imageBox.Image != null)
      {
        ClipboardHelper.CopyImage(imageBox.Image);
      }
      else
      {
        ClipboardHelper.PerformClipboardAction(container, tb => tb.Copy());
      }
    }

    public static void TryCut(Control container)
    {
      ClipboardHelper.PerformClipboardAction(container, tb => tb.Cut());
    }

    public static void TryPaste(Control container)
    {
      ClipboardHelper.PerformClipboardAction(container, tb => tb.Paste());
    }

    #endregion Public Methods

    #region Private Methods

    private static Bitmap Copy(this Image image, Color transparentColor)
    {
      Bitmap copy;

      copy = new Bitmap(image.Size.Width, image.Size.Height, PixelFormat.Format32bppArgb);

      using (Graphics g = Graphics.FromImage(copy))
      {
        g.Clear(transparentColor);
        g.PageUnit = GraphicsUnit.Pixel;
        g.DrawImage(image, new Rectangle(Point.Empty, image.Size));
      }

      return copy;
    }

    private static Control GetActiveControl(Control control)
    {
      Control activeControl;
      ContainerControl containerControl;
      TabControl tabControl;

      containerControl = control as ContainerControl;
      tabControl = control as TabControl;

      if (containerControl != null)
      {
        activeControl = ClipboardHelper.GetActiveControl(containerControl.ActiveControl);
      }
      else if (tabControl?.SelectedTab?.Controls.Count == 1)
      {
        activeControl = tabControl.SelectedTab.Controls[0];
      }
      else
      {
        activeControl = control;
      }

      return activeControl;
    }

    private static void PerformClipboardAction(Control container, Action<TextBoxBase> action)
    {
      Control control;

      control = ClipboardHelper.GetActiveControl(container);

      if (control is TextBoxBase textBox)
      {
        action(textBox);
      }
      else
      {
        SystemSounds.Beep.Play();
      }
    }

    #endregion Private Methods
  }
}
