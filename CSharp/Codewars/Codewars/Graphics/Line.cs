using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Codewars.Codewars.Graphics
{
    //Clear() //clears Canvas for new drawing(s)
    //ShowCanvas("Y", ref Drawing.Canvas) //here "Y" is the sign for your pixel as string output
    public class Graphics
    {
        private static bool[,] Canvas = new bool[Width, Height];

        private const int Width = 100, Height = 50;

        public void drawLine(int x1, int y1, int x2, int y2)
        {
            var dx = x2 - x1;
            var dy = y2 - y1;
            var sx = Math.Sign(dx);
            var sy = Math.Sign(dy);

            if (dx * sx > dy * sy)
            {
                //by x
                for (var x = 0; x <= dx * sx; x++)
                {
                    var y = x * dy / dx;
                    SetPixel(x * sx + x1, y + y1);
                }
            }
            else
            {
                //by y
                for (var y = 0; y <= dy * sy; y++)
                {
                    var x = y * sy * dx / dy;
                    SetPixel(x + x1, y * sy + y1);
                }
            }

            Print(Canvas);
        }

        public void drawCircle(int x0, int y0, int r)
        {
            var x = 0;
            var y = r;
            var delta = 1 - 2 * r;
            while (y >= 0)
            {
                SetPixel(x0 + x, y0 + y);
                SetPixel(x0 - x, y0 + y);
                SetPixel(x0 + x, y0 - y);
                SetPixel(x0 - x, y0 - y);
                var error = 2 * (delta + y) - 1;
                if ((delta < 0) && (error <= 0))
                {
                    delta += 2 * ++x + 1;

                    continue;
                }

                if ((delta > 0) && (error > 0))
                {
                    delta -= 2 * --y + 1;

                    continue;
                }

                delta += 2 * (++x - --y);
            }
        }

        private void Print(bool[,] canvas)
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    Debug.Write(Canvas[i, j] ? "*" : ".");
                }

                Debug.WriteLine("");
            }
        }

        private void SetPixel(int x, int y)
        {
            if (0 <= x && x < Width && 0 <= y && y < Height)
            {
                Canvas[x, y] = true;
            }
        }
    }

    [TestFixture]
    public class smile67KataTest
    {
        Graphics draw = new Graphics();
        const string noError = "Your graphic output is ok, so your solution is accepted, here's the image:\r\n";

        [Test]
        public void smile67KataTest_withoutRandom1()
        {
            draw.drawLine(0, 0, 50, 30);
        }

        [Test]
        public void smile67KataTest_withoutRandom2()
        {
            draw.drawLine(70, 40, 10, 20);
        }

        [Test]
        public void smile67KataTest_withoutRandom3()
        {
            draw.drawLine(-100, -50, 200, 80);
        }

        [Test]
        public void smile67KataTest_withoutRandom4()
        {
            draw.drawLine(-30, 100, 150, -100);
        }

        [Test]
        public void smile67KataTest_withoutRandom5()
        {
            draw.drawLine(80, 5, 12, 46);
        }
    }
}