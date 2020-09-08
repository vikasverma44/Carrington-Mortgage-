using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using ODHS_EDelivery.Models.InputCopyBookModels;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace Carrington_Service.Calculation_Classes
{
    public class ChapterSevenBillingStatement
    {
        public string PaymentAmount { get; set; }
        public string DeferredBalance { get; set; }
        public string Principal { get; set; }
        public string PastUnpaidAmount { get; set; }
        public string TotalFeesandCharges { get; set; }
        public string TotalFeesPaid { get; set; }
        public string TotalPaymentAmount { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string TotalPaidLastMonth { get; set; }
        public string FeesAndChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
        public string TotalDue { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        ChapterSevenBillingStatement()
        {

        }

        /* While Calculating Conditions must be applied*/
        public string GetPaymentAmount(AccountsModel accountModel)
        {

            if (accountModel.MasterFileDataPart_1Model.PrincipalBalance == "0")
            {
                PaymentAmount = Convert.ToString("0.00");
            }
            else
            {
                PaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.PastDueAmtTotalDue) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.CurrentPayment));
            }
            return PaymentAmount;
        }
        public string GetDeferredBalance(AccountsModel accountModel)
        {
            if ((Convert.ToInt32(accountModel.MasterFileDataPart2Model.TotalDeferredItemsBalance) - Convert.ToInt32(accountModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance)) == 0)
            {
                DeferredBalance = "N/A";
            }
            else
            {
                DeferredBalance = Convert.ToString(Convert.ToInt32(accountModel.MasterFileDataPart2Model.TotalDeferredItemsBalance) - Convert.ToInt32(accountModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance));
            }
            return DeferredBalance;
        }
        public string GetPrincipal(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart_1Model.PrincipalBalance == "0" || accountModel.MasterFileDataPart_1Model.CurrentPayment=="0")
            {
                Principal = "0.00";
            }
            else
            {
                Principal = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.P_IPayment) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.InterestOnPymtDue));

            }

                return Principal;
        }

        public string GetPastUnpaidAmount(AccountsModel accountModel)
        {
            //Total Fees Paid was not there so used total fees due
            PastUnpaidAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.PastDueAmtTotalDue) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.TotalFeesDue));
           
            return PastUnpaidAmount;
        }
        public string GetTotalFeesandCharges(AccountsModel accountModel)
        {
            //conditional statement is ther but not applying
            TotalFeesandCharges = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement)+Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement));
            return TotalFeesandCharges;
        }
        public string GetTotalFeesPaid(AccountsModel accountModel)
        {
           // TotalFeesPaid = Convert.ToString();
            return TotalFeesPaid;
        }
        public string GetTotalPaymentAmount(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart_1Model.PrincipalBalance == "0")
            {
                TotalPaymentAmount = Convert.ToString("0.00");
            }
            else
            {
                TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.PastDueAmtTotalDue) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.CurrentPayment));
            }
            return TotalPaymentAmount;

            }
        public string GetFeesAndChargesPaidLastMonth()
        {
         
            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel)
        {
            UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds2) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds3) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds4) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds5));
            return UnappliedFundsPaidLastMonth;
        }
        public string GetTotalPaidLastMonth()
        {
            //Calculation =  RSSI-TOT-PD-SINCE-LST-STMT     minus  (RSSI - TR - AMT  where RSSI - LOG - TRAN = 5705 or  5707 and  RSSI - TR - FEE - CODE = 67 or 198)  + PriorMoAmnt
            //Conditional Statement=
            //Copybook Field Name=RSSI-TOT-PD-SINCE-LST-STMT  minus RSSI - TR - AMT where RSSI-LOG - TRAN = 5705 or 5707 and RSSI - TR - FEE - CODE = 67 or 198  plus PriorMoAmnt
            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel)
        {
            Decimal total = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.FeesPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.LateChargesPaidYTD) - Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmount);
            if((Convert.ToInt32(accountModel.TransactionRecordModel.LogTransaction)==5705 || Convert.ToInt32(accountModel.TransactionRecordModel.LogTransaction) == 5707) && (Convert.ToInt32(accountModel.TransactionRecordModel.FeeCode)==67 || Convert.ToInt32(accountModel.TransactionRecordModel.FeeCode)==198))
            {
                FeesAndChargesPaidYeartoDate = Convert.ToString(total);
            }
            else
            {
                FeesAndChargesPaidYeartoDate = string.Empty;
            }
            return FeesAndChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            UnappliedFundsPaidYearToDate= Convert.ToString((accountModel.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0));
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {
            TotalPaidYearToDate= Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.PrincipalPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.InterestPaidYearToDate) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.EscrowPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.FeesPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.LateChargesPaidYTD) +(accountModel.MasterFileDataPart_1Model.UnappliedFundsCodeFirst !="L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0) + Convert.ToDecimal(accountModel.TransactionRecordModel.OptionalDeferredAmount));
            return TotalPaidYearToDate;
        }
        public string GetTotalDue(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart_1Model.PrincipalBalance == "0")
            {
                TotalDue = Convert.ToString("0.00");
            }
            else
            {
                TotalDue = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.PastDueAmtTotalDue) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.CurrentPayment));
            }
            return TotalDue;
            
        }
        public string GetSuspense(AccountsModel accountModel)
        {
            Suspense = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds2) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds3) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds4) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds5));
            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountModel)
        {
            Miscellaneous= Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountConstructionBalance) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountOptionalInsurance) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountToP_IShortage) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountPostedToDeferredPrincipal) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredInterest) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredLateCharge) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredEscrowAdv) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredPaidExpensesAdv) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredUnpaidExpenseAdv) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredAdminFees) + Convert.ToDecimal(accountModel.TransactionRecordModel.OptionalDeferredAmount));
            return Miscellaneous;
        }

    }
}