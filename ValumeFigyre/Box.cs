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
        private string typeFigyre;

        public Box(double height, double width, double deep)
        {
            if ((height <= 0)||(width<=0)||(deep<=0))
            {
                throw new Exception();
            }
            else
            {
                _height = height;
                _width = width;
                _deep = deep;
            }
        }

        //Реализуем свойства интерфейса
        public double Valume
        {
            get
            {
                return (_height * _width * _deep);
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
