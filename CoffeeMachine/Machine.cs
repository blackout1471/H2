using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    /// <summary>
    /// An electronic machine which can get turned on or off
    /// </summary>
    public abstract class Machine
    {
        public bool TurnedOn
        {
            get
            {
                return turnedOn;
            }

            private set
            {
                turnedOn = value;
            }
        }
        private bool turnedOn;

        public Machine() { }

        public void TurnOn() 
        {
            TurnedOn = true;
        }

        public void TurnOff()
        {
            TurnedOn = false;
        }
    }
}
