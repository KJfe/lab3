using System;

namespace Model
{
    //Реализуем интерфейс шара
    public class Sphear : IVolumeFigure
    {
        /// <summary>
        /// реализация поля
        /// </summary>
        public double Radius;
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
        /// <summary>
        /// Реализация интерфеййса, передача массива параметров
        /// </summary>
        public double[] Parametr
        {
            get
            {
                double[] p = { Math.Round(Radius, 3) };
                return p;
            }
        }
    }
}
