using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($@"{AppDomain.CurrentDomain.BaseDirectory}\\LogFile.txt");

            BirdSimulator simulator = new BirdSimulator(new Seagull(new WorldPosition(new Vector3(0f, 0f, 0f))), (x) => Console.WriteLine(x));
            simulator.Run();

            Console.ReadKey();
        }
    }
}
