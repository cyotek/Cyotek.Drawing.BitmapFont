# Change Log

## 2.0.1

### Fixed

* Fixed an issue if a text based font was missing a named value

## 2.0.0

### Added

* Added deployment targets for .NET Framework 3.5, 4.0, 4.5.2,
  4.6.2, 4.6.2, 4.8, .NET Standard 1.3, .NET Standard 2.0, .NET
  Standard 2.1, .NET Core 2.1, .NET Core 2.2, and .NET Core 3.1
* Added support for BMFont version 3 binary fonts
* Added additional constructor to `Character` struct
* Added `X`, `Y`, `Width` and `Height` properties to the
  `Character` class
* Added `OffsetX` and `OffsetY` properties to the `Character`
  class
* Added `IsEmpty` and static `Empty` properties to the
  `Character` class
* Added `InvalidChar` to the `BitmapFont` class. If a BMFont
  explicitly defines the "invalid" character, this will be
  assigned to this property, otherwise it will use
  `Character.Empty`

### Changed

* Performance improvements when loading text fonts
* `BitmapFont[char]` will no longer throw if a character not
  present in the font is requested, instead the value of the
  `InvalidChar` property will be returned

### Deprecated

* The `Character.Bounds` property has been deprecated and will
  be removed in a future version. The `X`, `Y`, `Width` and
  `Height` properties should be used instead
* The `Character.Offset` property has been deprecated and will
  be removed in a future version. The `OffsetX` and `OffsetY`
  properties should be used instead

### Removed

* Due to switch to SDK projects, the .NET Framework 2.0 target
  the library was originally compiled under is no longer
  available

### Fixed

* API documentation is once again included in the NuGet package

## 1.3.4

### Added

* Added benchmark project
* Added tests
* Added SourceLink package support

### Fixed

* The `LineHeight` and `BaseHeight` property values were swapped
  when loading XML format fonts

## 1.3.3

### Fixed

* `BitmapFont.GetKerning` always returned zero

## 1.3.2

### Changed

* Replaced digital signature
* Corrected version information

## 1.3.1

### Removed

* Removed nuget.exe and related resources as this is now handled
  natively by Visual Studio 2015

### Fixed

* Fixed an issue where missing attributes in plain text font
  files could cause a crash. Thanks to rds1983 for the fix.

## 1.3.0

### Added

* Added documentation

### Removed

* Removed `BitmapFont.NormalizeLineBreaks` as this method should
  never have been added

## 1.2.0

### Added

* Added NuGet package
* Moved the load code from `BitmapFontLoader` into the
  `BitmapFont`, leaving the original methods as placeholders.
  This now means you can override `BitmapFont.Load` if you need
  to do any custom processing, something you couldn't do with
  the static method
* Added new `Load` methods that supports using a `Stream` or
  `TextReader` to avoid the need for a file
* Added new `LoadText` and `LoadXml` methods that support
  strings, again therefore no longer requiring a file
* Minor performance improvements

### Fixed

* For some inexplicable reason, the XML font loader was loading
  the XML document twice

> **Note:** Only the Load methods that take a file name will set
> the `FileName` property of the `Page` object to a fully
> qualified path. The other methods will leave them as relative
> paths and you will need to handle this yourself.

## 1.1.0

### Added

* Added strong name
* Added `CLSCompliant` attribute

## 1.0.0

* Initial release
