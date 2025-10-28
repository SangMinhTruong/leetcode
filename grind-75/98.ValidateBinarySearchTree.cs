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
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBSTRecursive(root);
    }

    private bool ValidateInOrderIterative(TreeNode root)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;
        int? largestSoFar = null;

        while (cur != null || stack.Count > 0)
        {
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }

            cur = stack.Pop();

            if (largestSoFar != null && cur.val <= largestSoFar)
                return false;

            largestSoFar = cur.val;
            cur = cur.right;
        }

        return true;
    }

    private bool IsValidBSTRecursive(TreeNode root, int? min = null, int? max = null)
    {
        if (root == null)
            return true;

        if (min != null && root.val <= min || max != null && root.val >= max)
            return false;

        return IsValidBSTRecursive(root.left, min, root.val)
            && IsValidBSTRecursive(root.right, root.val, max);
    }
}
