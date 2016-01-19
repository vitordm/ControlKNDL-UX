using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControlKNDL_UX.Components
{
    public class Lognattor
    {
        /// <summary>
        /// Default path for logs
        /// </summary>
        public static string DefaultPath { get; set; } = @".\Logs\";

        /// <summary>
        /// Dafault extension for log
        /// </summary>
        public const string ext = "log";

        public static bool w(IDictionary<string, object> parm, string file = "log")
        {
            foreach (var i in parm)
            {
                string tx = i.Key;
                tx += " | " + i.Value.ToString();
                w(tx, file);
            }
            return true;
        }

        /// <summary>
        /// Friendly log
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool w(string txt, string file = "log")
        {
            string text = DateTime.Now.ToString() + " | ";
            text += txt;

            return write(text);

        }

        /// <summary>
        /// Writes a log
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="file"></param>
        /// <returns>Saved or no</returns>
        public static bool write(string txt, string file = "log")
        {
            try
            {
                if (!Directory.Exists(DefaultPath)) {
                    Directory.CreateDirectory(DefaultPath);
                }

                string path_file = DefaultPath + file + "." + Lognattor.ext;

                System.IO.FileStream Fs = new System.IO.FileStream(path_file, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.None);
                System.IO.StreamWriter Sw = new System.IO.StreamWriter(Fs);
                Sw.WriteLine(txt);

                Sw.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;

            }




        }

        /// <summary>
        /// Put a console information
        /// </summary>
        /// <param name="txt"></param>
        public static void info(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
