using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;

namespace UnitTests.ValumeFigyre
{
    /// <summary>
    /// Набор тестов для класса MyClass.
    /// </summary>
    [TestFixture]
    public class ValumeFigyreBoxTest
    {
        /// <summary>
        /// Тестирование свойства Count.
        /// </summary>
        /// <param name=”count”>Значение свойства Count.</param>
        [Test]
        [TestCase(3.22, 1.32132, 1.24124, ExpectedResult=5.281, TestName = "Box при (3.22, 1.32132, 1.24124) и результат 5,281")]
        [TestCase(2, 3, 5, ExpectedResult = 30,TestName ="Box при присваивании 2,3,5 и получили 30")]
        public double VolumeTest(double height, double width, double deep)
        {
            Box ValumeBox = new Box(height, width, deep);
            return ValumeBox.Volume;
        }
        
    }
}

