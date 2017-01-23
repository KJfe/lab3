using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    [TestFixture]
    class SphearTest
    {
        /// <summary>
        /// Тестирование свойства 
        /// </summary>
        /// <param name=”count”>Значение свойства Count.</param>
        [Test]
        [TestCase(5.32132, ExpectedResult = 631.171, TestName = "Sphear при (5.32132) и результат 631.171")]
        [TestCase(3, ExpectedResult = 113.097, TestName = "Sphear при присваивании (3) и получили 113.097")]
        public double VolumeTest(double radius)
        {
            Sphear ValumeSphear = new Sphear(radius);
            return ValumeSphear.Volume;
        }
       
    }
}
