using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KSHYWeb.Extensions
{
    public static class FTPExtensions
    {
        public static async Task<string> UploadFile(byte[] fileContents, string filePath, string userName, string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(userName, password);
                request.ContentLength = fileContents.Length;
                try
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    return response.StatusDescription;
                }
                catch
                {
                    return null;
                }                
            });
        }
        public static async Task<string> DeleteFile(string filePath, string userName, string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(userName, password);
                try
                {
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    return response.StatusDescription;
                }
                catch
                {
                    return null;
                }                
            });
        }
        public static async Task<string> CreateFolder(string filePath, string userName, string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Credentials = new NetworkCredential(userName, password);
                try
                {
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    return response.StatusDescription;
                }
                catch(Exception ex)
                {
                    return null;
                }               
            });
        }
        public static async Task<bool> ExistsFolder(string filePath, string userName, string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                bool directoryExists = false;
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(filePath);
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    request.UsePassive = true;
                    request.UseBinary = true;
                    //request.KeepAlive = false;
                    request.Credentials = new NetworkCredential(userName, password);
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        directoryExists = true;
                    }
                }
                catch
                {
                    directoryExists = false;
                }
                
                return directoryExists;
            });
        }
        public static async Task<List<string>> GetListFileOrFolder(string filePath, string userName, string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(userName, password);
                try
                {
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    string names = reader.ReadToEnd();

                    reader.Close();
                    response.Close();

                    return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                catch
                {
                    return null;
                }               
            });
        }
        public static async Task<List<string>> GetListFileOrFolderDetail(string filePath, string userName, string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential(userName, password);
                try
                {
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    string names = reader.ReadToEnd();

                    reader.Close();
                    response.Close();

                    return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                catch
                {
                    return null;
                }                
            });
        }
        public static async Task<Stream> OpenFile(string filePath, string userName, string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(userName, password);
                try
                {
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    return responseStream;
                }
                catch
                {
                    return null;
                }               
            });            
        }
    }
}
