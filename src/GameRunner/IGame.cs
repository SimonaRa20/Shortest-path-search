namespace GameRunner;

public interface IGame
{
    int Run(string filePath);
    char[,] Map(string filePath, ref int length);
    void ChangeMapSetExits(char[,] map, int length);
    int FindShortestPath(char[,] grid, int length);
}