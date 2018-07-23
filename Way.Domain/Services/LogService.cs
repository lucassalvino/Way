using System;
using System.IO;
using System.Threading.Tasks;

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

        public void AddLogByExceptionAsync(Exception Erro, String Requisicao = "")
        {
            Task.Run(()=> {
                AddLog($"{Erro.Message} \n\n\nStackTrace: {Erro.StackTrace}  \n\n\nDados Request: {Requisicao}");
            });
        }

        public void AddLogAsync(String Message)
        {
            Task.Run(() => { AddLog(Message); });
        }


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
