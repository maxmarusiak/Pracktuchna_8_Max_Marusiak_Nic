using System;

namespace StudentGroupSystem.Services
{
    public class BackupService
    {
        private readonly string backupFolder = "Backups";

        public BackupService()
        {
            if (!Directory.Exists(backupFolder))
                Directory.CreateDirectory(backupFolder);
        }

        public void CreateBackup(string sourcePath)
        {
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException("Source file not found", sourcePath);

            string fileName = Path.GetFileNameWithoutExtension(sourcePath);
            string extension = Path.GetExtension(sourcePath);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string backupFile = Path.Combine(backupFolder, $"{fileName}_backup_{timestamp}{extension}");

            File.Copy(sourcePath, backupFile, overwrite: true);
        }

        public void CleanOldBackups(int daysOld)
        {
            if (!Directory.Exists(backupFolder))
                return;

            var files = Directory.GetFiles(backupFolder);

            foreach (var file in files)
            {
                var creationTime = File.GetCreationTime(file);
                if ((DateTime.Now - creationTime).TotalDays >= daysOld)
                {
                    File.Delete(file);
                }
            }
        }
    }
}
