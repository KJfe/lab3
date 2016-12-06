using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace View
{
    public class CellFormatException:Exception
    {
        public CellFormatException(string editDesc) : base(string.Format("Format Error in cell {0} ", editDesc))
        {

        }
    }
}
