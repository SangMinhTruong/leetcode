public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        bool[,] rows = new bool[9, 9];
        bool[,] columns = new bool[9, 9];
        bool[,] blocks = new bool[9, 9];

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == '.')
                    continue;

                int num = (board[i][j] - '0') - 1;
                int blockNumber = i / 3 * 3 + j / 3;

                if (rows[i, num] || columns[j, num] || blocks[blockNumber, num])
                    return false;

                rows[i, num] = true;
                columns[j, num] = true;
                blocks[blockNumber, num] = true;
            }
        }

        return true;
    }
}
