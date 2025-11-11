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
    public bool IsSymmetric(TreeNode root)
    {
        return IsSymetric(root.left, root.right);
    }

    private bool IsSymetric(TreeNode left, TreeNode right)
    {
        if (left == null || right == null)
            return left == right;

        if (left.val != right.val)
            return false;

        return IsSymetric(left.left, right.right) && IsSymetric(left.right, right.left);
    }
}
