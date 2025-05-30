using System.Collections.Generic;
using System.Drawing;

namespace Spot_the_Difference_Game.logic
{
    public static class PredefinedDifferences
    {
        public static List<DifferencePair> EasyLevel => new List<DifferencePair>
        {
             new DifferencePair { Rect1 = new Rectangle(730, 135, 30, 30), Rect2 = new Rectangle(225,130, 30, 30) },
             new DifferencePair { Rect1 = new Rectangle(845, 175, 30, 30), Rect2 = new Rectangle(345, 190, 30, 30) },
             new DifferencePair { Rect1 = new Rectangle(350,50, 30, 30), Rect2 = new Rectangle(850,50, 30, 30) },

        };
        public static List<DifferencePair> MediumLevel => new List<DifferencePair>
        {
            new DifferencePair { Rect1 = new Rectangle(50,35, 30, 30), Rect2 = new Rectangle(560,35, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(65,150, 30, 30), Rect2 = new Rectangle(570,150, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(170, 205, 30, 30), Rect2 = new Rectangle(670,195, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(25, 305, 30, 30), Rect2 = new Rectangle(530,320, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(250, 225, 30, 30), Rect2 = new Rectangle(750,220, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(795,310, 30, 30), Rect2 = new Rectangle(285,305, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(340,375, 30, 30), Rect2 = new Rectangle(845,380, 30, 30) },

        };

        public static List<DifferencePair> HardLevel => new List<DifferencePair>
          {
            new DifferencePair { Rect1 = new Rectangle(35, 330, 30, 30), Rect2 = new Rectangle(535, 330, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(80, 275, 30, 30), Rect2 = new Rectangle(580, 275, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(170, 250, 30, 30), Rect2 = new Rectangle(665,255, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(215, 345, 30, 30), Rect2 = new Rectangle(715, 345, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(270, 365, 30, 30), Rect2 = new Rectangle(765, 360, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(225, 125, 30, 30), Rect2 = new Rectangle(725, 125, 30, 30) },
            new DifferencePair { Rect1 = new Rectangle(265, 180, 30, 30), Rect2 = new Rectangle(760, 175, 30, 30) },
          };


    }
}
