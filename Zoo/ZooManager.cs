using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Person;

namespace Zoo
{
    public class ZooManager
    {
        // Singleton pattern
        public static ZooManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ZooManager();

                return _instance;
            }
        }
        private static ZooManager _instance;
        private ZooManager() 
        {
            zf = new ZooFactory();

            Fences = new Fence[4];
            Fences[0] = zf.GenerateFence(ZooFactory.AnimalTypes.Elephant, 4);
            Fences[1] = zf.GenerateFence(ZooFactory.AnimalTypes.Rabbit, 6);
            Fences[2] = zf.GenerateFence(ZooFactory.AnimalTypes.Giraff, 6);
            Fences[3] = zf.GenerateFence(ZooFactory.AnimalTypes.Wolf, 6);

            Keepers = new Keeper[]
            {
                new Keeper("Kasper", Fences),
                new Keeper("Lukas", Fences)
            };

            Guests = new Buffer<Person.Person>(1500);

            PersonProducer = new PersonProducer(Guests);

        }

        /// <summary>
        /// The fences in the zoo
        /// </summary>
        public Fence[] Fences
        {
            get
            {
                return fences;
            }

            private set
            {
                fences = value;
            }
        }

        /// <summary>
        /// The zoo factory
        /// </summary>
        public ZooFactory Zf
        {
            get
            {
                return zf;
            }

            private set
            {
                zf = value;
            }
        }

        /// <summary>
        /// the keepers working in the zoo
        /// </summary>
        public Keeper[] Keepers
        {
            get
            {
                return keepers;
            }

            private set
            {
                keepers = value;
            }
        }

        /// <summary>
        /// Guests in the zoo
        /// </summary>
        public Buffer<Person.Person> Guests
        {
            get
            {
                return guests;
            }

            private set
            {
                guests = value;
            }
        }

        /// <summary>
        /// Person Producer
        /// </summary>
        public PersonProducer PersonProducer
        {
            get
            {
                return personProducer;
            }

            private set
            {
                personProducer = value;
            }
        }

        private Fence[] fences;
        private ZooFactory zf;
        private Keeper[] keepers;
        private Buffer<Person.Person> guests;
        private PersonProducer personProducer;

        /// <summary>
        /// Start all the threads
        /// </summary>
        public void Start()
        {
            for (int i = 0; i < Fences.Length; i++)
            {
                Fences[i].Start();
            }

            for (int i = 0; i < Keepers.Length; i++)
            {
                Keepers[i].Start();
            }

            PersonProducer.Start();
        }

        /// <summary>
        /// Attach keeper handlers
        /// </summary>
        /// <param name="turdCleanEvent"></param>
        public void AttachKeeperHandler(Keeper.TurdCleanedEvent turdCleanEvent)
        {
            for (int i = 0; i < Keepers.Length; i++)
            {
                Keepers[i].TurdCleanedHandler = turdCleanEvent;
            }
        }

        /// <summary>
        /// Attach animal shat event
        /// </summary>
        /// <param name="shatEvent"></param>
        public void AttachAnimalShatHandler(Animal.Animal.AnimalShitEvent shatEvent)
        {
            for (int i = 0; i < Fences.Length; i++)
            {
                Fences[i].AttachMethodForAnimalShit(shatEvent);
            }
        }

        /// <summary>
        /// Gets the amount of shits
        /// </summary>
        public int GetAmountOfShits()
        {
            int amount = 0;

            for (int i = 0; i < Fences.Length; i++)
            {
                amount += Fences[i].TurdBuffer.CurrentItems;
            }

            return amount;
        }
    }
}
