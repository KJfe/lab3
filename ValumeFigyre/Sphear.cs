using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValumeFigyre
{
    //Реализуем интерфейс шара
    public class Sphear : IValumeFigyre
    {
        private double _radius;
        public Sphear(double radius)
        {
            if ((radius <= 0)||((4 * Math.PI * Math.Pow(radius, 3)) / 3 >= double.MaxValue))
            {
                throw new Exception();
            }
            else
            {
                _radius = radius;
            }
                
        }

        //Реализуем свойства интерфейса
        public double Valume
        {
            get
            {
                return Math.Round(((4 * Math.PI * Math.Pow(_radius, 3)) / 3),3);
            }
        }

        public string TypeFigyre
        {
            get
            {
                return "Sphear";
            }
        }




    }
}
