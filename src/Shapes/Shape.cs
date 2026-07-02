namespace StudentGroupSystem.Shapes
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();


        public abstract string GetDescription();
    }
}
