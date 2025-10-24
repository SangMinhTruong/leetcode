public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        return LengthOfLISBinarySearch(nums);
    }

    private int LengthOfLISIterative(int[] nums)
    {
        int[] dp = new int[nums.Length];
        int max = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;

            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j] && 1 + dp[j] > dp[i])
                    dp[i] = 1 + dp[j];
            }

            if (dp[i] > max)
                max = dp[i];
        }

        return max;
    }

    private int LengthOfLISBinarySearch(int[] nums)
    {
        int maxIndex = 0;
        int[] sub = new int[nums.Length];

        foreach (int num in nums)
        {
            int low = 0;
            int high = maxIndex;

            while (low < high)
            {
                int mid = (low + high) / 2;
                if (sub[mid] >= num)
                    high = mid;
                else
                    low = mid + 1;
            }

            sub[high] = num;

            if (high == maxIndex)
                maxIndex++;
        }

        return maxIndex;
    }
}
