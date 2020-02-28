using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public interface ILog
    {
        object Lock { get; }

        void Append(string data);

        void Write(string data);

    }
}
