using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlKNDL_UX.Components
{
    public class Util
    {
        public static string utf8_decode(string text)
        {
            //return Encoding.GetEncoding("ISO-8859-1").GetString(Encoding.UTF8.GetBytes(text));
            return Encoding.UTF8.GetString(Encoding.GetEncoding(1252).GetBytes(text));
        }
    }
}
