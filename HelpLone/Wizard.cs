using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLone
{
    public class Wizard : Character, IMagic, IHeal, ITeleport
    {
        public void Heal()
        {
            Console.WriteLine("Healing");
        }

        public void Teleport(int x, int y)
        {
            Console.WriteLine($"Teleporting to {x} {y}");
        }

        public void ThrowFrostNova()
        {
            Console.WriteLine("Throwing frost nova");
        }

        public void ThrowMagicMissile()
        {
            Console.WriteLine("Throwing Magic Missile");
        }
    }
}
