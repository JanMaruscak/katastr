using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katastr
{
    abstract class UserInput
    {
        public abstract int maxPoints { get; }
        public void ChangeRatio(string measurement)
        {
            if(measurement == "km")
            {
            }
        }
        public int Ratio = 1000;
    }
    class DrawPolygon : UserInput
    {
        public override int maxPoints { get { return -1; } }
        public DrawPolygon()
        {
        }

    }
    class DrawLine : UserInput
    {
        public override int maxPoints { get { return 2; } }
        public DrawLine()
        {

        }

    }
}
