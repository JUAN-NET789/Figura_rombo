namespace HorseHarvester
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(string coordinate)
        {
            Column = coordinate[0] - 'A';
            Row = 8 - int.Parse(coordinate[1].ToString());
        }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return $"{(char)(Column + 'A')}{8 - Row}";
        }
    }

    public class Horse
    {
        public Position CurrentPosition { get; private set; }
        private static readonly Dictionary<string, (int, int)> Moves = new()
        {
            {"UL", (-2, -1)}, {"UR", (-2, 1)},
            {"LU", (-1, -2)}, {"LD", (1, -2)},
            {"RU", (-1, 2)}, {"RD", (1, 2)},
            {"DL", (2, -1)}, {"DR", (2, 1)}
        };
        public Horse(string initialPosition)
        {
            CurrentPosition = new Position(initialPosition);
        }
        public bool Move(string direction)
        {
            if (Moves.ContainsKey(direction))
            {
                var (dr, dc) = Moves[direction];
                var newRow = CurrentPosition.Row + dr;
                var newColumn = CurrentPosition.Column + dc;
                if (newRow >= 0 && newRow < 8 && newColumn >= 0 && newColumn < 8)
                {
                    CurrentPosition = new Position(newRow, newColumn);
                    return true;
                }
            }
            return false;
        }
    }
    public class Board
    {
        private readonly char?[,] _board = new char?[8, 8];
        public void AddFruit(string coordinate, char fruit)
        {
            var pos = new Position(coordinate);
            _board[pos.Row, pos.Column] = fruit;
        }
        public char? PickFruit(Position position)
        {
            var fruit = _board[position.Row, position.Column];
            _board[position.Row, position.Column] = null;
            return fruit;
        }
    }
}