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
    public ListNode ReverseList(ListNode head)
    {
        return ReverseListIterative(head);
    }

    private ListNode ReverseListIterative(ListNode head)
    {
        ListNode prev = null;

        while (head != null)
        {
            ListNode next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }

        return prev;
    }

    private ListNode ReverseListRecursive(ListNode head, ListNode newHead = null)
    {
        if (head == null)
            return newHead;

        ListNode next = head.next;
        head.next = newHead;

        return ReverseListRecursive(next, head);
    }
}
