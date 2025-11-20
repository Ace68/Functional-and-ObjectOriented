namespace ObjectOrientedWay.Maze
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public record Position(int X, int Y);

    public static class MazeHelper
    {
        public static Position MovePos(Position pos, Direction direction)
        {
            return direction switch
            {
                Direction.Up => new Position(pos.X, pos.Y + 1),
                Direction.Down => new Position(pos.X, pos.Y - 1),
                Direction.Left => new Position(pos.X - 1, pos.Y),
                Direction.Right => new Position(pos.X + 1, pos.Y),
                _ => throw new ArgumentException("Invalid direction")
            };
        }

        public static List<List<Direction>> FindAllPaths(
            (int Rows, int Cols) dimensions,
            Position start,
            HashSet<Position> walls)
        {
            var (rows, cols) = dimensions;

            bool IsExit(Position pos)
            {
                return pos.X == 0 || pos.X == rows - 1 || pos.Y == 0 || pos.Y == cols - 1;
            }

            bool IsValid(Position pos)
            {
                return pos.X >= 0 && pos.X < cols && pos.Y >= 0 && pos.Y < rows && !walls.Contains(pos);
            }

            List<List<Direction>> Explore(Position current, List<Direction> path, HashSet<Position> visited)
            {
                var results = new List<List<Direction>>();

                if (IsExit(current))
                {
                    var reversedPath = new List<Direction>(path);
                    reversedPath.Reverse();
                    results.Add(reversedPath);
                    return results;
                }

                foreach (var direction in new[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right })
                {
                    var nextPos = MovePos(current, direction);

                    if (IsValid(nextPos) && !visited.Contains(nextPos))
                    {
                        var newPath = new List<Direction>(path) { direction };
                        var newVisited = new HashSet<Position>(visited) { nextPos };
                        results.AddRange(Explore(nextPos, newPath, newVisited));
                    }
                }

                return results;
            }

            var initialVisited = new HashSet<Position> { start };
            return Explore(start, new List<Direction>(), initialVisited);
        }

        public static List<string> ToInstructions(List<Direction> directions)
        {
            var instructions = new List<(int Count, Direction Direction)>();

            foreach (var direction in directions.Reverse<Direction>())
            {
                if (instructions.Count > 0 && instructions[0].Direction == direction)
                {
                    instructions[0] = (instructions[0].Count + 1, direction);
                }
                else
                {
                    instructions.Insert(0, (1, direction));
                }
            }

            return instructions.Select(i => $"{i.Count} {i.Direction}").ToList();
        }
    }
}
