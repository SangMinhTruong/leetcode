/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution
{
    public Node CloneGraph(Node node)
    {
        return CloneGraphDFS(node, new Dictionary<Node, Node>());
    }

    private Node CloneGraphDFS(Node node, Dictionary<Node, Node> copies)
    {
        if (node == null)
            return null;

        if (!copies.ContainsKey(node))
        {
            copies[node] = new Node(node.val, new List<Node>());

            foreach (Node neighbor in node.neighbors)
            {
                copies[node].neighbors.Add(CloneGraphDFS(neighbor, copies));
            }
        }

        return copies[node];
    }
}
