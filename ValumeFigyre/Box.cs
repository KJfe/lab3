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
            if ((height <= 0)||(width<=0)||(deep<=0)||
                (height>=double.MaxValue)|| (width >= double.MaxValue)|| (deep >= double.MaxValue)||
                (height*width*deep>=double.MaxValue))
            {
                throw new Exception();
            }
            else
            {
                _height = height;
                _width =width;
                _deep = deep;
            }
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
                return "Parallepiped";
            }
        }


    }
}
