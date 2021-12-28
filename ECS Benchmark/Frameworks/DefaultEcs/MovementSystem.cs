using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace ECS_Benchmark.Frameworks.DefaultEcs;

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