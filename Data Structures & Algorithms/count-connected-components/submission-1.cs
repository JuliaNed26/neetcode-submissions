public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var graph = Enumerable.Range(0, n)
                            .ToDictionary(i => i, _ => new List<int>(n));
        foreach(var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        
        int componentsCount = n;
        var visited = new bool[n];
        for(int i = 0; i < n; i++)
        {
            if(!visited[i])
            {
                componentsCount -= Dfs(i) - 1;
            }
        }

        return componentsCount;
        

        int Dfs(int a)
        {
            int componentSize = 0;
            var stack = new Stack<int>();
            stack.Push(a);
            while(stack.Count() > 0)
            {
                var curNode = stack.Pop();
                if(visited[curNode])
                {
                    continue;
                }

                var neighbours = graph.GetValueOrDefault(curNode, []);
                foreach(var neighbour in neighbours)
                {
                    stack.Push(neighbour);
                }

                visited[curNode] = true;
                componentSize++;
            }

            return componentSize;
        }
    }
}
