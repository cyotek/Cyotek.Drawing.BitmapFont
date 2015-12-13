/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2015 Cyotek Ltd.
 *
 * Licensed under the MIT License. See license.txt for the full text.
 */

using System;
using System.ComponentModel;

namespace BitmapFontViewer
{
  // Based on http://www.csharp-examples.net/readonly-propertygrid/

  internal class PropertyGrid : System.Windows.Forms.PropertyGrid
  {
    #region Fields

    private bool _readOnly;

    #endregion

    #region Properties

    [Category("Behavior"), DefaultValue(false)]
    public bool ReadOnly
    {
      get { return _readOnly; }
      set
      {
        _readOnly = value;

        if (this.SelectedObject != null)
        {
          this.SetObjectAsReadOnly(this.SelectedObject, _readOnly);
        }
      }
    }

    #endregion

    #region Methods

    protected override void OnSelectedObjectsChanged(EventArgs e)
    {
      if (this.SelectedObject != null)
      {
        this.SetObjectAsReadOnly(this.SelectedObject, this.ReadOnly);
      }

      base.OnSelectedObjectsChanged(e);
    }

    protected void SetObjectAsReadOnly(object selectedObject, bool readOnly)
    {
      TypeDescriptor.AddAttributes(selectedObject, new Attribute[]
                                                   {
                                                     new ReadOnlyAttribute(readOnly)
                                                   });
    }

    #endregion
  }
}
