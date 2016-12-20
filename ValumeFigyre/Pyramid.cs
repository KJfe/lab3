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
        private double _area;
        private double _height;

        public Pyramid(double area, double height)
        {
            if ((height <= 0) || (area <= 0) ||
                  (height >= double.MaxValue) || (area >= double.MaxValue) ||
                  (height * area/3 >= double.MaxValue))
            {
                throw new Exception();
            }
            else
            {
                _area = area;
                _height = height;
            }
               
        }

        //Реализуем методы интерфейса
        public  double Valume
        {
            get
            {
                return Math.Round((_area * _height) / 3,3);
            }
            
        }

        public string TypeFigyre
        {
            get
            {
                return "Pyramid";
            }
        }



    }
}
