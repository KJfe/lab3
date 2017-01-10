using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValumeFigyre
{
    //Реализуем интерфейс Параллепипеда
    public class Box : IValumeFigyre
    {
        private double _height;
        private double _width;
        private double _deep;

        public Box(double height, double width, double deep)
        {
                _height = height;
                _width =width;
                _deep = deep;
        }

        //Реализуем свойства интерфейса
        public double Valume
        {
            get
            {
                return Math.Round(_height * _width * _deep,3);
            }
        }

        public string TypeFigyre
        {
            get
            {
                return "Box";
            }
        }

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
