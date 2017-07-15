/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2017 Cyotek Ltd.
 *
 * Licensed under the MIT License. See LICENSE.txt for the full text.
 */

 using BenchmarkDotNet.Running;

namespace Benchmarks
{
  class Program
  {
    #region Static Methods

    static void Main(string[] args)
    {
      BenchmarkRunner.Run<LoaderBenchmarks>();
    }

    #endregion
  }
}
