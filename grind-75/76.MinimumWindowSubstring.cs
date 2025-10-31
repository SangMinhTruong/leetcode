public class Solution
{
    public string MinWindow(string s, string t)
    {
        int[] characterCounts = new int[256];
        foreach (char c in t)
        {
            characterCounts[c]++;
        }

        int start = 0;
        int end = 0;
        int counter = t.Length;
        int minStart = 0;
        int minLength = int.MaxValue;

        while (end < s.Length)
        {
            if (characterCounts[s[end]] > 0)
                counter--;

            characterCounts[s[end]]--;

            while (counter == 0)
            {
                if (end - start + 1 < minLength)
                {
                    minLength = end - start + 1;
                    minStart = start;
                }

                characterCounts[s[start]]++;

                if (characterCounts[s[start]] > 0)
                    counter++;

                start++;
            }

            end++;
        }

        if (minLength < int.MaxValue)
            return s.Substring(minStart, minLength);

        return "";
    }
}
