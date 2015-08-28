using System;
using System.IO;
using System.Text;

namespace Domain.Logger
{
    public class Logger
    {
        public static void SaveMessageToLog(string msg)
        {
            using (var fs = new FileStream(@"D:\log.txt", FileMode.Append))
            {
                var tmp = string.Format("{0} : {1} ", DateTime.Now, msg);
                var buff = Encoding.Unicode.GetBytes(tmp + "\n");
                fs.Write(buff, 0, buff.Length);
            }
        }
    }
}