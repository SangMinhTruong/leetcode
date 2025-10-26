public class Solution
{
    public int MajorityElement(int[] nums)
    {
        return MajorityElementBoyerMoore(nums);
    }

    private int MajorityElementHashMap(int[] nums)
    {
        Dictionary<int, int> countMap = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            countMap[num] = countMap.GetValueOrDefault(num) + 1;
        }

        int majorityCount = nums.Length / 2;
        foreach (KeyValuePair<int, int> kvp in countMap)
        {
            if (kvp.Value > majorityCount)
                return kvp.Key;
        }

        return int.MinValue;
    }

    // https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm#Description
    private int MajorityElementBoyerMoore(int[] nums)
    {
        int count = 0;
        int candidate = nums[0];

        foreach (int num in nums)
        {
            if (count == 0)
            {
                candidate = num;
                count = 1;
            }
            else if (candidate == num)
                count++;
            else
                count--;
        }

        return candidate;
    }
}
