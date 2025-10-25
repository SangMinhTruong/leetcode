public class Solution
{
    public int HammingWeight(int n)
    {
        int count = 0;

        // 1011 n
        // 1010 n - 1
        // 1010 n & (n - 1)
        //
        // 1010 n
        // 1001 n - 1
        // 1000 n & (n - 1)
        //
        // 1000 n
        // 0111 n - 1
        // 0000 n & (n - 1)

        while (n != 0)
        {
            n &= (n - 1);
            count++;
        }

        return count;
    }
}
