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
    public class ValumeFigyreTest
    {
        /// <summary>
        /// Тестирование свойства Count.
        /// </summary>
        /// <param name=”count”>Значение свойства Count.</param>
        [Test]
        //[TestCase(4,5,6, TestName = "Тестирование Box при присваивании 4,5,6.")]
        // [TestCase(0,0,0, typeof(ArgumentException), TestName = "Тестирование Box при присваивании 0.")]

        // [TestCase(-1,-1,-1, ExpectedException() /*= typeof(ArgumentException)*/, TestName = "Тестирование Box при присваивании -1.")]
        //[TestCase(double.MaxValue, double.MaxValue, double.MaxValue, TestName = "Тестирование Box при присваивании MaxValue.")]
        //[TestCase(double.MaxValue - 1, double.MaxValue - 1, double.MaxValue - 1, TestName = "Тестирование Box при присваивании MaxValue - 1.")] 
        [TestCase(2, 3, 5, ExpectedResult = 30)]
        public double VolumeTest(double height, double width, double deep)
        {
            Box ValumeBox = new Box(height: height, width: width, deep: deep);
            return ValumeBox.Valume;
        }
        [TestCase(-1, -1, -1)]
        [TestCase(1, -1, -1)]
        [TestCase(1, 1, -1)]
        [TestCase(-1, 1, -1)]
        [TestCase(-1, -1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(-1, -1, 1)]
        [TestCase(0,5,12)]
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
