/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    public bool HasCycle(ListNode head)
    {
        var fast = head;
        var slow = head;
        do
        {
            if (fast == null || fast.next == null || fast.next.next == null)
                return false;
            fast = fast.next.next;
            slow = slow.next;
        } while (fast != slow);
        return true;
    }
}
