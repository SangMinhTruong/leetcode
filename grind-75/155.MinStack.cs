public class MinStack
{
    private class Node
    {
        public int val;
        public int min;
        public Node next;

        public Node(int val, int min, Node next)
        {
            this.val = val;
            this.min = min;
            this.next = next;
        }
    }

    private Node head;

    public MinStack() { }

    public void Push(int val)
    {
        if (head == null)
            head = new Node(val, val, null);
        else
            head = new Node(val, Math.Min(val, head.min), head);
    }

    public void Pop()
    {
        head = head.next;
    }

    public int Top()
    {
        return head.val;
    }

    public int GetMin()
    {
        return head.min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
