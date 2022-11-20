namespace GameRunner
{
    public interface IMapValidation
    {
        bool CheckMapLengthAndWidth(string filePath);
        bool CheckMapSymbols(string filePath);
        bool CheckMapExits(string filePath);
        char[,] ReadMap(string filePath);
        void ChangeMapSetExits(char[,] map);
    }
}
