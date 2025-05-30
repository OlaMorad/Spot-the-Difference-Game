//using Emgu.CV;
//using Emgu.CV.Structure;
//using Emgu.CV.CvEnum;
//using System.Drawing;
//using Emgu.CV.Util;
//using Spot_the_Difference_Game.logic;

//public static class DifferenceDetector
//{
//    public static List<DifferencePair> DetectDifferences(string imgPath1, string imgPath2, double minContourArea = 100)
//    {
//        List<DifferencePair> differences = new List<DifferencePair>();

//        // 1. Load images
//        Image<Gray, byte> img1 = new Image<Bgr, byte>(imgPath1).Convert<Gray, byte>();
//        Image<Gray, byte> img2 = new Image<Bgr, byte>(imgPath2).Convert<Gray, byte>();

//        // 2. Compute absolute difference
//        var diff = img1.AbsDiff(img2);

//        // 3. Threshold the difference image
//        var thresh = diff.ThresholdBinary(new Gray(30), new Gray(255));

//        // 4. Find contours
//        using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
//        {
//            Mat hierarchy = new Mat();
//            CvInvoke.FindContours(thresh, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

//            for (int i = 0; i < contours.Size; i++)
//            {
//                var contour = contours[i];
//                double area = CvInvoke.ContourArea(contour);
//                if (area > minContourArea)
//                {
//                    Rectangle rect = CvInvoke.BoundingRectangle(contour);
//                    Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);

//                    differences.Add(new DifferencePair(rect, rect));

//                }
//            }
//        }

//        return differences;
//    }
//}