Change Log
==========

1.0.2.0
-------
* NEW: Added NuGet package
* NEW: Moved the load code from `BitmapFontLoader` into the `BitmapFont`, leaving the original methods as placeholders. This now means you can override `BitmapFont.Load` if you need to do any custom processing, something you couldn't do with the static method
* NEW: Added new `Load` methods that supports using a `Stream` or `TextReader` to avoid the need for a file
* NEW: Added new `LoadText` and `LoadXml` methods that support strings, again therefore no longer requiring a file
* NEW: Minor performance improvements
* FIX: For some inexplicable reason, the XML font loader was loading the XML document twice

> **Note:** Only the Load methods that take a file name will set the `FileName` property of the `Page` object to a fully qualified path. The other methods will leave them as relative paths and you will need to handle this yourself.

1.0.1.0
-------
* NEW: Added strong name
* NEW: Added `CLSCompliant` attribute

1.0.0.0
-------
* Initial release
