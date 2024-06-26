using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinWire.Console.Linq
{
    public static class JoinQueries
    {
        public static IEnumerable<dynamic> CrossJoin()
        {
            List<string> colors = new List<string> { "Red", "Green", "Blue" };
            List<string> items = new List<string> { "Pen", "Book", "Glass" };

            var crossJoin = from color in colors
                            from item in items
                            select new { Color = color, Item = item };

            return crossJoin;
        }
    }
}
