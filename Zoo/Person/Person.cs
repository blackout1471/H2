using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Person
{
    public class Person
    {   
        
        /// <summary>
        /// The name of the person
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }
        }

        /// <summary>
        /// Whether the person is happy
        /// </summary>
        public int Happy
        {
            get
            {
                return happy;
            }

            private set
            {
                happy = value;
            }
        }

        private string name;
        private int happy;

        public Person(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Decrease Happinness
        /// </summary>
        public void DecreaseHappiness()
        {
            if (happy > 0)
                Happy--;
        }
    }
}
