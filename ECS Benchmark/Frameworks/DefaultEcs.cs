using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace ECS_Benchmark.Frameworks
{
    public struct PositionComponent
    {
        public float X;
        public float Y;
    }

    public struct DirectionComponent
    {
        public float X;
        public float Y;
    }

    public struct ModificationComponent
    {
        public float floaty;
        public int inty;
        public bool booly;
        public string stringy;
    }

    public class MovementSystem : AEntitySetSystem<float>
    {
        public MovementSystem(World world, IParallelRunner runner) 
            : base(world, runner)
        {
        }


        protected override void Update(float deltaTime, in Entity entity)
        {
            ref PositionComponent pos = ref entity.Get<PositionComponent>();
            DirectionComponent dir = entity.Get<DirectionComponent>();

            pos.X += dir.X * deltaTime;
            pos.Y += dir.Y * deltaTime;
        }
    }

    public class ChangeSystem : AEntitySetSystem<float>
    {
        public ChangeSystem(World world, IParallelRunner runner) 
            : base(world, runner)
        {
        }

        protected override void Update(float state, in Entity entity)
        {
            ref ModificationComponent mod = ref entity.Get<ModificationComponent>();

            mod.booly = !mod.booly;
            mod.floaty *= 1.000001f;
            mod.inty++;
        }
    }

    public static class DefaultEcsBenchmark
    {
        public static World CreateEntities(int count)
        {
            World world = new World();

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
