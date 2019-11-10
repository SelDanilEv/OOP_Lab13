using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    public class SDEFileInfo
    {
        public void FileData(string fileWay)
        {
            string tolog = "";
            Console.WriteLine("\tFileInfo");
            FileInfo fileInfo = new FileInfo(fileWay);
            if (fileInfo.Exists)
            {
                tolog += $"\tFull way : {fileInfo.DirectoryName}" + '\n' +
                        $"\tName: {fileInfo.Name}\n"+
                        $"\tCapacity: {fileInfo.Length} Bytes\n\tExtension: {fileInfo.Extension}\n\tCreationTime: {fileInfo.CreationTime}";
                Console.WriteLine(tolog);
                SDELog.WriteSome("FileInfo",tolog);
            }
            else
            {
                SDELog.WriteSome("FileInfo", "This file doesn't exists");
                Console.WriteLine("This file doesn't exists");
            }
        }
    }
}
