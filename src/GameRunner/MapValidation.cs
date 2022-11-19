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
            int length = 0;
            char[,] map = solution.Map(filePath, ref length);
            solution.ChangeMapSetExits(map, length);

            for (int i = 0; i < length; i++)
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
    }
}
