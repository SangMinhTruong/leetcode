public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        int[] taskCounts = new int[26];
        foreach (char task in tasks)
        {
            taskCounts[task - 'A']++;
        }

        PriorityQueue<char, int> queue = new PriorityQueue<char, int>(new TaskQueueComparer());
        for (int i = 0; i < taskCounts.Length; i++)
        {
            if (taskCounts[i] > 0)
                queue.Enqueue((char)('A' + i), taskCounts[i]);
        }

        int total = 0;
        while (queue.Count > 0)
        {
            int interval = n + 1;
            List<(char, int)> reEnqueue = new List<(char, int)>();

            while (interval > 0 && queue.Count > 0)
            {
                char task = queue.Dequeue();

                taskCounts[task - 'A']--;

                reEnqueue.Add((task, taskCounts[task - 'A']));

                interval--;
                total++;
            }

            foreach ((char task, int count) in reEnqueue)
            {
                if (count > 0)
                    queue.Enqueue(task, count);
            }

            if (queue.Count == 0)
                break;

            total += interval;
        }

        return total;
    }

    private class TaskQueueComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}
