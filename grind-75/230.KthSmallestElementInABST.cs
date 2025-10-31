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
    public int KthSmallest(TreeNode root, int k)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();

        while (root != null)
        {
            stack.Push(root);
            root = root.left;
        }

        while (k > 0)
        {
            TreeNode cur = stack.Pop();

            k--;

            if (k == 0)
                return cur.val;

            TreeNode right = cur.right;
            while (right != null)
            {
                stack.Push(right);
                right = right.left;
            }
        }

        return -1;
    }
}
