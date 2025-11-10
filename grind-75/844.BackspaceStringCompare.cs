public class Solution
{
    public bool BackspaceCompare(string s, string t)
    {
        int i = s.Length - 1;
        int j = t.Length - 1;

        while (true)
        {
            int backspace = 0;
            while (i >= 0 && (backspace > 0 || s[i] == '#'))
            {
                if (s[i] == '#')
                    backspace++;
                else
                    backspace--;

                i--;
            }

            backspace = 0;
            while (j >= 0 && (backspace > 0 || t[j] == '#'))
            {
                if (t[j] == '#')
                    backspace++;
                else
                    backspace--;

                j--;
            }

            if (i >= 0 && j >= 0 && s[i] == t[j])
            {
                i--;
                j--;
            }
            else
                break;
        }

        return i == -1 && j == -1;
    }
}
