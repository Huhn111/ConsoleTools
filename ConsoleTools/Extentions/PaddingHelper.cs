using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Extentions
{
    public static class PaddingHelper
    {
        public static string PadCenter(this string text, int totalWidth) => text.PadCenter(totalWidth, ' ');

        public static string PadCenter(this string text, int totalWidth, char paddingChar)
        {
            var padLeft = (totalWidth - text.Length) / 2;

            return text.PadRight(padLeft + text.Length, paddingChar)
                       .PadLeft(totalWidth, paddingChar);
        }
    }
}
