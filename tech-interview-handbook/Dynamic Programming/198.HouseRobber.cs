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
        int lastHouse = 0;
        int lastOtherHouse = 0;

        foreach (int num in nums)
        {
            int curHouse = Math.Max(lastOtherHouse + num, lastHouse);
            lastOtherHouse = lastHouse;
            lastHouse = curHouse;
        }

        return lastHouse;
    }
}
