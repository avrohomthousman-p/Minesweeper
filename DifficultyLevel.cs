using System;
using System.Drawing;

namespace MinesweeperModel
{
    public enum DifficultyLevel
    {
        Easy, // 10 x 8
        Medium,// 18 x 14
        Hard  // 24 x 20
    }

    public static class Extensions
    {
        public static Point GetSize(this DifficultyLevel dl )
        {
            switch (dl)
            {
                case DifficultyLevel.Easy:
                    return new Point(8, 10);
                case DifficultyLevel.Medium:
                    return new Point(14, 18);
                case DifficultyLevel.Hard:
                    return new Point(20, 24);
                default:
                    throw new ArgumentException($"The system only supports dificulties of easy, medium, or hard. Got {dl}");
            }
        }

        public static int GetBombsCount(this DifficultyLevel dl)
        {
            switch (dl)
            {
                case DifficultyLevel.Easy:
                    return 10;
                case DifficultyLevel.Medium:
                    return 40;
                case DifficultyLevel.Hard:
                    return 99;
                default:
                    throw new ArgumentException($"The system only supports dificulties of easy, medium, or hard. Got {dl}");

            }
        }
    }
}