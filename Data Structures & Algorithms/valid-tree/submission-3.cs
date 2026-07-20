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

        var visited = new bool[n];
        int processedNodes = 0;
        var queue = new Queue<(int node, int parent)>();
        queue.Enqueue((0, -1));

        return bfs() && n == processedNodes;

        bool bfs()
        {
            while (queue.Count != 0)
            {
                var curNode = queue.Dequeue();

                if(visited[curNode.node])
                {
                    return false;
                }

                foreach (var neighbour in adjList[curNode.node])
                {
                    if(curNode.parent != neighbour)
                    {
                        queue.Enqueue((neighbour, curNode.node));
                    }
                }

                visited[curNode.node] = true;
                processedNodes++;
            }
            return true;
        }
    }
}
