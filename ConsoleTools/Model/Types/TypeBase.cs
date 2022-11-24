using ConsoleTools.Enums;
using ConsoleTools.Exceptions;
using ConsoleTools.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Model.Types
{
    public abstract class TypeBase<T>
    {
        protected readonly Orientations _orientation;
        public int MinWidth { get => CalculateMinWidth(); }
        public int MaxWidth { get => CalculateMaxWidth(); }
        public Orientations Orientation { get => _orientation; }

        public int ActualWidth { get; set; }

        public TypeBase() { _orientation = Orientations.Left; }
        public TypeBase(Orientations orientation) { _orientation = orientation; }

        protected abstract int CalculateMaxWidth();
        protected abstract int CalculateMinWidth();
        public abstract string ConvertToString(T element);

        public virtual string FormatString(string? element)
        {
            var text = element ?? string.Empty;

            if (text.Length > MaxWidth)
                text = string.Concat(text.AsSpan(0, MaxWidth - 3), "...");

            return Orientation switch
            {
                Orientations.Left => text.PadRight(MinWidth),
                Orientations.Right => text.PadLeft(MinWidth),
                Orientations.Center => text.PadCenter(MinWidth),
                _ => throw new NotImplementedOrientationException(Orientation)
            };
        }
    }
}
