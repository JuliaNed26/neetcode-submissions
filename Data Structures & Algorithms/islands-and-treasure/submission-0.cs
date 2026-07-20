public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        var queue = new Queue<(int y, int x, int dist)>();
        for(int i = 0; i < grid.Length; i++) 
        {
            for(int k = 0; k < grid[0].Length; k++)
            {
                if(grid[i][k] == 0)
                {
                    queue.Enqueue((i, k, 0));
                }
            }
        }
        while(queue.Count() != 0)
        {
            var (y, x, curDist) = queue.Dequeue();
            if(grid[y][x] < curDist && curDist != 0)
            {
                continue;
            }

            grid[y][x] = curDist;
            if(x > 0 && grid[y][x-1] >= 1)
            {
                queue.Enqueue((y, x-1, curDist + 1));
            }
            if(x < grid[0].Length - 1 && grid[y][x+1] >= 1)
            {
                queue.Enqueue((y, x+1, curDist + 1));
            }
            if(y > 0 && grid[y-1][x] >= 1)
            {
                queue.Enqueue((y-1, x, curDist + 1));
            }
            if(y < grid.Length - 1 && grid[y+1][x] >= 1)
            {
                queue.Enqueue((y+1, x, curDist + 1));
            }
        }
    }
}
