using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public interface ISerializable<T>
    {
        void ReadData(string rawData);

        string WriteData();
    }
}
