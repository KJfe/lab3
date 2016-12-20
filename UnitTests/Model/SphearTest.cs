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
    class SphearTest
    {
        /// <summary>
        /// Тестирование свойства Count.
        /// </summary>
        /// <param name=”count”>Значение свойства Count.</param>
        [Test]
        [TestCase(5.32132, ExpectedResult = 631.171, TestName = "Sphear при (5.32132) и результат 631.171")]
        [TestCase(3, ExpectedResult = 113.097, TestName = "Sphear при присваивании (3) и получили 113.097")]
        public double VolumeTest(double radius)
        {
            Sphear ValumeSphear = new Sphear(radius);
            return ValumeSphear.Valume;
        }
        [TestCase(-1, TestName = "Sphear при (-1)")]
        [TestCase(0, TestName = "Sphear при (0)")]
        [TestCase(double.MaxValue, TestName = "Sphear при double.MaxValue.")]
        [TestCase(double.MinValue, TestName = "Sphear при double.MinValue.")]
        public void VolumeTestExeption(double radius)
        {
            Assert.Throws<Exception>(() => new Sphear(radius));
        }
    }
}
