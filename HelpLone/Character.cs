using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLone
{
    public abstract class Character
    {
        public virtual void Die()
        {
            Console.WriteLine("Die");
        }

        public virtual void Fight()
        {
            Console.WriteLine("Fight");
        }
    }
}
