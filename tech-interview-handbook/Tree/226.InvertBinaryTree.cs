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
    public TreeNode InvertTree(TreeNode root)
    {
        return InvertTreeIterativeBFS(root);
    }

    private TreeNode InvertTreeRecursive(TreeNode root)
    {
        if (root == null)
            return root;

        var currentLeft = root.left;
        var currentRight = root.right;
        root.left = InvertTreeRecursive(currentRight);
        root.right = InvertTreeRecursive(currentLeft);

        return root;
    }

    private TreeNode InvertTreeIterativeDFS(TreeNode root)
    {
        if (root == null)
            return root;

        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();
            var left = currentNode.left;
            currentNode.left = currentNode.right;
            currentNode.right = left;

            if (currentNode.left != null)
                stack.Push(currentNode.left);
            if (currentNode.right != null)
                stack.Push(currentNode.right);
        }
        return root;
    }

    private TreeNode InvertTreeIterativeBFS(TreeNode root)
    {
        if (root == null)
            return root;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            var left = currentNode.left;
            currentNode.left = currentNode.right;
            currentNode.right = left;

            if (currentNode.left != null)
                queue.Enqueue(currentNode.left);
            if (currentNode.right != null)
                queue.Enqueue(currentNode.right);
        }
        return root;
    }
}
