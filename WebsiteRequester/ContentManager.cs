using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteRequester
{
    public enum ContentRequestType
    {
        Website,
        File
    }

    public class ContentManager
    {
        private ContentRequest ContentRequester
        {
            get
            {
                return contentRequester;
            }

            set
            {
                contentRequester = value;
            }
        }
        private ContentRequest contentRequester;

        public ContentManager() { }

        private void SetRequestType(ContentRequestType type)
        {
            switch(type)
            {
                case ContentRequestType.File:
                    ContentRequester = new FileScrapper();
                    break;
                case ContentRequestType.Website:
                    ContentRequester = new WebsiteScrapper();
                    break;
                default:
                    throw new NotImplementedException();

            }
        }

        /// <summary>
        /// Get the content from a target
        /// ex a file path
        /// or a website uri
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetContent(string path, ContentRequestType type)
        {
            SetRequestType(type);
            return ContentRequester.GetContent(path);
        }
        
    }
}
