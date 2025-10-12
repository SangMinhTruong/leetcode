public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        int[] availableCharacters = new int[26];

        foreach (char c in magazine)
            availableCharacters[c - 'a']++;

        foreach (char c in ransomNote)
        {
            if (availableCharacters[c - 'a'] <= 0)
                return false;
            availableCharacters[c - 'a']--;
        }

        return true;
    }
}
