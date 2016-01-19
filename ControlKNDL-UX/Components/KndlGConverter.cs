using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private bool _success;
        public bool Success
        {
            get
            {
                return _success;
            }
        }

        public bool ConvertFile(string fileName)
        {
            if (fileName == null || fileName == string.Empty)
                throw new Exception("File is empty");
            string kndlGProgram = SettingsComponent.getKindleGenVersion();

            if (kndlGProgram == null || kndlGProgram == "")
                throw new Exception("Error - KindleGen is not configured");

            string kndl = System.Environment.CurrentDirectory;
            
            kndl += $"\\ext\\{kndlGProgram}\\kindlegen.exe";
            Process pProcess = new Process();
            pProcess.StartInfo.FileName = kndl;
            pProcess.StartInfo.Arguments = $"\"{fileName}\"";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            Log = pProcess.StandardOutput.ReadToEnd();
            pProcess.WaitForExit();

            Log = Util.utf8_decode(Log);

            //string logFile = "log_" + (new DateTime()).ToString("ddMMyyyyHHmmss");
            string logFile = "log_" + DateTime.Now.ToString("ddMMyyyyHHmmss");

            Components.Lognattor.write(Log, logFile);

            return true;
        }

    }
}
