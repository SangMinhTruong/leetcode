public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int offset = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                offset++;
            else if (offset > 0)
                (nums[i], nums[i - offset]) = (nums[i - offset], nums[i]);
        }
    }
}
