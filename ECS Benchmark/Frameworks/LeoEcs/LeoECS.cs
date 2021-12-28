using DefaultEcs.System;
using DefaultEcs.Threading;
using Leopotam.Ecs;

namespace ECS_Benchmark.Frameworks.LeoEcs
{
    public static class LeoECSBenchmarks
    {
        public static EcsWorld CreateEntities(int count)
        {
            EcsWorld world = new EcsWorld();

            for (int i = 0; i < count; i++)
            {
                EcsEntity entity = world.NewEntity();
                entity.Replace(new PositionComponent { X = i, Y = i });
                entity.Replace(new DirectionComponent { X = 0.5f, Y = 0.5f });
                entity.Replace(new ModificationComponent { floaty = 1f });
            }

            return world;
        }
    }
}
