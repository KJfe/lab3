using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValumeFigyre;
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
            return ValumeBox.Valume;
        }
        [TestCase(-1, -1, -1, TestName ="Box при (-1,-1,-1)")]
        [TestCase(1, 1, -1, TestName = "Box при (1,1,-1)")]
        [TestCase(1, -1, 1, TestName = "Box при (1,-1,1)")]
        [TestCase(-1, 1, 1, TestName = "Box при (-1,1,1)")]
        [TestCase(0,5,12, TestName = "Box при (0,5,12)")]
        [TestCase(5, 0, 12, TestName = "Box при (5,0,12)")]
        [TestCase(5, 12, 0, TestName = "Box при (5,12,0)")]
        [TestCase(double.MaxValue, double.MaxValue, double.MaxValue, TestName = "Box при double.MaxValue.")]
        [TestCase(double.MinValue, double.MinValue, double.MinValue, TestName = "Box при double.MinValue.")]
        public void VolumeTestExeption(double height, double width, double deep)
        {
            Assert.Throws<Exception>(() => new Box(height, width, deep));
        }
    }
}

/*namespace UnitTests
{
    public class Test
    {
    }
}*/
