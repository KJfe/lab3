using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValumeFigyre;

namespace View
{
    public interface IAddObjectDelegate
    {
        void DidFinish(IValumeFigyre figure);
    }
}
