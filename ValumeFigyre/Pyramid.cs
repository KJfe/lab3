using System;

namespace VolumeFigyre
{
    //Реализуем интерфейс пирамиды
    public class Pyramid : IVolumeFigure
    {
        /// <summary>
        /// реализация полей
        /// </summary>
        private double Area;
        private double Height;
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
    }
}
