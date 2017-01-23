using System;

namespace VolumeFigyre
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
    }
}
