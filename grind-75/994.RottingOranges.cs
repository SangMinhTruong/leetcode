public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int countFresh = 0;
        Queue<(int, int)> queue = new Queue<(int, int)>();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 2)
                    queue.Enqueue((i, j));
                else if (grid[i][j] == 1)
                    countFresh++;
            }
        }

        if (countFresh == 0)
            return 0;

        int minute = 0;

        (int, int)[] directions = new (int, int)[4] { (1, 0), (-1, 0), (0, 1), (0, -1) };
        while (queue.Count > 0)
        {
            int curSize = queue.Count;

            while (curSize > 0)
            {
                (int i, int j) = queue.Dequeue();

                foreach ((int dirI, int dirJ) in directions)
                {
                    int newI = i + dirI;
                    int newJ = j + dirJ;

                    if (newI < 0 || newI >= m || newJ < 0 || newJ >= n || grid[newI][newJ] != 1)
                        continue;

                    grid[newI][newJ] = 2;
                    countFresh--;

                    queue.Enqueue((newI, newJ));
                }

                curSize--;
            }

            minute++;
        }

        return countFresh == 0 ? minute - 1 : -1;
    }
}
