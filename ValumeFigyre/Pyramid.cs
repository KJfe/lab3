using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValumeFigyre
{
    //Реализуем интерфейс пирамиды
    public class Pyramid : IValumeFigyre
    {
        /// <summary>
        /// реализация полей
        /// </summary>
        private double _area;
        private double _height;
        /// <summary>
        /// Конструктор класса пирамиды, прием параметров фигуры
        /// </summary>
        /// <param name="area"></param>
        /// <param name="height"></param>
        public Pyramid(double area, double height)
        {  
                _area = area;
                _height = height;
        }
        /// <summary>
        /// Реализация интерфеййса, расчет объема
        /// </summary>
        public double Valume
        {
            get
            {
                return Math.Round((_area * _height) / 3,3);
            }

        }
        /// <summary>
        /// Реализация интерфеййса, передача типа фигуры
        /// </summary>
        public string TypeFigyre
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
                double[] p = { Math.Round(_area,3), Math.Round(_height, 3) };
                return p;
            }
        }
    }
}
