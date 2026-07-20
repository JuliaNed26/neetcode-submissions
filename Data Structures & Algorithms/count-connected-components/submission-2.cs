public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var graph = Enumerable.Range(0, n)
                            .ToDictionary(i => i, _ => new List<int>(n));
        foreach(var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        int componentsCount = 0;
        var visited = new bool[n];
        for(int i = 0; i < n; i++)
        {
            if(!visited[i])
            {
                componentsCount++;
                Bfs(i);
            }
        }

        return componentsCount;
        

        void Bfs(int a)
        {
            var queue = new Queue<int>();
            queue.Enqueue(a);
            while(queue.Count() > 0)
            {
                var curNode = queue.Dequeue();
                if(visited[curNode])
                {
                    continue;
                }

                var neighbours = graph.GetValueOrDefault(curNode, []);
                foreach(var neighbour in neighbours)
                {
                    queue.Enqueue(neighbour);
                }

                visited[curNode] = true;
            }
        }
    }
}