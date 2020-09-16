using Carrington_Service.Infrastructure;
using CarringtonMortgage.Models.InputCopyBookModels;
using System;
using System.Text;

namespace Carrington_Service.Calculation_Classes
{
    public class ChapterSevenOptionARMStatement : IChapterSevenOptionARMStatement
    {
        private string AmountDueOption1 { get; set; }
        private string AmountDueOption2 { get; set; }
        private string AmountDueOption3 { get; set; }
        private string AmountDueOption4 { get; set; }
        private string PrincipalOption1 { get; set; }
        private string AssistanceAmount { get; set; }
        private string ReplacementReserve { get; set; }
        private string OverduePaymentsOption1 { get; set; }
        private string TotalFeesChargedOption1 { get; set; }
        private string TotalFeesPaidOption1 { get; set; }
        private string TotalAmountDueOption1 { get; set; }
        private string PrincipalOption2 { get; set; }
        private string AssistanceAmountOption2 { get; set; }
        private string ReplacementReserveOption2 { get; set; }
        private string OverduePaymentsOption2 { get; set; }
        private string TotalFeesChargedOption2 { get; set; }

        private string TotalFeesPaidOption2 { get; set; }
        private string TotalAmountDueOption2 { get; set; }
        private string PrincipalOption3 { get; set; }
        private string AssistanceAmountOption3 { get; set; }
        private string ReplacementReserveOption3 { get; set; }
        private string OverduePaymentsOption3 { get; set; }
        private string TotalFeesChargedOption3 { get; set; }
        private string TotalFeesPaidOption3 { get; set; }
        private string TotalAmountDueOption3 { get; set; }
        private string PrincipalOption4 { get; set; }
        private string AssistanceAmountOption4 { get; set; }
        private string ReplacementReserveOption4 { get; set; }
        private string OverduePaymentsOption4 { get; set; }
        private string TotalFeesChargedOption4 { get; set; }
        private string TotalFeesPaidOption4 { get; set; }
        private string TotalAmountDueOption4 { get; set; }
        private string FeesandChargesPaidLastMonth { get; set; }
        private string UnappliedFundsPaidLastMonth { get; set; }
        private string FeesandChargesPaidYeartoDate { get; set; }
        private string UnappliedFundsPaidYearToDate { get; set; }
        private string PaymentAmountOption1 { get; set; }
        private string PaymentAmountOption2 { get; set; }
        private string PaymentAmountOption3 { get; set; }
        private string PaymentAmountOption4 { get; set; }
        private string Suspense { get; set; }
        private string Miscellaneous { get; set; }
        private string DeferredBalance { get; set; }
        private string TotalDue { get; set; }
        private string Hold { get; set; }
        private string PrimaryBorrowerBKAttorney { get; set; }
        private string SecondaryBorrower { get; set; }
        private string MailingBKAttorneyAddressLine1 { get; set; }
        private string MailingBKAttorneyAddressLine2 { get; set; }
        private string BorrowerAttorneyMailingCityStateZip { get; set; }
        private string MailingCountry { get; set; }
        private string PaymentDate { get; set; }
        private string InterestOption1 { get; set; }
        private string EscrowOption1 { get; set; }
        private string RegularMonthlyPaymentOption1 { get; set; }
        private string InterestOption2 { get; set; }
        private string EscrowOption2 { get; set; }
        private string RegularMonthlyPaymentOption2 { get; set; }
        private string InterestOption3 { get; set; }
        private string EscrowOption3 { get; set; }
        private string RegularMonthlyPaymentOption3 { get; set; }
        private string InterestOption4 { get; set; }
        private string EscrowOption4 { get; set; }
        private string RegularMonthlyPaymentOption4 { get; set; }
        private string Option4MinimumDescription { get; set; }
        private string POBoxAddress { get; set; }
       
        private string Date { get; set; }
        private string Amount { get; set; }
        private string BuydownBalance { get; set; }
        private string PartialClaim { get; set; }
        private string InterestRateUntil { get; set; }
        private string PrepaymentPenalty { get; set; }
        private string AccountHistoryInformationbox { get; set; }
        private string RecentPayment6 { get; set; }
        private string RecentPayment5 { get; set; }
        private string RecentPayment4 { get; set; }
        private string RecentPayment3 { get; set; }
        private string RecentPayment2 { get; set; }
        private string RecentPayment1 { get; set; }
        private string LenderPlacedInsuranceMessage { get; set; }
        private string StateNSF { get; set; }
        private string AutodraftMessage { get; set; }
        private string CMSPartialClaim { get; set; }
        private string HUDPartialClaim { get; set; }
        private string StateDisclosures { get; set; }
        private string PaymentInformationMessage { get; set; }

        private string ExMessage { get; set; }

        private StringBuilder finalLine;

        private ILogger Logger;

        public string GetFinalChapterSevenOptionARMStatement(AccountsModel accountModel)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();
            finalLine.Append("01" + "|");
            finalLine.Append("Option ARM BK CHPT 7 STMT" + "|");
            finalLine.Append(" " + "|");
            finalLine.Append("01" + "|");
            finalLine.Append(GetAmountDueOption1(accountModel) + "|");
            finalLine.Append(GetAmountDueOption2(accountModel) + "|");
            finalLine.Append(GetAmountDueOption3(accountModel) + "|");
            finalLine.Append(GetAmountDueOption4(accountModel) + "|");
            finalLine.Append(GetPrincipalOption1(accountModel) + "|");
            finalLine.Append(GetAssistanceAmount(accountModel) + "|");
            finalLine.Append(GetReplacementReserve(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption1(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption1(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption1(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption1(accountModel) + "|");
            finalLine.Append(GetPrincipalOption2(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption2(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption2(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption2(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption2(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption2(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption2(accountModel) + "|");
            finalLine.Append(GetPrincipalOption3(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption3(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption3(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption3(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption3(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption3(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption3(accountModel) + "|");
            finalLine.Append(GetPrincipalOption4(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption4(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption4(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption4(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption4(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption4(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption4(accountModel) + "|");
            finalLine.Append(GetFeesandChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GeUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesandChargesPaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetPaymentAmountOption1(accountModel) + "|");
            finalLine.Append(GetPaymentAmountOption2(accountModel) + "|");
            finalLine.Append(GetPaymentAmountOption3(accountModel) + "|");
            finalLine.Append(GetPaymentAmountOption4(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
            finalLine.Append(GetTotalDue(accountModel) + "|");
            finalLine.Append(GetHold(accountModel) + "|");
            finalLine.Append(GetPrimaryBorrowerBKAttorney(accountModel) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine1(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine2(accountModel) + "|");
            finalLine.Append(GetBorrowerAttorneyMailingCityStateZip(accountModel) + "|");
            finalLine.Append(GetMailingCountry(accountModel) + "|");
            finalLine.Append(GetPaymentDate(accountModel) + "|");
            finalLine.Append(GetInterestOption1(accountModel) + "|");
            finalLine.Append(GetEscrowOption1(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption1(accountModel) + "|");
            finalLine.Append(GetInterestOption2(accountModel) + "|");
            finalLine.Append(GetEscrowOption2(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption2(accountModel) + "|");
            finalLine.Append(GetInterestOption3(accountModel) + "|");
            finalLine.Append(GetEscrowOption3(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption3(accountModel) + "|");
            finalLine.Append(GetInterestOption4(accountModel) + "|");
            finalLine.Append(GetEscrowOption4(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption4(accountModel) + "|");
            finalLine.Append(GetOption4MinimumDescription(accountModel) + "|");
            finalLine.Append(GetPOBoxAddress(accountModel) + "|");
            finalLine.Append(GetDate(accountModel) + "|");
            finalLine.Append(GetAmount(accountModel) + "|");
            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetAccountHistoryInformationbox(accountModel) + "|");
            finalLine.Append(GetRecentPayment6(accountModel) + "|");
            finalLine.Append(GetRecentPayment5(accountModel) + "|");
            finalLine.Append(GetRecentPayment4(accountModel) + "|");
            finalLine.Append(GetRecentPayment3(accountModel) + "|");
            finalLine.Append(GetRecentPayment2(accountModel) + "|");
            finalLine.Append(GetRecentPayment1(accountModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            finalLine.Append(GetStateNSF(accountModel) + "|");
            finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            finalLine.Append(GetStateDisclosures(accountModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");

            return Convert.ToString(finalLine);
        }

        /* While Calculating Conditions must be applied*/
        private string GetAmountDueOption1(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption1 = "0";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    AmountDueOption1 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption1 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption1 = "N/A";
                }
                else
                {
                    AmountDueOption1 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
                }
                Logger.Trace("ENDED:  To Get Amount Due Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AmountDueOption1;
        }
        private string GetAmountDueOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption2 = "0";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else
                {
                    AmountDueOption2 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));

                }
                Logger.Trace("ENDED:  To Get Amount Due Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AmountDueOption2;
        }
        private string GetAmountDueOption3(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption3 = "0";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else
                {
                    AmountDueOption3 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                Logger.Trace("ENDED:  To Get Amount Due Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AmountDueOption3;
        }
        private string GetAmountDueOption4(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option4");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption4 = "0";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption4 = "N/A";
                }
                else
                {
                    AmountDueOption4 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }
                Logger.Trace("ENDED:  To Get Amount Due Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AmountDueOption4;
        }


        private string GetPrincipalOption1(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption1 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    PrincipalOption1 = "null";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption1 = "null";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption1 = "null";


                else
                {
                    PrincipalOption1 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                     - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:  To Get Principal Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrincipalOption1;
        }
        private string GetAssistanceAmount(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmount = "do not print the Assistance Amount line";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmount = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmount = "null";


                else
                {
                    AssistanceAmount = accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
                }
                Logger.Trace("ENDED:  To Get Assistance Amount");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AssistanceAmount;
        }
        private string GetReplacementReserve(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve");

                if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
               - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
               - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
               + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserve = "do not print the Replacement Reserve line";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserve = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserve = "0.00";


                else
                {
                    ReplacementReserve = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                                - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                                - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

                }
                Logger.Trace("ENDED:  To Get Replacement Reserve");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return ReplacementReserve;
        }
        private string GetOverduePaymentsOption1(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption1 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption1 = "null";


                else
                {
                    OverduePaymentsOption1 = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToInt64(GetTotalFeesPaidOption1(accountsModel)));
                }
                Logger.Trace("ENDED:  To Get Overdue Payments Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return OverduePaymentsOption1;
        }
        private string GetTotalFeesChargedOption1(AccountsModel accountsModel)//Issue
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "0";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "0";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "0";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption1 = "null";
                }
                else
                {
                    var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    if (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                        && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67))
                    {
                        TotalFeesChargedOption1 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                         || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                         && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                    {
                        TotalFeesChargedOption1 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else
                    {
                        TotalFeesChargedOption1 = Convert.ToString(Total);
                    }
                }
                Logger.Trace("ENDED:  To Get Total Fees Charged Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption1;
        }
        private string GetTotalFeesPaidOption1(AccountsModel accountsModel)// Issue
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";



                else if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption1 = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
                }
                else
                    TotalFeesPaidOption1 = "0.00";
                Logger.Trace("ENDED:  To Get Total Fees Paid Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption1;
        }
        private string GetTotalAmountDueOption1(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "N/A";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "N/A";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "N/A";


                else
                    TotalAmountDueOption1 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                Logger.Trace("ENDED:  To Get Total Amount Due Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption1;
        }


        private string GetPrincipalOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption1 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    PrincipalOption1 = "null";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption1 = "null";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption1 = "null";
                else
                {
                    AmountDueOption1 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                     - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("STARTED:  To Get Principal Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrincipalOption2;
        }
        private string GetAssistanceAmountOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "do not print the Assistance Amount line";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption2 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "null";
                else
                {
                    AssistanceAmountOption2 = accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
                }
                Logger.Trace("ENDED:  To Get Assistance Amount Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AssistanceAmountOption2;
        }
        private string GetReplacementReserveOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option2");

                if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
              - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
              - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
              + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption2 = "do not print the Replacement Reserve line";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption2 = "null";

                else
                {
                    ReplacementReserveOption2 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                                - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                                - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

                }
                Logger.Trace("ENDED:  To Get Replacement Reserve Option2");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return ReplacementReserveOption2;
        }
        private string GetOverduePaymentsOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption2 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else
                {
                    OverduePaymentsOption2 = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToInt64(GetTotalFeesPaidOption2(accountsModel)));
                }
                Logger.Trace("ENDED:  To Get Overdue Payments Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return OverduePaymentsOption2;
        }
        private string GetTotalFeesChargedOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "0";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "0";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "0";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption2 = "null";
                }
                else
                {
                    var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    if (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                        && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67))
                    {
                        TotalFeesChargedOption2 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                         || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                         && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                    {
                        TotalFeesChargedOption2 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else
                    {
                        TotalFeesChargedOption2 = Convert.ToString(Total);
                    }
                }
                Logger.Trace("ENDED:  To Get Total Fees Charged Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption2;
        }
        private string GetTotalFeesPaidOption2(AccountsModel accountsModel)
        {

            try
            {
                // need to check
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option2");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption2 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption2 = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
                }
                else
                    TotalFeesPaidOption2 = "0.00";
                Logger.Trace("ENDED:  To Get Total Fees Paid Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption2;
        }
        private string GetTotalAmountDueOption2(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption2 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalAmountDueOption2 = "N/A";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption2 = "N/A";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption2 = "N/A";

                else
                    TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
               
                Logger.Trace("ENDED:  To Get Total Amount Due Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption2;
        }


        private string GetPrincipalOption3(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption3 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    PrincipalOption3 = "null";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption3 = "null";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption3 = "null";
                else
                {
                    PrincipalOption3 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                     - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:  To Get Principal Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrincipalOption3;
        }
        private string GetAssistanceAmountOption3(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption3 = "do not print the Assistance Amount line";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption3 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption3 = "0.00";
                else
                {
                    AssistanceAmountOption3 = accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
                }
                Logger.Trace("ENDED:  To Get Assistance Amount Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AssistanceAmountOption3;
        }
        private string GetReplacementReserveOption3(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option3");

                if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
             - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
             - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
             + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption3 = "do not print the Replacement Reserve line";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption3 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption3 = "0.00";
                else
                {
                    ReplacementReserveOption3 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                                                - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                                - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

                }
                Logger.Trace("ENDED:  To Get Replacement Reserve Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return ReplacementReserveOption3;
        }
        private string GetOverduePaymentsOption3(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption2 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption2 = "null";
                else
                {
                    OverduePaymentsOption2 = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToInt64(GetTotalFeesPaidOption3(accountsModel)));
                }
                Logger.Trace("ENDED:  To Get Overdue Payments Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return OverduePaymentsOption3;
        }
        private string GetTotalFeesChargedOption3(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "0";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "0";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "0";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption3 = "null";
                }
                else
                {
                    var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    if (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                        && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67))
                    {
                        TotalFeesChargedOption3 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                         || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                         && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                    {
                        TotalFeesChargedOption3 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else
                    {
                        TotalFeesChargedOption3 = Convert.ToString(Total);
                    }
                }

                Logger.Trace("ENDED:  To Get Total Fees Charged Option3");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption3;
        }
        private string GetTotalFeesPaidOption3(AccountsModel accountsModel)
        {

            try
            {
                // need to check
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption3 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";


                else if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption3 = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
                }
                else
                    TotalFeesPaidOption3 = "0.00";

                Logger.Trace("ENDED:  To Get Total Fees Paid Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption3;
        }
        private string GetTotalAmountDueOption3(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption3 = "0.00";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    TotalAmountDueOption3 = "N/A";

                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption3 = "N/A";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption3 = "N/A";


                else
                    TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                Logger.Trace("ENDED:  To Get Total Amount Due Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption3;
        }


        private string GetPrincipalOption4(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option4");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption4 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                    PrincipalOption4 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption4 = "0.00";


                else
                {
                    PrincipalOption4 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                                     - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:  To Get Principal Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrincipalOption4;
        }
        private string GetAssistanceAmountOption4(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option4");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption4 = "do not print the Assistance Amount line";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption4 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption4 = "0.00";

                else
                {
                    AssistanceAmountOption4 = accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
                }

                Logger.Trace("ENDED:  To Get Assistance Amount Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AssistanceAmountOption4;
        }
        private string GetReplacementReserveOption4(AccountsModel accountsModel)
        {
            Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option4");
            try
            {
                if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
            - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
            - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption4 = "do not print the Replacement Reserve line";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption4 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption4 = "0.00";


                else
                {
                    ReplacementReserveOption4 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                                                - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                                                - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

                }
                Logger.Trace("ENDED:  To Get Replacement Reserve Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return ReplacementReserveOption4;
        }
        private string GetOverduePaymentsOption4(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option4");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption4 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption4 = "0.00";
                else
                {
                    OverduePaymentsOption4 = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToInt64(GetTotalFeesPaidOption4(accountsModel)));
                }
                Logger.Trace("ENDED:  To Get Overdue Payments Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return OverduePaymentsOption4;
        }
        private string GetTotalFeesChargedOption4(AccountsModel accountsModel)// issue
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option4");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption4 = "0";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption4 = "0";
                }
                else
                {
                    var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    if (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                        && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67))
                    {
                        TotalFeesChargedOption4 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                         || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                         && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                    {
                        TotalFeesChargedOption4 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else
                    {
                        TotalFeesChargedOption4 = Convert.ToString(Total);
                    }
                }
                Logger.Trace("ENDED:  To Get Total Fees Charged Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption4;
        }
        private string GetTotalFeesPaidOption4(AccountsModel accountsModel)
        {
            // need to check

            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option4");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption4 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption4 = "0.00";

                else if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption4 = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
                }
                else
                    TotalFeesPaidOption4 = "0.00";
                Logger.Trace("ENDED:  To Get Total Fees Paid Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption4;
        }
        private string GetTotalAmountDueOption4(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option4");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption4 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption4 = "N/A";


                else
                    TotalAmountDueOption4 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                Logger.Trace("ENDED:  Execute to Get Total Amount Due Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption4;
        }


        private string GetFeesandChargesPaidLastMonth(AccountsModel accountsModel)//Issue
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Fees and Charges Paid Last Month");

                var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData)
              + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData);

                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705
                    || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    &&
                    (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67
                    || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                {
                    FeesandChargesPaidLastMonth = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                else
                {
                    FeesandChargesPaidLastMonth = Convert.ToString(Total);
                }
                Logger.Trace("ENDED:  To Get Fees and Charges Paid Last Month");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return FeesandChargesPaidLastMonth;
        }
        private string GeUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Last Month");

                UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2));

                Logger.Trace("ENDED:  To Get Unapplied Funds Paid Last Month");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return UnappliedFundsPaidLastMonth;
        }
        private string GetFeesandChargesPaidYeartoDate(AccountsModel accountsModel)//Issue
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Fees and Charges Paid Year to Date");

                var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData);

                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705
                    || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    &&
                    (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67
                    || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                {
                    FeesandChargesPaidYeartoDate = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                else
                {
                    FeesandChargesPaidYeartoDate = Convert.ToString(Total);
                }
                Logger.Trace("ENDED:  To Get Fees and Charges Paid Year to Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return FeesandChargesPaidYeartoDate;
        }
        private string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel)//Issue
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Year To Date");

                UnappliedFundsPaidYearToDate = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd) : 0
          + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
          + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
          + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
          + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
                Logger.Trace("ENDED:  To Get Unapplied Funds Paid Year To Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return UnappliedFundsPaidYearToDate;

        }
        private string GetPaymentAmountOption1(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Payment Amount Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PaymentAmountOption1 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    PaymentAmountOption1 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    PaymentAmountOption1 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PaymentAmountOption1 = "N/A";
                }
                else
                {
                    PaymentAmountOption1 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
                }
                Logger.Trace("ENDED:  To Get Payment Amount Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentAmountOption1;
        }
        private string GetPaymentAmountOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Payment Amount Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PaymentAmountOption2 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    PaymentAmountOption2 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    PaymentAmountOption2 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PaymentAmountOption2 = "N/A";
                }
                else
                {
                    PaymentAmountOption2 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));
                }
                Logger.Trace("ENDED:  To Get Payment Amount Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentAmountOption2;
        }
        private string GetPaymentAmountOption3(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Payment Amount Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PaymentAmountOption4 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    PaymentAmountOption3 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    PaymentAmountOption3 = "N/A";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PaymentAmountOption3 = "N/A";
                }
                else
                {
                    PaymentAmountOption3 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                Logger.Trace("ENDED:  To Get Payment Amount Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentAmountOption3;
        }
        private string GetPaymentAmountOption4(AccountsModel accountsModel)
        {

            try
            {

                Logger.Trace("STARTED:  Execute to Get Payment Amount Option4");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PaymentAmountOption4 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PaymentAmountOption4 = "N/A";
                }
                else
                {
                    PaymentAmountOption4 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }
                Logger.Trace("ENDED:  To Get Payment Amount Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentAmountOption4;
        }
        private string GetSuspense(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Suspense");

                Suspense = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2));

                Logger.Trace("ENDED:  To Get Suspense");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Suspense;
        }
        private string GetMiscellaneous(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Miscellaneous");

                Miscellaneous = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lc_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Esc_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData)
               );

                Logger.Trace("ENDED:  To Get Miscellaneous");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Miscellaneous;
        }
        private string GetDeferredBalance(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Deferred Balance");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal)
                - Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal)
                    - Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                }
                Logger.Trace("ENDED:  To Get Deferred Balance");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return DeferredBalance;
        }
        private string GetTotalDue(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Due");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalDue = "0";
                }
                else
                {
                    TotalDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                Logger.Trace("ENDED:  To Get Total Due");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalDue;
        }
        private string GetHold(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Hold");

                if (accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    Hold = "create image but do not mail";
                }
                else
                {
                    Hold = accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt;
                }
                Logger.Trace("ENDED:  To Get Hold");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Hold;
        }
        private string GetPrimaryBorrowerBKAttorney(AccountsModel accountsModel)
        {



            //If RSSI-POC - STATEMENT - FLAG = Y, then copy 1 to RSSI-PRIMARY - NAME and copy 2 to
            //RSSI - VEND - NAME1"
            try
            {

                Logger.Trace("STARTED:  Execute to Get Primary Borrower BK Attorney");
                if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N"
                    || accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Null")
                {
                    PrimaryBorrowerBKAttorney = "do not print a statement";
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    PrimaryBorrowerBKAttorney = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    PrimaryBorrowerBKAttorney = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")// issue 
                {
                    PrimaryBorrowerBKAttorney = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name
                        + accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
                }
                Logger.Trace("ENDED:  To Get Primary Borrower BK Attorney");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrimaryBorrowerBKAttorney;
        }
        private string GetSecondaryBorrower(AccountsModel accountsModel)
        {
            try { 
            Logger.Trace("STARTED:  Execute to Get Secondary Borrower");
            if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                || accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
            {
                SecondaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
            }
            Logger.Trace("ENDED:  To Get Secondary Borrower");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return SecondaryBorrower;
        }
        private string GetMailingBKAttorneyAddressLine1(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Mailing BK Attorney Address Line1");

                if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    MailingBKAttorneyAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    MailingBKAttorneyAddressLine1 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    MailingBKAttorneyAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1
                        + accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
                }
                Logger.Trace("ENDED:  To Get Mailing BK Attorney Address Line1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return MailingBKAttorneyAddressLine1;
        }
        private string GetMailingBKAttorneyAddressLine2(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Mailing BK Attorney Address Line2");

                if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    MailingBKAttorneyAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    MailingBKAttorneyAddressLine2 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    MailingBKAttorneyAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2
                        + accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
                }
                Logger.Trace("ENDED:  To Get Mailing BK Attorney Address Line2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return MailingBKAttorneyAddressLine2;
        }
        private string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Borrower Attorney Mailing City State Zip");

                if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    BorrowerAttorneyMailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    BorrowerAttorneyMailingCityStateZip = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City
                        + accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State
                        + accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                }
                if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    BorrowerAttorneyMailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3
                        + accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City
                        + accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State
                        + accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                }
                Logger.Trace("ENDED:  To Get Borrower Attorney Mailing City State Zip");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return BorrowerAttorneyMailingCityStateZip;
        }
        private string GetMailingCountry(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Mailing Country");

                if (accountsModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Altr_Cntry;
                }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
                {
                    MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country;
                }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
                {
                    MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Appl_Country;
                }
                else
                {
                    MailingCountry = "null";
                }
                Logger.Trace("ENDED:  To Get Mailing Country");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return MailingCountry;
        }
        private string GetPaymentDate(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Payment Date");

                PaymentDate = accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte;

                Logger.Trace("ENDED:  To Get Payment Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentDate;
        }
        private string GetInterestOption1(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption1 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    InterestOption1 = "null";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption1 = "null";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption1 = "null";
                }
                else
                {
                    InterestOption1 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;
                }
                Logger.Trace("ENDED:  To Get Interest Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestOption1;
        }
        private string GetEscrowOption1(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Escrow Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption1 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    EscrowOption1 = "null";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption1 = "null";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption1 = "null";
                }
                else
                {
                    EscrowOption1 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

                }
                Logger.Trace("ENDED:  To Get Escrow Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return EscrowOption1;
        }
        private string GetRegularMonthlyPaymentOption1(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option1");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption1 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData;
                }
                Logger.Trace("ENDED:  To Get Regular Monthly Payment Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RegularMonthlyPaymentOption1;
        }


        private string GetInterestOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption2 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    InterestOption2 = "null";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption2 = "null";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption2 = "null";
                }
                else
                {
                    InterestOption2 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

                }
                Logger.Trace("ENDED:  To Get Interest Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestOption2;
        }
        private string GetEscrowOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Escrow Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption2 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    EscrowOption2 = "null";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption2 = "null";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption2 = "null";
                }
                else
                {
                    EscrowOption2 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

                }
                Logger.Trace("ENDED:  To Get Escrow Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return EscrowOption2;
        }
        private string GetRegularMonthlyPaymentOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option2");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = "null";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption2 = "null";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption2 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData;

                }
                Logger.Trace("ENDED:  To Get Regular Monthly Payment Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RegularMonthlyPaymentOption2;
        }

        private string GetInterestOption3(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption3 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    InterestOption3 = "null";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption3 = "null";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption3 = "null";
                }
                else
                {
                    InterestOption3 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

                }
                Logger.Trace("ENNDED:  To Get Interest Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestOption3;

        }
        private string GetEscrowOption3(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Escrow Option3");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption3 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    EscrowOption3 = "null";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption3 = "null";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption3 = "null";
                }
                else
                {
                    EscrowOption3 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

                }
                Logger.Trace("ENDED:  To Get Escrow Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return EscrowOption3;
        }
        private string GetRegularMonthlyPaymentOption3(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option3");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = "null";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption3 = "null";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption3 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData;

                }
                Logger.Trace("ENDED:  To Get Regular Monthly Payment Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RegularMonthlyPaymentOption3;
        }

        private string GetInterestOption4(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Option4");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption4 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption4 = "null";
                }
                else
                {
                    InterestOption4 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

                }
                Logger.Trace("ENDED:  To Get Interest Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestOption4;
        }
        private string GetEscrowOption4(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Escrow Option4");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption4 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption4 = "null";
                }
                else
                {
                    EscrowOption4 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

                }
                Logger.Trace("ENDED:  To Get Escrow Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return EscrowOption4;
        }
        private string GetRegularMonthlyPaymentOption4(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option4");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption4 = "0.00";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption4 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption4 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData;

                }
                Logger.Trace("ENDED:  To Get Regular Monthly Payment Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RegularMonthlyPaymentOption4;
        }

        private string GetOption4MinimumDescription(AccountsModel accountsModel)
        {


            try
            {
                Logger.Trace("STARTED:  Execute to Get Option4 Minimum Description");

                if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
               - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > 0)
                {
                    Option4MinimumDescription = "Your principal balance will decrease and you will be closer to paying off your loan. ";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                      - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) == 0)
                {
                    Option4MinimumDescription = "Your principal balance will stay the same and you will not be closer to paying off your loan.";
                }
                else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                      - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) < 0)
                {
                    Option4MinimumDescription = "Your principal balance will increase.You will be borrowing more money and losing equity in your home.";
                }
                else
                {
                    Option4MinimumDescription = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                      - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:  To Get Option4 Minimum Description");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Option4MinimumDescription;
        }
        private string GetPOBoxAddress(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get PO Box Address");

                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS"
                   || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA"
                   || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM"
                   || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                   || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                {
                    POBoxAddress = "Dallas P.O.Box Address";
                }
                else
                {
                    POBoxAddress = "Pasadena P.O.Box Address";
                }
                Logger.Trace("ENDED:  To Get PO Box Address");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return POBoxAddress;
        }
        private string GetDate(AccountsModel accountsModel)
        {


            try
            {
                Logger.Trace("STARTED:  Execute to Get Date");

                if (accountsModel.FeeRecordModel.Rssi_Fd_Fee_Type == "000")
                {
                    Date = accountsModel.FeeRecordModel.Rssi_Fd_Assess_Date;
                }
                else
                {
                    Date = accountsModel.TransactionRecordModel.Rssi_Tr_Date_PackedData;
                }
                Logger.Trace("ENDED:  To Get Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Date;
        }
        private string GetAmount(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount");

                if (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
                {
                    Amount = accountsModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData;
                }
                else if (accountsModel.FeeRecordModel.Rssi_Fd_Fee_Type == "000")
                {
                    Amount = accountsModel.FeeRecordModel.Rssi_Fd_Assess_Amt;
                }
                else
                {
                    Amount = accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData;
                }
                Logger.Trace("ENDED:  To Get Amount");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Amount;
        }
        private string GetBuydownBalance(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Buy down Balance");

                if (Convert.ToInt64(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                {
                    BuydownBalance = "N/A";
                }
                else
                {
                    BuydownBalance = accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                }
                Logger.Trace("ENDED:  To Get Buy down Balance");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return BuydownBalance;
        }
        private string GetPartialClaim(AccountsModel accountsModel)
        {

            try
            {

                Logger.Trace("STARTED:  Execute to Get Partial Claim");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    PartialClaim = "N/A";
                }
                else
                {
                    PartialClaim = accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;
                }
                Logger.Trace("ENDED:  To Get Partial Claim");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PartialClaim;
        }
        private string GetInterestRateUntil(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Rate Until");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000)
                {
                    InterestRateUntil = "(Until RSSI-RATE-CHG-DATE)";
                }
                else
                {
                    InterestRateUntil = "null";
                }
                Logger.Trace("ENDED:  To Get Interest Rate Until");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestRateUntil;
        }
        private string GetPrepaymentPenalty(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Prepayment Penalty");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                {
                    PrepaymentPenalty = "Yes";
                }
                else
                {
                    PrepaymentPenalty = "No";
                }
                Logger.Trace("ENDED:  To Get Prepayment Penalty");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrepaymentPenalty;
        }
        private string GetAccountHistoryInformationbox(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Account History Information box");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30
               && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 30)
                {
                    AccountHistoryInformationbox = "include the Delinquency Notice section";
                }
                else
                {
                    AccountHistoryInformationbox = "";
                }
                Logger.Trace("ENDED:  To Get Account History Information box");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AccountHistoryInformationbox;
        }
        private string GetRecentPayment6(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Recent Payment6");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_5 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_5;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)"; ;
                }
                Logger.Trace("ENDED:  To Get Recent Payment6");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RecentPayment6;
        }

        private string GetRecentPayment5(AccountsModel accountModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Recent Payment5");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                Logger.Trace("ENDED:  To Get Recent Payment5");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return RecentPayment5;
        }

        private string GetRecentPayment4(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Recent Payment4");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                Logger.Trace("ENDED:  To Get Recent Payment5");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return RecentPayment4;
        }

        private string GetRecentPayment3(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Recent Payment3");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";
                }
                Logger.Trace("ENDED:  To Get Recent Payment3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RecentPayment3;
        }

        private string GetRecentPayment2(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Recent Payment2");
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                Logger.Trace("ENDED:  To Get Recent Payment2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RecentPayment2;
        }

        private string GetRecentPayment1(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Recent Payment1");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                Logger.Trace("ENDED:  To Get Recent Payment1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RecentPayment1;
        }
        private string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Lender Placed Insurance Message");
                if ((Convert.ToInt64(accountsModel.EscrowRecordModel.Rssi_Esc_Type) == 20
                || Convert.ToInt64(accountsModel.EscrowRecordModel.Rssi_Esc_Type) == 21)
                && Convert.ToInt64(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 2450
                && (Convert.ToInt64(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 29000
                || Convert.ToInt64(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 29005
                || Convert.ToInt64(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 43000
                || Convert.ToInt64(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 43001))
                {
                    LenderPlacedInsuranceMessage = "Lender Placed Insurance message";
                }
                Logger.Trace("ENDED:  To Get Lender Placed Insurance Message");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
            }
            return LenderPlacedInsuranceMessage;
        }
        private string GetStateNSF(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get State NSF");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6
                || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 16
                || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 18
                || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 42
                )
                {
                    StateNSF = "State NSF message";
                }
                Logger.Trace("ENDED:  To Get State NSF");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return StateNSF;
        }
        private string GetAutodraftMessage(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Autodraft Message");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0
                && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    AutodraftMessage = "Autodraft message";
                }
                Logger.Trace("STARTED:  To Get Autodraft Message");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AutodraftMessage;
        }
        private string GetCMSPartialClaim(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get CMS Partial Claim");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
               && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                {
                    CMSPartialClaim = "CMS Partial Claim Message.";
                }
                Logger.Trace("ENDED:  To Get CMS Partial Claim");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return CMSPartialClaim;
        }
        private string GetHUDPartialClaim(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get HUD Partial Claim");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
            && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                {
                    HUDPartialClaim = "HUD Partial Claim Message.";
                }
                Logger.Trace("ENDED:  To Get HUD Partial Claim");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return HUDPartialClaim;
        }
        private string GetStateDisclosures(AccountsModel accountsModel)
        {


            try
            {
                Logger.Trace("STARTED:  Execute to Get State Disclosures");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 4
               || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 6
               || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 12
               || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 22
               || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 24
               || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 33
               || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 34
               || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 38
               || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 43
               || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3) == 44
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "AR"
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "CO"
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "HI"
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "MA"
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "MN"
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NC"
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NY"
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OR"
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TN"
               || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                {
                    StateDisclosures = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                }
                Logger.Trace("ENDED:  To Get State Disclosures");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return StateDisclosures;
        }
        private string GetPaymentInformationMessage(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Payment Information Message");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS"
                || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA"
                || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM"
                || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                {
                    PaymentInformationMessage = "Dallas P.O.Box Address";
                }
                else
                {
                    PaymentInformationMessage = "Pasadena P.O.Box Address";
                }
                Logger.Trace("ENDED:  To Get Payment Information Message");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentInformationMessage;
        }
    }
}
