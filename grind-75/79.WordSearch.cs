public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (Exist(board, word, i, j, 0))
                    return true;
            }
        }

        return false;
    }

    private bool Exist(char[][] board, string word, int i, int j, int wordIndex)
    {
        if (wordIndex == word.Length)
            return true;

        if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length)
            return false;

        if (board[i][j] != word[wordIndex])
            return false;

        board[i][j] = '#';

        bool exist =
            Exist(board, word, i + 1, j, wordIndex + 1)
            || Exist(board, word, i - 1, j, wordIndex + 1)
            || Exist(board, word, i, j + 1, wordIndex + 1)
            || Exist(board, word, i, j - 1, wordIndex + 1);

        board[i][j] = word[wordIndex];

        return exist;
    }
}
