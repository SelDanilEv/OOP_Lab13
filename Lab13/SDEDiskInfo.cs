using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;


namespace Lab13
{
    public class SDEDiskInfo
    {
        public void DiskInfo()
        {
            string tolog = "";
            Console.WriteLine("\tDiskInfo");
            
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                tolog = "";
                tolog += $"\tName: {drive.Name}" + '\n';
                tolog += $"\tType: {drive.DriveType}" + '\n';
                if (drive.IsReady)
                {
                    
                    tolog += $"\tFormat: {drive.DriveFormat}" + '\n';
                    tolog += "\tFreeSpace: available  "+
                        String.Format("{0:F3}", (double)drive.AvailableFreeSpace / 1048576 / 1024)+" GB, total  "+
                        String.Format("{0:F3}", (double)drive.TotalFreeSpace / 1048576 / 1024) +" GB" + '\n';
                    tolog += $"\tCapacity: "+String.Format("{0:F3}",(double)drive.TotalSize / 1048576 / 1024)+" GB" + '\n';
                }
                Console.WriteLine(tolog);
                
                SDELog.WriteSome("DiskInfo", tolog.Substring(0,tolog.Length-2));
            }
        }
    }
}
