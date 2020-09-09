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
        public Decimal TotalFeesPaid { get; set; }
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

            if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
            {
                PaymentAmount = Convert.ToString("0.00");
            }
            else
            {
                PaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
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
            if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0" || accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData=="0")
            {
                Principal = "0.00";
            }
            else
            {
                Principal = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));

            }

                return Principal;
        }

        public string GetPastUnpaidAmount(AccountsModel accountModel)
        {
            //Total Fees Paid was not there so used total fees due
            PastUnpaidAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.TotalFeesDue));
           
            return PastUnpaidAmount;
        }
        public string GetTotalFeesandCharges(AccountsModel accountModel)
        {
            //conditional statement is ther but not applying
            TotalFeesandCharges = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement)+Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement));
            return TotalFeesandCharges;
        }
        public decimal GetTotalFeesPaid(AccountsModel accountModel)
        {
            if ((Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData) +
                 Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                 Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
                

                    TotalFeesPaid = Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData) +
                    Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData) -
                    Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges);
            
            else
            {
                TotalFeesPaid = Convert.ToInt64(0.00);
            }

            return TotalFeesPaid;
        }
        public string GetTotalPaymentAmount(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
            {
                TotalPaymentAmount = Convert.ToString("0.00");
            }
            else
            {
                TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
            }
            return TotalPaymentAmount;

            }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {

            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
              &&
              (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {

                FeesAndChargesPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesPaidSinceLastStatement) +
                Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesPaidSinceLastStatement));
            }

            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel)
        {
            UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds2) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds3) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds4) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds5));
            return UnappliedFundsPaidLastMonth;
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
            &&
            (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {
                //Need to know and Add PriorMoAmnt in this section
                TotalPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.TotalAmountPaidSinceLastStatement) - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }
            else
            {
                TotalPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.TotalAmountPaidSinceLastStatement) - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }

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
            UnappliedFundsPaidYearToDate= Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0));
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {
            TotalPaidYearToDate= Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.PrincipalPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.EscrowPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.FeesPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.LateChargesPaidYTD) +(accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd !="L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0) + Convert.ToDecimal(accountModel.TransactionRecordModel.OptionalDeferredAmount));
            return TotalPaidYearToDate;
        }
        public string GetTotalDue(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
            {
                TotalDue = Convert.ToString("0.00");
            }
            else
            {
                TotalDue = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
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