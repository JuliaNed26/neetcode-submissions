public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        var adj = new Dictionary<string, List<string>>();
        foreach (var ticket in tickets) {
            if (!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }
        }

        tickets.Sort((a, b) => string.Compare(a[1], b[1]));
        foreach (var ticket in tickets) {
            adj[ticket[0]].Add(ticket[1]);
        }

        var res = new List<string> { "JFK" };
        Dfs("JFK", res, adj, tickets.Count + 1);
        return res;
    }

    private bool Dfs(string src, List<string> res,
                     Dictionary<string, List<string>> adj, int targetLen) {
        if (res.Count == targetLen) return true;
        if (!adj.ContainsKey(src)) return false;

        var temp = new List<string>(adj[src]);
        for (int i = 0; i < temp.Count; i++) {
            var v = temp[i];
            adj[src].RemoveAt(i);
            res.Add(v);
            if (Dfs(v, res, adj, targetLen)) return true;
            res.RemoveAt(res.Count - 1);
            adj[src].Insert(i, v);
        }
        return false;
    }
}
