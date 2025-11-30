public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] result = new int[temperatures.Length];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int previousIndex = stack.Pop();
                result[previousIndex] = i - previousIndex;
            }

            stack.Push(i);
        }

        return result;
    }
}
