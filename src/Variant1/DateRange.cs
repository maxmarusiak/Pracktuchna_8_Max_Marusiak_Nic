namespace Variant1;

public readonly struct DateRange : IEquatable<DateRange>
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public DateRange(DateTime start, DateTime end)
    {
        if (end < start)
            throw new ArgumentException("End date must be >= start date");

        Start = start;
        End = end;
    }

    public void Deconstruct(out DateTime start, out DateTime end)
    {
        start = Start;
        end = End;
    }

    public bool Contains(DateTime date)
    {
        return date >= Start && date <= End;
    }

    public bool Overlaps(DateRange other)
    {
        return Start <= other.End && End >= other.Start;
    }

    // IEquatable<T>
    public bool Equals(DateRange other)
    {
        return Start == other.Start && End == other.End;
    }

    public override bool Equals(object? obj)
    {
        return obj is DateRange dr && Equals(dr);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End);
    }

    // Operators
    public static bool operator ==(DateRange a, DateRange b) => a.Equals(b);
    public static bool operator !=(DateRange a, DateRange b) => !a.Equals(b);

    // Comparison operators (by length)
    public static bool operator >(DateRange a, DateRange b)
    {
        return (a.End - a.Start) > (b.End - b.Start);
    }

    public static bool operator <(DateRange a, DateRange b)
    {
        return (a.End - a.Start) < (b.End - b.Start);
    }

    public override string ToString()
    {
        return $"{Start:dd.MM.yyyy} — {End:dd.MM.yyyy}";
    }
}
