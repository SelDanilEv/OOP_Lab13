using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    public class SDEDirInfo
    {
        public void DirInfo(string dirWay)
        {
            string tolog = "";
            Console.WriteLine("\n\tDirInfo");
            if (Directory.Exists(dirWay))
            {
                string[] files = Directory.GetFiles(dirWay);
                int countFiles = 0;
                foreach (string s in files)
                {
                    countFiles++;
                }

                DirectoryInfo dirInfo = new DirectoryInfo(dirWay);

                tolog += $"\tFull way: {dirInfo.FullName}" + '\n' +
                    $"\tCreation Time: {dirInfo.CreationTime}" + '\n' +
                    $"\tCount Of Files: {countFiles}" + '\n';


                string[] dirs = Directory.GetDirectories(dirWay);
                int countSubDir = 0;
                foreach (string s in dirs)
                {
                    countSubDir++;
                }
                tolog += $"\tCount Of Sub Directories: {countSubDir}" + '\n' + $"\tParents: {dirInfo.Parent}" + '\n';
                Console.WriteLine(tolog);
                SDELog.WriteSome("DirInfo", tolog.Substring(0,tolog.Length-2));
            }
            else
            {
                SDELog.WriteSome("DirInfo", "This directory doesn't exists");
                Console.WriteLine("This directory doesn't exists");
            }
        }
    }
}
