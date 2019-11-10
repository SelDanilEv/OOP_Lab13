using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SDEDiskInfo diskInfo = new SDEDiskInfo();
                diskInfo.DiskInfo();

                SDEFileInfo file = new SDEFileInfo();
                file.FileData("Lab13.exe");

                SDEDirInfo dirInfo = new SDEDirInfo();
                dirInfo.DirInfo(@"../../../../labs");

                SDEFileManager fileManager = new SDEFileManager();
                fileManager.ShowInfoAboutFilesAndDirectories(@"../../../../labs");
                fileManager.CopyFiles(@"../../../../labs", "txt");
                fileManager.Archive(@"SDEInspect\SDEFiles");
                fileManager.ClearFiles();

                SDELog.CountAndDelete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
