namespace GameRunner;

public class Game : IGame
{
    private ISolution solution;

    public Game(ISolution solution)
    {
        this.solution = solution;
    }

    public int Run(string filePath)
    {
        if (solution.CheckMapLengthAndWidth(filePath) &&
            solution.CheckMapSymbols(filePath) &&
            solution.CheckMapExits(filePath))
        {
            int length = 0;
            char[,] map = solution.Map(filePath, ref length);
            solution.ChangeMapSetExits(map, length);
            return solution.FindShortestPath(map, length);
        }
        else
        {
            return 0;
        }
    }
}

