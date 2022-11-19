namespace GameRunner
{
    public interface ISolution
    {
        char[,] Map(string filePath, ref int length);
        void ChangeMapSetExits(char[,] map, int length);
        int FindShortestPath(char[,] grid, int length);
    }
}
