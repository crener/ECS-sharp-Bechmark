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
    public class UpdateMultiComponentSingleThreadBenchmarks : UpdateBase
    {
        public override void Setup()
        {
            m_defaultWorld = DefaultEcsBenchmark.CreateEntities(EntityQuantity);
            DefaultParallelRunner runner = new DefaultParallelRunner(1);
            sequential = new SequentialSystem<float>(
                new Frameworks.DefaultEcs.MovementSystem(m_defaultWorld, runner));

            m_leoWorld = LeoECSBenchmarks.CreateEntities(EntityQuantity);
            m_leoSystem = new Leopotam.Ecs.EcsSystems(m_leoWorld)
                .Add(new Frameworks.LeoEcs.MovementSystem());
            m_leoSystem.Init();

            m_leoLiteWorld = LeoECSLiteBenchmarks.CreateEntities(EntityQuantity);
            m_leoLiteSystem = new Leopotam.EcsLite.EcsSystems(m_leoLiteWorld)
                .Add(new Frameworks.LeoEcsLite.MovementSystem());
            m_leoLiteSystem.Init();
        }
    }
}
