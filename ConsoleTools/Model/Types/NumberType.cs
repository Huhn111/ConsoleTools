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
    public class NumberType<T> : TypeBase<T> where T : IBinaryNumber<T>
    {
        private readonly int _minWidth;
        private readonly int _maxWidth;

        public NumberType(int width) : this(width, width) { }
        public NumberType(int minWidth, int maxWidth)
        {
            _maxWidth = maxWidth;
            _minWidth = minWidth;
        }
        public NumberType(int width, Orientations orientation) : this(width, width, orientation) { }
        public NumberType(int minWidth, int maxWidth, Orientations orientation) : base(orientation)
        {
            _maxWidth = maxWidth;
            _minWidth = minWidth;
        }

        protected override int CalculateMaxWidth() => _maxWidth;
        protected override int CalculateMinWidth() => _minWidth;

        public override string ConvertToString(T element)
        {
            var text = element.ToString() ?? String.Empty;

            if (text.Length > MaxWidth)
            {
                var scientific = $"{element:e0}";

                if (scientific.Length <= MaxWidth)
                    text = $"{element:e0}";
            }

            return FormatString(text);
        }
    }
}
