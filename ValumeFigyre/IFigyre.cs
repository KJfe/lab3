using System;
using System.IO;
using System.Xml.Serialization;
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
