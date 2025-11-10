public class Solution
{
    public int[] CountBits(int n)
    {
        int[] result = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            // Each time, we shift right to get the previously computed result, optionally + 1 to account for the left-over odd bit
            // E.g.
            // i = 5 = 0101
            // i >> 1 = 0010 (which we should have already calculated)
            // + (i & 1) = 1 (which accounts for the odd bit when we shift right)
            result[i] = result[i >> 1] + (i & 1);
        }

        return result;
    }
}
