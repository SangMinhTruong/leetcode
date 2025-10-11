public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        return MaxSubArrayKadane(nums);
    }

    private int MaxSubArrayRecursionMemo(int[] nums)
    {
        int[,] memo = new int[2, nums.Length];
        for (int i = 0; i < 2; i++)
        for (int j = 0; j < nums.Length; j++)
            memo[i, j] = -1;

        return MaxSubArrayRecursionMemo(nums, 0, false, memo);
    }

    private int MaxSubArrayRecursionMemo(int[] nums, int i, bool mustPick, int[,] memo)
    {
        if (i >= nums.Length)
            return mustPick ? 0 : Int32.MinValue;

        int mustPickIndex = mustPick ? 1 : 0;

        if (memo[mustPickIndex, i] != -1)
            return memo[mustPickIndex, i];

        if (mustPick)
            memo[mustPickIndex, i] = Math.Max(
                0,
                nums[i] + MaxSubArrayRecursionMemo(nums, i + 1, true, memo)
            );
        else
            memo[mustPickIndex, i] = Math.Max(
                MaxSubArrayRecursionMemo(nums, i + 1, false, memo),
                nums[i] + MaxSubArrayRecursionMemo(nums, i + 1, true, memo)
            );

        return memo[mustPickIndex, i];
    }

    private int MaxSubArrayTabulation(int[] nums)
    {
        int[,] tabulation = new int[2, nums.Length];

        tabulation[1, 0] = nums[0];
        tabulation[0, 0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            tabulation[1, i] = Math.Max(nums[i], nums[i] + tabulation[1, i - 1]);
            tabulation[0, i] = Math.Max(tabulation[0, i - 1], tabulation[1, i]);
        }

        return tabulation[0, nums.Length - 1];
    }

    private int MaxSubArrayKadane(int[] nums)
    {
        int currentMax = 0;
        int max = Int32.MinValue;

        foreach (int num in nums)
        {
            currentMax = Math.Max(num, currentMax + num);
            max = Math.Max(currentMax, max);
        }

        return max;
    }

    // [-2,1,-3,4,-1,2,1,-5,4]
    // [ 0,0, 1,0, 4,3,5, 6,1]
    // [ 4,3, 6,2, 3,1,0, 4,0]
    //
    // [2,4,4,6,6,6,6,5,5]
    private int MaxSubArrayDivideAndConquer(int[] nums)
    {
        int[] pre = new int[nums.Length];
        int[] suf = new int[nums.Length];

        for (int i = 1; i < nums.Length; i++)
            pre[i] = Math.Max(0, nums[i - 1] + pre[i - 1]);

        for (int i = nums.Length - 2; i >= 0; i--)
            suf[i] = Math.Max(0, nums[i + 1] + suf[i + 1]);

        return MaxSubArrayDivideAndConquer(nums, 0, nums.Length - 1, pre, suf);
    }

    private int MaxSubArrayDivideAndConquer(int[] nums, int left, int right, int[] pre, int[] suf)
    {
        if (left > right)
            return Int32.MinValue;

        int mid = (left + right) / 2;

        return Math.Max(
            pre[mid] + nums[mid] + suf[mid],
            Math.Max(
                MaxSubArrayDivideAndConquer(nums, left, mid - 1, pre, suf),
                MaxSubArrayDivideAndConquer(nums, mid + 1, right, pre, suf)
            )
        );
    }
}
