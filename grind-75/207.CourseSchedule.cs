public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        IList<int>[] outNodes = new List<int>[numCourses];
        int[] inNodeCounts = new int[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            outNodes[i] = new List<int>();
        }

        foreach (int[] pre in prerequisites)
        {
            int nodeId = pre[0];
            int preId = pre[1];

            inNodeCounts[nodeId]++;
            outNodes[preId].Add(nodeId);
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (inNodeCounts[i] == 0)
                queue.Enqueue(i);
        }

        int completed = 0;

        while (queue.Count > 0)
        {
            int curNodeId = queue.Dequeue();

            foreach (int outNodeId in outNodes[curNodeId])
            {
                inNodeCounts[outNodeId]--;

                if (inNodeCounts[outNodeId] == 0)
                    queue.Enqueue(outNodeId);
            }

            completed++;
        }

        return completed == numCourses;
    }
}
