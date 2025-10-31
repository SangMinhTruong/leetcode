public class Solution
{
    public int Trap(int[] height)
    {
        return TrapTwoPointers(height);
    }

    private int TrapMaxLeftMaxRight(int[] height)
    {
        int length = height.Length;
        int[] maxLeft = new int[length];
        int[] maxRight = new int[length];

        for (int i = 1; i < length; i++)
        {
            maxLeft[i] = Math.Max(height[i - 1], maxLeft[i - 1]);
        }

        for (int i = length - 2; i >= 0; i--)
        {
            maxRight[i] = Math.Max(height[i + 1], maxRight[i + 1]);
        }

        int total = 0;

        for (int i = 0; i < length; i++)
        {
            int maxPossibleWaterLevel = Math.Min(maxLeft[i], maxRight[i]);

            if (maxPossibleWaterLevel > height[i])
                total += (maxPossibleWaterLevel - height[i]);
        }

        return total;
    }

    private int TrapTwoPointers(int[] height)
    {
        int maxLeft = height[0];
        int maxRight = height[height.Length - 1];
        int left = 1;
        int right = height.Length - 2;
        int total = 0;

        while (left <= right)
        {
            if (maxLeft < maxRight)
            {
                if (height[left] >= maxLeft)
                    maxLeft = height[left];
                else
                    total += (maxLeft - height[left]);

                left++;
            }
            else
            {
                if (height[right] >= maxRight)
                    maxRight = height[right];
                else
                    total += (maxRight - height[right]);

                right--;
            }
        }

        return total;
    }
}
