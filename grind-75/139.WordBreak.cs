public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        Trie root = new Trie();
        foreach (string word in wordDict)
        {
            root.AddWord(word);
        }

        int sLength = s.Length;
        bool[] dp = new bool[sLength + 1];
        dp[sLength] = true;

        int maxWordLength = wordDict.Max(word => word.Length);

        for (int i = sLength - 1; i >= 0; i--)
        {
            Trie curTrieNode = root;

            for (int j = i; j < Math.Min(i + maxWordLength, sLength); j++)
            {
                char c = s[j];

                if (!curTrieNode.Children.ContainsKey(c))
                    break;

                curTrieNode = curTrieNode.Children[c];

                if (curTrieNode.IsWord && dp[j + 1])
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[0];
    }

    private class Trie
    {
        public bool IsWord { get; set; }
        public Dictionary<char, Trie> Children { get; set; }

        public Trie()
        {
            IsWord = false;
            Children = new Dictionary<char, Trie>();
        }

        public void AddWord(string word)
        {
            Trie cur = this;

            foreach (char c in word)
            {
                if (!cur.Children.ContainsKey(c))
                    cur.Children[c] = new Trie();

                cur = cur.Children[c];
            }

            cur.IsWord = true;
        }
    }
}
