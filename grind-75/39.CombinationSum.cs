public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();

        CombinationSumBacktracking(result, new List<int>(), candidates, target, 0);

        return result;
    }

    private void CombinationSumBacktracking(
        IList<IList<int>> result,
        IList<int> temp,
        int[] candidates,
        int remain,
        int start
    )
    {
        if (remain == 0)
        {
            result.Add(new List<int>(temp));
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            if (candidates[i] > remain)
                continue;

            temp.Add(candidates[i]);

            CombinationSumBacktracking(result, temp, candidates, remain - candidates[i], i);

            temp.RemoveAt(temp.Count - 1);
        }
    }
}
