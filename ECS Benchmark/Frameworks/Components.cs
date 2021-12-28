using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
