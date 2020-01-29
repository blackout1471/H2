using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpJacob
{
    public abstract class Protocol
    {
        public abstract void Send(Message message);
    }
}
