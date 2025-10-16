public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

        List<int[]> result = new List<int[]>() { intervals[0] };
        foreach (var interval in intervals)
        {
            if (interval[0] <= result[result.Count - 1][1])
                result[result.Count - 1][1] = Math.Max(interval[1], result[result.Count - 1][1]);
            else
                result.Add(interval);
        }

        return result.ToArray();
    }
}
