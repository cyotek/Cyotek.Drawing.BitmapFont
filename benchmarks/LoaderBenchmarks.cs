using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Jobs;
using Cyotek.Drawing.BitmapFont;

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
    #region Constants

    private readonly string _textFileName;

    private readonly string _xmlFileName;

    #endregion

    #region Constructors

    public LoaderBenchmarks()
    {
      string path;

      path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");

      _textFileName = Path.Combine(path, "arial-32bi.fnt");
      _xmlFileName = Path.Combine(path, "arial-32bi.xml.fnt");
    }

    #endregion

    #region Methods

    [Benchmark]
    public BitmapFont LoadAuto()
    {
      return BitmapFontLoader.LoadFontFromFile(_xmlFileName);
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

    #endregion
  }
}
