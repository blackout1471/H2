using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpJacob
{
    public class HtmlConverter
    {
        public string ConvertPlainTextToHtml(string text)
        {
            return "" + text + "";
        }

        public void ConvertMessageBodyToHtml(Message m)
        {
            m.Body = ConvertPlainTextToHtml(m.Body);
        }
    }
}
