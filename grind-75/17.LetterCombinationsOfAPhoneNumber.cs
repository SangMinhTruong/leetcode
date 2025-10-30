public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        string[] keys = new string[10]
        {
            "",
            "",
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz",
        };
        IList<string> result = new List<string>();

        LetterCombinations("", 0, digits, keys, result);

        return result;
    }

    private void LetterCombinations(
        string prefix,
        int i,
        string digits,
        string[] keys,
        IList<string> result
    )
    {
        if (i >= digits.Length)
        {
            result.Add(prefix);
            return;
        }

        string letters = keys[digits[i] - '0'];
        foreach (char letter in letters)
        {
            LetterCombinations(prefix + letter, i + 1, digits, keys, result);
        }
    }
}
