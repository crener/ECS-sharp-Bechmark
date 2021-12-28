using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace ECS_Benchmark.Frameworks.DefaultEcs;

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