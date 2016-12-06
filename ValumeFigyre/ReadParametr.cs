using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValumeFigyre
{
    public class ReadParametr
    {
        public static double dRead()
        {
            //проверка на корректный ввод
            Boolean bFlags = false;
            while (!bFlags)
            {
                string str = Console.ReadLine();
                bFlags = true;
                try
                {
                    double dVariable = Convert.ToDouble(str);
                    if (0 >= dVariable)
                    {
                        Console.WriteLine("Значение не может быть меньше или равно нулю.");
                        bFlags = false;
                    }
                    else
                    {
                        return (dVariable);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка. Введены некоректные данные.(Возможно исправте '.' на ',')");
                    bFlags = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка. Введены не коректные данные. '{0}'", str);
                    bFlags = false;
                }
            }
            return -1;
        }
    }
}
