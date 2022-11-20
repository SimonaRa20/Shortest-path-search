namespace GameRunner
{
    public class MapValidation : IMapValidation
    {
        private ISolution solution;

        public MapValidation(ISolution solution)
        {
            this.solution = solution;
        }

        public bool CheckMapLengthAndWidth(string filePath)
        {
            char[,] map = ReadMap(filePath);

            if (map.GetLength(0) != map.GetLength(1) || map.GetLength(0) < 5 || map.GetLength(0) > 11001 || map.GetLength(1) < 5 || map.GetLength(1) > 11001)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckMapSymbols(string filePath)
        {
            char[,] map = ReadMap(filePath);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == ' ' || map[i, j] == '1' || map[i, j] == 'X')
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckMapExits(string filePath)
        {
            int count = 0;
            char[,] map = ReadMap(filePath);
            ChangeMapSetExits(map);

            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[i, j] == 'E')
                    {
                        count++;
                    }
                }
            }

            if (count <= 0 || count > 1000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public char[,] ReadMap(string filePath)
        {
            int columns = File.ReadAllLines(filePath)[0].Length;
            int rows = File.ReadAllLines(filePath).Count();
            char[,] arr = new char[rows, columns];
            StreamReader sr = File.OpenText(filePath);
            for (int i = 0; i < rows; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < columns; j++)
                {
                    arr[i, j] = line[j];
                }
            }
            return arr;
        }

        public void ChangeMapSetExits(char[,] map)
        {
            int rows = map.GetLength(0);
            int columns = map.GetLength(1);
            // marking outputs with different symbol
            char mapExit = 'E';
            for (int i = 0; i < rows; i++)
            {
                if (map[i, 0] == ' ')
                {
                    map[i, 0] = mapExit;
                }
                else if (map[rows - 1, i] == ' ')
                {
                    map[rows - 1, i] = mapExit;
                }
            }

            for (int j = 0; j < columns; j++)
            {
                if (map[0, j] == ' ')
                {
                    map[0, j] = mapExit;
                }
                else if (map[j, columns - 1] == ' ')
                {
                    map[j, columns - 1] = mapExit;
                }
            }
        }
    }
}
