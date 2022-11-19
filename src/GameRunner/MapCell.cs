namespace GameRunner
{
    public class MapCell
    {
        public int X;
        public int Y;
        public int Step;

        public MapCell(int x, int y, int s)
        {
            this.X = x;
            this.Y = y;
            this.Step = s;
        }
    }
}
