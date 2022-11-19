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
            int mapLength = File.ReadAllLines(filePath)[0].Length;
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

        public bool CheckMapSymbols(string filePath)
        {
            int mapLength = File.ReadAllLines(filePath).Length;
            char[,] arr = new char[mapLength, mapLength];
            StreamReader sr = File.OpenText(filePath);
            for (int i = 0; i < mapLength; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    arr[i, j] = line[j];
                    if (arr[i, j] == ' ' || arr[i, j] == '1' || arr[i, j] == 'X')
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
            int length = map.GetLength(0);
            int width = map.GetLength(1);
            ChangeMapSetExits(map);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
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

        private char[,] ReadMap(string filePath)
        {
            int mapLength = File.ReadAllLines(filePath)[0].Length;
            int mapWidth = File.ReadAllLines(filePath).Count();
            char[,] arr = new char[mapLength, mapLength];
            StreamReader sr = File.OpenText(filePath);
            for (int i = 0; i < mapLength; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    arr[i, j] = line[j];
                }
            }
            return arr;
        }

        private void ChangeMapSetExits(char[,] map)
        {
            int length = map.GetLength(0);
            int width = map.GetLength(1);
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
    }
}
