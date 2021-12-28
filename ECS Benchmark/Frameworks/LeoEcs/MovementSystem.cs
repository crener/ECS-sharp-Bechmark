using Leopotam.Ecs;

namespace ECS_Benchmark.Frameworks.LeoEcs;

public struct MovementSystem : IEcsRunSystem
{
    public EcsWorld? World;
    public EcsFilter<PositionComponent, DirectionComponent>? Filter;

    public void Run()
    {
        if (Filter != null)
        {
            foreach (int eid in Filter)
            {
                ref PositionComponent pos = ref Filter.Get1(eid);
                DirectionComponent dir = Filter.Get2(eid);

                pos.X += dir.X * Constants.FakeDeltaTime;
                pos.Y += dir.Y * Constants.FakeDeltaTime;
            }
        }
    }
}