using Xunit;

namespace ObjectOrientedWay.Maze
{
    /*
    7 ■■■■■■▫■
    6 ■▫▫▫■■▫■
    5 ■▫■■■■▫■
    4 ■▫■■■▫▫■
    3 ■▫▫▫▫▫■■
    2 ■■■■▫■■■
    1 ■▫▫▫▫■■■
    0 ■■■■■■■■
      01234567
    */
    public class MazeTest
    {
        [Fact]
        public void FindTheExit()
        {
            var walls = new HashSet<Position>
            {
                new(0, 7), new(1, 7), new(2, 7), new(3, 7), new(4, 7), new(5, 7), new(7, 7),
                new(0, 6), new(4, 6), new(5, 6), new(7, 6),
                new(0, 5), new(2, 5), new(3, 5), new(4, 5), new(5, 5), new(7, 5),
                new(0, 4), new(2, 4), new(3, 4), new(4, 4), new(7, 4),
                new(0, 3), new(6, 3), new(7, 3),
                new(0, 2), new(1, 2), new(2, 2), new(3, 2), new(5, 2), new(6, 2), new(7, 2),
                new(0, 1), new(5, 1), new(6, 1), new(7, 1),
                new(0, 0), new(1, 0), new(2, 0), new(3, 0), new(4, 0), new(5, 0), new(6, 0), new(7, 0)
            };

            var paths = MazeHelper.FindAllPaths((8, 8), new Position(7, 7), walls);

            Assert.Single(paths);
        }

        private static HashSet<Position> GetLargeMazeWalls()
        {
            return new HashSet<Position>
            {
                new(0, 17), new(1, 17), new(2, 17), new(3, 17), new(4, 17), new(5, 17), new(6, 17), new(7, 17), new(8, 17), new(9, 17), new(10, 17), new(11, 17), new(12, 17), new(13, 17), new(14, 17), new(15, 17), new(16, 17), new(17, 17),
                new(0, 16), new(1, 16), new(2, 16), new(3, 16), new(5, 16), new(6, 16), new(7, 16), new(8, 16), new(9, 16), new(10, 16), new(11, 16), new(12, 16), new(13, 16), new(14, 16), new(15, 16), new(16, 16), new(17, 16),
                new(0, 15), new(13, 15), new(14, 15), new(15, 15), new(17, 15),
                new(0, 14), new(1, 14), new(2, 14), new(3, 14), new(5, 14), new(6, 14), new(7, 14), new(8, 14), new(9, 14), new(10, 14), new(11, 14), new(13, 14), new(14, 14), new(15, 14), new(17, 14),
                new(0, 13), new(1, 13), new(2, 13), new(3, 13), new(5, 13), new(6, 13), new(7, 13), new(8, 13), new(13, 13), new(14, 13), new(15, 13), new(17, 13),
                new(0, 12), new(1, 12), new(2, 12), new(3, 12), new(9, 12), new(10, 12), new(11, 12), new(13, 12), new(14, 12), new(15, 12), new(17, 12),
                new(0, 11), new(1, 11), new(2, 11), new(3, 11), new(4, 11), new(5, 11), new(6, 11), new(7, 11), new(9, 11), new(10, 11), new(11, 11), new(13, 11), new(14, 11), new(15, 11), new(17, 11),
                new(0, 10), new(1, 10), new(6, 10), new(7, 10), new(9, 10), new(10, 10), new(11, 10), new(13, 10), new(14, 10), new(15, 10), new(17, 10),
                new(0, 9), new(1, 9), new(3, 9), new(4, 9), new(5, 9), new(6, 9), new(7, 9), new(8, 9), new(9, 9), new(10, 9), new(11, 9), new(13, 9), new(14, 9), new(15, 9), new(17, 9),
                new(0, 8), new(1, 8), new(3, 8), new(4, 8), new(5, 8), new(10, 8), new(11, 8), new(17, 8),
                new(0, 7), new(7, 7), new(8, 7), new(10, 7), new(11, 7), new(12, 7), new(13, 7), new(14, 7), new(16, 7), new(17, 7),
                new(0, 6), new(2, 6), new(3, 6), new(4, 6), new(5, 6), new(6, 6), new(7, 6), new(8, 6), new(10, 6), new(11, 6), new(12, 6), new(13, 6), new(14, 6), new(16, 6), new(17, 6),
                new(0, 5), new(2, 5), new(3, 5), new(17, 5),
                new(0, 4), new(2, 4), new(3, 4), new(4, 4), new(5, 4), new(6, 4), new(7, 4), new(8, 4), new(9, 4), new(10, 4), new(11, 4), new(12, 4), new(13, 4), new(14, 4), new(15, 4), new(16, 4), new(17, 4),
                new(0, 3), new(13, 3), new(14, 3), new(15, 3), new(17, 3),
                new(0, 2), new(1, 2), new(2, 2), new(3, 2), new(4, 2), new(5, 2), new(6, 2), new(7, 2), new(8, 2), new(10, 2), new(11, 2), new(13, 2), new(14, 2), new(15, 2), new(17, 2),
                new(0, 1), new(10, 1), new(11, 1), new(17, 1),
                new(0, 0), new(2, 0), new(3, 0), new(4, 0), new(5, 0), new(6, 0), new(7, 0), new(8, 0), new(9, 0), new(10, 0), new(11, 0), new(12, 0), new(13, 0), new(14, 0), new(15, 0), new(16, 0), new(17, 0)
            };
        }

        [Fact]
        public void FindTheExitLargeMaze()
        {
            var exit = new List<Direction>
            {
                Direction.Down,
                Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right,
                Direction.Down, Direction.Down, Direction.Down, Direction.Down, Direction.Down, Direction.Down, Direction.Down,
                Direction.Right, Direction.Right, Direction.Right,
                Direction.Down, Direction.Down, Direction.Down,
                Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left,
                Direction.Up, Direction.Up, Direction.Up,
                Direction.Left, Direction.Left, Direction.Left,
                Direction.Down,
                Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left,
                Direction.Down, Direction.Down, Direction.Down, Direction.Down,
                Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right,
                Direction.Down, Direction.Down,
                Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left,
                Direction.Down
            };

            var paths = MazeHelper.FindAllPaths((19, 19), new Position(18, 18), GetLargeMazeWalls());

            Assert.Single(paths);
            Assert.Equal(exit, paths.First());
        }

        [Fact]
        public void FindTheExitLargeMazeInstructions()
        {
            var exit = new List<string>
            {
                "1 Down",
                "8 Right",
                "7 Down",
                "3 Right",
                "3 Down",
                "6 Left",
                "3 Up",
                "3 Left",
                "1 Down",
                "5 Left",
                "4 Down",
                "8 Right",
                "2 Down",
                "8 Left",
                "1 Down"
            };

            var paths = MazeHelper.FindAllPaths((19, 19), new Position(18, 18), GetLargeMazeWalls());

            var instructions = MazeHelper.ToInstructions(paths.First());
            Assert.Equal(exit, instructions);
        }

        [Fact]
        public void FindTheShortestExitLargeMazeInstructions()
        {
            var exit = new List<string>
            {
                "1 Down",
                "8 Right",
                "7 Down",
                "4 Right",
                "4 Up",
                "1 Right"
            };

            var walls = GetLargeMazeWalls();
            walls.Remove(new Position(17, 12));

            var paths = MazeHelper.FindAllPaths((19, 19), new Position(18, 18), walls);

            var instructions =
                paths
                .OrderBy(p => p.Count)
                .First()
                .ToList();

            var instructionStrings = MazeHelper.ToInstructions(instructions);
            Assert.Equal(exit, instructionStrings);
        }
    }
}
