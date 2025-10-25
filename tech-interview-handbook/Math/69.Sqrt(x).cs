public class Solution
{
    public int MySqrt(int x)
    {
        return MySqrtBinarySearh(x);
    }

    private int MySqrtBinarySearh(int x)
    {
        if (x == 0)
            return 0;

        int low = 1;
        int high = x;

        while (low < high)
        {
            int mid = low + (high - low + 1) / 2;

            if (mid == x / mid)
                return mid;
            else if (mid > x / mid)
                high = mid - 1;
            else
                low = mid;
        }

        return low;
    }

    private int MySqrtNewton(int x)
    {
        if (x == 0)
            return 0;

        // // https://cp-algorithms.com/num_methods/roots_newton.html#application-for-calculating-the-square-root
        // long k = 1;
        // bool decreased = false;
        //
        // while (true) {
        //     long nk = (k + x / k) / 2;
        //
        //     if (k == nk || nk > k && decreased)
        //         break;
        //
        //     decreased = nk < k;
        //     k = nk;
        // }

        // https://en.wikipedia.org/wiki/Integer_square_root#Using_only_integer_division
        long k = x;

        while (k > x / k)
        {
            k = (k + x / k) / 2;
        }

        return (int)k;
    }
}
