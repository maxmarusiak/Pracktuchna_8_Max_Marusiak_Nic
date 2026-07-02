namespace StudentGroupSystem.Variant1
{
    public class Bus : Vehicle
    {
        public int Seats { get; set; }

        public override void Start()
        {
            Console.WriteLine($"Bus {Model} starts with passengers.");
        }

        public override string GetInfo()
        {
            return $"Bus: {Model}, Year: {Year}, Seats: {Seats}";
        }
    }
}
