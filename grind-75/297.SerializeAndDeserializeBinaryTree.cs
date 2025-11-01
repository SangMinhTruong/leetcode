/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec
{
    private static readonly string NULL_NODE = "#";
    private static readonly string DELIMITER = ",";

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        StringBuilder result = new StringBuilder();

        buildString(root, result);

        return result.ToString();
    }

    private void buildString(TreeNode root, StringBuilder result)
    {
        if (root == null)
            result.Append(NULL_NODE).Append(DELIMITER);
        else
        {
            result.Append(root.val).Append(DELIMITER);

            buildString(root.left, result);
            buildString(root.right, result);
        }
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        Queue<string> queue = new Queue<string>();

        foreach (string node in data.Split(DELIMITER, StringSplitOptions.RemoveEmptyEntries))
        {
            queue.Enqueue(node);
        }

        return buildTree(queue);
    }

    private TreeNode buildTree(Queue<string> queue)
    {
        string curVal = queue.Dequeue();

        if (curVal != NULL_NODE)
        {
            TreeNode curNode = new TreeNode(int.Parse(curVal));

            curNode.left = buildTree(queue);
            curNode.right = buildTree(queue);

            return curNode;
        }

        return null;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
