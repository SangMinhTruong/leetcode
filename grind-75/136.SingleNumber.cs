public class Solution
{
    public int SingleNumber(int[] nums)
    {
        int result = 0;

        // A ^ 0 = 0
        // A ^ A = 0
        // A ^ B ^ A = B
        //
        // A1 ^ A2 ^ A3 ^ ... Ak ... ^ A1 ^ A2 ^ A3 ... ^ An = Ak
        //                    ^
        //              unique element
        for (int i = 0; i < nums.Length; i++)
        {
            result ^= nums[i];
        }

        return result;
    }
}
