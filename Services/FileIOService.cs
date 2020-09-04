using Carrington_Service.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Carrington_Service.Services
{
    internal class FileIOService : IFileIOService
    {
        private readonly ILogger Logger;
        private readonly IConfigHelper ConfigHelper;
        private readonly int BufferSize = 80 * 1024;

        public FileIOService(ILogger logger, IConfigHelper configHelper)
        {
            Logger = logger;
            ConfigHelper = configHelper;
        }

        #region FileIO Public Methods

        public string ReadFileContentAsString(string fileNameWithPath)
        {
            if (File.Exists(fileNameWithPath))
            {
                return File.ReadAllText(fileNameWithPath);
            }
            else { return string.Empty; }
        }

        public string ResolveFileNameEndingChar(char endingChar, string fileName)
        {
            string fName = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            if (fName.EndsWith(endingChar.ToString()))
            {
                fName = fName.Remove(fName.Length - 1, 1);
                //fName = fName.Replace(_EndingChar.ToString(), string.Empty);
            }
            return fName + ext;
        }

        public List<string> GetAllFilesFromDirectory(string path, string[] searchPatterns, SearchOption searchOption = SearchOption.TopDirectoryOnly, bool ignoreSearchPattern = false)
        {
            if (!ignoreSearchPattern)
            {
                return searchPatterns.AsParallel()
                       .SelectMany(searchPattern =>
                              Directory.EnumerateFiles(path, searchPattern, searchOption)).ToList();
            }
            else
            {
                return searchPatterns.AsParallel()
                      .SelectMany(searchPattern =>
                             Directory.EnumerateFiles(path)).Distinct().ToList();
            }
        }

        public string GetFileDirectory(string fullFileNameWithPath)
        {
            if (File.Exists(fullFileNameWithPath))
            {
                return Path.GetDirectoryName(fullFileNameWithPath);
            }
            else { return string.Empty; }
        }

        public string GetFileName(string fullFileNameWithPath)
        {
            if (File.Exists(fullFileNameWithPath))
            {
                return Path.GetFileNameWithoutExtension(fullFileNameWithPath);
            }
            else { return string.Empty; }
        }

        public string GetFileExtension(string fullFileNameWithPath)
        {
            if (File.Exists(fullFileNameWithPath))
            {
                return Path.GetExtension(fullFileNameWithPath);
            }
            else { return string.Empty; }
        }

        public bool CreateFileFromFileStream(string fullFileNameWithPath, FileStream paramFileStream)
        {
            if (fullFileNameWithPath is null)
            {
                throw new ArgumentNullException(nameof(fullFileNameWithPath));
            }

            if (paramFileStream is null)
            {
                throw new ArgumentNullException(nameof(paramFileStream));
            }

            bool returnVal = false;
            try
            {
                using (FileStream fs = new FileStream(fullFileNameWithPath, FileMode.Create))
                {
                    //fs.Close();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                returnVal = false;
                Logger.Error(ex, "GetFileStream");
            }
            return returnVal;
        }

        public bool CreateFileFromFileStream(string fullFileNameWithPath, byte[] fileStream)
        {
            bool result = false;
            try
            {
                using (FileStream fs = new FileStream(fullFileNameWithPath, FileMode.Create))
                {
                    fs.Write(fileStream, 0, fileStream.Length);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Logger.Error(ex, "GetFileStream");
            }
            return result;
        }

       

        /// <summary>
        /// This method will check if the file is being used by another process or not
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected bool IsFileLocked(string file)
        {
            try
            {
                using (FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }

        #endregion


        #region FileIO Private Methods

        private bool CopyStream(Stream inStream, Stream outStream)
        {
            bool val = false;
            try
            {
                ConcurrentQueue<byte[]> dataQueue = new ConcurrentQueue<byte[]>();
                using (AutoResetEvent dataReady = new AutoResetEvent(false))
                {
                    using (AutoResetEvent dataProcessed = new AutoResetEvent(false))
                    {
                        Task readDataTask = Task.Factory.StartNew(() =>
                        {
                            while (true)
                            {
                                byte[] data = new byte[BufferSize];
                                int bytesRead = inStream.Read(data, 0, data.Length);
                                if (bytesRead != BufferSize)
                                {
                                    data = SubArray(data, 0, bytesRead);
                                }

                                dataQueue.Enqueue(data);
                                dataReady.Set();
                                if (bytesRead != BufferSize)
                                {
                                    break;
                                }

                                dataProcessed.WaitOne();
                            }
                        });
                        Task processDataTask = Task.Factory.StartNew(() =>
                        {
                            byte[] data;
                            do
                            {
                                dataReady.WaitOne();
                                dataQueue.TryDequeue(out data);
                                dataProcessed.Set();
                                outStream.Write(data, 0, data.Length);
                                if (data.Length != BufferSize)
                                {
                                    break;
                                }
                            } while (data.Length == BufferSize);
                        });
                        readDataTask.Wait();
                        processDataTask.Wait();
                    }
                }
                val = true;
            }
            catch
            {
                throw;
            }

            return val;
        }

        private T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        #endregion


        #region SFTP Public Methods

        //public bool SendSFTPFile(Enums.SFTP_Site sftpSite, string inPath, string sftpPath)
        //{
        //    bool retVal = false;
        //    if (!File.Exists(inPath))
        //    { return false; }
        //    try
        //    {
        //        Logger.Trace("TRANSFERRING FILE TO SFTP LOCATION: ");
        //        using (SftpClient sftpClient = GetSFTPClient(sftpSite))
        //        {
        //            Logger.Trace("SFTP Connection established... ");
        //            sftpClient.Connect();
        //            //sftp.ChangeDirectory("/MyFolder");
        //            using (FileStream uplfileStream = File.OpenRead(inPath))
        //            {
        //                sftpClient.UploadFile(uplfileStream, sftpPath, true);
        //                Logger.Trace("SFTP file stream uploaded...");
        //            }
        //            sftpClient.Disconnect();
        //            retVal = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Error While SFTP File Transfer");
        //    }

        //    return retVal;
        //}

        //public IEnumerable<SftpFile> ListSFTPFiles(string directoryPath, string sftpHost, int sftpPort, string sftpUsr, string sftpPwd)
        //{
        //    using (SftpClient sftp = new SftpClient(sftpHost, sftpPort, sftpUsr, sftpPwd))
        //    {
        //        IEnumerable<SftpFile> files;
        //        try
        //        {
        //            sftp.Connect();
        //            Logger.Trace("Reading from SFTP location");
        //            files = sftp.ListDirectory(directoryPath);
        //            sftp.Disconnect();
        //            return files;
        //        }
        //        catch (Exception e)
        //        {
        //            Logger.Error(e, "ListSFTPFiles");
        //            return null;
        //        }
        //    }
        //}

        //public bool SendSFTPFile(string inPath, string sftpPath, string sftpHost, int sftpPort, string sftpUsr, string sftpPwd)
        //{
        //    bool retVal = false;
        //    if (!File.Exists(inPath))
        //    { return false; }

        //    using (SftpClient sftp = new SftpClient(sftpHost, sftpPort, sftpUsr, sftpPwd))
        //    {
        //        try
        //        {
        //            sftp.Connect();
        //            Logger.Trace("TRANSFERRING FILE TO SFTP: ");
        //            //sftp.ChangeDirectory("/MyFolder");
        //            using (FileStream uplfileStream = File.OpenRead(inPath))
        //            {
        //                sftp.UploadFile(uplfileStream, sftpPath, true);
        //            }
        //            sftp.Disconnect();
        //            retVal = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.Error(ex, "Send SFTP");
        //        }
        //    }
        //    return retVal;
        //}

        #endregion


        #region SFTP Private Methods

        //private SftpClient GetSFTPClient(Enums.SFTP_Site sftpSite)
        //{
        //    SftpClient sftpClient = null;
        //    string sftpHost = string.Empty;
        //    int sftpPort = 0;
        //    string sftpUsr = string.Empty;
        //    string sftpPwd = string.Empty;

        //    switch (sftpSite)
        //    {
        //        case Enums.SFTP_Site.Default:
        //            break;
        //        case Enums.SFTP_Site.Input:
        //            sftpHost = ConfigHelper.Model.InputFilePathLocation_SFTP_Host;
        //            sftpPort = ConfigHelper.Model.InputFilePathLocation_SFTP_Port;
        //            sftpUsr = ConfigHelper.Model.InputFilePathLocation_SFTP_Usr;
        //            sftpPwd = ConfigHelper.Model.InputFilePathLocation_SFTP_Pwd;
        //            break;
        //        case Enums.SFTP_Site.Output:
        //            sftpHost = ConfigHelper.Model.OutputFilePathLocation_SFTP_Host;
        //            sftpPort = ConfigHelper.Model.OutputFilePathLocation_SFTP_Port;
        //            sftpUsr = ConfigHelper.Model.OutputFilePathLocation_SFTP_Usr;
        //            sftpPwd = ConfigHelper.Model.OutputFilePathLocation_SFTP_Pwd;
        //            break;
        //        default:
        //            break;
        //    }
        //    if (!string.IsNullOrEmpty(sftpHost) && sftpPort > 0 && !string.IsNullOrEmpty(sftpUsr) && !string.IsNullOrEmpty(sftpPwd))
        //    {
        //        sftpClient = new SftpClient(sftpHost, sftpPort, sftpUsr, sftpPwd);
        //    }

        //    return sftpClient;
        //}

        #endregion

    }
}

