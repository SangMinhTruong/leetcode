public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] ans = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            ans[i] = 1;
        }

        int cur = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            ans[i] *= cur;
            cur *= nums[i];
        }

        cur = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            ans[i] *= cur;
            cur *= nums[i];
        }

        return ans;
    }
}