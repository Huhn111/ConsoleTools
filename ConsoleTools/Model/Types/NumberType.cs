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
        private int _minWidth;
        private int _maxWidth;

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

        protected override int GetMaxWidth() => _maxWidth;
        protected override int GetMinWidth() => _minWidth ;

        protected override string ConvertToString(T element)
        {
            var text = element.ToString() ?? String.Empty;

            if (text.Length > MaxWidth)
                text = $"{element:e0}";

            return text;
        }

        protected override int GetElemetLength(T element)
        {
            var text = element.ToString() ?? String.Empty;
            var convertedLength = ConvertToString(element).Length;

            if (text.Length > MaxWidth)
            {
                _minWidth = convertedLength;

                if (convertedLength > MaxWidth)
                    _maxWidth = convertedLength;
            }

            return convertedLength;
        }
    }
}
