using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class BattleshipField
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            var xx = field.GetLength(0);
            var yy = field.GetLength(1);

            field = Expand(field, xx, yy);
            var ships = new Dictionary<int, int>()
            {
                { 1, 4 },
                { 2, 3 },
                { 3, 2 },
                { 4, 1 }
            };
            Print(field);

            var valid = Iterate(
                (0, 0, xx + 1, yy + 1),
                (x, y) =>
                {
                    if (field[x, y] < 1) return true;
                    if (field[x, y] == 1)
                    {
                        var ship = DetectShip(field, x, y);

                        if (!ValidateShip(ship, out var len)) return false;
                        if (!ships.TryGetValue(len, out var cnt) || cnt == 0) return false;
                        ships[len] = cnt - 1;
                        
                        if (!MarkShipAround(field, ship)) return false;
                        Print(field);
                    }

                    return true;
                });

            return valid && ships.Values.Sum() == 0;
        }

        private static bool ValidateShip((int x1, int y1, int x2, int y2) ship, out int len)
        {
            len = 0;
            if (ship.x1 == ship.x2 && ship.y2 != ship.y1)
            {
                len = Math.Abs(ship.y2 - ship.y1 + 1);
            }

            if (ship.x1 != ship.x2 && ship.y2 == ship.y1)
            {
                len = Math.Abs(ship.x2 - ship.x1 + 1);
            }

            if (ship.x1 == ship.x2 && ship.y2 == ship.y1)
            {
                len = 1;
            }

            return len != 0;
        }

        private static (int x1, int y1, int x2, int y2) DetectShip(int[,] field, int x, int y)
        {
            //find ship horizontally and vertically
            (int x1, int y1, int x2, int y2) ship;
            ship.x1 = Extend(field, x, y, -1, 0).x;
            ship.x2 = Extend(field, x, y, 1, 0).x;
            ship.y1 = Extend(field, x, y, 0, -1).y;
            ship.y2 = Extend(field, x, y, 0, 1).y;

            return ship;
        }

        private static (int x, int y) Extend(int[,] field, int x, int y, int dx, int dy)
        {
            while (field[x, y] == 1)
            {
                x += dx;
                y += dy;
            }

            return (x - dx, y - dy);
        }

        private static int[,] Expand(int[,] field, int xx, int yy)
        {
            xx += 2;
            yy += 2;
            var nf = new int[xx, yy];

            Iterate(
                (0, 0, xx - 1, yy - 1),
                (x, y) =>
                {
                    var outside = x == 0 || x == xx - 1 || y == 0 || y == yy - 1;
                    nf[x, y] = outside ? -1 : field[x - 1, y - 1];
                });

            return nf;
        }

        private static bool MarkShipAround(int[,] field, (int x1, int y1, int x2, int y2) ship)
        {
            return Iterate(
                (ship.x1 - 1, ship.y1 - 1, ship.x2 + 1, ship.y2 + 1),
                (x, y) =>
                {
                    if ((ship.x1 > x || x > ship.x2 || ship.y1 > y || y > ship.y2) && field[x,y] == 1)
                    {
                        return false;
                    }

                    field[x, y] = -1;

                    return true;
                });
        }

        private static void Iterate((int x1, int y1, int x2, int y2) range, Action<int, int> action)
        {
            Iterate(
                range,
                (x, y) =>
                {
                    action(x, y);

                    return true;
                });
        }

        private static bool Iterate((int x1, int y1, int x2, int y2) range, Func<int, int, bool> func)
        {
            for (var x = range.x1; x <= range.x2; x++)
            {
                for (var y = range.y1; y <= range.y2; y++)
                {
                    if (!func(x, y)) return false;
                }
            }

            return true;
        }

        private static void Print(int[,] field)
        {
            var l = field.GetLength(0);
            var m = field.GetLength(1);
            Iterate(
                (0, 0, l - 1, m - 1),
                (x, y) =>
                {
                    Console.Write(field[x, y] == -1 ? "*" : field[x, y].ToString());
                    if (y == m - 1)
                    {
                        Console.WriteLine();
                    }
                });
        }
    }
}