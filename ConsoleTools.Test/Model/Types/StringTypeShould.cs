using ConsoleTools.Enums;
using ConsoleTools.Model;
using ConsoleTools.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Test.Model.Types
{
    public class StringTypeShould
    {
        [InlineData(Orientations.Left, "Test", "Test      ")]
        [InlineData(Orientations.Right, "Test", "      Test")]
        [InlineData(Orientations.Center, "Test", "   Test   ")]
        [InlineData(Orientations.Left, "Long Test Text", "Long Te...")]
        [InlineData(Orientations.Right, "Long Test Text", "Long Te...")]
        [InlineData(Orientations.Center, "Long Test Text", "Long Te...")]
        [Theory]
        public void FormatText(Orientations orientation, string text, string expectedResult)
        {
            StringType sType = new(10, orientation) { ActualWidth = text.Length };

            var result = sType.ConvertToString(text);

            result.Length.ShouldBe(10);
            result.ShouldBe(expectedResult);
        }

        [Fact]
        public void BuildType()
        {
            StringType sType = new(10);
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
    }
}
