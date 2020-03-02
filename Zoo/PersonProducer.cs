using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zoo
{
    public class PersonProducer : BaseThread
    {
        /// <summary>
        /// The person buffer which the persons will be placed into
        /// </summary>
        public Buffer<Person.Person> PersonBuffer
        {
            get
            {
                return personBuffer;
            }

            private set
            {
                personBuffer = value;
            }
        }

        /// <summary>
        /// Guest factory
        /// </summary>
        public GuestFactory Gf
        {
            get
            {
                return gf;
            }

            private set
            {
                gf = value;
            }
        }

        private Buffer<Person.Person> personBuffer;
        private GuestFactory gf;

        public PersonProducer(Buffer<Person.Person> buffer)
        {
            personBuffer = buffer;
            gf = new GuestFactory();
        }

        protected override void ThreadWork()
        {
            while (true)
            {
                Monitor.Enter(PersonBuffer.Lock);

                try
                {
                    if (PersonBuffer.IsBufferFull)
                        Monitor.Wait(PersonBuffer.Lock);

                    PersonBuffer.AddItem(gf.GeneratePerson());
                }
                finally
                {
                    Monitor.Exit(PersonBuffer.Lock);
                }
            }
        }
    }
}
