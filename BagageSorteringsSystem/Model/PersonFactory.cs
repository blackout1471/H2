using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class PersonFactory
    {

        private readonly string[] names =
        {
            "Emil",
            "Peter",
            "Rene",
            "Marc",
            "Kenneth"
        };

        private readonly string[] bagagebrands =
        {
            "Heiner",
            "Bulla",
            "Grinds"
        };

        private Random rnd;

        public PersonFactory()
        {
            rnd = new Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// Generates a random person with bagage
        /// and gives them an gateId
        /// </summary>
        /// <param name="gateId"></param>
        /// <returns></returns>
        public Person GeneratePerson(uint gateId)
        {
            string rndBrand = bagagebrands[rnd.Next(0, bagagebrands.Length)];
            Array colors = Enum.GetValues(typeof(Color));
            Color rndColor = (Color)colors.GetValue(rnd.Next(colors.Length));
            float rndWeight = rnd.Next(20, 1000) / 100;
            Bagage curB = new Bagage(rndBrand, rndColor, rndWeight);

            string rndName = names[rnd.Next(0, names.Length)];
            string rndNumber = Guid.NewGuid().GetHashCode().ToString();

            Person curP = new Person(rndName, rndNumber, curB, gateId);

            return curP;
        }
    }
}
