public class Solution
{
    public bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !IsAlphanumeric(s[left]))
                left++;

            while (left < right && !IsAlphanumeric(s[right]))
                right--;

            if (ToLowerCase(s[left]) != ToLowerCase(s[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }

    private bool IsAlphanumeric(char c)
    {
        return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
    }

    private char ToLowerCase(char c)
    {
        if (c >= 'A' && c <= 'Z')
            return (char)(c - ('A' - 'a'));
        return c;
    }
}
