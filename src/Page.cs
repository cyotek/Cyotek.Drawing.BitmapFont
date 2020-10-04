using System.IO;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2012-2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Drawing.BitmapFont
{
  /// <summary>
  /// Represents a texture page.
  /// </summary>
  public struct Page
  {
    #region Private Fields

    private string _fileName;

    private int _id;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Creates a texture page using the specified ID and source file name.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="fileName">Filename of the texture image.</param>
    public Page(int id, string fileName)
      : this()
    {
      _fileName = fileName;
      _id = id;
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets the filename of the source texture image.
    /// </summary>
    /// <value>
    /// The name of the file containing the source texture image.
    /// </value>
    public string FileName
    {
      get { return _fileName; }
      set { _fileName = value; }
    }

    /// <summary>
    /// Gets or sets the page identifier.
    /// </summary>
    /// <value>
    /// The page identifier.
    /// </value>
    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Returns the fully qualified type name of this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> containing a fully qualified type name.
    /// </returns>
    /// <seealso cref="M:System.ValueType.ToString()"/>
    public override string ToString()
    {
      return string.Format("{0} ({1})", _id, Path.GetFileName(_fileName));
    }

    #endregion Public Methods
  }
}
