using DefaultEcs;

namespace ECS_Benchmark.Frameworks.DefaultEcs
{
    public static class DefaultEcsBenchmark
    {
        public static World CreateEntities(int count)
        {
            World world = new World(count + 1);

            for (int i = 0; i < count; i++)
            {
                Entity entity = world.CreateEntity();
                entity.Set(new PositionComponent{X = i, Y = i});
                entity.Set(new DirectionComponent{X = 0.5f, Y = 0.5f});
                entity.Set(new ModificationComponent(){floaty = 1f});
            }

            return world;
        }
    }
}
