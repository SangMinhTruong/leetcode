public class Solution
{
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int water = 0;

        while (left < right)
        {
            water = Math.Max(water, (right - left) * (Math.Min(height[left], height[right])));

            if (height[left] < height[right])
                left++;
            else if (height[left] > height[right])
                right--;
            else
            {
                left++;
                right--;
            }
        }

        return water;
    }
}
