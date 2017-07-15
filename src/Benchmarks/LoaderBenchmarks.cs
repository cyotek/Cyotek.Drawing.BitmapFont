using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using Cyotek.Drawing.BitmapFont;

namespace Benchmarks
{
  [MemoryDiagnoser]
  //[InliningDiagnoser]
  //[HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]
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
