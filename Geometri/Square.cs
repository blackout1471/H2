using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Square : Geometri
    {
        public float SideA
        {
            get { return sideA; }
            private set { sideA = value; }
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

        private float sideA;
        private float sideB;

        public Square(float sideA, float sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public override float GetPerimeter()
        {
            return (SideA * 2) + (SideB * 2);
        }

        public override float GetArea()
        {
            return SideA * 2;
        }

        /// <summary>
        /// Get the Geometri variables in string format
        /// </summary>
        /// <returns></returns>
        public override string GetInformation()
        {
            return String.Format("Side A: {0}\nSideB {1}", SideA, SideB);
        }


    }
}
