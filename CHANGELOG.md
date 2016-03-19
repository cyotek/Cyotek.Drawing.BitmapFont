Change Log
==========

1.3.1
-----

### Removed
* Removed nuget.exe and related resources as this is now handled natively by Visual Studio 2015

### Fixed
* Fixed an issue where missing attributes in plain text font files could cause a crash. Thanks to rds1983 for the fix.

1.3.0
-----

### Added
* Added documentation

### Removed
* Removed `BitmapFont.NormalizeLineBreaks` as this method should never have been added

1.2.0
-----

### Added
* Added NuGet package
* Moved the load code from `BitmapFontLoader` into the `BitmapFont`, leaving the original methods as placeholders. This now means you can override `BitmapFont.Load` if you need to do any custom processing, something you couldn't do with the static method
* Added new `Load` methods that supports using a `Stream` or `TextReader` to avoid the need for a file
* Added new `LoadText` and `LoadXml` methods that support strings, again therefore no longer requiring a file
* Minor performance improvements

### Fixed
* For some inexplicable reason, the XML font loader was loading the XML document twice

> **Note:** Only the Load methods that take a file name will set the `FileName` property of the `Page` object to a fully qualified path. The other methods will leave them as relative paths and you will need to handle this yourself.

1.1.0
-----

### Added
* Added strong name
* Added `CLSCompliant` attribute

1.0.0
-----

* Initial release
