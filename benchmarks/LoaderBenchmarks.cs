using BenchmarkDotNet.Attributes;
using Cyotek.Drawing.BitmapFont;
using System;
using System.IO;

// AngelCode bitmap font parsing using C#
// https://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp

// Copyright © 2017-2020 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.paypal.me/cyotek

namespace Benchmarks
{
  [MemoryDiagnoser]
  public class LoaderBenchmarks
  {
    #region Private Fields

    private readonly string _binaryFileName;

    private readonly string _textFileName;

    private readonly string _xmlFileName;

    #endregion Private Fields

    #region Public Constructors

    public LoaderBenchmarks()
    {
      string path;

      path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");

      _textFileName = Path.Combine(path, "text.fnt");
      _xmlFileName = Path.Combine(path, "xml.fnt");
      _binaryFileName = Path.Combine(path, "binary.fnt");
    }

    #endregion Public Constructors

    #region Public Methods

    [Benchmark]
    public BitmapFont LoadAutoBinary()
    {
      return BitmapFontLoader.LoadFontFromFile(_binaryFileName);
    }

    [Benchmark]
    public BitmapFont LoadAutoText()
    {
      return BitmapFontLoader.LoadFontFromFile(_textFileName);
    }

    [Benchmark]
    public BitmapFont LoadAutoXml()
    {
      return BitmapFontLoader.LoadFontFromFile(_xmlFileName);
    }

    [Benchmark]
    public BitmapFont LoadBinary()
    {
      return BitmapFontLoader.LoadFontFromTextFile(_binaryFileName);
    }

    [Benchmark]
    public BitmapFont LoadText()
    {
      return BitmapFontLoader.LoadFontFromTextFile(_textFileName);
    }

    [Benchmark]
    public BitmapFont LoadXml()
    {
      return BitmapFontLoader.LoadFontFromXmlFile(_xmlFileName);
    }

    #endregion Public Methods
  }
}
