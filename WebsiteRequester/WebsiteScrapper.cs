using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteRequester
{
    public class WebsiteScrapper : ContentRequest
    {
        /// <summary>
        /// Read the body of a website
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override string GetContent(string path)
        {
            string content;

            try
            {
                WebRequest request = WebRequest.Create(path);
                Stream contentStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();

                using (Stream dataStream = contentStream)
                {
                    StreamReader reader = new StreamReader(dataStream);
                    content = reader.ReadToEnd();
                }

                contentStream.Close();
            }
            catch(Exception e)
            {
                throw e;
            }

            return content;
        }
    }
}
