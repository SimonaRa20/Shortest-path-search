namespace GameRunner;

public class Game : IGame
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
        QItem source = new QItem(0, 0, 0);

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
                    source.row = i;
                    source.col = j;
                }
            }
        }

        // Apply BFS on matrix cells starting from X
        Queue<QItem> q = new Queue<QItem>();
        q.Enqueue(source);
        visited[source.row, source.col] = true;
        while (q.Count > 0)
        {
            QItem p = q.Peek();
            q.Dequeue();

            // Start
            if (grid[p.row, p.col] == 'X')
            {
                return p.dist;
            }

            // Move up
            if (p.row - 1 >= 0
                && visited[p.row - 1, p.col] == false)
            {
                q.Enqueue(new QItem(p.row - 1, p.col,
                                    p.dist + 1));
                visited[p.row - 1, p.col] = true;
            }

            // Move down
            if (p.row + 1 < length
                && visited[p.row + 1, p.col] == false)
            {
                q.Enqueue(new QItem(p.row + 1, p.col,
                                    p.dist + 1));
                visited[p.row + 1, p.col] = true;
            }

            // Move left
            if (p.col - 1 >= 0
                && visited[p.row, p.col - 1] == false)
            {
                q.Enqueue(new QItem(p.row, p.col - 1,
                                    p.dist + 1));
                visited[p.row, p.col - 1] = true;
            }

            // Meve right
            if (p.col + 1 < length
                && visited[p.row, p.col + 1] == false)
            {
                q.Enqueue(new QItem(p.row, p.col + 1,
                                    p.dist + 1));
                visited[p.row, p.col + 1] = true;
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

    public int Run(string filePath)
    {
        int length = 0;
        char[,] map = Map(filePath, ref length);
        ChangeMapSetExits(map, length);
        return FindShortestPath(map, length);
    }
}

public class QItem
{
    public int row;
    public int col;
    public int dist;

    public QItem(int x, int y, int w)
    {
        this.row = x;
        this.col = y;
        this.dist = w;
    }
}