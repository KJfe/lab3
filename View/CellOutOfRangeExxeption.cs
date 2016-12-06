using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    class CellOutOfRangeExxeption:Exception
    {
        public CellOutOfRangeExxeption(string editDesc) : base(string.Format("Range Error in cell {0} ", editDesc))
        {

        }
    }
}
