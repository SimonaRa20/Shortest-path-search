namespace GameRunner
{
    public interface ISolution
    {
        char[,] ReadFile(string filePath);
        void ChangeMapSetExits(char[,] map);
        int FindShortestPath(char[,] map);
    }
}
