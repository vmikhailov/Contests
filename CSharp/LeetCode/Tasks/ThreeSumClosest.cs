using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace LeetCode
{
	public class ThreeSumClosest
	{
		public static int Compute(int[] nums, int target)
		{
			int FindClosest(int[] nums, int index, int value)
			{
				var a = Array.BinarySearch(nums, index, nums.Length - index, value);
				if (a >= 0)
				{
					return nums[a];
				}

				a = ~a;

				if (a <= index)
				{
					return nums[index];
				}

				if (a == nums.Length || Math.Abs(value - nums[a - 1]) < Math.Abs(value - nums[a]))
				{
					return nums[a - 1];
				}
				else
				{
					return nums[a];
				}
			}
			
			var d = int.MaxValue;
			var f = int.MaxValue;

			Array.Sort(nums);

			for (var i = 0; i < nums.Length; i++)
			{
				for (var j = i + 1; j < nums.Length; j++)
				{
					var a = nums[i] + nums[j];
					var b = target - a;
					if (nums.Length - j - 1 > 0)
					{
						var c = FindClosest(nums, j + 1, b);
						var s = a + c;
						if (s == target)
						{
							return s;
						}

						if (d > Math.Abs(target - s))
						{
							f = s;
							d = Math.Abs(target - s);
						}
					}
				}
			}

			return f;
		}
	}

	[TestFixture]
	public class ThreeSumClosestTests
	{
		[Test]
		public void Compute_ExactTarget_ReturnsTarget()
		{
			ClassicAssert.AreEqual(0, ThreeSumClosest.Compute([-1, 2, 1, -4], 1));
		}

		[Test]
		public void Compute_BasicCase_ReturnsClosest()
		{
			ClassicAssert.AreEqual(2, ThreeSumClosest.Compute([-1, 2, 1, -4], 1));
		}

		[Test]
		public void Compute_ThreeElements_ReturnsSum()
		{
			ClassicAssert.AreEqual(6, ThreeSumClosest.Compute([1, 2, 3], 6));
		}

		[Test]
		public void Compute_AllNegative_ReturnsClosest()
		{
			ClassicAssert.AreEqual(-6, ThreeSumClosest.Compute([-3, -2, -1], -5));
		}

		[Test]
		public void Compute_WithZero_ReturnsCorrect()
		{
			ClassicAssert.AreEqual(2, ThreeSumClosest.Compute([0, 1, 2], 3));
		}
	}
}
