using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerUpdated
{
    public class BotPlayer : Player
    {
        private Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public BotPlayer(string _name) : base(_name, null)
        {
            InputMethod = () => GetRandomNumber();
        }

        /// <summary>
        /// Gets a random number from 0 - 100
        /// </summary>
        /// <returns></returns>
        private int GetRandomNumber()
        {
            return rnd.Next(0, 100);
        }
    }
}
