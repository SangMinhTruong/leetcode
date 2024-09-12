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
public class Solution {
    public ListNode ReverseList(ListNode head) {
        return ReverseListIterative(head);
    }

    private ListNode ReverseListIterative(ListNode head) {
        ListNode newHead = null;
        while (head != null) {
            var next = head.next;
            head.next = newHead;
            newHead = head;
            head = next;
        }
        return newHead;
    }

    private ListNode ReverseListRecurisve(ListNode head, ListNode newHead = null) {
        if (head == null) {
            return newHead;
        }
        var next = head.next;
        head.next = newHead;
        return ReverseListRecurisve(next, head);
    }
}