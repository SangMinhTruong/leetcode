public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        IList<string> result = new List<string>();
        GenerateParenthesis(n, 0, 0, "", result);
        return result;
    }

    private void GenerateParenthesis(
        int n,
        int left,
        int right,
        string combination,
        IList<string> result
    )
    {
        if (left + right == 2 * n)
        {
            result.Add(combination);
            return;
        }

        if (left < n)
            GenerateParenthesis(n, left + 1, right, combination + '(', result);

        if (right < left)
            GenerateParenthesis(n, left, right + 1, combination + ')', result);
    }
}
