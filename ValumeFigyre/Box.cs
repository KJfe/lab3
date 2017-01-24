using System;

namespace Model
{
    //Реализуем интерфейс Параллепипеда
    public class Box : IVolumeFigure
    {
        /// <summary>
        /// реализация полей
        /// </summary>
        public double Height;
        public double Width;
        public double Deep;
        /// <summary>
        /// крнструктор 
        /// </summary>
        public Box() { }
        /// <summary>
        /// Реализация интерфеййса, расчет объема
        /// </summary>
        public double Volume
        {
            get
            {
                return Math.Round(Height * Width * Deep,3);
            }
        }
        /// <summary>
        /// Реализация интерфеййса, передача типа фигуры
        /// </summary>
        public string TypeFigure
        {
            get
            {
                return "Box";
            }
        }
        /// <summary>
        /// Реализация интерфеййса, передача массива параметров
        /// </summary>
        public double[] Parametr
        {
            get
            {
                double[] p = { Math.Round(Width, 3), Math.Round(Height, 3), Math.Round(Deep, 3) };
                return p;
            }
        }
    }
}
