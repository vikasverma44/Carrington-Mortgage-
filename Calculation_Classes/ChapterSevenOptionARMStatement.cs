using Carrington_Service.Infrastructure;
using CarringtonMortgage.Models.InputCopyBookModels;
using System;
using System.Text;

namespace Carrington_Service.Calculation_Classes
{
    public class ChapterSevenOptionARMStatement
    {
        public string AmountDueOption1 { get; set; }
        public string AmountDueOption2 { get; set; }
        public string AmountDueOption3 { get; set; }
        public string AmountDueOption4 { get; set; }
        public string PrincipalOption1 { get; set; }
        public string AssistanceAmount { get; set; }
        public string ReplacementReserve { get; set; }
        public string OverduePaymentsOption1 { get; set; }
        public string TotalFeesChargedOption1 { get; set; }
        public string TotalFeesPaidOption1 { get; set; }
        public string TotalAmountDueOption1 { get; set; }
        public string PrincipalOption2 { get; set; }
        public string AssistanceAmountOption2 { get; set; }
        public string ReplacementReserveOption2 { get; set; }
        public string OverduePaymentsOption2 { get; set; }
        public string TotalFeesChargedOption2 { get; set; }

        public string TotalFeesPaidOption2 { get; set; }
        public string TotalAmountDueOption2 { get; set; }
        public string PrincipalOption3 { get; set; }
        public string AssistanceAmountOption3 { get; set; }
        public string ReplacementReserveOption3 { get; set; }
        public string OverduePaymentsOption3 { get; set; }
        public string TotalFeesChargedOption3 { get; set; }
        public string TotalFeesPaidOption3 { get; set; }
        public string TotalAmountDueOption3 { get; set; }
        public string PrincipalOption4 { get; set; }
        public string AssistanceAmountOption4 { get; set; }
        public string ReplacementReserveOption4 { get; set; }
        public string OverduePaymentsOption4 { get; set; }
        public string TotalFeesChargedOption4 { get; set; }
        public string TotalFeesPaidOption4 { get; set; }
        public string TotalAmountDueOption4 { get; set; }
        public string FeesandChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string FeesandChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string PaymentAmountOption1 { get; set; }
        public string PaymentAmountOption2 { get; set; }
        public string PaymentAmountOption3 { get; set; }
        public string PaymentAmountOption4 { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string DeferredBalance { get; set; }
        public string TotalDue { get; set; }


        public string FieldonStatement { get; set; }
        public string Hold { get; set; }
        public string PrimaryBorrowerBKAttorney { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingBKAttorneyAddressLine1 { get; set; }
        public string MailingBKAttorneyAddressLine2 { get; set; }
        public string BorrowerAttorneyMailingCityStateZip { get; set; }
        public string MailingCountry { get; set; }
        public string PaymentDate { get; set; }
        public string InterestOption1 { get; set; }
        public string EscrowOption1 { get; set; }
        public string RegularMonthlyPaymentOption1 { get; set; }
        public string InterestOption2 { get; set; }
        public string EscrowOption2 { get; set; }
        public string RegularMonthlyPaymentOption2 { get; set; }
        public string InterestOption3 { get; set; }
        public string EscrowOption3 { get; set; }
        public string RegularMonthlyPaymentOption3 { get; set; }
        public string InterestOption4 { get; set; }
        public string EscrowOption4 { get; set; }
        public string RegularMonthlyPaymentOption4 { get; set; }
        public string Option4MinimumDescription { get; set; }
        public string POBoxAddress { get; set; }
        //public string PaymentDate { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string AccountHistoryInformationbox { get; set; }
        public string RecentPayment6 { get; set; }
        public string RecentPayment5 { get; set; }
        public string RecentPayment4 { get; set; }
        public string RecentPayment3 { get; set; }
        public string RecentPayment2 { get; set; }
        public string RecentPayment1 { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string StateNSF { get; set; }
        public string AutodraftMessage { get; set; }
        public string CMSPartialClaim { get; set; }
        public string HUDPartialClaim { get; set; }
        public string StateDisclosures { get; set; }
        public string PaymentInformationMessage { get; set; }

        public string ExMessage { get; set; }

        public StringBuilder finalLine;

        public ILogger Logger;

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
        public string GetAmountDueOption1(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAmountDueOption1" + ExMessage);
            }
            return AmountDueOption1;
        }
        public string GetAmountDueOption2(AccountsModel accountsModel)
        {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAmountDueOption2" + ExMessage);
            }
            return AmountDueOption2;
        }
        public string GetAmountDueOption3(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAmountDueOption3" + ExMessage);
            }
            return AmountDueOption3;
        }
        public string GetAmountDueOption4(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAmountDueOption4" + ExMessage);
            }
            return AmountDueOption4;
        }


        public string GetPrincipalOption1(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrincipalOption1" + ExMessage);
            }
            return PrincipalOption1;
        }
        public string GetAssistanceAmount(AccountsModel accountsModel)
        {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAssistanceAmount" + ExMessage);
            }
            return AssistanceAmount;
        }
        public string GetReplacementReserve(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetReplacementReserve" + ExMessage);
            }
            return ReplacementReserve;
        }
        public string GetOverduePaymentsOption1(AccountsModel accountsModel)
        {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetOverduePaymentsOption1" + ExMessage);
            }
            return OverduePaymentsOption1;
        }
        public string GetTotalFeesChargedOption1(AccountsModel accountsModel)//Issue
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalFeesChargedOption1" + ExMessage);
            }
            return TotalFeesChargedOption1;
        }
        public string GetTotalFeesPaidOption1(AccountsModel accountsModel)// Issue
        {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalFeesPaidOption1" + ExMessage);
            }
            return TotalFeesPaidOption1;
        }
        public string GetTotalAmountDueOption1(AccountsModel accountsModel)
        {
            try
            {
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

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalAmountDueOption1" + ExMessage);
            }
            return TotalAmountDueOption1;
        }


        public string GetPrincipalOption2(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrincipalOption2" + ExMessage);
            }
            return PrincipalOption2;
        }
        public string GetAssistanceAmountOption2(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAssistanceAmountOption2" + ExMessage);
            }
            return AssistanceAmountOption2;
        }
        public string GetReplacementReserveOption2(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetReplacementReserveOption2" + ExMessage);
            }
            return ReplacementReserveOption2;
        }
        public string GetOverduePaymentsOption2(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetOverduePaymentsOption2" + ExMessage);
            }
            return OverduePaymentsOption2;
        }
        public string GetTotalFeesChargedOption2(AccountsModel accountsModel)
        {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalFeesChargedOption2" + ExMessage);
            }
            return TotalFeesChargedOption2;
        }
        public string GetTotalFeesPaidOption2(AccountsModel accountsModel)
        {
  
            try
            {
                // need to check
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalFeesPaidOption2" + ExMessage);
            }
            return TotalFeesPaidOption2;
        }
        public string GetTotalAmountDueOption2(AccountsModel accountsModel)
        {
            try
            {
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

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalAmountDueOption2" + ExMessage);
            }
            return TotalAmountDueOption2;
        }


        public string GetPrincipalOption3(AccountsModel accountsModel)
        {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrincipalOption3" + ExMessage);
            }
            return PrincipalOption3;
        }
        public string GetAssistanceAmountOption3(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAssistanceAmountOption3" + ExMessage);
            }
            return AssistanceAmountOption3;
        }
        public string GetReplacementReserveOption3(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetReplacementReserveOption3" + ExMessage);
            }
            return ReplacementReserveOption3;
        }
        public string GetOverduePaymentsOption3(AccountsModel accountsModel)
        {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetOverduePaymentsOption3" + ExMessage);
            }
            return OverduePaymentsOption3;
        }
        public string GetTotalFeesChargedOption3(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalFeesChargedOption3" + ExMessage);
            }
            return TotalFeesChargedOption3;
        }
        public string GetTotalFeesPaidOption3(AccountsModel accountsModel)
        {
       
            try
            {
                // need to check
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalFeesPaidOption3" + ExMessage);
            }
            return TotalFeesPaidOption3;
        }
        public string GetTotalAmountDueOption3(AccountsModel accountsModel)
        {
            try
            {
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

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalAmountDueOption3" + ExMessage);
            }
            return TotalAmountDueOption3;
        }


        public string GetPrincipalOption4(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrincipalOption4" + ExMessage);
            }
            return PrincipalOption4;
        }
        public string GetAssistanceAmountOption4(AccountsModel accountsModel)
        {
            try
            {

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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAssistanceAmountOption4" + ExMessage);
            }
            return AssistanceAmountOption4;
        }
        public string GetReplacementReserveOption4(AccountsModel accountsModel)
        {
            
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetReplacementReserveOption4" + ExMessage);
            }
            return ReplacementReserveOption4;
        }
        public string GetOverduePaymentsOption4(AccountsModel accountsModel)
        {
            
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption4 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption4 = "0.00";
                else
                {
                    OverduePaymentsOption4 = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToInt64(GetTotalFeesPaidOption4(accountsModel)));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetOverduePaymentsOption4" + ExMessage);
            }
            return OverduePaymentsOption4;
        }
        public string GetTotalFeesChargedOption4(AccountsModel accountsModel)// issue
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalFeesChargedOption4" + ExMessage);
            }
            return TotalFeesChargedOption4;
        }
        public string GetTotalFeesPaidOption4(AccountsModel accountsModel)
        {
            // need to check
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalFeesPaidOption4" + ExMessage);
            }
            return TotalFeesPaidOption4;
        }
        public string GetTotalAmountDueOption4(AccountsModel accountsModel)
        {
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption4 = "0.00";

                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption4 = "N/A";


                else
                    TotalAmountDueOption4 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalAmountDueOption4" + ExMessage);
            }
            return TotalAmountDueOption4;
        }


        public string GetFeesandChargesPaidLastMonth(AccountsModel accountsModel)//Issue
        {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetFeesandChargesPaidLastMonth" + ExMessage);
            }
            return FeesandChargesPaidLastMonth;
        }
        public string GeUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {
            
            try
            {
                UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetUnappliedFundsPaidLastMonth" + ExMessage);
            }
            return UnappliedFundsPaidLastMonth;
        }
        public string GetFeesandChargesPaidYeartoDate(AccountsModel accountsModel)//Issue
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetFeesandChargesPaidYeartoDate" + ExMessage);
            }
            return FeesandChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel)//Issue
        {
                        try
            {
                UnappliedFundsPaidYearToDate = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd) : 0
          + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
          + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
          + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
          + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetUnappliedFundsPaidYearToDate" + ExMessage);
            }
            return UnappliedFundsPaidYearToDate;

        }
        public string GetPaymentAmountOption1(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPaymentAmountOption1" + ExMessage);
            }
            return PaymentAmountOption1;
        }
        public string GetPaymentAmountOption2(AccountsModel accountsModel)
        {
          
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPaymentAmountOption2" + ExMessage);
            }
            return PaymentAmountOption2;
        }
        public string GetPaymentAmountOption3(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPaymentAmountOption3" + ExMessage);
            }
            return PaymentAmountOption3;
        }
        public string GetPaymentAmountOption4(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPaymentAmountOption4" + ExMessage);
            }
            return PaymentAmountOption4;
        }
        public string GetSuspense(AccountsModel accountsModel)
        {
            
            try
            {
                Suspense = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetSuspense" + ExMessage);
            }
            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountsModel)
        { 
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMiscellaneous" + ExMessage);
            }
            return Miscellaneous;
        }
        public string GetDeferredBalance(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetDeferredBalance" + ExMessage);
            }
            return DeferredBalance;
        }
        public string GetTotalDue(AccountsModel accountsModel)
        {
            
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalDue = "0";
                }
                else
                {
                    TotalDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalDue" + ExMessage);
            }
            return TotalDue;
        }
        public string GetHold(AccountsModel accountsModel)
        {
            
            try
            {
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    Hold = "create image but do not mail";
                }
                else
                {
                    Hold = accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetHold" + ExMessage);
            }
            return Hold;
        }
        public string GetPrimaryBorrowerBKAttorney(AccountsModel accountsModel)
        {

            

            //If RSSI-POC - STATEMENT - FLAG = Y, then copy 1 to RSSI-PRIMARY - NAME and copy 2 to
            //RSSI - VEND - NAME1"
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrimaryBorrowerBKAttorney" + ExMessage);
            }
            return PrimaryBorrowerBKAttorney;
        }
        public string GetSecondaryBorrower(AccountsModel accountsModel)
        {
            if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                || accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
            {
                SecondaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
            }
            return SecondaryBorrower;
        }
        public string GetMailingBKAttorneyAddressLine1(AccountsModel accountsModel)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingBKAttorneyAddressLine1" + ExMessage);
            }
            return MailingBKAttorneyAddressLine1;
        }
        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountsModel)
        { 
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingBKAttorneyAddressLine2" + ExMessage);
            }
            return MailingBKAttorneyAddressLine2;
        }
        public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetBorrowerAttorneyMailingCityStateZip" + ExMessage);
            }
            return BorrowerAttorneyMailingCityStateZip;
        }
        public string GetMailingCountry(AccountsModel accountsModel)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingCountry" + ExMessage);
            }
            return MailingCountry;
        }
        public string GetPaymentDate(AccountsModel accountsModel) {
            try
            {
                PaymentDate = accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPaymentDate" + ExMessage);
            }
            return PaymentDate; 
        }
        public string GetInterestOption1(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetInterestOption1" + ExMessage);
            }
            return InterestOption1;
        }
        public string GetEscrowOption1(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetEscrowOption1" + ExMessage);
            }
            return EscrowOption1;
         }
        public string GetRegularMonthlyPaymentOption1(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRegularMonthlyPaymentOption1" + ExMessage);
            }
            return RegularMonthlyPaymentOption1;
        }


        public string GetInterestOption2(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetInterestOption2" + ExMessage);
            }
            return InterestOption2;
        }
        public string GetEscrowOption2(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetEscrowOption2" + ExMessage);
            }
            return EscrowOption2;
        }
        public string GetRegularMonthlyPaymentOption2(AccountsModel accountsModel) {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRegularMonthlyPaymentOption2" + ExMessage);
            }
            return RegularMonthlyPaymentOption2;
        }

        public string GetInterestOption3(AccountsModel accountsModel) {
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetInterestOption3" + ExMessage);
            }
            return InterestOption3;

        }
        public string GetEscrowOption3(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetEscrowOption3" + ExMessage);
            }
            return EscrowOption3;
        }
        public string GetRegularMonthlyPaymentOption3(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRegularMonthlyPaymentOption3" + ExMessage);
            }
            return RegularMonthlyPaymentOption3;
        }

        public string GetInterestOption4(AccountsModel accountsModel) {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetInterestOption4" + ExMessage);
            }
            return InterestOption4;
        }
        public string GetEscrowOption4(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetEscrowOption4" + ExMessage);
            }
            return EscrowOption4;
        }
        public string GetRegularMonthlyPaymentOption4(AccountsModel accountsModel) {
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRegularMonthlyPaymentOption4" + ExMessage);
            }
            return RegularMonthlyPaymentOption4;
        }

        public string GetOption4MinimumDescription(AccountsModel accountsModel) {
            
           
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetOption4MinimumDescription" + ExMessage);
            }
            return Option4MinimumDescription;
        }
        public string GetPOBoxAddress(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPOBoxAddress" + ExMessage);
            }
            return POBoxAddress;
        }
        public string GetDate(AccountsModel accountsModel) {
            
           
            try
            {
                if (accountsModel.FeeRecordModel.Rssi_Fd_Fee_Type == "000")
                {
                    Date = accountsModel.FeeRecordModel.Rssi_Fd_Assess_Date;
                }
                else
                {
                    Date = accountsModel.TransactionRecordModel.Rssi_Tr_Date_PackedData;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetDate" + ExMessage);
            }
            return Date;
        }
        public string GetAmount(AccountsModel accountsModel)
        {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAmount" + ExMessage);
            }
            return Amount;
        }
        public string GetBuydownBalance(AccountsModel accountsModel) {
            
            try
            {
                if (Convert.ToInt64(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                {
                    BuydownBalance = "N/A";
                }
                else
                {
                    BuydownBalance = accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetBuydownBalance" + ExMessage);
            }
            return BuydownBalance;
        }
        public string GetPartialClaim(AccountsModel accountsModel) {
           
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    PartialClaim = "N/A";
                }
                else
                {
                    PartialClaim = accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPartialClaim" + ExMessage);
            }
            return PartialClaim;
        }
        public string GetInterestRateUntil(AccountsModel accountsModel) {
            
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000)
                {
                    InterestRateUntil = "(Until RSSI-RATE-CHG-DATE)";
                }
                else
                {
                    InterestRateUntil = "null";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetInterestRateUntil" + ExMessage);
            }
            return InterestRateUntil;
        }
        public string GetPrepaymentPenalty(AccountsModel accountsModel) {
            
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                {
                    PrepaymentPenalty = "Yes";
                }
                else
                {
                    PrepaymentPenalty = "No";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrepaymentPenalty" + ExMessage);
            }
            return PrepaymentPenalty;
        }
        public string GetAccountHistoryInformationbox(AccountsModel accountsModel) {
           
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30
               && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 30)
                {
                    AccountHistoryInformationbox = "include the Delinquency Notice section";
                }
                else
                {
                    AccountHistoryInformationbox = "";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAccountHistoryInformationbox" + ExMessage);
            }
            return AccountHistoryInformationbox;
        }
        public string GetRecentPayment6(AccountsModel accountModel)
        {
            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { RecentPayment6 = "RSSI-PMT-DUE-5-DATE: Fully paid on RSSI-PMT-PAID-5-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { RecentPayment6 = "RSSI - PMT - DUE - 4 - DATE: Fully paid on RSSI-PMT - PAID - 4 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { RecentPayment6 = "RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                { RecentPayment6 = "RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                { RecentPayment6 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { RecentPayment6 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRecentPayment6" + ExMessage);
            }
            return RecentPayment6;
        }

        public string GetRecentPayment5(AccountsModel accountModel)
        {

            try
            {

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { RecentPayment5 = "RSSI-PMT-DUE-4-DATE: Fully paid on RSSI-PMT-PAID-4-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { RecentPayment5 = "RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { RecentPayment5 = "RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                { RecentPayment5 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment5 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { RecentPayment5 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRecentPayment5" + ExMessage);
            }

            return RecentPayment5;
        }

        public string GetRecentPayment4(AccountsModel accountModel)
        {
            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { RecentPayment4 = "RSSI-PMT-DUE-3-DATE: Fully paid on RSSI-PMT-PAID-3-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { RecentPayment4 = "RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { RecentPayment4 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment4 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment4 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { RecentPayment4 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRecentPayment4" + ExMessage);
            }

            return RecentPayment4;
        }

        public string GetRecentPayment3(AccountsModel accountModel)
        {

            
            try
            {
               

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { RecentPayment3 = "RSSI-PMT-DUE-2-DATE: Fully paid on RSSI-PMT-PAID-2-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { RecentPayment3 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment3 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment3 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment3 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { RecentPayment3 = "RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRecentPayment3" + ExMessage);
            }
            return RecentPayment3;
        }

        public string GetRecentPayment2(AccountsModel accountModel)
        {
            try
            {

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { RecentPayment2 = "RSSI-PMT-DUE-1-DATE: Fully paid on RSSI-PMT-PAID-1-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment2 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment2 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment2 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment2 = "RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { RecentPayment2 = "RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRecentPayment2" + ExMessage);
            }
            return RecentPayment2;
        }

        public string GetRecentPayment1(AccountsModel accountModel)
        {
            try
            {

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment1 = "RSSI-PAST-DATE (1): Unpaid balance of $RSSI-REG-AMT (1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment1 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment1 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment1 = "RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { RecentPayment1 = "RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { RecentPayment1 = "RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRecentPayment1" + ExMessage);
            }
            return RecentPayment1;
        }
        public string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel) {
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetLenderPlacedInsuranceMessage" + ExMessage);
            }
            return LenderPlacedInsuranceMessage;
        }
        public string GetStateNSF(AccountsModel accountsModel) { 
            
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6
                || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 16
                || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 18
                || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 42
                )
                {
                    StateNSF = "State NSF message";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetStateNSF" + ExMessage);
            }
            return StateNSF;
        }
        public string GetAutodraftMessage(AccountsModel accountsModel) { 
            
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0
                && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    AutodraftMessage = "Autodraft message";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAutodraftMessage" + ExMessage);
            }
            return AutodraftMessage;
        }
        public string GetCMSPartialClaim(AccountsModel accountsModel) {
           
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
               && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                {
                    CMSPartialClaim = "CMS Partial Claim Message.";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetCMSPartialClaim" + ExMessage);
            }
            return CMSPartialClaim;
        }
        public string GetHUDPartialClaim(AccountsModel accountsModel) {
           
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
            && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                {
                    HUDPartialClaim = "HUD Partial Claim Message.";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetHUDPartialClaim" + ExMessage);
            }
            return HUDPartialClaim;
        }
        public string GetStateDisclosures(AccountsModel accountsModel) {

               
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetStateDisclosures" + ExMessage);
            }
            return StateDisclosures;
        }
        public string GetPaymentInformationMessage(AccountsModel accountsModel) {
            
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPaymentInformationMessage" + ExMessage);
            }
            return PaymentInformationMessage;
        }
    }
}
