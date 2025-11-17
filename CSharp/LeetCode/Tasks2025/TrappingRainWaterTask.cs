namespace LeetCode.Tasks2025;

public class TrappingRainWaterTask
{
    /*42. Trapping Rain Water
    Given n non-negative integers representing an elevation map where the width of each bar is 1,
    compute how much water it can trap after raining.

     **
     ****  **
     ********
    */

    public int Trap1(int[] height)
    {
        var ladder = new Stack<int>();
        var water = 0;

        for (var i = 0; i < height.Length; i++)
        {
            var right = height[i];

            while (ladder.Count > 0 && right > height[ladder.Peek()])
            {
                var low = ladder.Pop();

                if (!ladder.TryPeek(out var j))
                {
                    break;
                }

                var width = i - j - 1;
                var h = Math.Min(height[i], height[j]) - height[low];
                water += width * h;
            }

            ladder.Push(i);
        }

        return water;
    }

    public int Trap(int[] height)
    {
        var n = height.Length;

        var leftMax = 0;
        var rightMax = 0;

        var left = 0;
        var right = n - 1;

        var totalWater = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                leftMax = Math.Max(leftMax, height[left]); // Update max left
                totalWater += leftMax - height[left]; // Update total water
                left++; // Move left forward
            }
            else
            {
                rightMax = Math.Max(rightMax, height[right]); // Update max right
                totalWater += rightMax - height[right]; // Update total water
                right--; // Move right backward
            }
        }

        return totalWater;
    }
}
