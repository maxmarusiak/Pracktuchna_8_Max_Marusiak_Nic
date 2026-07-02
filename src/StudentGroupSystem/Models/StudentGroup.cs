using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGroupSystem.Models
{
    public class StudentGroup : BaseEntity
    {
        public string GroupName { get; set; }
        public Point[] LabPlaces { get; private set; } = Array.Empty<Point>();
        public GradeRecord[] GradeHistory { get; private set; } = Array.Empty<GradeRecord>();


        public List<UniversityMember> Members { get; set; }

        public StudentGroup(int id, string name)
            : base(id)
        {
            GroupName = name;
            Members = new List<UniversityMember>();
        }

        public void AddGrade(int studentId, GradeRecord record)
        {
            GradeHistory = GradeHistory.Append(record).ToArray();
        }

        public void AssignLabPlace(int studentId, Point place)
        {
            LabPlaces = LabPlaces.Append(place).ToArray();
        }

        public StudentRecord[] GetAllRecords()
        {
            return Students.Select(s => s.GetRecord()).ToArray();
        }
        public void OptimizeStorage()
        {
            GradeHistory = GradeHistory.Distinct().ToArray();
            LabPlaces = LabPlaces.Distinct().ToArray();

            Console.WriteLine("Storage optimized using structs.");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Group: {GroupName}, Members: {Members.Count}";
        }

        public void AddMember(UniversityMember member)
        {
            Members.Add(member);
        }

        public void RemoveMember(int id)
        {
            var m = Members.FirstOrDefault(x => x.Id == id);
            if (m != null)
                Members.Remove(m);
        }

        public IEnumerable<UniversityMember> Search(string fragment)
        {
            return Members.Where(m => m.Name.Contains(fragment, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Student> GetStudents()
        {
            return Members.OfType<Student>();
        }

        public double GetAverageGrade()
        {
            var students = Members.OfType<Student>().ToList();
            if (students.Count == 0) return 0;

            return students.Average(s => s.AverageGrade.Value);
        }

        public void PrintAll()
        {
            foreach (var m in Members)
                Console.WriteLine(m.GetInfo());
        }

         public double GetTotalAreaOfAllShapes()
        {
            double total = 0;

            foreach (var student in Students)
            {
                foreach (var shape in student.Shapes)
                {
                    total += shape.CalculateArea();   // поліморфізм через Shape
                }
            }

            return total;
        }

        public void DrawAllShapes()
        {
            foreach (var student in Students)
            {
                foreach (var shape in student.Shapes)
                {
                    if (shape is IDrawable drawable)
                    {
                        drawable.Draw();              // поліморфізм через інтерфейс
                    }
                }
            }
        }

        public void ResizeAllShapes(double factor)
        {
            foreach (var student in Students)
            {
                foreach (var shape in student.Shapes)
                {
                    if (shape is IResizable resizable)
                    {
                        resizable.Resize(factor);     // поліморфізм через інтерфейс
                    }
                }
            }
        }

        public void PrintAllShapes()
        {
            foreach (var student in Students)
            {
                foreach (var shape in student.Shapes)
                {
                    if (shape is IPrintable printable)
                    {
                        Console.WriteLine(printable.GetPrintInfo());
                    }
                }
            }
        }


        public void Save(string filePath, StorageFormat format)
        {
            var fileManager = new FileManager();

            switch (format)
            {
                case StorageFormat.Json:
                    fileManager.SaveToJson(this, filePath);
                    break;

                case StorageFormat.Txt:
                    string text = ToTextFormat();
                    fileManager.SaveToText(text, filePath);
                    break;
            }
        }

        public static StudentGroup Load(string filePath, StorageFormat format)
        {
            var fileManager = new FileManager();

            return format switch
            {
                StorageFormat.Json => fileManager.LoadFromJson<StudentGroup>(filePath),
                StorageFormat.Txt => FromTextFormat(fileManager.ReadFromText(filePath)),
                _ => throw new InvalidOperationException("Unsupported format")
            };
        }

        private string ToTextFormat()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Group: {GroupName}");
            sb.AppendLine("Students:");

            foreach (var student in Students)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName} — {student.AverageGrade}");
            }

            return sb.ToString();
        }

        private static StudentGroup FromTextFormat(string content)
        {
            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var group = new StudentGroup
            {
                GroupName = lines[0].Replace("Group: ", "").Trim()
            };

            for (int i = 2; i < lines.Length; i++)
            {
                var parts = lines[i].Split('—');
                if (parts.Length == 2)
                {
                    var nameParts = parts[0].Trim().Split(' ');
                    var student = new Student
                    {
                        FirstName = nameParts[0],
                        LastName = nameParts[1],
                        AverageGrade = double.Parse(parts[1].Trim())
                    };

                    group.Students.Add(student);
                }
            }

            return group;
        }

        
    }
}
