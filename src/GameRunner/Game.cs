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
            char[,] map = solution.ReadFile(filePath);
            solution.ChangeMapSetExits(map);
            return solution.FindShortestPath(map);
        }
        else
        {
            return 0;
        }
    }
}

