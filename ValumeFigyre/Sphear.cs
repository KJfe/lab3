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

        /*private double rad
        {
            set { My_rad = value; }
            get { return My_rad; }
        }*/

        //public Sphear() { }
        public Sphear(double radius)
        {
            _radius = radius;
        }

        //Реализуем свойства интерфейса
        public double Valume
        {
            get
            {
                return ((4 * Math.PI * Math.Pow(_radius, 3)) / 3);
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
