using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D05_NestedAndGenerics
{
    interface IBitComparable<T>
    {
        int CompareTo(T other);

        void SomeOther();
    }
}
