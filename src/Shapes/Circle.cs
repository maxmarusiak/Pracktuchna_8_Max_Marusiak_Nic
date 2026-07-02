using System;

namespace StudentGroupSystem.Shapes
{
    public class Circle : Shape, IResizable, IDrawable, IPrintable
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string GetDescription()
        {
            return $"Circle: {Name}, Color: {Color}, Radius: {Radius}";
        }

        public void Resize(double factor)
        {
            Radius *= factor;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Circle {Name} with radius {Radius}");
        }

        public string GetPrintInfo()
        {
            return $"[Circle] {Name} — R={Radius}, Area={CalculateArea():F2}";
        }
    }
}
