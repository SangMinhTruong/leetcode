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
    public bool IsBalanced(TreeNode root)
    {
        return IsBalancedBottomUp(root) != -1;
    }

    private bool IsBalancedTopDown(TreeNode root)
    {
        if (root == null)
            return true;

        int heightDiff = Height(root.left) - Height(root.right);
        if (heightDiff < -1 || heightDiff > 1)
            return false;

        return IsBalanced(root.left) && IsBalanced(root.right);
    }

    private int Height(TreeNode root)
    {
        if (root == null)
            return 0;

        return 1 + Math.Max(Height(root.left), Height(root.right));
    }

    private int IsBalancedBottomUp(TreeNode root)
    {
        if (root == null)
            return 0;

        int leftHeight = IsBalancedBottomUp(root.left);
        if (leftHeight == -1)
            return -1;

        int rightHeight = IsBalancedBottomUp(root.right);
        if (rightHeight == -1)
            return -1;

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
