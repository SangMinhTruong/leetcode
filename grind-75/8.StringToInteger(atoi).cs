public class Solution
{
    public int MyAtoi(string s)
    {
        int i = 0;
        int sign = 1;
        int result = 0;

        while (i < s.Length && s[i] == ' ')
            i++;

        if (i == s.Length)
            return 0;

        if (s[i] == '+' || s[i] == '-')
        {
            sign = s[i] == '+' ? 1 : -1;
            i++;
        }

        while (i < s.Length)
        {
            int digit = s[i] - '0';

            if (digit < 0 || digit > 9)
                break;

            if (
                int.MaxValue / 10 < result
                || int.MaxValue / 10 == result && int.MaxValue % 10 < digit
            )
            {
                return sign == 1 ? int.MaxValue : int.MinValue;
            }

            result = result * 10 + digit;
            i++;
        }

        return sign * result;
    }
}
