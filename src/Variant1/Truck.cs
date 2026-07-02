namespace StudentGroupSystem.Variant1
{
    public class Truck : Vehicle
    {
        public double LoadCapacity { get; set; }

        public override void Start()
        {
            Console.WriteLine($"Truck {Model} rumbles to life.");
        }

        public override string GetInfo()
        {
            return $"Truck: {Model}, Year: {Year}, Capacity: {LoadCapacity} tons";
        }
    }
}
