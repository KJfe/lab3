using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using NUnit.Framework;

namespace UnitTests.Model
{
    [TestFixture]
    class InspectonParametrTest
    {
        [Test]
        [TestCase("5","Height", ExpectedResult = 5, TestName = "InspectionParametr.Parametr при (5,Height)")]
        public  double InspectonParametrs(string edit, string editDesc)
        {
            return InspectionParametr.Parametr(edit, editDesc);
        }
      
        [TestCase("-5fg", "Area", TestName = "InspectionParametr.Parametr при (-5fg, Area)")]
        [TestCase("feflk", "Area", TestName = "InspectionParametr.Parametr при (feflk, Area)")]
        public void InspectonParametrCellFormatException(string edit, string editDesc)
        {
            Assert.Throws<CellFormatException>(() => InspectionParametr.Parametr(edit, editDesc));
        }

        [TestCase("-5", "Area", TestName = "InspectionParametr.Parametr при -5")]
        [TestCase("0", "Area", TestName = "InspectionParametr.Parametr при 0")]
        public void InspectonParametrCellOutOfRangeExxeption(string edit, string editDesc)
        {
            Assert.Throws<CellOutOfRangeExxeption>(() => InspectionParametr.Parametr(edit, editDesc));
        }
    }
}
