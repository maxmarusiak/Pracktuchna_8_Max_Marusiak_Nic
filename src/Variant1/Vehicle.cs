namespace StudentGroupSystem.Variant1
{
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public int Year { get; set; }

        public virtual void Start()
        {
            Console.WriteLine($"{Model} ({Year}) is starting...");
        }

        public virtual void Stop()
        {
            Console.WriteLine($"{Model} is stopping...");
        }

        public abstract string GetInfo();
    }
}
