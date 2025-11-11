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
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (IsEqual(root, subRoot))
            return true;

        if (root == null)
            return false;

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool IsEqual(TreeNode root1, TreeNode root2)
    {
        if (root1 == null || root2 == null)
            return root1 == root2;

        if (root1.val != root2.val)
            return false;

        return IsEqual(root1.left, root2.left) && IsEqual(root1.right, root2.right);
    }
}
