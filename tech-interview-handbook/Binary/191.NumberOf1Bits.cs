public class Solution
{
    public int HammingWeight(int n)
    {
        return HammingWeightBitFlip(n);
    }

    private int HammingWeightBitShift(int n)
    {
        int count = 0;

        while (n != 0)
        {
            if ((n & 1) == 1)
                count++;

            n >>= 1;
        }

        return count;
    }

    private int HammingWeightBitFlip(int n)
    {
        int count = 0;

        // n: ...100 1 00... <- ALL 0s -> ...000
        //           ^
        // the first 1 bit starting from the right
        //
        // n - 1: ...100 0 11... <- ALL 1s -> ...111
        //               ^
        // the first 1 bit becomes 0 and ALL the 0s to the right become 1s
        //
        // n & (n - 1): ...100 0 00... <- ALL 0s -> ...000
        //                     ^
        // the 1 bit is flipped and considered counted, ALL bits to the right is set to 0s
        // we then repeat the process until there is no more 1 bits

        while (n != 0)
        {
            n &= (n - 1);
            count++;
        }

        return count;
    }
}
