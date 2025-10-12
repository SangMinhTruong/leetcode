public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        return CombineIterative(n, k);
    }

    private IList<IList<int>> CombineRecursion(int n, int k)
    {
        IList<IList<int>> result = new List<IList<int>>();
        CombineRecursion(n, k, 1, new List<int>(), result);
        return result;
    }

    private void CombineRecursion(
        int n,
        int k,
        int start,
        IList<int> combination,
        IList<IList<int>> result
    )
    {
        if (k <= 0)
        {
            result.Add(new List<int>(combination));
            return;
        }

        for (int i = start; i <= n; i++)
        {
            combination.Add(i);
            CombineRecursion(n, k - 1, i + 1, combination, result);
            combination.RemoveAt(combination.Count - 1);
        }
    }

    private IList<IList<int>> CombineIterative(int n, int k)
    {
        IList<IList<int>> result = new List<IList<int>>();
        int[] combination = new int[k];
        int i = 0;

        while (i >= 0)
        {
            combination[i]++;

            if (combination[i] > n)
                i--;
            else if (i == k - 1)
                result.Add(new List<int>(combination));
            else
            {
                i++;
                combination[i] = combination[i - 1];
            }
        }

        return result;
    }
}
