/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        PriorityQueue<ListNode, int> queue = new PriorityQueue<ListNode, int>();

        foreach (ListNode list in lists)
        {
            if (list != null)
                queue.Enqueue(list, list.val);
        }

        ListNode result = new ListNode();
        ListNode current = result;

        while (queue.Count > 0)
        {
            ListNode minNode = queue.Dequeue();

            if (minNode.next != null)
                queue.Enqueue(minNode.next, minNode.next.val);

            current.next = minNode;
            current = minNode;
        }

        return result.next;
    }
}
