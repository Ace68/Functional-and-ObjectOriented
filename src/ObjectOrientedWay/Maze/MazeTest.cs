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
    }
}
