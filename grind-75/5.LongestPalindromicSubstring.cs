public class Solution
{
    public string LongestPalindrome(string s)
    {
        return LongestPalindromeTwoPointers(s);
    }

    private string LongestPalindromeDP(string s)
    {
        bool[,] dp = new bool[s.Length, s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            dp[i, i] = true;
        }

        int resultStartIndex = 0;
        int resultLength = 1;

        for (int end = 0; end < s.Length; end++)
        {
            for (int start = end - 1; start >= 0; start--)
            {
                if (s[start] == s[end] && (end - start == 1 || dp[start + 1, end - 1]))
                {
                    dp[start, end] = true;

                    int newLength = end - start + 1;

                    if (resultLength < newLength)
                    {
                        resultStartIndex = start;
                        resultLength = newLength;
                    }
                }
            }
        }

        return s.Substring(resultStartIndex, resultLength);
    }

    private string LongestPalindromeTwoPointers(string s)
    {
        int resultStartIndex = 0;
        int resultLength = 1;

        for (int i = 0; i < s.Length; i++)
        {
            int right = i;

            while (right < s.Length && s[i] == s[right])
            {
                right++;
            }

            int left = i - 1;

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            int newLength = (right - 1) - (left + 1) + 1;

            if (resultLength < newLength)
            {
                resultStartIndex = left + 1;
                resultLength = newLength;
            }
        }

        return s.Substring(resultStartIndex, resultLength);
    }
}
