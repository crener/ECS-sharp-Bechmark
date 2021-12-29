
using Leopotam.EcsLite;

namespace ECS_Benchmark.Frameworks.LeoEcsLite;

public class MovementSystem : IEcsInitSystem, IEcsRunSystem
{

    private EcsPool<PositionComponent> posPool;
    private EcsPool<DirectionComponent> dirPool;
    private EcsFilter filter;

    public void Init(EcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        posPool = world.GetPool<PositionComponent>();
        dirPool = world.GetPool<DirectionComponent>();

        filter = world.
            Filter<PositionComponent>()
            .Inc<DirectionComponent>()
            .End(posPool.GetRawDenseItems().Length);
    }

    public void Run(EcsSystems systems)
    {
        foreach (int eid in filter)
        {
            ref PositionComponent pos = ref posPool.Get(eid);
            DirectionComponent dir = dirPool.Get(eid);

            pos.X += dir.X * Constants.FakeDeltaTime;
            pos.Y += dir.Y * Constants.FakeDeltaTime;
        }
    }
}