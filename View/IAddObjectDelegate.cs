using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValumeFigyre;

namespace View
{
    /// <summary>
    /// интефейс для делегата
    /// </summary>
    public interface IAddObjectDelegate
    {
        /// <summary>
        /// реализация делегата
        /// </summary>
        /// <param name="figure"></param>
        void DidFinish(IVolumeFigure figure);
    }
}
