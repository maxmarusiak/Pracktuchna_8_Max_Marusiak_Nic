using System.Text.Json;

namespace StudentGroupSystem.Services
{
    public class FileManager
    {
        public void SaveToJson<T>(T data, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
        }

        public T LoadFromJson<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }

        public void SaveToText(string content, string filePath)
        {
            File.WriteAllText(filePath, content);
        }

        public string ReadFromText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
