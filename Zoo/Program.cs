using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zoo.Animal;
using Zoo.Person;

namespace Zoo
{
    class Program
    {

        static void Main(string[] args)
        {
            ZooManager.Instance.AttachAnimalShatHandler(AnimalShat);
            ZooManager.Instance.AttachKeeperHandler(KeeperCleanedAShit);
            ZooManager.Instance.Start();

            while (true)
            {
                UpdateGUI();
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }

        private static void UpdateGUI()
        {
            Console.Clear();
            Console.WriteLine($"Amount of shits: {ZooManager.Instance.GetAmountOfShits()}\n" +
                $"Amount of Guests: {ZooManager.Instance.Guests.CurrentItems}\n" +
                $"Amount of Keepers: {ZooManager.Instance.Keepers.Length}");
        }

        private static void AnimalShat(Animal.Animal animal, turd.Turd turd)
        {
            
            
        }

        private static void KeeperCleanedAShit(Keeper keeper, turd.Turd turd)
        {
           
        }
    }
}
