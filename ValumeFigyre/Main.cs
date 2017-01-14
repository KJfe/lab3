using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValumeFigyre
{
    enum Figyres : int
    {
        Box=1,
        Sphear=2,
        Pyramid=3
    };
    class VolumeFigyre
    {
        static void Main(string[] args)
        {
            bool end = false;
                while (!end)
                {
                Console.Clear();
                Console.WriteLine("Расчитать объем для:");
                Console.WriteLine("1. Параллепипеда");
                Console.WriteLine("2. Шара");
                Console.WriteLine("3. Пирамиды");
                Console.WriteLine("Выход, любое значение");
                Console.WriteLine("Введите номер варианта:");
                
                switch ((Figyres)ReadParametr.dRead())
                    {
                        case Figyres.Box:
                            {
                                Console.Clear();
                                Box ValumeBox = new Box(height: ReadParametr.dRead(), width: ReadParametr.dRead(), deep: ReadParametr.dRead());
                                Console.Clear();
                                //ValumeBox.Rewrite();
                                Console.WriteLine("Объем Параллепипела = {0}", ValumeBox.Volume);
                                Console.Read();
                                break;
                            }
                        case Figyres.Sphear:
                            {
                                Console.Clear();
                                Sphear ValumeSphear = new Sphear(radius: ReadParametr.dRead());
                                Console.Clear();
                                //ValumeSphear.Rewrite();
                                Console.WriteLine("Объем шара = {0}", ValumeSphear.Volume);
                                Console.Read();
                                break;
                            }
                        case Figyres.Pyramid:
                            {
                                Console.Clear();
                                Pyramid ValumePyramid = new Pyramid(area: ReadParametr.dRead(),height: ReadParametr.dRead());
                                Console.Clear();
                                //ValumePyramid.Rewrite();
                                Console.WriteLine("Объем шара = {0}", ValumePyramid.Volume);
                                Console.Read();
                                break;
                            }
                        default:
                            break;
                            
                    }
                Console.WriteLine("Хотите выйти? 1 (да), 2 (нет)");
                if (ReadParametr.dRead()==1 )
                    {
                    return;
                    }
                }

          Console.Read();
        }
    }
}
