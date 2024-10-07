public class Solution
{
  public int NumIslands(char[][] grid)
  {
    return NumIslandsDFS(grid);
  }

  private int NumIslandsDFS(char[][] grid)
  {
    if (grid == null)
      return 0;

    int count = 0;
    for (int i = 0; i < grid.Length; i++)
    {
      for (int j = 0; j < grid[0].Length; j++)
      {
        if (grid[i][j] == '1')
        {
          DFS(grid, i, j);
          count++;
        }
      }
    }
    return count;
  }

  private void DFS(char[][] grid, int i, int j)
  {
    if (grid[i][j] != '1')
      return;

    grid[i][j] = '#';
    (int, int)[] directions = [(0, 1), (0, -1), (1, 0), (-1, 0)];
    foreach (var direction in directions)
    {
      var nextI = i + direction.Item1;
      var nextJ = j + direction.Item2;
      if (nextI >= 0 && nextJ >= 0 && nextI < grid.Length && nextJ < grid[0].Length)
        DFS(grid, nextI, nextJ);
    }
  }

  private int NumIslandsBFS(char[][] grid)
  {
    if (grid == null)
      return 0;

    int count = 0;
    for (int i = 0; i < grid.Length; i++)
    {
      for (int j = 0; j < grid[0].Length; j++)
      {
        if (grid[i][j] == '1')
        {
          BFS(grid, i, j);
          count++;
        }
      }
    }
    return count;
  }

  private void BFS(char[][] grid, int i, int j)
  {
    Queue<(int, int)> queue = new Queue<(int, int)>();
    queue.Enqueue((i, j));
    while (queue.Count > 0)
    {
      (int curI, int curJ) = queue.Dequeue();
      grid[curI][curJ] = '#';
      (int, int)[] directions = [(0, 1), (0, -1), (1, 0), (-1, 0)];
      foreach (var direction in directions)
      {
        var nextI = curI + direction.Item1;
        var nextJ = curJ + direction.Item2;
        if (nextI >= 0 && nextJ >= 0 && nextI < grid.Length && nextJ < grid[0].Length && grid[nextI][nextJ] == '1')
          queue.Enqueue((nextI, nextJ));
      }
    }
  }
}