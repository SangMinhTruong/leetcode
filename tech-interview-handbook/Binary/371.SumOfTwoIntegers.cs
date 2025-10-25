public class Solution
{
    public int GetSum(int a, int b)
    {
        // 1110 a
        // 0110 b
        //
        // 1000 a ^ b
        // 1100 carry
        //
        // 00100 a ^ b
        // 10000 carry
        //
        // 10100 a ^ b
        // 000000 carry

        while (b != 0)
        {
            int carry = (a & b) << 1;
            a = a ^ b;
            b = carry;
        }

        return a;
    }
}
