public class Solution
{
    public int Calculate(string s)
    {
        int result = 0;
        int sign = 1;
        int num = 0;

        Stack<int> stack = new Stack<int>();
        stack.Push(sign);

        // "-(12-(3-(4-5+2))-3)"
        // - [-] 12 [-]- [-+] 3 [-+]- [-+-] 4 [-+-]- 5 [-+-]+ 2 [-+] [-] [-]- 3 []
        foreach (char c in s)
        {
            if (c >= '0' && c <= '9')
            {
                num = num * 10 + (c - '0');
            }
            else if (c == '+' || c == '-')
            {
                result += sign * num;
                sign = stack.Peek() * (c == '+' ? 1 : -1);
                num = 0;
            }
            else if (c == '(')
            {
                stack.Push(sign);
            }
            else if (c == ')')
            {
                stack.Pop();
            }
        }

        return result += sign * num;
    }
}
