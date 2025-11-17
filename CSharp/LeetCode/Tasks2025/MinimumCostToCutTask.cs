namespace LeetCode.Tasks2025;

public class MinimumCostToCutTask
{
    /*
    Given a wooden stick of length n units. The stick is labelled from 0 to n. For example, a stick of length 6 is labelled as follows:
    Given an integer array cuts where cuts[i] denotes a position you should perform a cut at.
    You should perform the cuts in order, you can change the order of the cuts as you wish.
    The cost of one cut is the length of the stick to be cut, the total cost is the sum of costs of all cuts. When you cut a stick, it will be split into two smaller sticks (i.e. the sum of their lengths is the length of the stick before the cut). Please refer to the first example for a better explanation.
    Return the minimum total cost of the cuts.
     */
    public int MinCost(int n, int[] cuts)
    {
        Array.Sort(cuts);

        var totalPositions = cuts.Length + 2;
        var positions = new int[totalPositions];

        positions[0] = 0;
        positions[totalPositions - 1] = n;

        for (var i = 0; i < cuts.Length; i++)
        {
            positions[i + 1] = cuts[i];
        }

        var minCosts = new int[totalPositions, totalPositions];

        for (var len = 2; len < totalPositions; len++)
        {
            // segment length by indices
            for (var left = 0; left + len < totalPositions; left++)
            {
                var right = left + len;
                var minSegmentCost = int.MaxValue;

                for (var cut = left + 1; cut < right; cut++)
                {
                    var currentStickLength = positions[right] - positions[left];
                    var cost = currentStickLength + minCosts[left, cut] + minCosts[cut, right];
                    minSegmentCost = Math.Min(cost, minSegmentCost);
                }

                minCosts[left, right] = minSegmentCost == int.MaxValue ? 0 : minSegmentCost;
            }
        }

        return minCosts[0, totalPositions - 1];
    }
}
