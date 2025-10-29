public class Solution
{
    public void SortColors(int[] nums)
    {
        int red = 0;
        int white = 0;
        int blue = nums.Length - 1;

        while (white <= blue)
        {
            if (nums[white] == 0)
            {
                (nums[white], nums[red]) = (nums[red], nums[white]);

                red++;
                white++;
            }
            else if (nums[white] == 1)
                white++;
            else
            {
                (nums[white], nums[blue]) = (nums[blue], nums[white]);

                blue--;
            }
        }
    }
}
