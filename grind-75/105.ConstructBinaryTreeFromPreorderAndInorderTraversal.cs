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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return BuildTree(0, 0, inorder.Length - 1, preorder, inorder);
    }

    private TreeNode BuildTree(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
    {
        if (inStart > inEnd)
            return null;

        TreeNode root = new TreeNode(preorder[preStart]);
        int rootInorderIndex = 0;

        for (int i = inStart; i <= inEnd; i++)
        {
            if (inorder[i] == preorder[preStart])
            {
                rootInorderIndex = i;
                break;
            }
        }

        root.left = BuildTree(preStart + 1, inStart, rootInorderIndex - 1, preorder, inorder);
        root.right = BuildTree(
            preStart + (rootInorderIndex - inStart + 1),
            rootInorderIndex + 1,
            inEnd,
            preorder,
            inorder
        );

        return root;
    }
}
