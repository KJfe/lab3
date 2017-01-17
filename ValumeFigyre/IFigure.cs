using System;
using System.IO;
using System.Xml.Serialization;
namespace ValumeFigyre
{
    /// <summary>
    /// определен набор обстрактных методов
    /// </summary>
    public interface IVolumeFigure
    {
        /// <summary>
        /// Возвращает Объем фигуры
        /// </summary>
        double Volume
        {
            get;
        }
        /// <summary>
        /// Возвращает тип фигуры
        /// </summary>
        string TypeFigure
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
