public class Solution
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        Dictionary<string, IList<int>> emailAccountMap = new Dictionary<string, IList<int>>();

        for (int i = 0; i < accounts.Count; i++)
        {
            for (int j = 1; j < accounts[i].Count; j++)
            {
                string email = accounts[i][j];

                if (!emailAccountMap.ContainsKey(email))
                    emailAccountMap[email] = new List<int>();

                emailAccountMap[email].Add(i);
            }
        }

        bool[] visited = new bool[accounts.Count];
        IList<IList<string>> result = new List<IList<string>>();

        for (int i = 0; i < accounts.Count; i++)
        {
            if (visited[i])
                continue;

            List<string> currentAccount = new List<string> { accounts[i][0] };
            SortedSet<string> mergedEmails = new SortedSet<string>(new EmailComparer());

            DFS(accounts, i, mergedEmails, visited, emailAccountMap);

            currentAccount.AddRange(mergedEmails);
            result.Add(currentAccount);
        }

        return result;
    }

    private void DFS(
        IList<IList<string>> accounts,
        int i,
        SortedSet<string> mergedEmails,
        bool[] visited,
        Dictionary<string, IList<int>> emailAccountMap
    )
    {
        if (visited[i])
            return;

        visited[i] = true;

        for (int j = 1; j < accounts[i].Count; j++)
        {
            string email = accounts[i][j];

            mergedEmails.Add(email);

            IList<int> linkedAccounts = emailAccountMap[email];
            foreach (int accountIndex in linkedAccounts)
            {
                DFS(accounts, accountIndex, mergedEmails, visited, emailAccountMap);
            }
        }
    }

    private class EmailComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            return string.CompareOrdinal(a, b);
        }
    }
}
