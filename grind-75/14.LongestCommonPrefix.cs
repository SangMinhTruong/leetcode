public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        return LongestCommonPrefixBruteForce(strs);
    }

    private string LongestCommonPrefixBruteForce(string[] strs)
    {
        StringBuilder sb = new StringBuilder();
        string first = strs[0];

        for (int i = 0; i < first.Length; i++)
        {
            char c = first[i];

            for (int j = 1; j < strs.Length; j++)
            {
                if (i >= strs[j].Length || c != strs[j][i])
                    return sb.ToString();
            }

            sb.Append(c);
        }

        return sb.ToString();
    }

    private string LongestCommonPrefixSort(string[] strs)
    {
        Array.Sort(strs);

        StringBuilder sb = new StringBuilder();
        string first = strs[0];
        string last = strs[strs.Length - 1];

        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] != last[i])
                break;

            sb.Append(first[i]);
        }

        return sb.ToString();
    }
}
