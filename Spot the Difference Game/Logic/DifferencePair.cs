public class DifferencePair
{
    public Rectangle Rect1 { get; set; }
    public Rectangle Rect2 { get; set; }

    public Point Rect1Center => new Point(Rect1.X + Rect1.Width / 2, Rect1.Y + Rect1.Height / 2);
    public Point Rect2Center => new Point(Rect2.X + Rect2.Width / 2, Rect2.Y + Rect2.Height / 2);

    public bool Contains(Point p, int tolerance)
    {
        return Rectangle.Inflate(Rect1, tolerance, tolerance).Contains(p)
            || Rectangle.Inflate(Rect2, tolerance, tolerance).Contains(p);
    }
 
}
