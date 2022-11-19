namespace GameRunner;

public class Game : IGame
{
    private ISolution solution;
    private IMapValidation validation;

    public Game(ISolution solution, IMapValidation validation)
    {
        this.solution = solution;
        this.validation = validation;
    }

    public int Run(string filePath)
    {
        if (validation.CheckMapLengthAndWidth(filePath) &&
            validation.CheckMapSymbols(filePath) &&
            validation.CheckMapExits(filePath))
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

