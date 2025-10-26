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
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int diameter = 0;

        Height(root, ref diameter);

        return diameter;
    }

    private int Height(TreeNode root, ref int diameter)
    {
        if (root == null)
            return 0;

        int leftHeight = Height(root.left, ref diameter);
        int rightHeight = Height(root.right, ref diameter);

        diameter = Math.Max(diameter, leftHeight + rightHeight);

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
