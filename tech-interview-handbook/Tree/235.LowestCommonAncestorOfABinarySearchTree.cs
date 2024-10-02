/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        return LowestCommonAncestorIterative(root, p, q);
    }

    private TreeNode LowestCommonAncestorRecursive(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val > p.val && root.val > q.val)
            return LowestCommonAncestorRecursive(root.left, p, q);
        else if (root.val < p.val && root.val < q.val)
            return LowestCommonAncestorRecursive(root.right, p, q);
        return root;
    }

    private TreeNode LowestCommonAncestorIterative(TreeNode root, TreeNode p, TreeNode q)
    {
        var small = Math.Min(p.val, q.val);
        var large = Math.Max(p.val, q.val);
        while (root != null)
        {
            if (root.val > large)
                root = root.left;
            else if (root.val < small)
                root = root.right;
            else
                return root;
        }
        return null;
    }
}
