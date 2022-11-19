namespace GameRunner
{
    public class Solution : ISolution
    {
        public void ChangeMapSetExits(char[,] map, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (map[0, i] == ' ')
                {
                    map[0, i] = 'E';
                }
                else if (map[i, 0] == ' ')
                {
                    map[i, 0] = 'E';
                }
                else if (map[length - 1, i] == ' ')
                {
                    map[length - 1, i] = 'E';
                }
                else if (map[i, length - 1] == ' ')
                {
                    map[i, length - 1] = 'E';
                }
            }
        }

        public int FindShortestPath(char[,] grid, int length)
        {
            MapCell source = new MapCell(0, 0, 0);

            // Marking blocked cells as visited.
            bool[,] visited = new bool[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (grid[i, j] == '1')
                    {
                        visited[i, j] = true;
                    }
                    else
                    {
                        visited[i, j] = false;
                    }

                    // Finding source
                    if (grid[i, j] == 'E')
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
                if (grid[p.X, p.Y] == 'X')
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

                // Meve right
                if (p.Y + 1 < length && visited[p.X, p.Y + 1] == false)
                {
                    q.Enqueue(new MapCell(p.X, p.Y + 1, p.Step + 1));
                    visited[p.X, p.Y + 1] = true;
                }
            }
            return -1;
        }

        public char[,] Map(string filePath, ref int length)
        {
            length = File.ReadAllLines(filePath).Length;
            char[,] arr = new char[length, length];
            StreamReader sr = File.OpenText(filePath);

            for (int i = 0; i < length; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    arr[i, j] = line[j];
                }
            }

            return arr;
        }

        public bool CheckMapLengthAndWidth(string filePath)
        {
            int mapLength = File.ReadAllLines(filePath).Length;
            int mapWidth = File.ReadAllLines(filePath).Count();

            if (mapLength != mapWidth || mapLength < 5 || mapLength > 11001 || mapWidth < 5 || mapWidth > 11001)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
