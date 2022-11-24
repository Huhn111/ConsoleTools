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

        [Fact]
        public void BuildType()
        {
            NumberType<int> sType = new(10);
            sType.MaxWidth.ShouldBe(10);
            sType.MinWidth.ShouldBe(10);
            sType.Orientation.ShouldBe(Orientations.Left);

            sType = new(15, 20);
            sType.MaxWidth.ShouldBe(20);
            sType.MinWidth.ShouldBe(15);
            sType.Orientation.ShouldBe(Orientations.Left);

            sType = new(10, Orientations.Right);
            sType.MaxWidth.ShouldBe(10);
            sType.MinWidth.ShouldBe(10);
            sType.Orientation.ShouldBe(Orientations.Right);

            sType = new(15, 20, Orientations.Center);
            sType.MaxWidth.ShouldBe(20);
            sType.MinWidth.ShouldBe(15);
            sType.Orientation.ShouldBe(Orientations.Center);
        }

        [InlineData(Orientations.Left, 1, 9, "9")]
        [InlineData(Orientations.Left, 3, 9, "9  ")]
        [InlineData(Orientations.Right, 3, 9, "  9")]
        [InlineData(Orientations.Center, 3, 9, " 9 ")]
        [InlineData(Orientations.Left, 3, 100000000, "1e+008")]
        [InlineData(Orientations.Left, 6, 100000000, "1e+008")]
        [Theory]
        public void FormatText(Orientations orientation, int length, int number, string expectedResult)
        {
            NumberType<int> sType = new(length, orientation) { ActualMaxWidth = number.ToString().Length };

            var result = sType.GetFormatedString(number);

            result.Length.ShouldBe(length);
            result.ShouldBe(expectedResult);
        }

        [InlineData(4, 1, 100, 4, 1234)]
        [InlineData(7, 1, 100, 4, 1234567)]
        [InlineData(6, 1, 100, 4, 123456789)]
        [Theory]
        public void GetActualMaxWidth(int expectedLength, params int[] collection)
        {
            NumberType<int> sType = new(7);

            var result = sType.GetActualMaxWidth(collection);

            result.ShouldBe(expectedLength);
        }


        [InlineData(3, 10, 3, 10)]
        [InlineData(3, 3, 6, 6)]
        [InlineData(3, 4, 6, 6)]
        [Theory]
        public void UpdateWidth(int minWidth, int maxWidth, int expMinWidth, int expMaxWidth)
        {
            NumberType<int> sType = new(minWidth, maxWidth);
            int[] collection = { 123456789 };

            _ = sType.GetActualMaxWidth(collection);

            sType.MinWidth.ShouldBe(expMinWidth);
            sType.MaxWidth.ShouldBe(expMaxWidth);
        }
    }
}
