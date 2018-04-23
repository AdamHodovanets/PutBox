using System;
using System.IO;
using System.Net;
using FluentFTP;

namespace FtpController
{
    public class FtpManager : IFtpManager
    {
        private readonly string _host;
        private readonly string _user;
        private readonly string _pass;
        private FtpWebRequest _ftpRequest;
        private FtpWebResponse _ftpResponse;
        private Stream _ftpStream;
        private readonly int _bufferSize = 2048;

        public FtpManager(string hostIp, string userName, string password)
        {
            _host = hostIp;
            _user = userName;
            _pass = password;
        }

        public void DeleteFtpDirectoryAndContent(string path)
        {
            path = $@"www.putbox.somee.com/{path}";
            using (var conn = new FtpClient())
            {
                conn.Host = @"ftp://putbox.somee.com";
                conn.Credentials = new NetworkCredential(_user, _pass);

                foreach (var item in conn.GetListing(path, FtpListOption.AllFiles | FtpListOption.ForceList)
                )
                    switch (item.Type)
                    {
                        case FtpFileSystemObjectType.Directory:
                            conn.DeleteDirectory(item.FullName, FtpListOption.AllFiles | FtpListOption.ForceList);
                            break;
                        case FtpFileSystemObjectType.File:
                            conn.DeleteFile(item.FullName);
                            break;
                    }
            }
        }


        public void Download(string remoteFile, string localFile)
        {
            try
            {
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + remoteFile);
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                _ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                _ftpStream = _ftpResponse.GetResponseStream();
                var localFileStream = new FileStream(localFile, FileMode.Create);
                var byteBuffer = new byte[_bufferSize];
                var bytesRead = _ftpStream.Read(byteBuffer, 0, _bufferSize);
                try
                {
                    while (bytesRead > 0)
                    {
                        localFileStream.Write(byteBuffer, 0, bytesRead);
                        bytesRead = _ftpStream.Read(byteBuffer, 0, _bufferSize);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                localFileStream.Close();
                _ftpStream.Close();
                _ftpResponse.Close();
                _ftpRequest = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Upload(string remoteFile, string localFile)
        {
            try
            {
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + remoteFile);
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                _ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                _ftpStream = _ftpRequest.GetRequestStream();
                var localFileStream = new FileStream(localFile, FileMode.Create);
                var byteBuffer = new byte[_bufferSize];
                var bytesSent = localFileStream.Read(byteBuffer, 0, _bufferSize);
                try
                {
                    while (bytesSent != 0)
                    {
                        _ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, _bufferSize);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                localFileStream.Close();
                _ftpStream.Close();
                _ftpRequest = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Delete(string deleteFile)
        {
            try
            {
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + deleteFile);
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                _ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                _ftpResponse.Close();
                _ftpRequest = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Rename(string currentFileNameAndPath, string newFileName)
        {
            try
            {
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + currentFileNameAndPath);
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                _ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                _ftpRequest.RenameTo = newFileName;
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                _ftpResponse.Close();
                _ftpRequest = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CreateDirectory(string newDirectory)
        {
            try
            {
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + newDirectory);
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                _ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                _ftpResponse.Close();
                _ftpRequest = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public string GetFileCreatedDateTime(string fileName)
        {
            try
            {
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + fileName);
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                _ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                _ftpStream = _ftpResponse.GetResponseStream();
                var ftpReader = new StreamReader(_ftpStream);
                string fileInfo = null;
                try
                {
                    fileInfo = ftpReader.ReadToEnd();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                ftpReader.Close();
                _ftpStream.Close();
                _ftpResponse.Close();
                _ftpRequest = null;
                return fileInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return "";
        }

        public string GetFileSize(string fileName)
        {
            try
            {
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + fileName);
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                _ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                _ftpStream = _ftpResponse.GetResponseStream();
                var ftpReader = new StreamReader(_ftpStream);
                string fileInfo = null;
                try
                {
                    while (ftpReader.Peek() != -1) fileInfo = ftpReader.ReadToEnd();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                ftpReader.Close();
                _ftpStream.Close();
                _ftpResponse.Close();
                _ftpRequest = null;
                return fileInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return "";
        }

        public string[] DirectoryListSimple(string directory)
        {
            try
            {
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + directory);
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                _ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                _ftpStream = _ftpResponse.GetResponseStream();
                var ftpReader = new StreamReader(_ftpStream);
                string directoryRaw = null;
                try
                {
                    while (ftpReader.Peek() != -1) directoryRaw += ftpReader.ReadLine() + "|";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                ftpReader.Close();
                _ftpStream.Close();
                _ftpResponse.Close();
                _ftpRequest = null;
                try
                {
                    var directoryList = directoryRaw.Split("|".ToCharArray());
                    return directoryList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return new[] { "" };
        }

        public string[] DirectoryListDetailed(string directory)
        {
            try
            {
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + directory);
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                _ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                _ftpStream = _ftpResponse.GetResponseStream();
                var ftpReader = new StreamReader(_ftpStream);
                string directoryRaw = null;
                try
                {
                    while (ftpReader.Peek() != -1) directoryRaw += ftpReader.ReadLine() + "|";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                ftpReader.Close();
                _ftpStream.Close();
                _ftpResponse.Close();
                _ftpRequest = null;
                try
                {
                    var directoryList = directoryRaw.Split("|".ToCharArray());
                    return directoryList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return new[] { "" };
        }
    }
}