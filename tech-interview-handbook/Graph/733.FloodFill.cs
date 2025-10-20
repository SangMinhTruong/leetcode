public class Solution
{
    int[] DIR = new int[] { 0, 1, 0, -1, 0 };

    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        return FloodFillBFS(image, sr, sc, color);
    }

    private int[][] FloodFillDFS(int[][] image, int sr, int sc, int color)
    {
        if (image[sr][sc] == color)
            return image;

        var oldColor = image[sr][sc];
        image[sr][sc] = color;

        for (int i = 0; i < 4; i++)
        {
            var nextR = sr + DIR[i];
            var nextC = sc + DIR[i + 1];
            if (
                nextR >= 0
                && nextC >= 0
                && nextR < image.Length
                && nextC < image[0].Length
                && image[nextR][nextC] == oldColor
            )
            {
                FloodFillDFS(image, nextR, nextC, color);
            }
        }

        return image;
    }

    private int[][] FloodFillBFS(int[][] image, int sr, int sc, int color)
    {
        if (image[sr][sc] == color)
            return image;

        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { sr, sc });
        var oldColor = image[sr][sc];

        while (queue.Count > 0)
        {
            int[] curNode = queue.Dequeue();
            image[curNode[0]][curNode[1]] = color;
            for (int i = 0; i < 4; i++)
            {
                var nextR = curNode[0] + DIR[i];
                var nextC = curNode[1] + DIR[i + 1];
                if (
                    nextR < 0
                    || nextC < 0
                    || nextR >= image.Length
                    || nextC >= image[0].Length
                    || image[nextR][nextC] != oldColor
                )
                    continue;
                queue.Enqueue(new int[] { nextR, nextC });
            }
        }

        return image;
    }
}
