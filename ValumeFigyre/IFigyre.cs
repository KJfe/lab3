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
        /// <summary>
        /// Возвращает Объем фигуры
        /// </summary>
        double Valume
        {
            get;
        }
        /// <summary>
        /// Возвращает тип фигуры
        /// </summary>
        string TypeFigyre
        {
            get;
        }
        /// <summary>
        /// Возвращает массив входных параметров
        /// </summary>
        double[] Parametr
        {
            get;
        }

    }
}
