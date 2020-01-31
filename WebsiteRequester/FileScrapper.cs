using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteRequester
{
    public class FileScrapper : ContentRequest
    {
        /// <summary>
        /// Read from a file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override string GetContent(string path)
        {
            string content;

            try
            {
                content = File.ReadAllText(path);
            }
            catch(Exception e)
            {
                throw e;
            }

            return content;
        }
    }
}
