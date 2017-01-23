using System;

namespace VolumeFigyre
{
    //Реализуем интерфейс шара
    public class Sphear : IVolumeFigure
    {
        /// <summary>
        /// реализация поля
        /// </summary>
        private double Radius;
        /// <summary>
        /// Конструктор класса шара
        /// </summary>
        public Sphear() { }
        /// <summary>
        /// Реализация интерфеййса, расчет объема
        /// </summary>
        public double Volume
        {
            get
            {
                return Math.Round(((4 * Math.PI * Math.Pow(Radius, 3)) / 3),3);
            }
        }
        /// <summary>
        /// Реализация интерфеййса, передача типа фигуры
        /// </summary>
        public string TypeFigure
        {
            get
            {
                return "Sphear";
            }
        }
    }
}
