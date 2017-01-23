using System;

namespace Model
{
    //Реализуем интерфейс пирамиды
    public class Pyramid : IVolumeFigure
    {
        /// <summary>
        /// реализация полей
        /// </summary>
        public double Area;
        public double Height;
        /// <summary>
        /// Конструктор класса 
        /// </summary>
        public Pyramid() { }
        /// <summary>
        /// Реализация интерфеййса, расчет объема
        /// </summary>
        public double Volume
        {
            get
            {
                return Math.Round((Area * Height) / 3,3);
            }

        }
        /// <summary>
        /// Реализация интерфеййса, передача типа фигуры
        /// </summary>
        public string TypeFigure
        {
            get
            {
                return "Pyramid";
            }
        }
        /// <summary>
        /// Реализация интерфеййса, передача массива параметров
        /// </summary>
        public double[] Parametr
        {
            get
            {
                double[] p = { Math.Round(Area, 3), Math.Round(Height, 3) };
                return p;
            }
        }
    }
}
