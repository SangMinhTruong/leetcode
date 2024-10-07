public class Solution
{
  int[] DIR = new int[] { 0, 1, 0, -1, 0 };

  public int[][] UpdateMatrix(int[][] mat)
  {
    return UpdateMatrixDP(mat);
  }

  private int[][] UpdateMatrixBFS(int[][] mat)
  {
    int m = mat.Length;
    int n = mat[0].Length;

    Queue<int[]> queue = new Queue<int[]>();
    for (int i = 0; i < m; i++)
    {
      for (int j = 0; j < n; j++)
      {
        if (mat[i][j] == 0)
          queue.Enqueue(new int[] { i, j });
        else
          mat[i][j] = -1;
      }
    }

    while (queue.Count > 0)
    {
      int[] cur = queue.Dequeue();
      int r = cur[0], c = cur[1];
      for (int i = 0; i < 4; i++)
      {
        int nr = r + DIR[i];
        int nc = c + DIR[i + 1];
        if (nr < 0 || nc < 0 || nr >= m || nc >= n || mat[nr][nc] != -1)
          continue;
        mat[nr][nc] = mat[r][c] + 1;
        queue.Enqueue(new int[] { nr, nc });
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

        int top = MAX, left = MAX;
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

        int bottom = MAX, right = MAX;
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