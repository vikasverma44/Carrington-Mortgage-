using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarringtonMortgage.Infrastructure
{
    internal interface IFileIOService
    {

        #region FileIO Public Methods

        bool MoveFile(string oldFileName, string destFileName);
        bool DeleteFile(string destFileName);
        bool CopyFile(string inPath, string outPath);
        string ReadFileContentAsString(string fileNameWithPath);
        string ResolveFileNameEndingChar(char endingChar, string fileName);
        List<string> GetAllFilesFromDirectory(string path, string[] searchPatterns, SearchOption searchOption = SearchOption.TopDirectoryOnly, bool ignoreSearchPattern = false);
        string GetFileDirectory(string fullFileNameWithPath);
        string GetFileName(string fullFileNameWithPath);
        string GetFileExtension(string fullFileNameWithPath);
        bool CreateFileFromFileStream(string fullFileNameWithPath, FileStream paramFileStream);
        bool CreateFileFromFileStream(string fullFileNameWithPath, byte[] fileStream);
      //  DataSet GetMaskingSourceDataSet();

        #endregion

        //#region SFTP Public Methods

        //bool SendSFTPFile(Enums.SFTP_Site sftpSite, string inPath, string sftpPath);
        //IEnumerable<SftpFile> ListSFTPFiles(string directoryPath, string sftpHost, int sftpPort, string sftpUsr, string sftpPwd);
        //bool SendSFTPFile(string inPath, string sftpPath, string sftpHost, int sftpPort, string sftpUsr, string sftpPwd);

        //#endregion
    }
}
