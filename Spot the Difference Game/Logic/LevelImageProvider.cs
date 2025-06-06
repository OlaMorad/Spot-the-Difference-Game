﻿using Spot_the_Difference_Game.logic;
using Spot_the_Difference_Game.UI;

namespace Spot_the_Difference_Game.Logic
{
    public static class LevelImageProvider
    {
        public static LevelImages GetImagesForLevel(GameForm.GameLevel level)
        {
            switch (level)
            {
                case GameForm.GameLevel.Easy:
                    return new LevelImages("Images\\image1.jpg", "Images\\image2.jpg");

                case GameForm.GameLevel.Medium:
                    return new LevelImages("Images\\image3.jpg", "Images\\image4.jpg");

                case GameForm.GameLevel.Hard:
                    return new LevelImages("Images\\img1.jpg", "Images\\img2.jpg");

                default:
                    return new LevelImages("Images\\image_5.jpg", "Images\\image_6.jpg");
            }
        }
    }
}
