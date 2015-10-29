namespace T14.Labyrinth
{
    public struct Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }
        public int Col { get; private set; }

        public static Position operator +(Position one, Position two)
        {
            var newPosition = new Position(one.Row + two.Row, one.Col + two.Col);
            return newPosition;
        }

        public static Position operator -(Position one, Position two)
        {
            var newPosition = new Position(one.Row - two.Row, one.Col - two.Col);
            return newPosition;
        }
    }
}