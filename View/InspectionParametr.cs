using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValumeFigyre;
using System.Windows.Forms;

namespace View
{
    public class InspectionParametr
    {
        public static double Parametr(string edit, string editDesc)
        {
            double doubleEdit = 0;
            try
            {
                doubleEdit = Convert.ToDouble(edit);
            }
            catch(Exception)
            {
                throw new CellFormatException(editDesc);
            }

            if (doubleEdit <= 0)
            {
                throw new CellOutOfRangeExxeption(editDesc);
            }

            return doubleEdit;
        }
    }
}
