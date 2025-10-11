public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int[] map = new int[128];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = -1;
        }

        int left = 0;
        int maxLength = 0;
        for (int right = 0; right < s.Length; right++)
        {
            if (map[s[right]] >= left)
                left = map[s[right]] + 1;
            map[s[right]] = right;
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
