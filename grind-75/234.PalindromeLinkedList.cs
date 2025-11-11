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
    public bool IsPalindrome(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode prev = null;
        while (slow != null)
        {
            ListNode next = slow.next;

            slow.next = prev;
            prev = slow;
            slow = next;
        }

        while (prev != null)
        {
            if (head.val != prev.val)
                return false;

            head = head.next;
            prev = prev.next;
        }

        return true;
    }
}
