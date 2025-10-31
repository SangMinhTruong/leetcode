public class Solution
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (n == 1)
            return new List<int>() { 0 };

        HashSet<int>[] adj = new HashSet<int>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = new HashSet<int>();
        }

        foreach (int[] edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            if (adj[i].Count == 1)
                queue.Enqueue(i);
        }

        IList<int> result = new List<int>();

        while (queue.Count > 0)
        {
            result = new List<int>();
            int curLeafCount = queue.Count;

            while (curLeafCount > 0)
            {
                int curLeaf = queue.Dequeue();

                result.Add(curLeaf);

                if (adj[curLeaf].Count == 0) // We reach the last node
                    break;

                int adjNode = adj[curLeaf].Single(); // There is always only 1 adj node

                adj[adjNode].Remove(curLeaf);

                if (adj[adjNode].Count == 1)
                    queue.Enqueue(adjNode);

                curLeafCount--;
            }
        }

        return result;
    }
}
