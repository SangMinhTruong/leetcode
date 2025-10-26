public class Solution
{
    public int LongestPalindrome(string s)
    {
        int[] lowercaseAlphabet = new int[26];
        int[] uppercaseAlphabet = new int[26];

        int count = 0;
        int oddCharCount = 0;

        foreach (char c in s)
        {
            bool isLowercase = IsLowercase(c);
            int[] alphabet = isLowercase ? lowercaseAlphabet : uppercaseAlphabet;
            int offset = isLowercase ? c - 'a' : c - 'A';

            if (alphabet[offset] > 0)
            {
                alphabet[offset]--;
                oddCharCount--;
                count++;
            }
            else
            {
                alphabet[offset]++;
                oddCharCount++;
            }
        }

        return oddCharCount > 0 ? count * 2 + 1 : count * 2;
    }

    private bool IsLowercase(char c)
    {
        return c >= 'a' && c <= 'z';
    }
}
