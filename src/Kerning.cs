using System;

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
  /// Represents the font kerning between two characters.
  /// </summary>
  public struct Kerning : IEquatable<Kerning>
  {
    #region Private Fields

    private readonly int _amount;

    private readonly char _firstCharacter;

    private readonly char _secondCharacter;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="firstCharacter">The first character.</param>
    /// <param name="secondCharacter">The second character.</param>
    /// <param name="amount">How much the x position should be adjusted when drawing the second
    /// character immediately following the first.</param>
    public Kerning(char firstCharacter, char secondCharacter, int amount)
      : this()
    {
      _firstCharacter = firstCharacter;
      _secondCharacter = secondCharacter;
      _amount = amount;
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets how much the x position should be adjusted when drawing the second character immediately following the first.
    /// </summary>
    /// <value>
    /// How much the x position should be adjusted when drawing the second character immediately following the first.
    /// </value>
    public int Amount
    {
      get { return _amount; }
    }

    /// <summary>
    /// Gets or sets the first character.
    /// </summary>
    /// <value>
    /// The first character.
    /// </value>
    public char FirstCharacter
    {
      get { return _firstCharacter; }
    }

    /// <summary>
    /// Gets or sets the second character.
    /// </summary>
    /// <value>
    /// The second character.
    /// </value>
    public char SecondCharacter
    {
      get { return _secondCharacter; }
    }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Check if the object represents kerning between the same two characters.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>
    /// Whether or not the object represents kerning between the same two characters.
    /// </returns>
    public override bool Equals(object obj)
    {
      if (obj == null) return false;
      if (obj.GetType() != typeof(Kerning)) return false;

      return this.Equals((Kerning)obj);
    }

    /// <summary>
    /// Check if the other kerning is between the same two characters.
    /// </summary>
    /// <param name="other"></param>
    /// <returns>
    /// Whether or not the other kerning is between the same two characters.
    /// </returns>
    public bool Equals(Kerning other)
    {
      return _firstCharacter == other._firstCharacter && _secondCharacter == other._secondCharacter;
    }

    /// <summary>
    /// Return the hash code of the kerning between the two characters.
    /// </summary>
    /// <returns>
    /// A unique hash code of the kerning between the two characters.
    /// </returns>
    public override int GetHashCode()
    {
      unchecked
      {
        return (_firstCharacter << 16) | _secondCharacter;
      }
    }

    /// <summary>
    /// Returns the fully qualified type name of this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> containing a fully qualified type name.
    /// </returns>
    /// <seealso cref="M:System.ValueType.ToString()"/>
    public override string ToString()
    {
      return string.Format("{0} to {1} = {2}", _firstCharacter, _secondCharacter, _amount);
    }

    #endregion Public Methods
  }
}
