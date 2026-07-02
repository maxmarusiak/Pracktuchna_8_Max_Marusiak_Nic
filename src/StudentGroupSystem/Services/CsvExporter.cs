using System.Text;
using StudentGroupSystem.Models.Students;

namespace StudentGroupSystem.Services
{
    public class CsvExporter
    {
        public void ExportToCsv(StudentGroup group, string filePath)
        {
            var sb = new StringBuilder();

            // Header
            sb.AppendLine("FirstName,LastName,AverageGrade");

            // Rows
            foreach (var student in group.Students)
            {
                sb.AppendLine($"{student.FirstName},{student.LastName},{student.AverageGrade}");
            }

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
