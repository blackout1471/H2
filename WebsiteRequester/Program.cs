using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteRequester
{
    class Program
    {
        static void Main(string[] args)
        {
            ContentManager manager = new ContentManager();

            Console.WriteLine(manager.GetContent("TextFile1.txt", ContentRequestType.File));
            Console.WriteLine(manager.GetContent("https://docs.microsoft.com", ContentRequestType.Website));

            Console.ReadKey();
        }
    }
}
