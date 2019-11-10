using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    public static class SDELog
    {
        private static string _logWay = @"log_File.txt";
        private static bool _flag = false;
        private static int _counter = 0;

        private static void tryCreateFile(string currentDate)
        {
            using (StreamWriter sw2 = new StreamWriter(_logWay, true, System.Text.Encoding.Default))
                sw2.Close();
            using (StreamReader sr = new StreamReader(_logWay, System.Text.Encoding.Default))
            {
                string tmp = sr.ReadLine();
                sr.Close();
                if (tmp == null)
                    using (StreamWriter sw = new StreamWriter(_logWay, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("File was created in " + currentDate + '\n' +
                             "1)action    2)way    3)time" + '\n'
                            );
                    }
                _flag = true;
            }
        }

        public static void WriteSome(string action, string way)
        {
            System.Threading.Thread.Sleep(600);
            string currentDate = DateTime.Now.ToString();
            if (!_flag)
                tryCreateFile(currentDate);

            using (StreamWriter sw = new StreamWriter(_logWay, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("1)" + action + "\n2)" + way + "\n3)" + currentDate + '\n');
                sw.Close();
            }
        }

        public static void CountAndDelete()
        {
            _counter = 0;
            DateTime dt;
            DateTime ct = DateTime.Now;
            string Date;
            string buffer = "";
            string onestr = "";
            string tolog = "";
            using (StreamReader sr = new StreamReader(_logWay, System.Text.Encoding.Default))
            {
                buffer += sr.ReadLine() + 'n'; buffer += sr.ReadLine() + 'n'; tolog += buffer; buffer = "";
                while (onestr != null)
                {
                    onestr = sr.ReadLine();
                    buffer += onestr+'\n';
                    if (onestr!=null&&onestr!="")
                        if (onestr[0] == '3')
                        {
                            Date = onestr.Substring(2);
                            dt = DateTime.Parse(Date);
                            TimeSpan timeSpan;
                            timeSpan = ct.Subtract(dt);
                            if ((int)timeSpan.TotalHours == 0)
                            {
                                _counter++;
                                tolog += buffer;
                            }
                            buffer = "";
                        }
                }
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(_logWay, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(tolog);
                sw.Close();
            }
        }
    }
}