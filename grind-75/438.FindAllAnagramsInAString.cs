public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        int[] alphabet = new int[26];
        foreach (char c in p)
        {
            alphabet[c - 'a']++;
        }

        int counter = p.Length;
        int left = 0;
        int right = 0;
        IList<int> result = new List<int>();

        while (right < s.Length)
        {
            if (alphabet[s[right] - 'a'] > 0)
                counter--;

            alphabet[s[right] - 'a']--;
            right++;

            if (counter == 0)
                result.Add(left);

            if (right - left == p.Length)
            {
                if (alphabet[s[left] - 'a'] >= 0)
                    counter++;

                alphabet[s[left] - 'a']++;
                left++;
            }
        }

        return result;
    }
}
