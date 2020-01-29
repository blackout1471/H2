using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpJacob
{
    public enum Carrier
    {
        VMessage,
        SMTP
    }

    public class MessageManager
    {
        public HtmlConverter HtmlConverter
        {
            get
            {
                return htmlConverter;
            }

            private set
            {
                htmlConverter = value;
            }
        }
        public Protocol Protocol
        {
            get
            {
                return protocol;
            }

            private set
            {
                protocol = value;
            }
        }

        private Protocol protocol;
        private HtmlConverter htmlConverter;

        public MessageManager()
        {
            HtmlConverter = new HtmlConverter();
        }

        private void SetProtocol(Carrier protocol)
        {
            switch(protocol)
            {
                case Carrier.SMTP:
                    Protocol = new SMTP();
                    break;
                case Carrier.VMessage:
                    Protocol = new VMessage();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void ConvertMessageToHtml(Message m)
        {
            m.Body = HtmlConverter.ConvertPlainTextToHtml(m.Body);
        }

        public void SendMessage(Message m, bool isHTML, Carrier carrier)
        {
            SetProtocol(carrier);

            if (isHTML)
                ConvertMessageToHtml(m);

            Protocol.Send(m);
        }

        public void SendMessageToAll(Receiver[] To, Message m, bool isHTML, Carrier carrier)
        {
            SetProtocol(carrier);

            if (isHTML)
                ConvertMessageToHtml(m);

            foreach (Receiver r in To)
            {
                m.To = r;
                Protocol.Send(m);
            }      
        }
    }
}
