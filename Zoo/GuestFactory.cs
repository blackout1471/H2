using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class GuestFactory
    {
        private readonly string[] names = { 
            "brand",
            "Lad",
            "Lud",
            "Lars",
            "Per"
        };

        private Random rnd = new Random();

        /// <summary>
        /// Generate a random person
        /// </summary>
        /// <returns></returns>
        public Person.Person GeneratePerson()
        {
            return new Person.Person(names[rnd.Next(0, names.Length)]);
        }
    }
}
