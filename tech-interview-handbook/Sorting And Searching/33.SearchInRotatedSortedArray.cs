public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] > nums[right])
                left = mid + 1;
            else
                right = mid;
        }

        int rotation = left;
        left = 0;
        right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int realMid = (mid + rotation) % nums.Length;
            if (nums[realMid] == target)
                return realMid;
            else if (nums[realMid] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return -1;
    }
}
