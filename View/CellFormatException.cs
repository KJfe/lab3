using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace View
{
    /// <summary>
    /// Exception если формат в ячейке не верный
    /// </summary>
    public class CellFormatException:Exception
    {
        /// <summary>
        /// Ориентации ошибки
        /// </summary>
        /// <param name="editDesc"></param>
        public CellFormatException(string editDesc) : base(string.Format("Format Error in cell {0} ", editDesc)) { }
    }
}
