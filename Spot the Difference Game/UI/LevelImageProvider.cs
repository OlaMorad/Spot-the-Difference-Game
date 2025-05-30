using Spot_the_Difference_Game.UI;

namespace Spot_the_Difference_Game.logic
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
                    return new LevelImages("Images\\image_5.jpg", "Images\\image_6.jpg");

                default:
                    return new LevelImages("Images\\default1.jpg", "Images\\default2.jpg");
            }
        }
    }
}
