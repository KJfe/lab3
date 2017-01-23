namespace Model
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
