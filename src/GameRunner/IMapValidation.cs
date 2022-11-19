namespace GameRunner
{
    public interface IMapValidation
    {
        bool CheckMapLengthAndWidth(string filePath);
        bool CheckMapSymbols(string filePath);
        bool CheckMapExits(string filePath);
    }
}
