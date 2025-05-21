using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot_the_Difference_Game.logic
{
    public class LevelImages
    {
        public string Image1Path { get; set; }
        public string Image2Path { get; set; }

        public LevelImages(string img1, string img2)
        {
            Image1Path = img1;
            Image2Path = img2;
        }
    }
}

