using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Triangle : Geometri
    {
        public float SideA
        {
            get
            {
                return sideA;
            }

           private  set
            {
                sideA = value;
            }
        }

        public float SideB
        {
            get
            {
                return sideB;
            }

            private set
            {
                sideB = value;
            }
        }

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

        private float sideA;
        private float sideB;
        private float sideC;

        public Triangle(float a, float b, float c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        public override float GetArea()
        {
            return (SideA * SideB) * 0.5f;
        }

        public override float GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override string GetInformation()
        {
            return string.Format("Side A {0}\nSide B {1}\nSide C {2}", sideA, SideB, SideC);
        }
    }
}
