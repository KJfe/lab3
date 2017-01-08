using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValumeFigyre;
using NUnit.Framework;

namespace UnitTests.Model
{
    [TestFixture]
    class PeramidTest
    {
        /// <summary>
        /// Тестирование свойства Count.
        /// </summary>
        /// <param name=”count”>Значение свойства Count.</param>
        [Test]
        [TestCase(3.22, 1.32132, ExpectedResult = 1.418, TestName = "Pyramid при (3.22, 1.32132) и результат 1.418")]
        [TestCase(2, 3, ExpectedResult = 2, TestName = "Pyramid при присваивании 2,3 и получили 2")]
        public double VolumeTest(double area, double height)
        {
            Pyramid ValumePyramid = new Pyramid(area, height);
            return ValumePyramid.Valume;
        }
    }
}
