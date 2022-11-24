using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using ConsoleTools.Enums;
using ConsoleTools.Exceptions;
using System.ComponentModel;

namespace ConsoleTools.Model.Types
{
    public class Int32Type : TypeBase<int>
    {
        private readonly int _minWidth;
        public Int32Type(int minWidth) => _minWidth = minWidth;
        public Int32Type(int minWidth, Orientations orientation) : base(orientation) => _minWidth = minWidth;

        protected override int CalculateMaxWidth() => ActualWidth;
        protected override int CalculateMinWidth() => _minWidth;

        public override string ConvertToString(int element)
        {
            return FormatString(element.ToString());
        }
    }
}
