public class Solution
{
    // F(n) = F(n - 1) + F(n - 2)

    public int ClimbStairs(int n)
    {
        return ClimbStairsIterative(n);
    }

    private int ClimbStairsRecursion(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        return ClimbStairsRecursion(n - 1) + ClimbStairsRecursion(n - 2);
    }

    private int ClimbStairsMemo(int n, Dictionary<int, int> memo)
    {
        if (n == 0 || n == 1)
            return 1;
        if (!memo.ContainsKey(n))
            memo.Add(n, ClimbStairsMemo(n - 1, memo) + ClimbStairsMemo(n - 2, memo));
        return memo[n];
    }

    private int ClimbStairsDP(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = dp[1] = 1;
        for (int i = 2; i <= n; i++)
            dp[i] = dp[i - 1] + dp[i - 2];
        return dp[n];
    }

    private int ClimbStairsIterative(int n)
    {
        int first = 1;
        int second = 1;
        int result = first;
        for (int i = 2; i <= n; i++)
        {
            result = first + second;
            second = first;
            first = result;
        }
        return result;
    }
}
