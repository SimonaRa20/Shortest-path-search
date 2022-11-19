namespace GameRunner
{
    public interface ISolution
    {
        bool CheckMapLengthAndWidth(string filePath);
        bool CheckMapSymbols(string filePath);
        bool CheckMapExits(string filePath);
        char[,] Map(string filePath, ref int length);
        void ChangeMapSetExits(char[,] map, int length);
        int FindShortestPath(char[,] grid, int length);
    }
}
