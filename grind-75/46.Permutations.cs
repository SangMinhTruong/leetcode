public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();

        PermuteBacktracking(result, new List<int>(), nums);

        return result;
    }

    private void PermuteBacktracking(IList<IList<int>> result, IList<int> temp, int[] nums)
    {
        if (temp.Count == nums.Length)
        {
            result.Add(new List<int>(temp));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (temp.Contains(nums[i]))
                continue;

            temp.Add(nums[i]);

            PermuteBacktracking(result, temp, nums);

            temp.RemoveAt(temp.Count - 1);
        }
    }
}
