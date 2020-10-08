using System.IO;

// Loading the color palette from a BBM/LBM image file using C
// https://www.cyotek.com/blog/loading-the-color-palette-from-a-bbm-lbm-image-file-using-csharp

// Copyright © 2014 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo
{
  internal class FileInfo
  {
    #region Private Fields

    private readonly string _fullPath;

    #endregion Private Fields

    #region Public Constructors

    public FileInfo(string fullPath)
    {
      _fullPath = fullPath;
    }

    #endregion Public Constructors

    #region Public Properties

    public string FullPath
    {
      get { return _fullPath; }
    }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A string that represents the current object.
    /// </returns>
    public override string ToString()
    {
      return Path.GetFileName(_fullPath);
    }

    #endregion Public Methods
  }
}