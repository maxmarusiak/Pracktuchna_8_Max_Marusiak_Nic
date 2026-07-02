namespace StudentGroup.Core.Structs;

public readonly struct StudentRecord : IEquatable<StudentRecord>
{
    public int Id { get; }
    public string Name { get; }
    public int Age { get; }

    public StudentRecord(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public void Deconstruct(out int id, out string name, out int age)
    {
        id = Id;
        name = Name;
        age = Age;
    }

    public bool Equals(StudentRecord other) =>
        Id == other.Id && Name == other.Name && Age == other.Age;

    public override bool Equals(object? obj) =>
        obj is StudentRecord sr && Equals(sr);

    public override int GetHashCode() =>
        HashCode.Combine(Id, Name, Age);

    public static bool operator ==(StudentRecord a, StudentRecord b) => a.Equals(b);
    public static bool operator !=(StudentRecord a, StudentRecord b) => !a.Equals(b);

    public override string ToString() => $"{Id}: {Name}, {Age} y.o.";
}
