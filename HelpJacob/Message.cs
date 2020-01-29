using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpJacob
{
    public struct Message
    {
        public Receiver To;
        public string From;
        public string Body;
        public string Subject; 
        public string Cc;

        public Message(Receiver to, string from, string body, string subject, string cc)
        {
            To = to;
            From = from;
            Body = body;
            Subject = subject;
            Cc = cc;
        }
    }
}
