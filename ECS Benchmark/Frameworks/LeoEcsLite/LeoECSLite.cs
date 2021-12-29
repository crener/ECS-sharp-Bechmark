using Leopotam.EcsLite;

namespace ECS_Benchmark.Frameworks.LeoEcsLite
{
    public static class LeoECSLiteBenchmarks
    {
        public static EcsWorld CreateEntities(int count)
        {
            EcsWorld world = new EcsWorld();
            EcsPool<PositionComponent> posPool = world.GetPool<PositionComponent>();
            EcsPool<DirectionComponent> dirPool = world.GetPool<DirectionComponent>();
            EcsPool<ModificationComponent> modPool = world.GetPool<ModificationComponent>();

            for (int i = 0; i < count; i++)
            {
                int entity = world.NewEntity();

                ref PositionComponent pos = ref posPool.Add(entity);
                pos.X = i;
                pos.Y = i;

                ref DirectionComponent dir = ref dirPool.Add(entity);
                dir.X = 0.5f;
                dir.Y = 0.5f;

                ref ModificationComponent mod = ref modPool.Add(entity);
                mod.floaty = 1f;
            }

            return world;
        }
    }
}
