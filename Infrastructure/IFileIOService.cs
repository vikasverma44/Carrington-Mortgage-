using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Carrington_Service.Infrastructure
{
    internal interface IFileIOService
    {

        #region FileIO Public Methods

        //bool MoveFile(string oldFileName, string destFileName);
        //bool DeleteFile(string destFileName);
        //bool CopyFile(string inPath, string outPath);
        string ReadFileContentAsString(string fileNameWithPath);
        string ResolveFileNameEndingChar(char endingChar, string fileName);
        List<string> GetAllFilesFromDirectory(string path, string[] searchPatterns, SearchOption searchOption = SearchOption.TopDirectoryOnly, bool ignoreSearchPattern = false);
        string GetFileDirectory(string fullFileNameWithPath);
        string GetFileName(string fullFileNameWithPath);
        string GetFileExtension(string fullFileNameWithPath);
        bool CreateFileFromFileStream(string fullFileNameWithPath, FileStream paramFileStream);
        bool CreateFileFromFileStream(string fullFileNameWithPath, byte[] fileStream);


        #endregion

        
    }
}

