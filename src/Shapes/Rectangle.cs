using System;

namespace StudentGroupSystem.Shapes
{
    public class Rectangle : Shape, IResizable, IDrawable, IPrintable
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string GetDescription()
        {
            return $"Rectangle: {Name}, Color: {Color}, W={Width}, H={Height}";
        }

        public void Resize(double factor)
        {
            Width *= factor;
            Height *= factor;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Rectangle {Name} ({Width}x{Height})");
        }

        public string GetPrintInfo()
        {
            return $"[Rectangle] {Name} — {Width}x{Height}, Area={CalculateArea():F2}";
        }
    }
}
