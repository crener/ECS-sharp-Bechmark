using DefaultEcs;
using Leopotam.Ecs;

namespace ECS_Benchmark.Frameworks.LeoEcs;

public class ChangeSystem : IEcsRunSystem
{
    public World? World;
    public EcsFilter<ModificationComponent>? Filter;

    public void Run()
    {
        if (Filter != null)
        {
            foreach (int eid in Filter)
            {
                ref ModificationComponent mod = ref Filter.Get1(eid);

                mod.booly = !mod.booly;
                mod.floaty *= 1.000001f;
                mod.inty++;
            }
        }
    }
}