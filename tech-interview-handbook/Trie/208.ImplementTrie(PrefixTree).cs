public class Trie
{
    private bool isEnd = false;
    private Trie[] children = new Trie[26];

    public void Insert(string word)
    {
        var currentNode = this;
        foreach (var c in word)
        {
            if (currentNode.children[c - 'a'] == null)
                currentNode.children[c - 'a'] = new Trie();
            currentNode = currentNode.children[c - 'a'];
        }
        currentNode.isEnd = true;
    }

    public bool Search(string word)
    {
        var currentNode = this;
        foreach (var c in word)
        {
            if (currentNode.children[c - 'a'] == null)
                return false;
            currentNode = currentNode.children[c - 'a'];
        }
        return currentNode.isEnd;
    }

    public bool StartsWith(string prefix)
    {
        var currentNode = this;
        foreach (var c in prefix)
        {
            if (currentNode.children[c - 'a'] == null)
                return false;
            currentNode = currentNode.children[c - 'a'];
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
