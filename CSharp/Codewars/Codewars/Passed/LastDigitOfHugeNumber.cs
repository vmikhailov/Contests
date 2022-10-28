using System;

namespace Codewars.Codewars.Passed
{
    public static class LastDigitOfHugeNumber
    {
        public static int LastDigit(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 1;

            arr = RemoveZeros(arr);

            var d = arr[0] % 10;

            return arr.Length switch
            {
                1 => d,
                2 => (int)Math.Pow(d, (arr[1] - 1) % 4 + 1) % 10,
                _ => d switch
                {
                    0 => 0,
                    1 => 1,
                    5 => 5,
                    6 => 6,
                    4 => arr[1] % 2 == 0 ? 6 : 4,
                    9 => arr[1] % 2 == 0 ? 1 : 9,
                    2 => (arr[1] % 4) switch
                    {
                        0 => 6,
                        1 => 2,
                        2 => arr[2] == 1 ? 4 : 6,
                        3 => arr[2] % 2 == 1 ? 8 : 2,
                        _ => 0
                    },
                    3 => (arr[1] % 4) switch
                    {
                        0 => 1,
                        1 => 3,
                        2 => arr[2] == 1 ? 9 : 1,
                        3 => arr[2] % 2 == 1 ? 7 : 3,
                        _ => 0
                    },
                    7 => (arr[1] % 4) switch
                    {
                        0 => 1,
                        1 => 7,
                        2 => arr[2] == 1 ? 9 : 1,
                        3 => arr[2] % 2 == 1 ? 3 : 7,
                        _ => 0
                    },
                    8 => (arr[1] % 4) switch
                    {
                        0 => 6,
                        1 => 8,
                        2 => arr[2] == 1 ? 4 : 6,
                        3 => arr[2] % 2 == 1 ? 2 : 8,
                        _ => 0
                    },
                    _ => 0
                }
            };
        }
        
        private static int[] RemoveZeros(int[] arr)
        {
            var cnt = 0;
            var prevIsZero = false;
            for (var i = arr.Length - 1; i >= 0; i--)
            {
                var v = arr[i];
               
                if (prevIsZero)
                {
                    arr[i] = 1;
                    cnt = 1;
                    prevIsZero = false;
                    continue;
                }

                if (v == 0)
                {
                    cnt = 0;
                    prevIsZero = true;
                    continue;
                }

                cnt++;
            }

            if (cnt == 0) return new[] { 0 };
            
            if (cnt < arr.Length)
            {
                var newArray = new int[cnt];
                Array.Copy(arr, newArray, cnt);
            }

            return arr;
        }
    }
}