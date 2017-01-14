using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Exception если элемент в ячейке неверный
    /// </summary>
    public class CellOutOfRangeExxeption:Exception
    {
        /// <summary>
        /// Ориентации ошибки
        /// </summary>
        /// <param name="editDesc"></param>
        public CellOutOfRangeExxeption(string editDesc) : base(string.Format("Range Error in cell {0} ", editDesc)) { } 
    }
}
