using System;

namespace StudentGroupSystem.Services.Logging
{
    public class Logger
    {
        private readonly string logFolder = "Logs";
        private readonly string logFile;

        public Logger()
        {
            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            logFile = Path.Combine(logFolder, "app.log");
        }

        public void Log(string message)
        {
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}";
            File.AppendAllText(logFile, entry + Environment.NewLine);
        }
    }
}
