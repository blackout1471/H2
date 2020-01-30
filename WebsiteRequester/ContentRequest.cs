using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteRequester
{
    public abstract class ContentRequest
    {
        public abstract string GetContent(string path);
    }
}
