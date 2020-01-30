﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLone
{
    public class Barbarian : Character, IMelee, IHeal, ISlash
    {
        public void Bash()
        {
            Console.WriteLine("Bash");
        }

        public void Cleave()
        {
            Console.WriteLine("Cleave");
        }

        public void Heal()
        {
            Console.WriteLine("Heal");
        }

        public void Slash()
        {
            Console.WriteLine("Slash");
        }
    }
}
