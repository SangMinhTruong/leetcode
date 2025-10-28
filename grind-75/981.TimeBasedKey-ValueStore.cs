public class TimeMap
{
    private Dictionary<string, List<(int, string)>> map;

    public TimeMap()
    {
        map = new Dictionary<string, List<(int, string)>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        if (!map.ContainsKey(key))
            map[key] = new List<(int, string)>();

        map[key].Add((timestamp, value));
    }

    public string Get(string key, int timestamp)
    {
        if (!map.ContainsKey(key))
            return "";

        List<(int, string)> timestamps = map[key];

        int left = 0;
        int right = timestamps.Count - 1;
        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;
            (int midTimeStamp, string value) = timestamps[mid];

            if (midTimeStamp == timestamp)
                return value;
            else if (midTimeStamp < timestamp)
                left = mid;
            else
                right = mid - 1;
        }

        (int resultTimeStamp, string resultValue) = timestamps[left];

        return resultTimeStamp > timestamp ? "" : resultValue;
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */
