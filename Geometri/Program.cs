using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    class Program
    {
        static void Main(string[] args)
        {
            Geometri[] geometri =
            {
                new Parralelogram(5, 3, 30),
                new Square(20, 20),
                new Trapez(10, 7, 8, 7),
                new Triangle(5, 3, 10)
            };

            foreach(Geometri gem in geometri)
            {
                Console.WriteLine(gem.GetClassName());
                Console.WriteLine(gem.GetInformation());
                Console.WriteLine("Areal {0}", gem.GetArea());
                Console.WriteLine("Perimeter {0}\n", gem.GetPerimeter());
            }

            Console.ReadKey();
        }
    }
}
