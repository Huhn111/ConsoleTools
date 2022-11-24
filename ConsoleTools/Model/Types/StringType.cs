using ConsoleTools.Enums;
using ConsoleTools.Exceptions;
using ConsoleTools.Extentions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Model.Types
{
    public class StringType : TypeBase<string>
    {
        private readonly int _minWidth;
        private readonly int _maxWidth;

        public StringType(int width) : this(width, width) { }
        public StringType(int minWidth, int maxWidth) 
        {
            _maxWidth = maxWidth;
            _minWidth = minWidth;
        }
        public StringType(int width, Orientations orientation) : this(width, width, orientation) { }
        public StringType(int minWidth, int maxWidth, Orientations orientation) : base(orientation) 
        {
            _maxWidth = maxWidth;
            _minWidth = minWidth;
        }

        protected override int CalculateMaxWidth() => _maxWidth;
        protected override int CalculateMinWidth() => _minWidth;

        public override string ConvertToString(string element)
        {
            return FormatString(element);
        }
    }
}
