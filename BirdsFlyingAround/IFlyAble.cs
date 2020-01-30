using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    public interface IFlyAble
    {
        /// <summary>
        /// The method to fly
        /// </summary>
        /// <param name="direction"></param>
        void Fly(Vector3 direction);
    }
}
