public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var queue = new PriorityQueue<int[], int>();
        foreach (var point in points)
        {
            var distanceInverse = -DistanceToOriginSquare(point);
            if (queue.Count == k)
                queue.EnqueueDequeue(point, distanceInverse);
            else
                queue.Enqueue(point, distanceInverse);
        }

        int[][] res = new int[k][];
        while (queue.Count > 0)
            res[--k] = queue.Dequeue();

        return res;
    }

    private int DistanceToOriginSquare(int[] point) => point[0] * point[0] + point[1] * point[1];
}
