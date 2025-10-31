public class LRUCache
{
    private Dictionary<int, Node> hashMap;
    private Node head;
    private Node tail;
    private int capacity;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        hashMap = new Dictionary<int, Node>(capacity);
        head = new Node();
        tail = new Node();

        head.next = tail;
        tail.prev = head;
    }

    public int Get(int key)
    {
        if (!hashMap.ContainsKey(key))
            return -1;

        Node node = hashMap[key];

        MoveToFirst(node);

        return node.val;
    }

    public void Put(int key, int value)
    {
        if (!hashMap.ContainsKey(key))
        {
            if (hashMap.Count >= capacity)
            {
                Node last = PopLast();

                hashMap.Remove(last.key);
            }

            Node newNode = new Node();

            AddFirst(newNode);

            hashMap[key] = newNode;

            newNode.key = key;
            newNode.val = value;
        }
        else
        {
            Node node = hashMap[key];

            node.val = value;

            MoveToFirst(node);
        }
    }

    private class Node
    {
        public Node prev;
        public Node next;
        public int key;
        public int val;
    }

    private void AddFirst(Node node)
    {
        node.next = head.next;
        node.prev = head;

        head.next.prev = node;
        head.next = node;
    }

    private void Remove(Node node)
    {
        Node prev = node.prev;
        Node next = node.next;

        prev.next = next;
        next.prev = prev;
    }

    private void MoveToFirst(Node node)
    {
        Remove(node);
        AddFirst(node);
    }

    private Node PopLast()
    {
        Node node = tail.prev;
        Remove(tail.prev);

        return node;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
