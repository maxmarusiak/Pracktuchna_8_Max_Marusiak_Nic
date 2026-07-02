namespace StudentGroupSystem.Variant1
{
    public class Car : Vehicle
    {
        public int Doors { get; set; }

        public override void Start()
        {
            Console.WriteLine($"Car {Model} starts smoothly.");
        }

        public override string GetInfo()
        {
            return $"Car: {Model}, Year: {Year}, Doors: {Doors}";
        }
    }
}
