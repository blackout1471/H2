using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Trapez : Square
    {
        public float SideC
        {
            get
            {
                return sideC;
            }

            private set
            {
                sideC = value;
            }
        }
        public float SideD
        {
            get
            {
                return sideD;
            }

            private set
            {
                sideD = value;
            }
        }

        private float sideC;
        private float sideD;

        public Trapez(float sideA, float sideB, float sideC, float sideD) : base(sideA, sideB)
        {
            SideC = sideC;
            SideD = sideD;
        }

        public float GetHeight()
        {
            float s = (SideA + SideB - SideC + SideD) / 2;
            return (2 / (SideA - SideC)) * (float)Math.Sqrt(s * (s - SideA + SideC) * (s - SideB) * (s - SideD));
        }

        public override float GetPerimeter()
        {
            return SideA + SideB + SideC + SideD;
        }

        public override float GetArea()
        {
            return 0.5f * (SideA + SideC) * GetHeight();
        }

        public override string GetInformation()
        {
            string s = base.GetInformation();

            return s + string.Format("\nSide C {0}\nSide D {1}", SideC, SideD);
        }


    }
}
