using System;

namespace Domain.Utils
{
    public class Logger
    {
        public static void Log(Exception error, string tag)
        {
            try
            {
                if (error.InnerException != null) Log(error.InnerException, tag);
                string line = $"{System.DateTime.Now:dd/MM/yyyy HH:mm:ss} {error?.Message} : {error?.StackTrace}{System.Environment.NewLine}";
                if (!System.IO.Directory.Exists("LOGS"))
                    System.IO.Directory.CreateDirectory("LOGS");
                using var fw = System.IO.File.Open($"LOGS/{tag}_{System.DateTime.Now:dd_MM_yyyy}.txt", System.IO.FileMode.Append);
                var lineBytes = System.Text.Encoding.ASCII.GetBytes(line);
                fw.Write(lineBytes);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
