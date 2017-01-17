using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValumeFigyre
{
    //Реализуем интерфейс Параллепипеда
    [Serializable]
    public class Box : IVolumeFigure
    {
        /// <summary>
        /// реализация полей
        /// </summary>
        private double _height;
        private double _width;
        private double _deep;
        /// <summary>
        /// крнструктор параллепипеда, прием параметров
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="deep"></param>
        public Box(double height, double width, double deep)
        {
                _height = height;
                _width =width;
                _deep = deep;
        }
        /// <summary>
        /// Реализация интерфеййса, расчет объема
        /// </summary>
        public double Volume
        {
            get
            {
                return Math.Round(_height * _width * _deep,3);
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
                double[] p = { Math.Round(_width,3), Math.Round(_height, 3), Math.Round(_deep, 3) };
                return p;
            }
        }
    }
}
