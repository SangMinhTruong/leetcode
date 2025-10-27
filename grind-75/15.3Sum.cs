public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            int target = -nums[i];
            int front = i + 1;
            int back = nums.Length - 1;

            while (front < back)
            {
                int sum = nums[front] + nums[back];

                if (sum < target)
                    front++;
                else if (sum > target)
                    back--;
                else
                {
                    IList<int> triplet = new List<int>() { nums[i], nums[front], nums[back] };
                    result.Add(triplet);

                    while (front < back && nums[front] == triplet[1])
                        front++;

                    while (front < back && nums[back] == triplet[2])
                        back--;
                }
            }

            while (i + 1 < nums.Length && nums[i] == nums[i + 1])
                i++;
        }

        return result;
    }
}
