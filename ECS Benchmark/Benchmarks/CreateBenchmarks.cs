using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using ECS_Benchmark.Frameworks;
using ECS_Benchmark.Frameworks.DefaultEcs;
using ECS_Benchmark.Frameworks.LeoEcs;

namespace ECS_Benchmark
{
    [MemoryDiagnoser()]
    public class CreateBenchmarks
    {
        [Params(100, 1000, 5000, 10000, 20000, 100000, 1000000, 5000000, 10000000, 15000000, 20000000)]
        public int EntityQuantity { get; set; }

        private World? m_defaultWorld = null;

        [IterationCleanup]
        public void Cleanup()
        {
            m_defaultWorld?.Dispose();
        }
        
        [Benchmark]
        public void DefaultEcs()
        {
            m_defaultWorld = DefaultEcsBenchmark.CreateEntities(EntityQuantity);
        }

        [Benchmark]
        public void LeoEcs()
        {
            LeoECSBenchmarks.CreateEntities(EntityQuantity);
        }
    }
}
