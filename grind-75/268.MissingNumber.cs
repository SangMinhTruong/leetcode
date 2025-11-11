public class Solution
{
    public int MissingNumber(int[] nums)
    {
        return MissingNumberXOR(nums);
    }

    private int MissingNumberXOR(int[] nums)
    {
        int result = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            result = result ^ i ^ nums[i];
        }

        return result ^ nums.Length;
    }

    private int MissingNumberFlags(int[] nums)
    {
        bool[] flags = new bool[nums.Length + 1];

        for (int i = 0; i < nums.Length; i++)
        {
            flags[nums[i]] = true;
        }

        for (int i = 0; i <= nums.Length; i++)
        {
            if (!flags[i])
                return i;
        }

        return -1;
    }
}
