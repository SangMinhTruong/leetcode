/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        return MaxDepthRecursive(root);
    }

    private int MaxDepthRecursive(TreeNode root)
    {
        if (root == null)
            return 0;

        return 1 + Math.Max(MaxDepthRecursive(root.left), MaxDepthRecursive(root.right));
    }

    private int MaxDepthIterativeDFS(TreeNode root)
    {
        if (root == null)
            return 0;

        int max = 0;

        var stack = new Stack<(TreeNode, int)>();
        stack.Push((root, 1));

        while (stack.Count > 0)
        {
            var (currentNode, currentDepth) = stack.Pop();

            max = Math.Max(max, currentDepth);

            if (currentNode.left != null)
                stack.Push((currentNode.left, currentDepth + 1));

            if (currentNode.right != null)
                stack.Push((currentNode.right, currentDepth + 1));
        }

        return max;
    }

    private int MaxDepthIterativeBFS(TreeNode root)
    {
        if (root == null)
            return 0;

        int max = 0;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int size = queue.Count;

            while (size > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);

                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);

                size--;
            }

            max++;
        }

        return max;
    }
}
