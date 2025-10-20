public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        return FloodFillDFS(image, sr, sc, color, image[sr][sc]);
    }

    private int[][] FloodFillDFS(int[][] image, int sr, int sc, int color, int oldColor)
    {
        if (
            sr < 0
            || sc < 0
            || sr >= image.Length
            || sc >= image[0].Length
            || image[sr][sc] != oldColor
            || image[sr][sc] == color
        )
            return image;

        image[sr][sc] = color;

        FloodFillDFS(image, sr + 1, sc, color, oldColor);
        FloodFillDFS(image, sr - 1, sc, color, oldColor);
        FloodFillDFS(image, sr, sc + 1, color, oldColor);
        FloodFillDFS(image, sr, sc - 1, color, oldColor);

        return image;
    }

    private int[][] FloodFillBFS(int[][] image, int sr, int sc, int color)
    {
        if (image[sr][sc] == color)
            return image;

        var oldColor = image[sr][sc];

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((sr, sc));

        (int, int)[] directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];
        while (queue.Count > 0)
        {
            (int curR, int curC) = queue.Dequeue();

            image[curR][curC] = color;

            foreach ((int dirR, int dirC) in directions)
            {
                var nextR = curR + dirR;
                var nextC = curC + dirC;

                if (
                    nextR >= 0
                    && nextC >= 0
                    && nextR < image.Length
                    && nextC < image[0].Length
                    && image[nextR][nextC] == oldColor
                )
                    queue.Enqueue((nextR, nextC));
            }
        }

        return image;
    }
}
