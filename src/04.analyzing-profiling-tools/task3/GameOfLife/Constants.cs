using GameOfLife.Models;
using System.Collections.Generic;

namespace GameOfLife
{
    public static class Constants
    {
        public static class Ads
        {
            public static List<AdModel> AdContents = new List<AdModel>
            {
               new AdModel { FileName = "ad1.jpg", Url = "http://example1.com" },
               new AdModel { FileName = "ad2.jpg", Url = "http://example2.com" },
               new AdModel { FileName = "ad3.jpg", Url = "http://example3.com" },
            };

            public const int DefaultAdIndex = 0;
            public const int DefaultAdSecondsInterval = 3;

            public const int AdWindowDefaultWidth = 350;
            public const int AdWindowDefaultHeight = 100;
        }

        public static class GameOfLifeOptions
        {
            public const int MillisecondsTickInterval = 200;
        }

        public static class Graphics
        {
            public const int DefaultCellDiameter = 5;
            public const int DefaultThicknessLength = 0;
        }
    }
}