using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    public class Human : Player
    {
        public Human(string name, Func<int> inputMethod) : base(name)
        {
            SetInputMethod(inputMethod);
        }
    }
}
