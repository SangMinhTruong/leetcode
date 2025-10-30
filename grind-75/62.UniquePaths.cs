public class Solution
{
    public int UniquePaths(int m, int n)
    {
        int[,] dp = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                {
                    dp[i, j] = 1;
                    continue;
                }

                int pathsTop = i > 0 ? dp[i - 1, j] : 0;
                int pathsLeft = j > 0 ? dp[i, j - 1] : 0;

                dp[i, j] = pathsTop + pathsLeft;
            }
        }

        return dp[m - 1, n - 1];
    }
}
