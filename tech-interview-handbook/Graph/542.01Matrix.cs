public class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        return UpdateMatrixDP(mat);
    }

    private int[][] UpdateMatrixBFS(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 0)
                    queue.Enqueue((i, j));
                else
                    mat[i][j] = -1;
            }
        }

        (int, int)[] directions = new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
        while (queue.Count > 0)
        {
            (int i, int j) = queue.Dequeue();
            foreach ((int dirI, int dirJ) in directions)
            {
                int newI = i + dirI;
                int newJ = j + dirJ;

                if (newI < 0 || newJ < 0 || newI >= m || newJ >= n || mat[newI][newJ] != -1)
                    continue;

                mat[newI][newJ] = mat[i][j] + 1;
                queue.Enqueue((newI, newJ));
            }
        }

        return mat;
    }

    private int[][] UpdateMatrixDP(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        int MAX = m + n;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 0)
                    continue;

                int top = MAX;
                int left = MAX;
                if (i - 1 >= 0)
                    top = mat[i - 1][j];
                if (j - 1 >= 0)
                    left = mat[i][j - 1];

                mat[i][j] = Math.Min(top, left) + 1;
            }
        }

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (mat[i][j] == 0)
                    continue;

                int bottom = MAX;
                int right = MAX;
                if (i + 1 < m)
                    bottom = mat[i + 1][j];
                if (j + 1 < n)
                    right = mat[i][j + 1];

                mat[i][j] = Math.Min(mat[i][j], Math.Min(bottom, right) + 1);
            }
        }

        return mat;
    }
}
