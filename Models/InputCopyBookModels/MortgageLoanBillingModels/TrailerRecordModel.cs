using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
   public class TrailerRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string Filler1 { get; set; }
        public string SequenceNumber { get; set; }
        public string TotalNumberOfBRecords { get; set; }
        public string TotalNumberOfARecords { get; set; }
        public string TotalNumberOfRRecords { get; set; }
        public string TotalNumberOfERecords { get; set; }
        public string TotalNumberOfTRecords { get; set; }
        public string TotalNumberOfORecords { get; set; }
        public string TotalNumberOfFRecords { get; set; }
        public string TotalNumberOfURecords { get; set; }
        public string TotalNumberOf2Records { get; set; }
        public string TotalNumberOfPRecords { get; set; }
        public string TotalNumberOfLRecords { get; set; }
        public string TotalNumberOfSRecords { get; set; }
        public string TotalNumberOfFrRecords { get; set; }
        public string TotalNumberOfRecordsIncludingHeaderAndTrailerRecords { get; set; }
        public string TotalLoanCount { get; set; }

    }
}
