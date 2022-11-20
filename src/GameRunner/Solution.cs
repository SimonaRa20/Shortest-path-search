namespace GameRunner
{
    public class Solution : ISolution
    {
        public int FindShortestPath(char[,] map)
        {
            MapCell source = new MapCell(0, 0, 0);
            int length = map.GetLength(0);
            int width = map.GetLength(1);
            // Marking blocked cells as visited.
            bool[,] visited = new bool[width, length];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (map[i, j] == '1')
                    {
                        visited[i, j] = true;
                    }
                    else
                    {
                        visited[i, j] = false;
                    }

                    // Finding source
                    if (map[i, j] == 'E')
                    {
                        source.X = i;
                        source.Y = j;
                    }
                }
            }

            // Apply BFS on matrix cells starting from X
            Queue<MapCell> q = new();
            q.Enqueue(source);
            visited[source.X, source.Y] = true;
            while (q.Count > 0)
            {
                MapCell p = q.Peek();
                q.Dequeue();

                // Start
                if (map[p.X, p.Y] == 'X')
                {
                    return p.Step;
                }

                // Move up
                if (p.X - 1 >= 0 && visited[p.X - 1, p.Y] == false)
                {
                    q.Enqueue(new MapCell(p.X - 1, p.Y, p.Step + 1));
                    visited[p.X - 1, p.Y] = true;
                }

                // Move down
                if (p.X + 1 < length && visited[p.X + 1, p.Y] == false)
                {
                    q.Enqueue(new MapCell(p.X + 1, p.Y, p.Step + 1));
                    visited[p.X + 1, p.Y] = true;
                }

                // Move left
                if (p.Y - 1 >= 0 && visited[p.X, p.Y - 1] == false)
                {
                    q.Enqueue(new MapCell(p.X, p.Y - 1, p.Step + 1));
                    visited[p.X, p.Y - 1] = true;
                }

                // Move right
                if (p.Y + 1 < width && visited[p.X, p.Y + 1] == false)
                {
                    q.Enqueue(new MapCell(p.X, p.Y + 1, p.Step + 1));
                    visited[p.X, p.Y + 1] = true;
                }
            }
            return -1;
        }
    }
}
