public class Solution
{
    public int NumIslands(char[][] grid)
    {
        return NumIslandsDFS(grid);
    }

    private int NumIslandsDFS(char[][] grid)
    {
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
        if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] != '1')
            return;

        grid[i][j] = '#';

        DFS(grid, i + 1, j);
        DFS(grid, i - 1, j);
        DFS(grid, i, j + 1);
        DFS(grid, i, j - 1);
    }

    private int NumIslandsBFS(char[][] grid)
    {
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

            (int, int)[] directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];
            foreach ((int dirI, int dirJ) in directions)
            {
                var nextI = curI + dirI;
                var nextJ = curJ + dirJ;

                if (
                    nextI >= 0
                    && nextJ >= 0
                    && nextI < grid.Length
                    && nextJ < grid[0].Length
                    && grid[nextI][nextJ] == '1'
                )
                    queue.Enqueue((nextI, nextJ));
            }
        }
    }
}
