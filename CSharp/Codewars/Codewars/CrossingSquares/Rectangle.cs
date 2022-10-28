using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codewars.Codewars.CrossingSquares
{
    public class Rectangle
    {
        public int X1 { get; }
        public int Y1 { get; }
        public int X2 { get; }
        public int Y2 { get; }

        private (int x, int y, bool xinc, bool yinc)[] _corners;

        public Rectangle(int[] coords)
            : this(coords[0], coords[1], coords[2], coords[3])
        {
        }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            X1 = x1 < x2 ? x1 : x2;
            Y1 = y1 < y2 ? y1 : y2;
            X2 = x1 < x2 ? x2 : x1;
            Y2 = y1 < y2 ? y2 : y1;
        }

        public bool HasIntersectionWith(Rectangle r) =>
            r.Corners.Any(PointInside) || Corners.Any(r.PointInside) ||
            r.X1 < X1 && X2 < r.X2 && Y1 < r.Y1 && r.Y2 < Y2 ||
            X1 < r.X1 && r.X2 < X2 && r.Y1 < Y1 && Y2 < r.Y2;
         
        public bool IsCoveredBy(Rectangle r) => r.X1 <= X1 && r.Y1 <= Y1 && r.X2 >= X2 && r.Y2 >= Y2;

        private bool PointInside((int x, int y, bool xinc, bool yinc) c)
        {
            return (X1 <= c.x && c.xinc || X1 < c.x) &&
                   (Y1 <= c.y && c.yinc || Y1 < c.y) &&
                   (X2 >= c.x && !c.xinc || X2 > c.x) &&
                   (Y2 >= c.y && !c.yinc || Y2 > c.y);
        }


        public (int x, int y, bool xinc, bool yinc)[] Corners =>
            _corners ??= new[]
            {
                (X1, Y1, true, true),
                (X2, Y1, false, true),
                (X2, Y2, false, false),
                (X1, Y2, true, false)
            };

        public long Square() => (long)(X2 - X1) * (Y2 - Y1);

        public Rectangle[] Exclude(Rectangle r)
        {
            return ExcludeImpl(r).Where(x => x.Square() > 0).ToArray();
        }

        private IEnumerable<Rectangle> ExcludeImpl(Rectangle r)
        {
            if (IsCoveredBy(r)) return new[] { r };
            if (!HasIntersectionWith(r)) return new[] { r, this };

            // number of points inside
            var numberOfPointsInside1 = r.Corners.Count(PointInside);
            switch (numberOfPointsInside1)
            {
                case 1: return OneCorner(r);
                case 2: return TwoCornersDirect(r);
                case 4: return new[] { this };
            }

            // inverted case: number of points inside
            var numberOfPointsInside2 = Corners.Count(r.PointInside);
            if (numberOfPointsInside2 == 2)
            {
                return TwoCornersInverted(r);
            }

            //mid part overlap 
            return MidOverlap(r);
        }

        private IEnumerable<Rectangle> OneCorner(Rectangle r)
        {
            var points = r.Corners.Select((p, i) => new { p, i }).Where(x => PointInside(x.p)).Select(x => x.i + 1).ToList();

            if (points.Count != 1)
            {
                Debug.WriteLine("WTF");
            }

            var point = points.Single();

            yield return r;

            switch (point)
            {
                case 1:
                    yield return new Rectangle(X1, r.Y1, r.X1, Y2);
                    yield return new Rectangle(X1, Y1, X2, r.Y1);

                    yield break;
                case 2:
                    yield return new Rectangle(r.X2, r.Y1, X2, Y2);
                    yield return new Rectangle(X1, Y1, X2, r.Y1);

                    yield break;
                case 3:
                    yield return new Rectangle(r.X2, Y1, X2, r.Y2);
                    yield return new Rectangle(X1, r.Y2, X2, Y2);

                    yield break;
                case 4:
                    yield return new Rectangle(X1, Y1, r.X1, r.Y2);
                    yield return new Rectangle(X1, r.Y2, X2, Y2);

                    yield break;
            }
        }

        private IEnumerable<Rectangle> TwoCornersDirect(Rectangle r)
        {
            var points = r.Corners.Select((p, i) => new { p, i }).Where(x => PointInside(x.p)).ToArray();
            var corners = points.Select(x => x.i + 1).ToArray();

            yield return r;

            if (corners.SequenceEqual(new[] { 3, 4 }))
            {
                //top
                yield return new Rectangle(X1, r.Y2, X2, Y2);
                yield return new Rectangle(X1, Y1, r.X1, r.Y2);
                yield return new Rectangle(r.X2, Y1, X2, r.Y2);
            }
            else if (corners.SequenceEqual(new[] { 1, 4 }))
            {
                //right
                yield return new Rectangle(X1, Y1, r.X1, Y2);
                yield return new Rectangle(r.X1, Y1, X2, r.Y1);
                yield return new Rectangle(r.X1, r.Y2, X2, Y2);
            }
            else if (corners.SequenceEqual(new[] { 1, 2 }))
            {
                //bottom
                yield return new Rectangle(X1, Y1, X2, r.Y1);
                yield return new Rectangle(X1, r.Y1, r.X1, Y2);
                yield return new Rectangle(r.X2, r.Y1, X2, Y2);
            }
            else if (corners.SequenceEqual(new[] { 2, 3 }))
            {
                //left
                yield return new Rectangle(r.X2, Y1, X2, Y2);
                yield return new Rectangle(X1, Y1, r.X2, r.Y1);
                yield return new Rectangle(X1, r.Y2, r.X2, Y2);
            }
        }

        private IEnumerable<Rectangle> TwoCornersInverted(Rectangle r)
        {
            var points = Corners.Select((p, i) => new { p, i }).Where(x => r.PointInside(x.p)).ToArray();
            var corners = points.Select(x => x.i + 1).ToArray();

            yield return r;
            if (corners.SequenceEqual(new[] { 3, 4 }))
            {
                //top
                yield return new Rectangle(X1, Y1, X2, r.Y1);
            }
            else if (corners.SequenceEqual(new[] { 1, 4 }))
            {
                //right
                yield return new Rectangle(r.X2, Y1, X2, Y2);
            }
            else if (corners.SequenceEqual(new[] { 1, 2 }))
            {
                //bottom
                yield return new Rectangle(X1, r.Y2, X2, Y2);
            }
            else if (corners.SequenceEqual(new[] { 2, 3 }))
            {
                //left
                yield return new Rectangle(X1, Y1, r.X1, Y2);
            }
        }

        private IEnumerable<Rectangle> MidOverlap(Rectangle r)
        {
            yield return r;
            if (X1 < r.X1)
            {
                yield return new Rectangle(X1, Y1, r.X2, Y2);
                yield return new Rectangle(r.X2, Y1, X2, Y2);
            }
            else
            {
                yield return new Rectangle(X1, Y1, X2, r.Y1);
                yield return new Rectangle(X1, r.Y2, X2, Y2);
            }
        }

        public override int GetHashCode()
        {
            return (X1 * 239) ^ (X2 * 719) ^ (Y1 * 1321) ^ (Y2 * 1747);
        }

        public override bool Equals(object obj)
        {
            var r = obj as Rectangle;

            if (r == null) return false;

            return X1 == r.X1 && X2 == r.X2 && Y1 == r.Y1 && Y2 == r.Y2;
        }
    }
}