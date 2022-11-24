using ConsoleTools.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Test.Extentions
{
    public class PaddingHelperShould
    {
        [Fact]
        public void centerText()
        {
            var text = "foo";

            var result = text.PadCenter(7);

            result.ShouldBe("  foo  ");
        }
    }
}
