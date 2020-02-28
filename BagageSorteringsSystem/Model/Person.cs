using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class Person : ISerializable<Person>
    {
        /// <summary>
        /// The name of the passenger
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
        /// The passenger number
        /// </summary>
        public string PassagerNumber
        {
            get
            {
                return passagerNumber;
            }

            private set
            {
                passagerNumber = value;
            }
        }

        /// <summary>
        /// The persons bagage
        /// </summary>
        public Bagage Bagage
        {
            get
            {
                return bagage;
            }

            private set
            {
                bagage = value;
            }
        }

        /// <summary>
        /// The gate which the person belongs to
        /// </summary>
        public uint GateId
        {
            get
            {
                return gateId;
            }

           private set
            {
                gateId = value;
            }
        }

        private string name;
        private string passagerNumber;
        private Bagage bagage;
        private uint gateId;

        /// <summary>
        /// Constructor used for when reading data
        /// </summary>
        /// <param name="bagage"></param>
        public Person(Bagage bagage)
        {
            Name = "";
            PassagerNumber = "";
            Bagage = bagage;
            GateId = 0;
        }

        public Person(string name, string pnumber, Bagage bagage, uint gateId)
        {
            Name = name;
            PassagerNumber = pnumber;
            Bagage = bagage;
            GateId = gateId;
        }

        /// <summary>
        /// Read data from a string
        /// </summary>
        /// <param name="rawData"></param>
        public void ReadData(string rawData)
        {
            string[] arr = rawData.Split('|');

            if (arr.Length != 3)
                throw new Exception("Not correct data");

            uint tGateId = uint.Parse(arr[0]);
            string tName = arr[1];
            string tPassN = arr[2];

            GateId = tGateId;
            Name = tName;
            PassagerNumber = tPassN;
        }

        /// <summary>
        /// Write person to string
        /// </summary>
        /// <returns></returns>
        public string WriteData()
        {
            return $"{GateId}|{Name}|{PassagerNumber}";
        }
    }
}
