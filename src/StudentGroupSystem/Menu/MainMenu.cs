using System;
using StudentGroupSystem.Models.Groups;
using StudentGroupSystem.Models.Students;
using StudentGroupSystem.Shapes;
using StudentGroupSystem.Shapes.Interfaces;

namespace StudentGroupSystem.Menu
{
    public class MainMenu
    {
        private StudentGroup _group;
        private Student _currentStudent;
        private Logger _logger = new Logger();
        private LogRotationService _logRotation = new LogRotationService();


        public MainMenu()
        {
            _group = new StudentGroup(1, "Polymorphism Group");
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MAIN MENU (POLYMORPHISM) ===");
                Console.WriteLine("1. Add Bachelor");
                Console.WriteLine("2. Add Master");
                Console.WriteLine("3. Add PhD");
                Console.WriteLine("4. Show All Members");
                Console.WriteLine("5. Select Student");
                Console.WriteLine("6. Show Average Grade");

                Console.WriteLine("31. Add Shape");
                Console.WriteLine("32. Show All Shapes");
                Console.WriteLine("33. Total Area of Shapes");
                Console.WriteLine("34. Resize All Shapes");
                Console.WriteLine("35. Draw All Shapes");
                Console.WriteLine("36. Print Shapes Info");
                Console.WriteLine("37. Demonstrate Dynamic Binding");

                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                string input = Console.ReadLine();

                _logger.Log($"User selected option: {input}");

                switch (input)
                {
                    case "1":
                        _logger.Log("Executing AddBachelor()");
                        AddBachelor();
                        break;

                    case "2":
                        _logger.Log("Executing AddMaster()");
                        AddMaster();
                        break;

                    case "3":
                        _logger.Log("Executing AddPhD()");
                        AddPhD();
                        break;

                    case "4":
                        _logger.Log("Executing PrintAll()");
                        _group.PrintAll();
                        Console.ReadKey();
                        break;

                    case "5":
                        _logger.Log("Executing SelectStudent()");
                        SelectStudent();
                        break;

                    case "6":
                        _logger.Log("Executing GetAverageGrade()");
                        Console.WriteLine($"Average grade: {_group.GetAverageGrade()}");
                        Console.ReadKey();
                        break;

                    case "31":
                        _logger.Log("Executing AddNewShape()");
                        AddNewShape();
                        break;

                    case "32":
                        _logger.Log("Executing ShowAllShapes()");
                        ShowAllShapes();
                        break;

                    case "33":
                        _logger.Log("Executing CalculateTotalArea()");
                        CalculateTotalArea();
                        break;

                    case "34":
                        _logger.Log("Executing ResizeAllShapes()");
                        ResizeAllShapes();
                        break;

                    case "35":
                        _logger.Log("Executing DrawAllShapes()");
                        DrawAllShapes();
                        break;

                    case "36":
                        _logger.Log("Executing PrintAllShapes()");
                        PrintAllShapes();
                        break;

                    case "37":
                        _logger.Log("Executing DemonstrateDynamicBinding()");
                        DemonstrateDynamicBinding();
                        break;

                    case "38":
                        _logger.Log("Executing DemoPointAndGrade()");
                        DemoPointAndGrade();
                        break;

                    case "39":
                        _logger.Log("Executing PerformanceTest.Run()");
                        new PerformanceTest().Run();
                        break;

                    case "40":
                        _logger.Log("Executing ConvertStudentToRecord()");
                        ConvertStudentToRecord();
                        break;

                    case "41":
                        _logger.Log("Executing ShowGradeHistory()");
                        ShowGradeHistory();
                        break;

                    case "42":
                        _logger.Log("Executing TestEqualsStructs()");
                        TestEqualsStructs();
                        break;

                    case "43":
                        _logger.Log("Executing OptimizeStorage()");
                        group.OptimizeStorage();
                        break;

                    case "44":
                        _logger.Log("Executing SaveJson()");
                        SaveJson();
                        break;

                    case "45":
                        _logger.Log("Executing LoadJson()");
                        LoadJson();
                        break;

                    case "46":
                        _logger.Log("Executing ExportCsv()");
                        ExportCsv();
                        break;

                    case "47":
                        _logger.Log("Executing SaveReportTxt()");
                        SaveReportTxt();
                        break;

                    case "48":
                        _logger.Log("Executing CreateBackup()");
                        CreateBackup();
                        break;

                    case "49":
                        _logger.Log("Executing ViewBackups()");
                        ViewBackups();
                        break;

                    case "50":
                        _logger.Log("Executing ImportStudentsTxt()");
                        ImportStudentsTxt();
                        break;

                    case "51":
                        _logger.Log("Executing CleanOldBackups()");
                        CleanOldBackups();
                        break;

                    case "52":
                        _logger.Log("Executing TestExceptionHandling()");
                        _group.TestExceptionHandling();
                        break;

                    case "0":
                        _logger.Log("Exiting program");
                        return;

                    default:
                        _logger.Log("Invalid option selected");
                        Console.WriteLine("Invalid option");
                        Console.ReadKey();
                        break;
                }

                _logRotation.RotateIfNeeded();
            }
        }


        // ---------------- STUDENTS ----------------

        private void AddBachelor()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Grade: ");
            double grade = double.Parse(Console.ReadLine());

            var gp = new GradePoint(id + 1000, grade);
            var b = new BachelorStudent(id, name, gp);

            _group.AddMember(b);
        }

        private void AddMaster()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Grade: ");
            double grade = double.Parse(Console.ReadLine());

            var gp = new GradePoint(id + 2000, grade);
            var m = new MasterStudent(id, name, gp);

            _group.AddMember(m);
        }

        private void AddPhD()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Grade: ");
            double grade = double.Parse(Console.ReadLine());

            var gp = new GradePoint(id + 3000, grade);
            var p = new PhDStudent(id, name, gp);

            _group.AddMember(p);
        }

        private void SelectStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            _currentStudent = _group.Search(name).FirstOrDefault();

            if (_currentStudent == null)
            {
                Console.WriteLine("Student not found.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Selected: {_currentStudent.Name}");
                Console.ReadKey();
            }
        }

        // ---------------- SHAPES ----------------

        private void AddNewShape()
        {
            if (_currentStudent == null)
            {
                RequireStudent();
                return;
            }

            Console.WriteLine("Choose shape: 1 - Circle, 2 - Rectangle, 3 - Triangle, 4 - Square");
            int choice = int.Parse(Console.ReadLine());

            Shape shape = null;

            switch (choice)
            {
                case 1:
                    Console.Write("Radius: ");
                    shape = new Circle { Radius = double.Parse(Console.ReadLine()), Name = "Circle", Color = "Red" };
                    break;

                case 2:
                    Console.Write("Width: ");
                    double w = double.Parse(Console.ReadLine());
                    Console.Write("Height: ");
                    double h = double.Parse(Console.ReadLine());
                    shape = new Rectangle { Width = w, Height = h, Name = "Rectangle", Color = "Blue" };
                    break;

                case 3:
                    Console.Write("Side A: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Side B: ");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("Side C: ");
                    double c = double.Parse(Console.ReadLine());
                    shape = new Triangle { A = a, B = b, C = c, Name = "Triangle", Color = "Green" };
                    break;

                case 4:
                    Console.Write("Side: ");
                    double s = double.Parse(Console.ReadLine());
                    shape = new Square { Side = s, Name = "Square", Color = "Yellow" };
                    break;
            }

            if (shape != null)
            {
                _currentStudent.AddShape(shape);
                Console.WriteLine("Shape added!");
            }

            Console.ReadKey();
        }

        private void ShowAllShapes()
        {
            if (_currentStudent == null)
            {
                RequireStudent();
                return;
            }

            foreach (var shape in _currentStudent.Shapes)
            {
                Console.WriteLine(shape.GetDescription());
            }

            Console.ReadKey();
        }

        private void RequireStudent()
        {
            Console.WriteLine("Select a student first!");
            Console.ReadKey();
        }


        private void CalculateTotalArea()
        {
            double total = _group.GetTotalAreaOfAllShapes();
            Console.WriteLine($"Total area: {total:F2}");
            Console.ReadKey();
        }

        private void ResizeAllShapes()
        {
            Console.Write("Resize factor: ");
            double factor = double.Parse(Console.ReadLine());

            _group.ResizeAllShapes(factor);
            Console.WriteLine("Shapes resized!");

            Console.ReadKey();
        }

        private void DrawAllShapes()
        {
            _group.DrawAllShapes();
            Console.ReadKey();
        }

        private void PrintAllShapes()
        {
            _group.PrintAllShapes();
            Console.ReadKey();
        }

        private void DemonstrateDynamicBinding()
        {
            if (_currentStudent == null)
            {
                RequireStudent();
                return;
            }

            foreach (var shape in _currentStudent.Shapes)
            {
                Console.WriteLine(shape.GetDescription());
                Console.WriteLine($"Area: {shape.CalculateArea()}");
                Console.WriteLine($"Perimeter: {shape.CalculatePerimeter()}");
            }

            Console.ReadKey();
        }

                private void SaveJson()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            _group.Save(path, StorageFormat.Json);
            Console.WriteLine("Saved to JSON.");
        }

        private void LoadJson()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            _group = StudentGroup.Load(path, StorageFormat.Json);
            Console.WriteLine("Loaded from JSON.");
        }

        private void ExportCsv()
        {
            Console.Write("Enter CSV file path: ");
            string path = Console.ReadLine();
            _group.ExportGradesToCsv(path);
            Console.WriteLine("CSV exported.");
        }

        private void SaveReportTxt()
        {
            Console.Write("Enter TXT file path: ");
            string path = Console.ReadLine();
            _fileManager.SaveToText(_group.ToString(), path);
            Console.WriteLine("Report saved.");
        }

        private void CreateBackup()
        {
            Console.Write("Enter source file path: ");
            string path = Console.ReadLine();
            _fileManager.CreateBackup(path);
            Console.WriteLine("Backup created.");
        }

        private void ViewBackups()
        {
            Console.WriteLine("Backup files:");
            foreach (var file in Directory.GetFiles("Backups"))
            {
                Console.WriteLine(file);
            }
        }

        private void ImportStudentsTxt()
        {
            Console.Write("Enter TXT file path: ");
            string path = Console.ReadLine();
            string content = _fileManager.ReadFromText(path);
            Console.WriteLine("TXT content loaded (you can parse it later):");
            Console.WriteLine(content);
        }

        private void CleanOldBackups()
        {
            Console.Write("Enter days old: ");
            int days = int.Parse(Console.ReadLine());
            _fileManager.CleanOldBackups(days);
            Console.WriteLine("Old backups cleaned.");
        }
    }
}
