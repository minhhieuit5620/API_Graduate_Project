using System;
using System.IO;

namespace ISCommon.Utility
{
    public static class ISFolder
    {
        /// <summary>
        ///    Hàm kiểm tra thư mục đã tồn tại chưa:
        /// </summary>
        /// <param name="path">Đường dẫn thư mục cha</param>        
        /// <param name="folderName">Tên thư mục</param>        
        public static bool ISExists(string path, string folderName)
        {           
            // Determine whether the directory exists. 
            if (Directory.Exists(path + folderName))
            {
                // That path exists already;
                return true;
            }
            return false;
        }

        /// <summary>
        ///    Hàm kiểm tra thư mục đã tồn tại chưa:
        /// </summary>
        /// <param name="path">Đường dẫn thư mục</param>      
        public static bool ISExists(string path)
        {
            // Determine whether the directory exists. 
            if (Directory.Exists(path))
            {
                // That path exists already;
                return true;
            }
            return false;
        }

        /// <summary>
        ///    Hàm copy thu muc: trả về giá trị int(1: di chuyển thành công, 0: thư mục muốn chuyển không tồn tại, -1: di chuyển có lỗi)
        /// </summary>
        /// <param name="oldPath">Đường dẫn lưu trữ folder hiện tại</param>        
        /// <param name="newPath">Đường dẫn muốn chuyển folder tới</param>      
        /// <param name="folderName">Tên thư mục muốn di chuyển</param>        

        public static int ISCopy(string sourceDirName, string destDirName, bool copySubDirs, out string error)
        {
            error = "";
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                return 0;
            }

            int result = 1;
            try
            {
                // If the destination directory doesn't exist, create it. 
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    if (File.Exists(temppath))
                    {
                        File.Delete(temppath);
                    }
                    file.CopyTo(temppath, false);
                }

                // If copying subdirectories, copy them and their contents to new location. 
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        result = ISCopy(subdir.FullName, temppath, copySubDirs, out error);
                    }
                }

            }
            catch(Exception e)
            {
                result = -1;
                error = e.Message;
            }
            return result;
        }

        /// <summary>
        ///    Hàm di chuyển thư mục: trả về giá trị int(1: di chuyển thành công, 0: thư mục muốn chuyển không tồn tại, -1: di chuyển có lỗi)
        /// </summary>
        /// <param name="oldPath">Đường dẫn lưu trữ folder hiện tại</param>        
        /// <param name="newPath">Đường dẫn muốn chuyển folder tới</param>      
        /// <param name="folderName">Tên thư mục muốn di chuyển</param>        
        public static int ISMove(string oldPath, string newPath, string folderName)
        {
            DirectoryInfo dirInfoOld = new DirectoryInfo(oldPath + folderName);
            if (dirInfoOld.Exists == true)
            {
                try
                {
                    if (!Directory.Exists(newPath))
                        Directory.CreateDirectory(newPath);

                    dirInfoOld.MoveTo(newPath + folderName);
                    return 1;
                }
                catch
                {
                    return -1;
                }
            }
            return 0;
        }

        /// <summary>
        ///    Hàm thay đổi thư mục: trả về giá trị int(1: di chuyển thành công, 0: thư mục muốn chuyển không tồn tại, -1: di chuyển có lỗi)
        /// </summary>
        /// <param name="oldPath">Đường dẫn lưu trữ thư mục</param>        
        /// <param name="oldName">Tên cũ</param>      
        /// <param name="newName">Tên mới</param>        
        public static int ISReName(string rootPath, string oldName, string newName)
        {
            DirectoryInfo dirInfoOld = new DirectoryInfo(rootPath + oldName);
            if (dirInfoOld.Exists == true)
            {
                try
                {
                    if (!Directory.Exists(rootPath))
                        Directory.CreateDirectory(rootPath);

                    dirInfoOld.MoveTo(rootPath + newName);
                    return 1;
                }
                catch
                {
                    return -1;
                }
            }
            return 0;
        }

        /// <summary>
        ///    Hàm tạo thư mục:
        /// </summary>
        /// <param name="path">Đường dẫn thư mục</param>    
        /// <returns>-1: Đường dẫn đã tồn tại, 0: Có lỗi, 1: Tạo thành công</returns>
        public static int ISCreate(string path)
        {
           try
            {
                // Determine whether the directory exists. 
                if (Directory.Exists(path))
                {
                    // That path exists already;
                    return -1;
                }

                // Try to create the directory.
                Directory.CreateDirectory(path);
               // Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
               // di.Delete();
               // Console.WriteLine("The directory was deleted successfully.");
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally { }
        }

        /// <summary>
        ///    Hàm tạo thư mục:
        /// </summary>
        /// <param name="path">Đường dẫn thư mục cha</param>        
        /// <param name="folderName">Tên thư mục</param>    
        /// <returns>-1: Thư mục đã tồn tại, 0: Có lỗi, 1: Tạo thành công</returns>
        public static int ISCreate(string path, string folderName)
        {
            try
            {
                // Determine whether the directory exists. 
                if (Directory.Exists(path + folderName))
                {
                    // That path exists already;
                    return -1;
                }

                // Try to create the directory.
                Directory.CreateDirectory(path + folderName);
                // Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
                // di.Delete();
                // Console.WriteLine("The directory was deleted successfully.");
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally { }
        }

        /// <summary>
        ///    Hàm tạo thư mục:
        /// </summary>
        /// <param name="path">Đường dẫn thư mục</param>     
        /// <param name="error">Thông báo lỗi</param>   
        /// <returns>-1: Đường dẫn đã tồn tại, 0: Có lỗi, 1: Tạo thành công</returns>
        public static int ISCreate(string path, out string error)
        {
            error = "";
            try
            {
                // Determine whether the directory exists. 
                if (Directory.Exists(path))
                {
                    // That path exists already;
                    return -1;
                }

                // Try to create the directory.
                Directory.CreateDirectory(path);
                // Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
                // di.Delete();
                // Console.WriteLine("The directory was deleted successfully.");
                return 1;
            }
            catch (Exception e)
            {
                error = e.Message;
                return 0;
            }
            finally { }
        }

        /// <summary>
        ///    Hàm tạo thư mục:
        /// </summary>
        /// <param name="path">Đường dẫn thư mục cha</param>        
        /// <param name="folderName">Tên thư mục</param>     
        /// <param name="error">Thông báo lỗi</param>   
        /// <returns>-1: Thư mục đã tồn tại, 0: Có lỗi, 1: Tạo thành công</returns>
        public static int ISCreate(string path, string folderName, out string error)
        {
            error = "";
            try
            {
                // Determine whether the directory exists. 
                if (Directory.Exists(path + folderName))
                {
                    // That path exists already;
                    return -1;
                }

                // Try to create the directory.
                Directory.CreateDirectory(path + folderName);
                // Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
                // di.Delete();
                // Console.WriteLine("The directory was deleted successfully.");
                return 1;
            }
            catch (Exception e)
            {
                error = e.Message;
                return 0;
            }
            finally { }
        }

        /// <summary>
        ///    Hàm xóa thư mục:
        /// </summary>
        /// <param name="pathFolder">Đường dẫn thư mục muốn xóa</param>      
        /// <returns>-1: Đường dẫn không tồn tại, 0: Có lỗi, 1: Xóa thành công</returns>
        public static int ISDelete(string pathFolder)
        {
            if (Directory.Exists(pathFolder))
            {
                try
                {
                    Directory.Delete(pathFolder, true);
                    return 1;
                }
                catch (Exception e)
                {
                    return 0;
                }
                finally { }
            }
            else
            {
                return -1;
            }
        }
    }
}