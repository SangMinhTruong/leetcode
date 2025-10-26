public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        int[] alphabet = new int[26];

        for (int i = 0; i < s.Length; i++)
            alphabet[s[i] - 'a']++;

        for (int i = 0; i < t.Length; i++)
            alphabet[t[i] - 'a']--;

        foreach (int c in alphabet)
            if (c != 0)
                return false;

        return true;
    }
}
