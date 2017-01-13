using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValumeFigyre
{
    //Реализуем интерфейс шара
    [Serializable]
    public class Sphear : IValumeFigyre
    {
        /// <summary>
        /// реализация поля
        /// </summary>
        private double _radius;
        /// <summary>
        /// Конструктор класса шара, приме параметров
        /// </summary>
        /// <param name="radius"></param>
        public Sphear(double radius)
        {         
                _radius = radius;     
        }
        /// <summary>
        /// Реализация интерфеййса, расчет объема
        /// </summary>
        public double Valume
        {
            get
            {
                return Math.Round(((4 * Math.PI * Math.Pow(_radius, 3)) / 3),3);
            }
        }
        /// <summary>
        /// Реализация интерфеййса, передача типа фигуры
        /// </summary>
        public string TypeFigyre
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
                double[] p = { Math.Round(_radius,3) };
                return p;
            }
        }
    }
}
