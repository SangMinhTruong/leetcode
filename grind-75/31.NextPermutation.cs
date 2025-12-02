public class Solution
{
    // https://www.nayuki.io/page/next-lexicographical-permutation-algorithm
    public void NextPermutation(int[] nums)
    {
        int suffixIndex = nums.Length - 1;

        while (suffixIndex > 0)
        {
            if (nums[suffixIndex] > nums[suffixIndex - 1])
                break;

            suffixIndex--;
        }

        if (suffixIndex > 0)
        {
            int pivot = suffixIndex - 1;
            int j = nums.Length - 1;

            while (j > pivot)
            {
                if (nums[j] > nums[pivot])
                    break;

                j--;
            }

            (nums[pivot], nums[j]) = (nums[j], nums[pivot]);
        }

        int left = suffixIndex;
        int right = nums.Length - 1;

        while (left < right)
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);

            left++;
            right--;
        }
    }
}
