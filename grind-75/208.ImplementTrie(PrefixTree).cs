public class Trie
{
    private bool hasWord;
    private Trie[] alphabet;

    public Trie()
    {
        hasWord = false;
        alphabet = new Trie[26];
    }

    public void Insert(string word)
    {
        Trie currentNode = this;
        foreach (char character in word)
        {
            int index = character - 'a';

            if (currentNode.alphabet[index] == null)
                currentNode.alphabet[index] = new Trie();

            currentNode = currentNode.alphabet[index];
        }

        currentNode.hasWord = true;
    }

    public bool Search(string word)
    {
        Trie currentNode = this;
        foreach (char character in word)
        {
            int index = character - 'a';

            if (currentNode.alphabet[index] == null)
                return false;

            currentNode = currentNode.alphabet[index];
        }

        return currentNode.hasWord;
    }

    public bool StartsWith(string prefix)
    {
        Trie currentNode = this;
        foreach (char character in prefix)
        {
            int index = character - 'a';

            if (currentNode.alphabet[index] == null)
                return false;

            currentNode = currentNode.alphabet[index];
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
