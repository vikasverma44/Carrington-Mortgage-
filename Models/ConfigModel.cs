
using System.Collections.Generic;

namespace Carrington_Service.Models
{
    public class ConfigModel
    {
        // Logger Congiguration
        public bool IsLoggingEnabled { get; set; }
        public int LoggingFileMaxSizeInMB { get; set; }
        public string LoggingPath { get; set; }
        public bool IsReleaseMode { get; set; }

        //SMTP Details
        public bool IsEmailEnabled { get; set; }
        public string SMTP_Host { get; set; }
        public int SMTP_Port { get; set; }
        public string SMTP_Usr { get; set; }
        public string SMTP_Pwd { get; set; }
        public string SMTP_From { get; set; }
        public string SMTP_To { get; set; }
    }
}
