using ConsoleTools.Enums;
using ConsoleTools.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Test.Model.Types
{
    public class NumberTypeShould
    {
        [InlineData(Orientations.Left, 1, 9, "9")]
        [InlineData(Orientations.Left, 3, 9, "9  ")]
        [InlineData(Orientations.Right, 3, 9, "  9")]
        [InlineData(Orientations.Center, 3, 9, " 9 ")]
        [InlineData(Orientations.Left, 5, 100000000, "10...")]
        [InlineData(Orientations.Left, 6, 100000000, "1e+008")]
        [Theory]
        public void FormatText(Orientations orientation, int length, int number, string expectedResult)
        {
            NumberType<int> sType = new(length, orientation) { ActualWidth = number.ToString().Length };

            var result = sType.ConvertToString(number);

            result.Length.ShouldBe(length);
            result.ShouldBe(expectedResult);
        }
    }
}
