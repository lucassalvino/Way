using System;
using System.IO;

namespace Way.Domain.Services
{
    public class LogService
    {
        public LogService(String FolderLog = "Logs")
        {
            if (!string.IsNullOrEmpty(FolderLog))
            {
                this.FolderLog = FolderLog;
            }
            else
            {
                this.FolderLog = "Logs";
            }
        }

        public String FolderLog { get; private set; }

        public void AddLog(String Message)
        {
            if (!Directory.Exists(FolderLog))
                Directory.CreateDirectory(FolderLog);

            String NameFile = $"{FolderLog}/{DateTime.Now.Date.ToShortDateString().Replace('/', '_')}.Log";
            StreamWriter file = File.AppendText(NameFile);
            file.WriteLine($"[{DateTime.Now}] {Message}");
            file.Close();
        }
    }
}
