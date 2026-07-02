using System;

namespace StudentGroupSystem.Shapes
{
    public class Triangle : Shape, IResizable, IDrawable, IPrintable
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public override double CalculateArea()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public override double CalculatePerimeter()
        {
            return A + B + C;
        }

        public override string GetDescription()
        {
            return $"Triangle: {Name}, Color: {Color}, Sides: {A}, {B}, {C}";
        }

        public void Resize(double factor)
        {
            A *= factor;
            B *= factor;
            C *= factor;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Triangle {Name} with sides {A}, {B}, {C}");
        }

        public string GetPrintInfo()
        {
            return $"[Triangle] {Name} — Sides={A},{B},{C}, Area={CalculateArea():F2}";
        }
    }
}
