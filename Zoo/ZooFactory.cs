using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animal;

namespace Zoo
{
    public class ZooFactory
    {
        /// <summary>
        /// Types of animals
        /// </summary>
        public enum AnimalTypes
        {
            Elephant,
            Rabbit,
            Giraff,
            Wolf
        }

        /// <summary>
        /// Generate animal
        /// </summary>
        /// <param name="animalType"></param>
        /// <returns></returns>
        public Animal.Animal GenerateAnimal(AnimalTypes animalType)
        {
            Animal.Animal an = null;

            switch(animalType)
            {
                case AnimalTypes.Elephant:
                    an = new Elephant("a");
                    break;
                case AnimalTypes.Rabbit:
                    an = new Rabbit("b");
                    break;
                case AnimalTypes.Giraff:
                    an = new Giraff("c");
                    break;
                case AnimalTypes.Wolf:
                    an = new Wolf("d");
                    break;
                default:
                    an = new Elephant("a");
                    break;
            }

            return an;
        }

        /// <summary>
        /// Generate a fence with an amount of animals
        /// </summary>
        /// <param name="types"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Fence GenerateFence(AnimalTypes types, int amount)
        {
            Animal.Animal[] animals = new Animal.Animal[amount];

            for (int i = 0; i < animals.Length; i++)
            {
                animals[i] = GenerateAnimal(types);
            }

            return new Fence(animals);
        }
    }
}
