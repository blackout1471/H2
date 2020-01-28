using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Parralelogram : Square
    {
        public int Angle
        {
            get
            {
                return angle;
            }

            private set
            {
                angle = value;
            }
        }
        private int angle;

        public Parralelogram(int sideA, int sideB, int angle) : base(sideA, sideB)
        {
            Angle = angle;
        }

        public override float GetArea()
        {
            // Remember to convert from degrees to radians.
            return (SideA * SideB) * (float)Math.Sin(AngleToRadian(Angle));
        }

        public override string GetInformation()
        {
            string s = base.GetInformation();

            return s + string.Format("\nAngle: {0}", Angle);
        }
    }
}
