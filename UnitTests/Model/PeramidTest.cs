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
        [TestCase(-1, -1, TestName = "Pyramid при (-1,-1)")]
        [TestCase(1, -1, TestName = "Pyramid при (1,-1)")]
        [TestCase(-1, 1, TestName = "Pyramid при (-1,1)")]
        [TestCase(0, 5, TestName = "Pyramid при (0,5)")]
        [TestCase(5, 0, TestName = "Pyramid при (5,0)")]
        [TestCase(double.MaxValue, double.MaxValue, TestName = "Pyramid при double.MaxValue.")]
        [TestCase(double.MinValue, double.MinValue, TestName = "Pyramid при double.MinValue.")]
        public void VolumeTestExeption(double area, double height)
        {
            Assert.Throws<Exception>(() => new Pyramid(area, height));
        }
    }
}
