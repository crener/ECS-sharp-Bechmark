
using Leopotam.EcsLite;

namespace ECS_Benchmark.Frameworks.LeoEcsLite;

public class ChangeSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter filter;
    private EcsPool<ModificationComponent> modPool;
    
    public void Init(EcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        modPool = world.GetPool<ModificationComponent>();
        filter = world.Filter<ModificationComponent>().End(modPool.GetRawDenseItems().Length);
    }

    public void Run(EcsSystems systems)
    {
        foreach (int eid in filter)
        {
            ref ModificationComponent mod = ref modPool.Get(eid);

            mod.booly = !mod.booly;
            mod.floaty *= 1.000001f;
            mod.inty++;
        }
    }
}