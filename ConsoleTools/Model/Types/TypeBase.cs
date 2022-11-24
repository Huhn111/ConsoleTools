using ConsoleTools.Enums;
using ConsoleTools.Exceptions;
using ConsoleTools.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleTools.Model.Types
{
    public abstract class TypeBase<T>
    {
        protected readonly Orientations _orientation;
        public int MinWidth { get => GetMinWidth(); }
        public int MaxWidth { get => GetMaxWidth(); }
        public int ActualMaxWidth { get; set; }
        public Orientations Orientation { get => _orientation; }

        public TypeBase() { _orientation = Orientations.Left; }
        public TypeBase(Orientations orientation) { _orientation = orientation; }

        protected abstract int GetMaxWidth();
        protected abstract int GetMinWidth();
        protected abstract string ConvertToString(T element);
        protected virtual string FormatString(string? element)
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

        protected virtual int GetElemetLength(T element) => ConvertToString(element).Length;
        public virtual string GetFormatedString(T element) => FormatString(ConvertToString(element));
        public virtual int GetActualMaxWidth(IEnumerable<T> elementList) => elementList.Select(GetElemetLength).Max();
    }
}
