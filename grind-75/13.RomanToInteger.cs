public class Solution
{
    public int RomanToInt(string s)
    {
        Dictionary<char, int> translations = new Dictionary<char, int>()
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000,
        };

        int result = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (translations[s[i]] < translations[s[i + 1]])
                result -= translations[s[i]];
            else
                result += translations[s[i]];
        }

        return result + translations[s[s.Length - 1]];
    }
}
