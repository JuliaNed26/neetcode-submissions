public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        var dsu = new DSU(n);
        var componentsCount = n;
        foreach(var edge in edges)
        {
            var union = dsu.Union(edge[0], edge[1]);
            // cycle detected
            if (!union)
            {
                return false;
            }

            componentsCount--;
        }

        return componentsCount == 1;
    }
}

public class DSU
{
    private int[] parents;
    private int[] sizes;

    public DSU(int size)
    {
        parents = Enumerable.Range(0, size)
                            .Select(i => i)
                            .ToArray();
        sizes = new int[size];
        Array.Fill(sizes, 1);
    }

    public bool Union(int a, int b)
    {
        var parA = Find(a);
        var parB = Find(b);

        if(parA == parB) 
        {
            return false;
        }
        
        if(sizes[parB] > sizes[parA])
        {
            parents[parA] = parB;
            sizes[parB] += sizes[parA];
            return true;
        }

        parents[parB] = parA;
        sizes[parA] += sizes[parB];
        return true;
    }

    public int Find(int a)
    {
        if (parents[a] == a)
        {
            return a;
        }

        var rootParent = Find(parents[a]);
        parents[a] = rootParent;
        return rootParent;
    }
}
