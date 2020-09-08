using ODHS_EDelivery.Models.InputCopyBookModels;
using ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels;
using System;
using System.Runtime.Remoting.Messaging;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Carrington_Service.Calculation_Classes
{
    public class ChapterThirteenBillingStatement
    {
        public string PaymentAmount { get; set; }
        public string Principal { get; set; }
        public decimal PastUnpaidAmount { get; set; }
        public decimal TotalFeesPaid { get; set; }
        public string TotalPaymentAmount { get; set; }
        public string DeferredBalance { get; set; }
        public decimal FeesAndChargesPaidLastMonth { get; set; }
        public decimal UnappliedFundsPaidLastMonth { get; set; }
        public decimal TotalPaidLastMonth { get; set; }
        public decimal FeesAndChargesPaidYeartoDate { get; set; }
        public decimal UnappliedFundsPaidYearToDate { get; set; }
        public decimal TotalPaidYearToDate { get; set; }
        public decimal Suspense { get; set; }
        public decimal Miscellaneous { get; set; }
        ChapterThirteenBillingStatement()
        {

        }

        /* While Calculating Conditions must be applied and copybook fields must be verified twice*/
        public string GetPaymentAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PaymentAmount = "0.00";


            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) >
                 Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.CurrentDueDate))

                PaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            else
                PaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));

            return PaymentAmount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetDeferredBalance(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance) -
                Convert.ToInt64(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance)) == 0)
                DeferredBalance = "N/A";
            else
                DeferredBalance = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance) -
                Convert.ToInt64(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance));

            return DeferredBalance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPrincipal(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0 ||
                Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)

                Principal = "0.00";

            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) >
                    Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.CurrentDueDate))

                Principal = "0.00";

            else
            {
                Principal = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.P_IPayment) -
                    Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestOnPymtDue));
            }

            return Principal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public decimal GetPastUnpaidAmount(AccountsModel accountsModel)
        {

            PastUnpaidAmount = Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts) - GetTotalFeesPaid(accountsModel);
            return PastUnpaidAmount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public decimal GetTotalFeesPaid(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable) +
                Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)) <
                Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
            {

                TotalFeesPaid = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable) +
                    Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue) -
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges);
            }
            else
            {
                TotalFeesPaid = Convert.ToInt64(0.00);
            }

            return TotalFeesPaid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalPaymentAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalPaymentAmount = "0.00";


            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) >
                 Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.CurrentDueDate))

                TotalPaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            else
                TotalPaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));

            return TotalPaymentAmount;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public decimal GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
              &&
              (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {

                FeesAndChargesPaidLastMonth = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesPaidSinceLastStatement) +
                Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesPaidSinceLastStatement) -
                Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount);
            }

            return FeesAndChargesPaidLastMonth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public decimal GetUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {


            return UnappliedFundsPaidLastMonth;
        }
        public decimal GetTotalPaidLastMonth()
        {

            return TotalPaidLastMonth;
        }
        public decimal GetFeesAndChargesPaidYeartoDate()
        {

            return FeesAndChargesPaidYeartoDate;
        }
        public decimal GetUnappliedFundsPaidYearToDate()
        {

            return UnappliedFundsPaidYearToDate;
        }
        public decimal GetTotalPaidYearToDate()
        {

            return TotalPaidYearToDate;
        }

        public decimal GetSuspense()
        {
            return Suspense;
        }
        public decimal GetMiscellaneous()
        {

            return Miscellaneous;
        }

    }
}