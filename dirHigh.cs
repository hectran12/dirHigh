using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dirCsharp
{
    public class dirHigh
    {
        /// <summary>
        /// Có cái mới thì update tiếp
        /// </summary>
        public bool status { get; set; }

        public void DirectoryCopy(
        string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
            status = true;
        }


        public long getSizeFolder (string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo info = new DirectoryInfo(@path);
                status = true;
                return info.EnumerateFiles().Sum(file => file.Length);
                
            } else
            {
                status = false;
                return 0;
            }
            
        }
        public string createFolder (string location, string namefolder)
        {
            string file_create = location + @"\" + namefolder;
            if (Directory.Exists(location))
            {
                if (!Directory.Exists(file_create))
                {
                    Directory.CreateDirectory(file_create);
                    status = true;
                    return file_create;
                }
                else
                {
                    status = false;
                    return "Tạo thư mục thất bại";
                }
            } else
            {
                status = false;
                return "Không tìm thấy mục chứa!";
            }
            
        }
    }  
}
