using System;
using System.Collections.Generic;
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

        public static bool W(IDictionary<string, object> parm, string file = "log")
        {
            foreach (var i in parm)
            {
                string tx = i.Key;
                tx += " | " + i.Value.ToString();
                W(tx, file);
            }
            return true;
        }

        /// <summary>
        /// Friendly log
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool W(string txt, string file = "log")
        {
            string text = DateTime.Now.ToString() + " | ";
            text += txt;

            return Write(text);

        }

        /// <summary>
        /// Writes a log
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="file"></param>
        /// <returns>Saved or no</returns>
        public static bool Write(string txt, string file = "log")
        {
            try
            {
                if (!Directory.Exists(DefaultPath)) {
                    Directory.CreateDirectory(DefaultPath);
                }

                string path_file = DefaultPath + file + "." + Lognattor.ext;

                using(var fs = new System.IO.FileStream(path_file, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.None))
                {
                    using(var sw = new System.IO.StreamWriter(fs))
                    {
                        sw.WriteLine(txt);
                        sw.Close();
                    }
                }

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
        public static void Info(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
