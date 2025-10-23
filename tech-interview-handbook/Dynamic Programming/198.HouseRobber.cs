public class Solution
{
    public int Rob(int[] nums)
    {
        return RobIterative(nums);
    }

    private int RobRecursive(int[] nums, int i, int?[] memo)
    {
        if (i < 0)
            return 0;

        if (memo[i] != null)
            return memo[i].Value;

        memo[i] = Math.Max(
            RobRecursive(nums, i - 2, memo) + nums[i],
            RobRecursive(nums, i - 1, memo)
        );

        return memo[i].Value;
    }

    private int RobIterative(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        int prev1 = 0;
        int prev2 = 0;

        foreach (int num in nums)
        {
            int cur = Math.Max(prev1 + num, prev2);
            prev1 = prev2;
            prev2 = cur;
        }

        return prev2;
    }
}
