using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class ActiveBankruptcyInformationRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string BankruptcyType { get; set; }
        public string BkrFilingChapterNumberPrior1 { get; set; }
        public string BkrFilingCaseNumber1 { get; set; }
        public string BkrFiledBy1 { get; set; }
        public string BkrFilingDebtorActive { get; set; }
        public string BankruptcyFiledByCodebtor { get; set; }
        public string BkrFiledByCoborrowerIndicator1 { get; set; }
        public string BankruptcyFiledByCoborrowerIndicator2Active { get; set; }
        public string BankruptcyFiledByCoborrowerIndicator3Active { get; set; }
        public string BankruptcyFiledByCoborrowerIndicator4Active { get; set; }
        public string BankruptcyFiledByCoborrowerIndicator5Active { get; set; }
        public string BankruptcyFiledByCoborrowerIndicator6Active { get; set; }
        public string BankruptcyFiledByCoborrowerIndicator7Active { get; set; }
        public string BankruptcyFiledByCoborrowerIndicator8Active { get; set; }
        public string BankruptcyFiledByCoborrowerIndicator9Active { get; set; }
        public string BankruptcyFiledByCoborrowerIndicator10Active { get; set; }
        public string BankruptcyDateFiledActive { get; set; }
        public string BankruptcyConversionDateActive { get; set; }
        public string BankruptcyReaffirmationDateActive { get; set; }
        public string BankruptcyDischargeDateActive { get; set; }
        public string BankruptcyDismissedDateActive { get; set; }
        public string BankruptcyMotionForReliefActive { get; set; }
        public string ConcurrentBankruptcyTypeActive { get; set; }

        public string ConcurrentBankruptcyChapterActive { get; set; }
        public string ConcurrentBankruptcyCaseNumberActive { get; set; }
        public string ConcurrentBankruptcyFiledByCodeActive { get; set; }
        public string ConcurrentBankruptcyFiledByNameActive { get; set; }
        public string ConcurrentBankruptcyCoDebtorNameActive { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator1Active { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator2Active { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator3Active { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator4Active { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator5Active { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator6Active { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator7Active { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator8Active { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator9Active { get; set; }
        public string ConcurrentBankruptcyFiledByCoborrowerIndicator10Active { get; set; }
        public string ConcurrentBankruptcyFiledByDateActive { get; set; }
        public string ConcurrentBankruptcyConversionDateActive { get; set; }
        public string ConcurrentBankruptcyReaffirmationDateActive { get; set; }
        public string ConcurrentBankruptcyDischargedDateActive { get; set; }
        public string ConcurrentBankruptcyDismissedDateActive { get; set; }
        public string ConcurrentBankruptcyReliefGrantedDateActive { get; set; }
        public string BankruptcyPostPetitionAmountDue { get; set; } 
        public string BankruptcyPostPetitionLateChangeAmount { get; set; }
        public string TotalReceivedDuringBkrPrePetition { get; set; }
        public string PostPetitionFeesAndCharges { get; set; }
        public string PrePetitionFundsReceivedLastBillingCycle { get; set; }
        public string PrePetitionArrearage { get; set; }
        public string BankruptcyStatementNotice { get; set; }
        public string BankruptcyAttorneyName { get; set; }
        public string BankruptcyAttorneyAddress1 { get; set; }
        public string BankruptcyAttorneyAddress2 { get; set; }
        public string BankruptcyAttorneyCity { get; set; }
        public string BankruptcyAttorneyState { get; set; }

        public string BankruptcyAttorneyZip { get; set; }
        public string PrePetitionSuspenseBalance { get; set; }
        public string PostPetitionSuspenseBalance { get; set; }
        public string PostPetitionSuspenseBalanceAgreedOrder { get; set; }
        public string PostPetitionAoAmountDue { get; set; }
        public string PostPetitionAoDueDate { get; set; }
        public string BkrCramDownFlag { get; set; }
        public string PastUnpaidPostPetitionAmounts { get; set; }
        public string BkrDischarged { get; set; }
        public string PostPetitionShortfall { get; set; }
        public string PostPetitionAoShortfall { get; set; }
        public string PrePetitionDueDate { get; set; }
        public string PrePetitionPaymentAmount { get; set; }
        public string PrePetitionShortfall { get; set; }
        public string PostPetitionPaymentDate { get; set; }
        public string PostPetitionPaymentAmount { get; set; }
        public string PostPetitionLateChargeAmount { get; set; }
        public string Filler { get; set; }

    }
}
