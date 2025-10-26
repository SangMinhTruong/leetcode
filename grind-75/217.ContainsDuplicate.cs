public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        return ContainsDuplicateHashMap(nums);
    }

    public bool ContainsDuplicateHashMap(int[] nums)
    {
        Dictionary<int, bool> hashSet = new Dictionary<int, bool>();

        foreach (int num in nums)
        {
            if (hashSet.ContainsKey(num))
                return true;

            hashSet[num] = true;
        }

        return false;
    }

    public bool ContainsDuplicateSorting(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
                return true;
        }

        return false;
    }
}
