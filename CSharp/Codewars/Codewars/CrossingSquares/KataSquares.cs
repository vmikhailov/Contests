using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codewars.Codewars.CrossingSquares
{
    public static class KataSquares
    {
        public static long Calculate(IEnumerable<int[]> rectangles)
        {
            var field = new HashSet<Rectangle>();
            var listOfRectangles = rectangles.Select(x => new Rectangle(x)).Where(x => x.Square() > 0)
                                             .OrderBy(x => x.X1*x.Y1)
                                             .ToList();
            var n = listOfRectangles.Count();

            var xx = new IntervalLine<int, Rectangle>();
            var yy = new IntervalLine<int, Rectangle>();

            foreach (var r in listOfRectangles)
            {
                var xi = xx.GetIntersections(r.X1, r.X2);
                var yi = yy.GetIntersections(r.Y1, r.Y2);
                var inter = xi.Intersect(yi).ToList();

                var slices = new HashSet<Rectangle> { r };
                foreach (var original in inter)
                {
                    var toSlice = slices.Where(x => x.HasIntersectionWith(original)).ToList();
                    foreach (var rect in toSlice)
                    {
                        if (!rect.IsCoveredBy(original))
                        {
                            var newSlices = rect.Exclude(original);
                            if (newSlices != null)
                            {
                                slices.Remove(rect);

                                if (newSlices[0] != original)
                                {
                                    field.Remove(original);
                                    xx.RemoveInterval(r.X1, r.X2, original);
                                    yy.RemoveInterval(r.Y1, r.Y2, original);
                                    slices.AddRange(newSlices);
                                }
                                else
                                {
                                    slices.AddRange(newSlices[1..]);
                                }
                            }
                            else
                            {
                                Debug.WriteLine("WTF");
                            }
                        }
                        else
                        {
                            slices.Remove(rect);
                        }
                    }
                }

                foreach (var slice in slices)
                {
                    field.Add(slice);
                    xx.AddInterval(slice.X1, slice.X2, slice);
                    yy.AddInterval(slice.Y1, slice.Y2, slice);
                }
            }
            
            var s = field.Select(x => x.Square()).Sum();

            return s;
        }

        private static void AddRange<T>(this ISet<T> set, IEnumerable<T> values)
        {
            foreach (var v in values)
            {
                set.Add(v);
            }
        }
    }

    /*
    if(Environment.StackTrace.Contains("DifficultCommonFaces") || stop)
    {
    stop = true;
    return rectangles.Count();
    }*/
}