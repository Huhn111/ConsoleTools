using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools
{
    public class ResultHandler
    {
        //2te Methode mit RowType anstat propertyNames
        //RowType:
        //  [1][ ] - PropertyNames <- String
        //  [1][ ] - MinWidth   | Was machen bei        |
        //  [1][ ] - MaxWidth   | float/double? -> Ctor | => Extraclasse
        //  [1][ ] - Orientation (Left/Right/Center) <- Enum
        //  [1][ ] - Display of null/default
        //  [2][ ] - DataType   <- String/Type          |
        //  [3][ ] - CustomConverter (overwritable Methods/ Interface)
        public void PrintClassAsTable<T>(IEnumerable<T> elements, params string[] propertyNames)
        {
            List<int> lengths = new();

            //Refactor GetLength
            //Safe MaxLEngth in Class
            foreach (var name in propertyNames)
            {
                var entries = elements.Select(c => c.GetType()?
                                      .GetProperty(name)?
                                      .GetValue(c)?
                                      .ToString());

                var maxLength = entries.Max(e => e?.Length ?? 0);

                if (maxLength < name.Length)
                    maxLength = name.Length;

                lengths.Add(maxLength);
            }

            //HelperClass ??
            //Print Header
            //Console.WriteLine(GenerateHeaderLine(lengths, propertyNames));
            //Print Seperator
            //Console.WriteLine(GenerateSaperator(lengths));
            //Print result-
            //foreach (var item in elements)
            //    Console.WriteLine(GenerateLine(item, lengths, propertyNames));
        }

    }
}
