using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class BotPlayer : Player
    {
        public BotPlayer() : base("Bot")
        {
            SetInputMethod(() => GetRandomNumber());
        }

        private int GetRandomNumber()
        {
            return 0;
        }
    }
}
