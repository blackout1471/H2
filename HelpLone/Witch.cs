using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLone
{
    public class Witch : Character, IHeal, IShield, ISlash, ITeleport
    {
        public void Heal()
        {
            Console.WriteLine("Heal");
        }

        public void RaiseShield()
        {
            Console.WriteLine("RaiseShield");
        }

        public void ShieldGlare()
        {
            Console.WriteLine("ShieldGlare");
        }

        public void Slash()
        {
            Console.WriteLine("Slash");
        }

        public void Teleport(int x, int y)
        {
            Console.WriteLine($"Teleporting: {x} {y}");
        }
    }
}
