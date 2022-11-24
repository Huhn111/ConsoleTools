using ConsoleTools.Enums;
using ConsoleTools.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Model
{
    public class ColumnDefinition<T>
    {
        public string PropertyName { get; private set; }
        public string ColumnName { get; private set; }

        public TypeBase<T> Type { get; set; }

        public ColumnDefinition(string propertyName, TypeBase<T> type)
        {
            PropertyName = propertyName;
            ColumnName = propertyName;
            Type = type;
        }

        public ColumnDefinition(string propertyName, string columnName, TypeBase<T> type)
        {
            PropertyName = propertyName;
            ColumnName = columnName;
            Type = type;
        }

    }
}
