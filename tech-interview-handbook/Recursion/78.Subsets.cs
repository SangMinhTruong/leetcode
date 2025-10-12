public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        SubsetsBacktracking(nums, 0, new List<int>(), result);
        return result;
    }

    private void SubsetsBacktracking(
        int[] nums,
        int start,
        IList<int> subset,
        IList<IList<int>> result
    )
    {
        result.Add(new List<int>(subset));
        for (int i = start; i < nums.Length; i++)
        {
            subset.Add(nums[i]);
            SubsetsBacktracking(nums, i + 1, subset, result);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
