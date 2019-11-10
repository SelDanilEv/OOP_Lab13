using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;

namespace Lab13
{
    public class SDEFileManager
    {
        private static string inspectDirWay = "SDEInspect";
        private static string fileDirInfoWay = inspectDirWay + '/' + "SDEdirinfo";
        private static string FilesDirWay = "SDEFiles";


        public void ShowInfoAboutFilesAndDirectories(string dirWay)
        {
            Directory.CreateDirectory(inspectDirWay);

            FileInfo fileInfo = new FileInfo(fileDirInfoWay);

            using (FileStream fstream = new FileStream(fileDirInfoWay, FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                if (Directory.Exists(inspectDirWay))
                {
                    sw.WriteLine("Files:");
                    string[] files = Directory.GetFiles(dirWay);
                    foreach (string s in files)
                    {
                        FileInfo f = new FileInfo(s);
                        sw.WriteLine(f.FullName);
                    }
                    sw.WriteLine();
                    sw.WriteLine("Folders");
                    string[] dirs = Directory.GetDirectories(dirWay);
                    foreach (string s in dirs)
                    {
                        DirectoryInfo d = new DirectoryInfo(s);
                        sw.WriteLine(d.FullName);
                    }
                }
                sw.Close();
            }

            fileInfo.CopyTo(fileDirInfoWay + "copy.txt", true);
            fileInfo.Delete();
            SDELog.WriteSome("Show info about files and dir",inspectDirWay);
        }

        public void CopyFiles(string dirWay, string expansion)
        {
            Directory.CreateDirectory(FilesDirWay);

            string[] files2 = Directory.GetFiles(dirWay);

            foreach (string s in files2)
            {
                FileInfo fileInfo = new FileInfo(s);
                if (fileInfo.Extension == '.' + expansion)
                    File.Copy(s, FilesDirWay + '/' + fileInfo.Name, true);
            }
            Directory.Move(FilesDirWay, inspectDirWay + '/' + FilesDirWay);
            SDELog.WriteSome("Copy files with some expansion", inspectDirWay + '/' + FilesDirWay);
        }

        public void Archive(string dirWay)
        {
            using (ZipFile zip = new ZipFile())
            {
                //zip.Password = "password";
                zip.AddItem(dirWay);
                zip.Save("Files.zip");
            }
            using (ZipFile zip = ZipFile.Read("Files.zip"))
            {
                Directory.CreateDirectory("Unzip");
                zip.ExtractAll("Unzip/", ExtractExistingFileAction.OverwriteSilently);
            }
            SDELog.WriteSome("Zip and unzip", "Unzip");
        }

        public void ClearFiles()
        {
            Console.WriteLine("Clear Files");
            Console.ReadKey();

            Directory.Delete(inspectDirWay,true);
            Directory.Delete("Unzip", true);
            File.Delete("Files.zip");

            SDELog.WriteSome("Clear files", "final");
        }
    }
}