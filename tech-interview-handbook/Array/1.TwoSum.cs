public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var numToFind = target - nums[i];

            if (dictionary.ContainsKey(numToFind))
                return new int[2] { i, dictionary[numToFind] };

            dictionary[nums[i]] = i;
        }

        return new int[2];
    }
}
