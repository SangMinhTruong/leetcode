public class Solution
{
    public bool CanPartition(int[] nums)
    {
        return CanPartitionKnapsack(nums);
    }

    private bool CanPartitionBacktracking(int[] nums)
    {
        int target = 0;
        foreach (int num in nums)
        {
            target += num;
        }

        if (target % 2 != 0)
            return false;

        target /= 2;

        bool?[,] memo = new bool?[nums.Length, target + 1];

        return Backtracking(nums, 0, target, memo);
    }

    private bool Backtracking(int[] nums, int i, int remaining, bool?[,] memo)
    {
        if (remaining == 0)
            return true;

        if (i >= nums.Length || remaining < 0)
            return false;

        if (memo[i, remaining] != null)
            return memo[i, remaining].Value;

        memo[i, remaining] =
            Backtracking(nums, i + 1, remaining - nums[i], memo)
            || Backtracking(nums, i + 1, remaining, memo);

        return memo[i, remaining].Value;
    }

    private bool CanPartitionKnapsack(int[] nums)
    {
        int target = 0;
        foreach (int num in nums)
        {
            target += num;
        }

        if (target % 2 != 0)
            return false;

        target /= 2;

        bool[,] memo = new bool[nums.Length + 1, target + 1];
        memo[0, 0] = true;

        // Classic knapsack formula: V[i][w] = max(V[i - 1][w], V[i - 1][w - wi] + Vi)
        // This problem formula: B[i][w] = B[i - 1][sum] || B[i - 1][sum - nums[i - 1]]
        for (int i = 1; i <= nums.Length; i++)
        {
            for (int sum = 0; sum <= target; sum++)
            {
                int curNum = nums[i - 1];

                if (sum - curNum >= 0)
                    memo[i, sum] = memo[i - 1, sum - curNum] || memo[i - 1, sum];
                else
                    memo[i, sum] = memo[i - 1, sum];
            }
        }

        return memo[nums.Length, target];
    }
}
