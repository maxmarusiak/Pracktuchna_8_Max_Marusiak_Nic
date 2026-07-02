using System;

namespace StudentGroupSystem.Shapes
{
    public class Square : Rectangle
    {
        public double Side
        {
            get => Width;
            set
            {
                Width = value;
                Height = value;
            }
        }

        public override string GetDescription()
        {
            return $"Square: {Name}, Color: {Color}, Side={Side}";
        }

        public override string GetPrintInfo()
        {
            return $"[Square] {Name} — Side={Side}, Area={CalculateArea():F2}";
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing Square {Name} with side {Side}");
        }
    }
}
