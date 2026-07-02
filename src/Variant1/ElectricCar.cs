namespace StudentGroupSystem.Variant1
{
    public class ElectricCar : Vehicle
    {
        public int BatteryCapacity { get; set; }

        public override void Start()
        {
            Console.WriteLine($"Electric car {Model} powers on silently.");
        }

        public override string GetInfo()
        {
            return $"ElectricCar: {Model}, Year: {Year}, Battery: {BatteryCapacity} kWh";
        }
    }
}
