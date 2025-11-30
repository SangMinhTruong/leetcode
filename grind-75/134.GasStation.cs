public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int totalGas = 0;
        int curGas = 0;
        int start = 0;

        for (int i = 0; i < gas.Length; i++)
        {
            totalGas += gas[i] - cost[i];
            curGas += gas[i] - cost[i];

            if (curGas < 0)
            {
                start = i + 1;
                curGas = 0;
            }
        }

        return totalGas >= 0 ? start : -1;
    }
}
