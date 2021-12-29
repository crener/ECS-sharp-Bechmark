using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using ECS_Benchmark.Frameworks;
using ECS_Benchmark.Frameworks.DefaultEcs;
using ECS_Benchmark.Frameworks.LeoEcs;
using ECS_Benchmark.Frameworks.LeoEcsLite;

namespace ECS_Benchmark
{
    [MemoryDiagnoser()]
    public abstract class UpdateBase
    {
        [Params(100, 1000, 5000, 10000, 20000, 100000)]//, 1000000, 5000000, 10000000, 15000000, 20000000)]
        public int EntityQuantity { get; set; }

        protected World? m_defaultWorld = null;
        protected SequentialSystem<float>? sequential;

        protected Leopotam.Ecs.EcsWorld? m_leoWorld;
        protected Leopotam.Ecs.EcsSystems? m_leoSystem;

        protected Leopotam.EcsLite.EcsWorld? m_leoLiteWorld = null;
        protected Leopotam.EcsLite.EcsSystems? m_leoLiteSystem;

        [GlobalSetup]
        public abstract void Setup();

        [GlobalCleanup]
        public void Cleanup()
        {
            m_defaultWorld?.Dispose();
        }
        
        [Benchmark]
        public void DefaultEcs()
        {
            sequential?.Update(Constants.FakeDeltaTime);
        }

        [Benchmark]
        public void LeoEcs()
        {
            m_leoSystem?.Run();
        }

        [Benchmark]
        public void LeoEcsLite()
        {
            m_leoLiteSystem?.Run();
        }
    }
}
