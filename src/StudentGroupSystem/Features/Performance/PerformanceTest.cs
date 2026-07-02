using System.Diagnostics;
using StudentGroupSystem.Models;
using StudentGroupSystem.Models.Structs;

namespace StudentGroupSystem.Features.Performance;

public class PerformanceTest
{
    public void Run()
    {
        var sw = new Stopwatch();

        sw.Start();
        var structArr = GenerateStructs(500000);
        sw.Stop();
        Console.WriteLine($"Struct creation: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        Array.Sort(structArr);
        sw.Stop();
        Console.WriteLine($"Struct sort: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        var classArr = GenerateClasses(500000);
        sw.Stop();
        Console.WriteLine($"Class creation: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        Array.Sort(classArr);
        sw.Stop();
        Console.WriteLine($"Class sort: {sw.ElapsedMilliseconds} ms");
    }

    private StudentRecord[] GenerateStructs(int count)
    {
        var arr = new StudentRecord[count];
        for (int i = 0; i < count; i++)
            arr[i] = new StudentRecord(i, $"Name{i}", 20);
        return arr;
    }

    private Student[] GenerateClasses(int count)
    {
        var arr = new Student[count];
        for (int i = 0; i < count; i++)
            arr[i] = new Student(i, $"Name{i}", 20);
        return arr;
    }
}
