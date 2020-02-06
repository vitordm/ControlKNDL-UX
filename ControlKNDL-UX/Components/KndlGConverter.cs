using System;
using System.Diagnostics;

namespace ControlKNDL_UX.Components
{
    public class KndlGConverter
    {
        public Settings SettingsComponent { get; set; }

        public KndlGConverter()
        {
            SettingsComponent = new Settings();
        }

        public string Log { get; set; }

        public bool ConvertFile(string fileName)
        {
            if (fileName == null || fileName == string.Empty)
                throw new Exception("File is empty");
            string kndlGProgram = SettingsComponent.getKindleGenVersion();

            if (kndlGProgram == null || kndlGProgram == "")
                throw new Exception("Error - KindleGen is not configured");

            string kndl = System.Environment.CurrentDirectory;
            
            kndl += $"\\ext\\{kndlGProgram}\\kindlegen.exe";
            using (var process = new Process())
            {
                process.StartInfo.FileName = kndl;
                process.StartInfo.Arguments = $"\"{fileName}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                Log = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                Log = Util.utf8_decode(Log);
            }
            string logFile = "log_" + DateTime.Now.ToString("ddMMyyyyHHmmss");
            Lognattor.Write(Log, logFile);

            return true;
        }

    }
}
