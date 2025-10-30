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
    public IList<int> RightSideView(TreeNode root)
    {
        if (root == null)
            return new List<int>();

        IList<int> result = new List<int>();

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int curSize = queue.Count;

            for (int i = 0; i < curSize; i++)
            {
                TreeNode curNode = queue.Dequeue();

                if (i == curSize - 1)
                    result.Add(curNode.val);

                if (curNode.left != null)
                    queue.Enqueue(curNode.left);

                if (curNode.right != null)
                    queue.Enqueue(curNode.right);
            }
        }

        return result;
    }
}
