public class Solution
{
    // x = 7
    // n = 11 = 0b1011
    //
    // 1    0    1    1
    // 7^8  7^4  7^2  7^1
    //
    // pow = 7^8 * 7^2 * 7^1
    public double MyPow(double x, int n)
    {
        if (n < 0)
        {
            n = -n;
            x = 1 / x;
        }

        double pow = 1;

        while (n != 0)
        {
            if ((n & 1) != 0)
                pow *= x;

            x *= x;
            n >>>= 1;
        }

        return pow;
    }

    // Technically, we can do this with any base
    public double MyPowBase10(double x, int n)
    {
        long bigN = n;

        if (bigN < 0)
        {
            bigN = -bigN;
            x = 1 / x;
        }

        double pow = 1;

        while (bigN != 0)
        {
            if (bigN % 10 != 0)
                for (int i = 0; i < bigN % 10; i++)
                    pow *= x;

            double curX = x;
            for (int i = 1; i < 10; i++)
                x *= curX;

            bigN = bigN / 10;
        }

        return pow;
    }
}
