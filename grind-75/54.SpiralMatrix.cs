public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();
        int n = matrix.Length;
        int m = matrix[0].Length;

        int left = 0;
        int right = m - 1;
        int up = 0;
        int down = n - 1;

        while (result.Count < m * n)
        {
            for (int i = left; i <= right && result.Count < m * n; i++)
                result.Add(matrix[up][i]);

            for (int i = up + 1; i <= down - 1 && result.Count < m * n; i++)
                result.Add(matrix[i][right]);

            for (int i = right; i >= left && result.Count < m * n; i--)
                result.Add(matrix[down][i]);

            for (int i = down - 1; i >= up + 1 && result.Count < m * n; i--)
                result.Add(matrix[i][left]);

            left++;
            right--;
            up++;
            down--;
        }

        return result;
    }
}
