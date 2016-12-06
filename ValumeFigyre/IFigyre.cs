using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValumeFigyre
{
    //Определен набор обстрактных методов
    public interface IValumeFigyre
    {
        double Valume
        {
            get;
        }

        string TypeFigyre
        {
            get;
        }

    }
}
