public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        var adjList = Enumerable.Range(0,n)
                                .Select(_ => new List<int>(n))
                                .ToList();
        foreach(var edge in edges)
        {
            if(edge[0] == edge[1])
            {
                return false;
            }
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        // 0 - untouched, 1 - visiting, 2 - visited
        var visited = new int[n];
        int processedNodes = 0;

        return dfs(0) && n == processedNodes;

        bool dfs(int curNode)
        {
            if(visited[curNode] == 1)
            {
                return true;
            }

            if(visited[curNode] == 2)
            {
                return false;
            }

            visited[curNode] = 1;

            foreach (var neighbour in adjList[curNode])
            {
                if(!dfs(neighbour))
                {
                    return false;
                }
            }

            visited[curNode] = 2;
            processedNodes++;
            return true;
        }
    }
}
