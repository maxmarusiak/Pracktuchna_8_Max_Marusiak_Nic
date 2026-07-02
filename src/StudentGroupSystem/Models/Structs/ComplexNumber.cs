namespace StudentGroup.Core.Structs;

public readonly struct ComplexNumber : IEquatable<ComplexNumber>
{
    public double Real { get; }
    public double Imag { get; }

    public ComplexNumber(double real, double imag)
    {
        Real = real;
        Imag = imag;
    }

    public void Deconstruct(out double real, out double imag)
    {
        real = Real;
        imag = Imag;
    }

    public bool Equals(ComplexNumber other) =>
        Real == other.Real && Imag == other.Imag;

    public override bool Equals(object? obj) =>
        obj is ComplexNumber cn && Equals(cn);

    public override int GetHashCode() =>
        HashCode.Combine(Real, Imag);

    public static bool operator ==(ComplexNumber a, ComplexNumber b) => a.Equals(b);
    public static bool operator !=(ComplexNumber a, ComplexNumber b) => !a.Equals(b);

    public override string ToString() => $"{Real} + {Imag}i";
}
