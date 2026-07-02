namespace StudentGroup.Core.Structs;

public readonly struct GradeRecord : IEquatable<GradeRecord>
{
    public string Subject { get; }
    public int Grade { get; }
    public DateTime Date { get; }

    public GradeRecord(string subject, int grade, DateTime date)
    {
        Subject = subject;
        Grade = grade;
        Date = date;
    }

    public void Deconstruct(out string subject, out int grade, out DateTime date)
    {
        subject = Subject;
        grade = Grade;
        date = Date;
    }

    public bool Equals(GradeRecord other) =>
        Subject == other.Subject && Grade == other.Grade && Date == other.Date;

    public override bool Equals(object? obj) =>
        obj is GradeRecord gr && Equals(gr);

    public override int GetHashCode() =>
        HashCode.Combine(Subject, Grade, Date);

    public static bool operator ==(GradeRecord a, GradeRecord b) => a.Equals(b);
    public static bool operator !=(GradeRecord a, GradeRecord b) => !a.Equals(b);

    public override string ToString() => $"{Subject}: {Grade} ({Date:dd.MM.yyyy})";
}
