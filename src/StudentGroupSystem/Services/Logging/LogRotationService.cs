using System;

namespace StudentGroupSystem.Services.Logging
{
    public class LogRotationService
    {
        private readonly string logFolder = "Logs";
        private readonly string logFile = "app.log";

        public void RotateLogs()
        {
            string fullPath = Path.Combine(logFolder, logFile);

            if (!File.Exists(fullPath))
                return;

            long size = new FileInfo(fullPath).Length;

            // Ротація при розмірі > 1 MB
            if (size > 1_000_000)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string rotated = Path.Combine(logFolder, $"app_{timestamp}.log");

                File.Move(fullPath, rotated);
            }
        }
    }
}
