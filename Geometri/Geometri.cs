using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public abstract class Geometri
    {
        public abstract float GetArea();
        public abstract float GetPerimeter();

        public abstract string GetInformation();

        public string GetClassName()
        {
            return this.GetType().ToString();
        }

       
        public float AngleToRadian(int angle)
        {
            return angle * 0.0174533f;
        }

        public int RadiansToAngle(float radians)
        {
            return (int)(radians * 57.2958f);
        }
    }
}
