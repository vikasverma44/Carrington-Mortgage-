using Carrington_Service.Infrastructure;
using CarringtonMortgage.Helpers;
using CarringtonMortgage.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.Calculation_Classes
{
    public class OptionARMBillingStatement : IOptionARMBillingStatement
    {
        public OptionARMBillingStatement(ILogger logger)
        {
            Logger = logger;
        }
        #region Object Declaration  ==>
        public ILogger Logger;
        public string ExMessage { get; set; }

        public StringBuilder finalLine;

        #endregion

        #region public Property ==>
        public string AmountDueOption1 { get; set; }
        public string AmountDueOption2 { get; set; }
        public string AmountDueOption3 { get; set; }
        public string AmountDueOption4 { get; set; }
        public string PastDueBalance { get; set; }
        public string DeferredBalance { get; set; }
        public string UnappliedFunds { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string FeesandChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
        public string PrincipalOption1 { get; set; }
        public string AssistanceAmountOption1 { get; set; }
        public string ReplacementReserveOption1 { get; set; }
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
        public string MinimumLatePaymentAmount { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string TotalDue { get; set; }

        public string Hold { get; set; }
        public string MailingCountry { get; set; }
        public string PaymentIsReceivedAfter { get; set; }
        public string LateFee { get; set; }
        public string ChargeOffNoticeNoticeMessage { get; set; }
        public string NegativeAmortization { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }

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
        public string DueDate { get; set; }
        public string IfReceivedAfterDate { get; set; }
        public string LateChargeAmount { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string ModificationDate { get; set; }
        public string MaturityDate { get; set; }
        public string DelinquencyNoticebox { get; set; }
        public string LossMitigtationNotice { get; set; }
        public string ForeclosureNotice { get; set; }
        public string ACHMessage { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string BankruptcyMessage { get; set; }
        public string RepaymentPlanMessage { get; set; }
        public string StateNSFMessage { get; set; }
        public string ChargeOffNotice { get; set; }
        public string CMSPartialClaim { get; set; }
        public string HUDPartialClaim { get; set; }
        public string StateDisclosures { get; set; }
        public string PaymentInformationMessage { get; set; }

        public string RecentPayment6 { get; set; }
        public string RecentPayment5 { get; set; }
        public string RecentPayment4 { get; set; }
        public string RecentPayment3 { get; set; }
        public string RecentPayment2 { get; set; }
        public string RecentPayment1 { get; set; }

        #endregion
        int co = 0;
        public StringBuilder GetFinalOptionARMBillingStatement(AccountsModel accountsModel)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();
  
            finalLine.Append(GetTotalFeesChargedOption1(accountsModel) + "|");
            finalLine.Append(GetDeferredBalance(accountsModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption4(accountsModel) + "|");
            finalLine.Append(GetAmountDueOption1(accountsModel) + "|");
            finalLine.Append(GetAmountDueOption2(accountsModel) + "|");
            finalLine.Append(GetAmountDueOption3(accountsModel) + "|");
            finalLine.Append(GetAmountDueOption4(accountsModel) + "|");
            finalLine.Append(GetPrincipalOption1(accountsModel) + "|");
            finalLine.Append(GetOverduePaymentsOption1(accountsModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption1(accountsModel) + "|");
            finalLine.Append(GetTotalAmountDueOption1(accountsModel) + "|");
            finalLine.Append(GetPrincipalOption2(accountsModel) + "|");
            finalLine.Append(GetAssistanceAmountOption2(accountsModel) + "|");
            finalLine.Append(GetReplacementReserveOption2(accountsModel) + "|");
            finalLine.Append(GetOverduePaymentsOption2(accountsModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption2(accountsModel) + "|");
            finalLine.Append(GetTotalAmountDueOption2(accountsModel) + "|");
            finalLine.Append(GetPrincipalOption3(accountsModel) + "|");
            finalLine.Append(GetAssistanceAmountOption3(accountsModel) + "|");
            finalLine.Append(GetReplacementReserveOption3(accountsModel) + "|");
            finalLine.Append(GetOverduePaymentsOption3(accountsModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption3(accountsModel) + "|");
            finalLine.Append(GetTotalAmountDueOption3(accountsModel) + "|");
            finalLine.Append(GetPrincipalOption4(accountsModel) + "|");
            finalLine.Append(GetAssistanceAmountOption4(accountsModel) + "|");
            finalLine.Append(GetReplacementReserveOption4(accountsModel) + "|");
            finalLine.Append(GetOverduePaymentsOption4(accountsModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption4(accountsModel) + "|");
            finalLine.Append(GetTotalAmountDueOption4(accountsModel) + "|");
            finalLine.Append(GeUnappliedFundsPaidLastMonth(accountsModel) + "|");
            finalLine.Append(GetFeesandChargesPaidYeartoDate(accountsModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountsModel) + "|");
            finalLine.Append(GeSuspense(accountsModel) + "|");
            finalLine.Append(GetMiscellaneous(accountsModel) + "|");
            finalLine.Append(GetTotalDue(accountsModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidLastMonth(accountsModel) + "|");
            finalLine.Append(GetUnappliedFunds(accountsModel) + "|");
            finalLine.Append(GetPastDueBalance(accountsModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountsModel) + "|");
            finalLine.Append(GetAssistanceAmountOption1(accountsModel) + "|");
            finalLine.Append(GetReplacementReserveOption1(accountsModel) + "|");
            finalLine.Append(GetMinimumLatePaymentAmount(accountsModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption3(accountsModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption2(accountsModel) + "|");
            finalLine.Append(GetHold(accountsModel) + "|");
            finalLine.Append(GetAttention(accountsModel) + "|");
            finalLine.Append(GetPrimaryBorrower(accountsModel) + "|");
            finalLine.Append(GetSecondaryBorrower(accountsModel) + "|");
            finalLine.Append(GetMailingAddressLine1(accountsModel) + "|");
            finalLine.Append(GetMailingAddressLine2(accountsModel) + "|");
            finalLine.Append(GetMailingCityStateZip(accountsModel) + "|");
            finalLine.Append(GetMailingCountry(accountsModel) + "|");
            finalLine.Append(GetPaymentIsReceivedAfter(accountsModel) + "|");
            finalLine.Append(GetLateFee(accountsModel) + "|");
            finalLine.Append(GetChargeOffNoticeNoticeMessage(accountsModel) + "|");
            finalLine.Append(GetNegativeAmortization(accountsModel) + "|");
            finalLine.Append(GetBuydownBalance(accountsModel) + "|");
            finalLine.Append(GetPartialClaim(accountsModel) + "|");
            finalLine.Append(GetInterestOption1(accountsModel) + "|");
            finalLine.Append(GetEscrowOption1(accountsModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption1(accountsModel) + "|");
            finalLine.Append(GetInterestOption2(accountsModel) + "|");
            finalLine.Append(GetEscrowOption2(accountsModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption2(accountsModel) + "|");
            finalLine.Append(GetInterestOption3(accountsModel) + "|");
            finalLine.Append(GetEscrowOption3(accountsModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption3(accountsModel) + "|");
            finalLine.Append(GetInterestOption4(accountsModel) + "|");
            finalLine.Append(GetEscrowOption4(accountsModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption4(accountsModel) + "|");
            finalLine.Append(GetOption4MinimumDescription(accountsModel) + "|");
            finalLine.Append(GetPOBoxAddress(accountsModel) + "|");
            finalLine.Append(GetReceivedAfterDate(accountsModel) + "|");
            finalLine.Append(GetLateChargeAmount(accountsModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountsModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountsModel) + "|");
            finalLine.Append(GetModificationDate(accountsModel) + "|");
            finalLine.Append(GetMaturityDate(accountsModel) + "|");
            finalLine.Append(GetDelinquencyNoticebox(accountsModel) + "|");
            finalLine.Append(GetLossMitigtationNotice(accountsModel) + "|");
            finalLine.Append(GetForeclosureNotice(accountsModel) + "|");
            finalLine.Append(GetACHMessage(accountsModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountsModel) + "|");
            finalLine.Append(GetBankruptcyMessage(accountsModel) + "|");
            finalLine.Append(GetRepaymentPlanMessage(accountsModel) + "|");
            finalLine.Append(GetStateNSFMessage(accountsModel) + "|");
            finalLine.Append(GetChargeOffNotice(accountsModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountsModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountsModel) + "|");
            finalLine.Append(GetStateDisclosures(accountsModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountsModel) + "|");
            finalLine.Append(GetRecentPayment6(accountsModel) + "|");
            finalLine.Append(GetRecentPayment5(accountsModel) + "|");
            finalLine.Append(GetRecentPayment4(accountsModel) + "|");
            finalLine.Append(GetRecentPayment3(accountsModel) + "|");
            finalLine.Append(GetRecentPayment2(accountsModel) + "|");
            finalLine.Append(GetRecentPayment1(accountsModel) + "|");
            return finalLine;
        }


        /* While Calculating Conditions must be applied*/

        #region Old Code ==>>
        public string GetTotalFeesChargedOption1(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to get Total Fees Charged Option1 operation.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption1 = "null";
                }
                else
                {
                    var Total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    if (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                        && (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67))
                    {
                        TotalFeesChargedOption1 = Convert.ToString(Total - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else if ((Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                         || Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                         && (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                    {
                        TotalFeesChargedOption1 = Convert.ToString(Total - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else
                    {
                        TotalFeesChargedOption1 = Convert.ToString(Total);
                    }
                }
                Logger.Trace("ENDED:    Total Fees Charged Option1 operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesChargedOption1"+ ex.TargetSite.Name);
                 return "";
            }
            return TotalFeesChargedOption1;
        }
        public string GetDeferredBalance(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to get Deferred Balance operation.");
                if (model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal != "\0\0\0\0\0.\0\f" && model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal != "\0\0\0\u0090¶.\u009d\f" 
                    && model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal=="\0\0\0¿o.Ê\f" && model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal.Trim() == ""
                    && Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    if (model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal != "\0\0\0\0\0.\0\f" && model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal != "\0\0\0\u0090¶.\u009d\f"
                        && model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal == "\0\0\0¿o.Ê\f" &&  model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal.Trim()=="")
                    {
                        DeferredBalance = model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal == "\0\0\0\0\0.\0\f" ? "0" : Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                            Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                    }
                    else { DeferredBalance = "0"; }
                }
                Logger.Trace("ENDED:    To Deferred Balance operation.");
                return DeferredBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetDeferredBalance"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetTotalFeesChargedOption4(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to get Total Fees Charged Option4 operation.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData!=null && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption4 = "0";
                }
                else if (accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData != null &&  Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption4 = "0";
                }
                else
                {
                    var Total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    if (accountsModel.TransactionRecordModel.Rssi_Log_Tran != null && accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc!=null &&
                        accountsModel.TransactionRecordModel.Rssi_Log_Tran == "5605"
                        && (accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc == "67"))
                    {
                        TotalFeesChargedOption4 = Convert.ToString(Total - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else if (accountsModel.TransactionRecordModel.Rssi_Log_Tran != null && accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc != null && 
                        (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                         || accountsModel.TransactionRecordModel.Rssi_Log_Tran == "5707")
                         && (accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc == "198"))
                    {
                        TotalFeesChargedOption4 = Convert.ToString(Total - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else
                    {
                        TotalFeesChargedOption4 = Convert.ToString(Total);
                    }
                }
                Logger.Trace("ENDED:   Total Fees Charged Option4 operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesChargedOption4 " + ex.TargetSite.Name);
                 return "";
            }
            return TotalFeesChargedOption4;
        }
        public string GetAmountDueOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option 1 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption1 = "0.00";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    AmountDueOption1 = "N/A";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption1 = "N/A";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption1 = "N/A";
                }
                else
                {
                    AmountDueOption1 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
                }
                Logger.Trace("ENDED:   To Amount Due Option 1 operation.");
                return AmountDueOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAmountDueOption1"+ ex.TargetSite.Name);
                 return "";
            }

        }
        public string GetAmountDueOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option 2 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption2 = "0.00";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else
                {
                    AmountDueOption2 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));
                }
                Logger.Trace("ENDED:   To Amount Due Option 2 operation.");
                return AmountDueOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAmountDueOption2"+ ex.TargetSite.Name);
                 return "";
            }

        }
        public string GetAmountDueOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option 3 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption3 = "0";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else
                {
                    AmountDueOption3 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                Logger.Trace("ENDED:   To Amount Due Option 3 operation.");
                return AmountDueOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAmountDueOption3"+ ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetAmountDueOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option 4 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption4 = "0";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption4 = "N/A";
                }
                else
                {
                    AmountDueOption4 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }

                Logger.Trace("ENDED:   To Amount Due Option 4 operation.");
                return AmountDueOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAmountDueOption4"+ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetPrincipalOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option 1 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PrincipalOption1 = "0.00";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    PrincipalOption1 = null;
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    PrincipalOption1 = null;
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PrincipalOption1 = null;
                }
                else
                {
                    PrincipalOption1 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData) -
                                            Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }

                Logger.Trace("ENDED:   To Principal Option 1 operation.");
                return PrincipalOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipalOption1" +ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetOverduePaymentsOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 1 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption1 = "null";

                else
                {
                    //not found total fees paid
                    OverduePaymentsOption1 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
                }
                Logger.Trace("ENDED:   To Overdue Payments Option 1 operation.");
                return OverduePaymentsOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOverduePaymentsOption1"+ ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetTotalFeesPaidOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 1 operation.");
                // need to check
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";


                else if ((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption1 = Convert.ToString((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
                }
                else
                    TotalFeesPaidOption1 = "0.00";
                Logger.Trace("ENDED:   Total Fees Paid Option 1 operation.");
                return TotalFeesPaidOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaidOption1"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetTotalAmountDueOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total AmountDue Option 1 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "N/A";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "N/A";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "N/A";

                else
                    TotalAmountDueOption1 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                   + Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));

                Logger.Trace("ENDED:   Get Total AmountDue Option 1 operation.");
                return TotalAmountDueOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalAmountDueOption1"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetPrincipalOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option2 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    PrincipalOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption2 = "null";
                else
                {
                    PrincipalOption2 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:   Get Principal Option2 operation.");
                return PrincipalOption2;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipalOption2"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetAssistanceAmountOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option 2 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "do not print the Assistance Amount line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption2 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "null";

                else
                {
                    AssistanceAmountOption2 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1);
                }
                Logger.Trace("ENDED:   Get Assistance Amount Option 2 operation.");
                return AssistanceAmountOption2;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAssistanceAmountOption2"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetReplacementReserveOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option2 operation.");

                if ((Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                   - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                    - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                   + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption2 = "do not print the Replacement Reserve line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else
                {
                    ReplacementReserveOption2 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                                - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                                - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
                }

                Logger.Trace("ENDED:   Get Replacement Reserve Option2 operation.");
                return ReplacementReserveOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReplacementReserveOption2"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetOverduePaymentsOption2(AccountsModel model)
        {
            //what is - Total Fees Paid
            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 2 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption2 = "null";


                else
                {
                    OverduePaymentsOption2 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
                }
                Logger.Trace("ENDED:   Get Overdue Payments Option 2 operation.");
                return OverduePaymentsOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOverduePaymentsOption2"+ ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetTotalFeesPaidOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 2 operation.");

                // need to check
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if ((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption2 = Convert.ToString((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
                }
                else
                    TotalFeesPaidOption2 = "0.00";
                Logger.Trace("ENDED:   Get Total Fees Paid Option 2 operation.");
                return TotalFeesPaidOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaidOption2"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetTotalAmountDueOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option 2 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalAmountDueOption2 = "N/A";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption2 = "N/A";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption2 = "N/A";

                else
                    TotalAmountDueOption2 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                   + Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));
                Logger.Trace("ENDED:   Get Total Amount Due Option 2 operation.");
                return TotalAmountDueOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalAmountDueOption2"+ ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetPrincipalOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option 3 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption3 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    PrincipalOption3 = "N/A";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption3 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption3 = "null";

                else
                {
                    PrincipalOption3 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:   Get Principal Option 3 operation.");
                return PrincipalOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipalOption3"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetAssistanceAmountOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option 3 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption3 = "then do not print the Assistance Amount line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AssistanceAmountOption3 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption3 = "0.00";
                }
                else
                {
                    AssistanceAmountOption3 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
                }
                Logger.Trace("ENDED:   Get Assistance Amount Option 3 operation.");
                return AssistanceAmountOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAssistanceAmountOption3" +ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetReplacementReserveOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option 3 operation.");

                if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) -
                    Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData) -
                    Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                    Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption3 = "then do not print the Replacement Reserve line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    ReplacementReserveOption3 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption3 = "0.00";
                }
                else
                {
                    ReplacementReserveOption3 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) -
                                             Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData) -
                                              Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                                             Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
                }
                Logger.Trace("ENDED:   Get Replacement Reserve Option 3 operation.");
                return ReplacementReserveOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReplacementReserveOption3"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetOverduePaymentsOption3(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 3 operation.");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption2 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption2 = "null";
                else
                {
                    OverduePaymentsOption2 = Convert.ToString(Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToDecimal(GetTotalFeesPaidOption3(accountsModel)));
                }

                Logger.Trace("ENDED:   Get Replacement Overdue Payments Option 3 operation.");
                return OverduePaymentsOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOverduePaymentsOption3"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetTotalFeesPaidOption3(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 3 operation.");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption3 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";

                else if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption3 = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
                }
                else
                    TotalFeesPaidOption3 = "0.00";

                Logger.Trace("ENDED:   Get Total Fees Paid Option 3 operation.");
                return TotalFeesPaidOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaidOption3"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetTotalAmountDueOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option 3 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalAmountDueOption3 = "0.00";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    TotalAmountDueOption3 = "Option Not Available";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalAmountDueOption3 = "Option Not Available";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalAmountDueOption3 = "Option Not Available";
                }
                else
                {
                    TotalAmountDueOption3 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                Logger.Trace("ENDED:   Get Total Amount Due Option 3 operation.");
                return TotalAmountDueOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalAmountDueOption3"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetPrincipalOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option 4 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PrincipalOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                {
                    PrincipalOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PrincipalOption4 = "0.00";
                }
                else
                {
                    PrincipalOption4 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData) - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:   Get Principal Option 4 operation.");
                return PrincipalOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipalOption4"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetAssistanceAmountOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option 4 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption4 = "then do not print the Assistance Amount line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AssistanceAmountOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption4 = "0.00";
                }
                else
                {
                    AssistanceAmountOption4 = Convert.ToString(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData);
                }
                Logger.Trace("ENDED:   Get Assistance Amount Option 4 operation.");
                return AssistanceAmountOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAssistanceAmountOption4"+ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetReplacementReserveOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement ReserveOption 4 operation.");

                if (model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData != null &&
                    model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData != null && Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData) -
                    Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData) -
                    Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                    Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    return "then do not print the Replacement Reserve line.";
                }
                else if (model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData != null && Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    return "0.00";
                }
                else if (model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData != null && Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    return "0.00";
                }
                Logger.Trace("ENDED:   Get Replacement ReserveOption 4 operation.");
                return ReplacementReserveOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReplacementReserveOption4"+ ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetOverduePaymentsOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 4 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    OverduePaymentsOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    OverduePaymentsOption4 = "0.00";
                }
                else
                {
                    string calvalue = (GetTotalFeesPaidOption3(model));// == null ? 0 : Convert.ToDecimal(GetTotalFeesPaidOption3(model))).ToString();
                    string calvalue1 = calvalue == "null" ? "0" : calvalue;

                    OverduePaymentsOption4 =
                    Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                        Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
                        Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData) - Convert.ToDecimal(calvalue1));

                    //(GetTotalFeesPaidOption3(model)==null ? 0:  Convert.ToDecimal(GetTotalFeesPaidOption3(model))) );
                }
                Logger.Trace("ENDED:   Get Overdue Payments Option 4 operation.");
                return OverduePaymentsOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOverduePaymentsOption4"+ ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetTotalFeesPaidOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 4 operation.");

                var TotalFeeCharged = Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesPaidOption4 = "0";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesPaidOption4 = "0";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                    < Convert.ToDecimal(TotalFeeCharged))
                {
                    TotalFeesPaidOption4 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                   + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                   - Convert.ToDecimal(GetTotalFeesChargedOption4(model)));
                }
                else
                {
                    TotalFeesPaidOption4 = "0";
                }
                Logger.Trace("ENDED:   Get Total Fees Paid Option 4  operation.");
                return TotalFeesPaidOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaidOption4"+ex.TargetSite.Name);
                return "";
            }
        }
        public string GetTotalAmountDueOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total AmountDue Option4 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalAmountDueOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalAmountDueOption4 = "0.00";
                }
                else
                {
                    TotalAmountDueOption4 = model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData != null ? Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)) : "0";
                }
                Logger.Trace("ENDED:   Get  Total AmountDue Option4   operation.");
                return TotalAmountDueOption4;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalAmountDueOption4"+ ex.TargetSite.Name);
                 return "";
            }
        }

        public string GeUnappliedFundsPaidLastMonth(AccountsModel model)
        {
            try
            {

                return "";

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GeUnappliedFundsPaidLastMonth" + ex.TargetSite.Name);
                 return "";
            }

        }

        public string GetFeesandChargesPaidYeartoDate(AccountsModel model)
        {
            try
            {
                return Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) +
                                           Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetFeesandChargesPaidYeartoDate" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
                return UnappliedFundsPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetUnappliedFundsPaidYearToDate" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GeSuspense(AccountsModel model)
        {
            try
            {
                if (model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2!=null && model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3!=null
                    && model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04!=null &&  model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05!=null)
                    {                 return Convert.ToString(Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) +
                         Convert.ToDecimal((model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2.Replace("{","")).Replace("}","").Replace("P", "")) +
                         Convert.ToDecimal((model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3.Replace("{", "")).Replace("}", "").Replace("P", "")) +
                         Convert.ToDecimal((model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04.Replace("{", "")).Replace("}", "").Replace("P", "")) +
                         Convert.ToDecimal((model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05.Replace("{", "")).Replace("}", "").Replace("P", "")));
                    }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GeSuspense" + ex.TargetSite.Name);
                 return "";
            }
            return "";
        }

        public string GetMiscellaneous(AccountsModel model)
        {
            try
            {
                if(model.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData!=null && model.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData != null &&
                    model.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg != null && model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData != null &&
                    model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData != null && model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData != null &&
                    model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData != null && model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData != null &&
                    model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData != null && model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData != null && 
                    model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData != null)
                return Convert.ToString(Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData) +
                      Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData) +
                      Convert.ToDecimal((model.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg.Replace("{", "")).Replace("}", "")) +
                      Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData) +
                      Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData) +
                      Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData) +
                      Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData) +
                      Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData) +
                      Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData) +
                      Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData) +
                      Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMiscellaneous" + ex.TargetSite.Name);
                 return "";
            }
            return "";
        }
        public string GetTotalDue(AccountsModel model)
        {
            try
            {
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    return "0.00";

                return model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData != null ? Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)) : "0";
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalDue" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel model)
        {

            try
            {
                return Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                     Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalDue" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetUnappliedFunds(AccountsModel accountsModel)
        {
            try
            {
                UnappliedFunds = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
                return UnappliedFunds;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalDue" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetPastDueBalance(AccountsModel model)
        {
            try
            {
                return Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                     Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
                     Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPastDueBalance" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetTotalPaidYearToDate(AccountsModel accountsModel)
        {


            try
            {
                TotalPaidYearToDate = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
                                         + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
                                         + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                                         + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                                         + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                                         + accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                                         + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                                         + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                                         + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                                         + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));


                return TotalPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalPaidYearToDate" + ex.TargetSite.Name);
                 return "";
            }

        }
        public string GetAssistanceAmountOption1(AccountsModel model)
        {

            try
            {
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    return "then do not print the Assistance Amount line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    return "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    return "0.00";
                }
                else
                {
                    return Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAssistanceAmountOption1" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetReplacementReserveOption1(AccountsModel model)
        {
            try
            {

                if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) -
                    Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData) -
                     Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                    Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    return "then do not print the Replacement Reserve line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    return "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    return "0.00";
                }
                else
                {
                    return Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) -
                                             Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData) -
                                        Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                    Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReplacementReserveOption1" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetMinimumLatePaymentAmount(AccountsModel model)
        {
            try
            {
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    return "N/A";
                }
                else
                {
                    return model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData != null ? Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                    Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData) +
                    Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData)) : "0";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMinimumLatePaymentAmount" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetTotalFeesChargedOption3(AccountsModel accountsModel)
        {
            try
            {
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "0";
                }
                else if (accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData != null && Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption3 = "null";
                }
                else
                {
                    var Total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    if (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                        && (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67))
                    {
                        TotalFeesChargedOption3 = Convert.ToString(Total - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else if ((Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                         || Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                         && (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                    {
                        TotalFeesChargedOption3 = Convert.ToString(Total - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else
                    {
                        TotalFeesChargedOption3 = Convert.ToString(Total);
                    }
                }
                return TotalFeesChargedOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesChargedOption3" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetTotalFeesChargedOption2(AccountsModel accountsModel)
        {
            try
            {
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "0";
                }
                else if (accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData != null && Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption2 = "null";
                }
                else
                {
                    var Total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    if (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                        && (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67))
                    {
                        TotalFeesChargedOption2 = Convert.ToString(Total - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else if ((Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                         || Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                         && (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                    {
                        TotalFeesChargedOption2 = Convert.ToString(Total - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                    }
                    else
                    {
                        TotalFeesChargedOption2 = Convert.ToString(Total);
                    }
                }
                return TotalFeesChargedOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesChargedOption2" + ex.TargetSite.Name);
                 return "";
            }
        }

        #endregion

        #region New Methods ==>

        public string GetHold(AccountsModel accountModel)
        {
            try
            {
                if (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                    Hold = "Create image but do not mail.";
                return Hold;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetHold" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetAttention(AccountsModel accountsModel)
        {

            String attention = string.Empty;
            try
            {
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
                return attention;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAttention" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetPrimaryBorrower(AccountsModel accountsModel)
        {

            String primaryBorrower = string.Empty;

            try
            {
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR1-F"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR2-F"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR3-F"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR4-F"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR5-F"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR6-F"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR1-F"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR8-F"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR9-F"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR10-F"; }

                return primaryBorrower;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrimaryBorrower" + ex.TargetSite.Name);
                 return "";
            }
        }


        public string GetSecondaryBorrower(AccountsModel accountsModel)
        {

            String secondaryBorrower = string.Empty;

            try
            {
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
                return secondaryBorrower;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrimaryBorrower" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetMailingAddressLine1(AccountsModel accountsModel)
        {

            String mailingAddressLine1 = string.Empty;
            try
            {
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR01-ADRS1"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR02-ADRS1"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR03-ADRS1"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR04-ADRS1"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR05-ADRS1"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR06-ADRS1"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR07-ADRS1"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR08-ADRS1"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR09-ADRS1"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR10-ADRS1"; }
                return mailingAddressLine1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingAddressLine1" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetMailingAddressLine2(AccountsModel accountsModel)
        {

            String mailingAddressLine2 = string.Empty;
            try
            {
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR01 - ADRS2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR02-ADRS2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR03-ADRS2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR04-ADRS2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR05-ADRS2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR06-ADRS2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR07-ADRS2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR08-ADRS2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR09-ADRS2"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR10-ADRS2"; }
                return mailingAddressLine2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingAddressLine2" + ex.TargetSite.Name);
                 return "";
            }


        }

        public string GetMailingCityStateZip(AccountsModel accountsModel)
        {

            String mailingCityStateZip = string.Empty;

            try
            {
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { mailingCityStateZip = " RSSI-CB_CBWR1_CITY, RSSI-CB-CBWR1-STATE RSSI-CB-CBWR1-ZIP"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR2_CITY, RSSI-CB-CBWR2-STATE RSSI-CB-CBWR2-ZIP"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR3_CITY, RSSI-CB-CBWR3-STATE RSSI-CB-CBWR3-ZIP"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR4_CITY, RSSI-CB-CBWR4-STATE RSSI-CB-CBWR4-ZIP"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR5_CITY, RSSI-CB-CBWR5-STATE RSSI-CB-CBWR5-ZIP"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR6_CITY, RSSI-CB-CBWR6-STATE RSSI-CB-CBWR6-ZIP"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR7_CITY, RSSI-CB-CBWR7-STATE RSSI-CB-CBWR7-ZIP"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR8_CITY, RSSI-CB-CBWR8-STATE RSSI-CB-CBWR8-ZIP"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR9_CITY, RSSI-CB-CBWR9-STATE RSSI-CB-CBWR9-ZIP"; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR10-ITY, RSSI-CB-CBWR10-STATE RSSI-CB-CBWR10-ZIP"; }

                return mailingCityStateZip;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingCityStateZip" + ex.TargetSite.Name);
                 return "";
            }


        }

        public string GetMailingCountry(AccountsModel accountModel)
        {
            try
            {
                if (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                    MailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Altr_Cntry;
                else if (accountModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
                    MailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country;
                else if (accountModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
                    MailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Appl_Country;
                else
                    MailingCountry = null;
                return MailingCountry;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingCountry" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetPaymentIsReceivedAfter(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PaymentIsReceivedAfter = "suppress Late Charge message";

                return PaymentIsReceivedAfter;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPaymentIsReceivedAfter" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetLateFee(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    LateFee = "suppress Late Charge message";

                return LateFee;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetLateFee" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetChargeOffNoticeNoticeMessage(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
                    ChargeOffNoticeNoticeMessage = "Print he Charge Off Notice";
                else if ((Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30)
                        && (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0))
                    ChargeOffNoticeNoticeMessage = "print the Delinquency Notice";
                else if ((Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) < 30)
                        && (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0))
                    ChargeOffNoticeNoticeMessage = "print the Re-Finance Notice";
                return ChargeOffNoticeNoticeMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetChargeOffNoticeNoticeMessage" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetNegativeAmortization(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData) == 0)
                    NegativeAmortization = "N/A";
                else
                    NegativeAmortization = accountModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData;
                return NegativeAmortization;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetNegativeAmortization" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetBuydownBalance(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                    BuydownBalance = "N/A";
                else
                    BuydownBalance = accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;

                return BuydownBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetBuydownBalance" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetPartialClaim(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                    PartialClaim = "N/A";
                else
                    PartialClaim = accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;

                return PartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPartialClaim" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetInterestOption1(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    InterestOption1 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0
                    || Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                    || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                    )
                {
                    InterestOption1 = null;
                }
                return InterestOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestOption1" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetEscrowOption1(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowOption1 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0
                    || Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                    || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                    )
                {
                    EscrowOption1 = null;
                }
                return EscrowOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowOption1" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetRegularMonthlyPaymentOption1(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPaymentOption1 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0
                    || Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                    || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                    )
                {
                    RegularMonthlyPaymentOption1 = null;
                }
                return RegularMonthlyPaymentOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPaymentOption1" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetInterestOption2(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    InterestOption2 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0
                    || Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                    || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                    )
                {
                    InterestOption2 = null;
                }
                return InterestOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestOption2" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetEscrowOption2(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowOption2 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0
                    || Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                    || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                    )
                {
                    EscrowOption2 = null;
                }
                return EscrowOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowOption2" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetRegularMonthlyPaymentOption2(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPaymentOption2 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0
                    || Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                    || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                    )
                {
                    RegularMonthlyPaymentOption2 = null;
                }
                return RegularMonthlyPaymentOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPaymentOption2" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetInterestOption3(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    InterestOption3 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0
                    || Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                    || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                    )
                {
                    InterestOption3 = null;
                }
                return InterestOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestOption3" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetEscrowOption3(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowOption3 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0
                    || Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                    || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                    )
                {
                    EscrowOption3 = null;
                }
                return EscrowOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowOption3" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetRegularMonthlyPaymentOption3(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPaymentOption3 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0
                    || Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                    || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                    )
                {
                    RegularMonthlyPaymentOption3 = null;
                }
                return RegularMonthlyPaymentOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPaymentOption3" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetInterestOption4(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    InterestOption4 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData) == 0)
                    InterestOption4 = "0.00";
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                    InterestOption4 = accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData;
                else
                    InterestOption4 = accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

                return InterestOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestOption4" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetEscrowOption4(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowOption4 = "0.00";
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    EscrowOption4 = "0.00";
                return EscrowOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowOption4" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetRegularMonthlyPaymentOption4(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPaymentOption4 = "0.00";
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    RegularMonthlyPaymentOption4 = "0.00";
                return RegularMonthlyPaymentOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPaymentOption4" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetOption4MinimumDescription(AccountsModel accountModel)
        {
            try
            {
                if ((Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                        - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData)) > 0)
                    Option4MinimumDescription = "Your principal balance will decrease and you will be closer to paying off your loan.";
                else if ((Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                    - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData)) == 0)
                    Option4MinimumDescription = "Your principal balance will stay the same and you will not be closer to paying off your loan.";
                else if ((Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                    - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData)) < 0)
                    Option4MinimumDescription = "Your principal balance will increase.You will be borrowing more money and losing equity in your home.";

                return Option4MinimumDescription;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOption4MinimumDescription" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetPOBoxAddress(AccountsModel accountModel)
        {
            var mailingState = "KS, LA, NM, OK, TX";
            try
            {
                if (mailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                    POBoxAddress = "Dallas P.O.Box Address.";
                else
                    POBoxAddress = "Pasadena P.O.Box  Address.";
                return POBoxAddress;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPOBoxAddress" + ex.TargetSite.Name);
                 return "";
            }

        }
        public string GetReceivedAfterDate(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    IfReceivedAfterDate = "suppress Late Charge message";

                return IfReceivedAfterDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReceivedAfterDate" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetLateChargeAmount(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    LateChargeAmount = "suppress Late Charge message";

                return LateChargeAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetLateChargeAmount" + ex.TargetSite.Name);
                 return "";
            }
        }

        //public string GetDate(AccountsModel accountModel)
        //{
        //    if (accountModel.FeeRecordModel.RSSI_FT_TYPE_CODE == "000")
        //        Date = accountModel.FeeRecordModel.RSSI_FEE_DATE_ASSESSED;
        //    else
        //        Date = accountModel.MasterFileDataPart_1Model.Rssi_Bank_Trans_PackedData;
        //    return Date;

        //}
        //public string GetAmount(AccountsModel accountModel)
        //{
        //    if (Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData;
        //    else if (accountModel.TransactionRecordModel.RSSI_FT_TYPE_CODE == "000")
        //        Amount = accountModel.TransactionRecordModel.RSSI_FEE_AMT_ASSESSED;
        //    else
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData;
        //    return Amount;

        //}

        public string GetInterestRateUntil(AccountsModel accountModel)
        {
            //if (Convert.ToUInt64(Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
            try
            {
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
                    InterestRateUntil = "Until RSSI-RATE-CHG-DATE";
                else
                    InterestRateUntil = null;

                return InterestRateUntil;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestRateUntil" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetPrepaymentPenalty(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                    PrepaymentPenalty = "Yes";
                else
                    PrepaymentPenalty = "No";

                return PrepaymentPenalty;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrepaymentPenalty" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetModificationDate(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Modify_Date).IncludeCenturyDate(true)) > 19000000)
                    ModificationDate = accountModel.MasterFileDataPart_1Model.Rssi_Modify_Date;
                else
                    ModificationDate = "N/A";

                return ModificationDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetModificationDate" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetMaturityDate(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Balloon_Date).IncludeCenturyDate(true)) > 19000000)
                    MaturityDate = accountModel.MasterFileDataPart_1Model.Rssi_Balloon_Date;
                else
                    MaturityDate = accountModel.MasterFileDataPart_1Model.Rssi_Mat_Date;

                return MaturityDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMaturityDate" + ex.TargetSite.Name);

                 return "";
            }
        }
        public string GetDelinquencyNoticebox(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) > 30 && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                    DelinquencyNoticebox = "include the Delinquency Notice section";
                else
                    DelinquencyNoticebox = "";

                return DelinquencyNoticebox;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetDelinquencyNoticebox" + ex.TargetSite.Name);

                 return "";
            }
        }

        public string GetLossMitigtationNotice(AccountsModel accountsModel)
        {

            String lossMitigtationNotice = string.Empty;
            try
            {
                if (accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program.Trim() != "" && accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program.Trim() != "")
                    if (decimal.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (2 - 10) || decimal.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (12 - 14))
                    {
                        lossMitigtationNotice = "PLEASE TAKE NOTICE that You have agreed to the following loss mitigation program: [Program Name].";
                    }

                return lossMitigtationNotice;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetLossMitigtationNotice" + ex.TargetSite.Name);

                 return "";
            }
        }

        public string GetForeclosureNotice(AccountsModel accountsModel)
        {
            //if (decimal.Parse(accountsModel.MasterFileDataPart_1Model.RSSI_FBR_F_ACT_START_DT) > 0)  Did not found "RSSI-FBR-F-ACT-START-DT" in copy book

            try
            {
                if (decimal.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date) > 0)
                {
                    ForeclosureNotice = "PLEASE TAKE NOTICE that Carrington Mortgage Services, LLC has made the first notice or filing required to start a foreclosure.";
                }

                return ForeclosureNotice;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetForeclosureNotice" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetACHMessage(AccountsModel accountsModel)
        {

            try
            {
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0 &&
                        Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0)
                {
                    ACHMessage = "Autodraft message";
                }
                else
                    ACHMessage = "print Direct Pay Soliciation message";

                return ACHMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetACHMessage" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel)
        {
            try
            {
                if (accountsModel.EscrowRecordModel.rssi_esc_type == "20" || accountsModel.EscrowRecordModel.rssi_esc_type == "21" &&
                     accountsModel.EscrowRecordModel.Rssi_Ins_Co == "2450" && accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29000" ||
                     accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29005" || accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43000" ||
                     accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43001")
                { LenderPlacedInsuranceMessage = "then print Lender Placed Insurance message"; }

                return LenderPlacedInsuranceMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetLenderPlacedInsuranceMessage" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetBankruptcyMessage(AccountsModel accountsModel)
        {
            try
            {
                //CultureInfo culture = new CultureInfo("en-US");
                //DateTime tempDate = Convert.ToDateTime("00/00/00");
                if (accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Dschg_Dt_PackedData != null && accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != null )
                {
                    if (CommonHelper.GetFormatedDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Dschg_Dt_PackedData) > Convert.ToDateTime("01/01/01") &&
                    CommonHelper.GetFormatedDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("01/01/01"))
                    BankruptcyMessage = "print Bankruptcy message.";
                }
                return BankruptcyMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetBankruptcyMessage" + ex.TargetSite.Name);

                 return "";
            }
        }

        public string GetRepaymentPlanMessage(AccountsModel accountsModel)
        {
            try
            {
                // If (RSSI-REPY-REMAIN-BAL not = 00000C)
                //DOUBT
                //if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Repy_Remain_Bal_PackedData) !=00000C
                return RepaymentPlanMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRepaymentPlanMessage" + ex.TargetSite.Name);

                 return "";
            }
        }

        public string GetStateNSFMessage(AccountsModel accountsModel)
        {
            try
            {
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "6" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "16"
                      || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "18" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "42")
                { StateNSFMessage = "print State NSF message"; }

                return StateNSFMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetStateNSFMessage" + ex.TargetSite.Name);
                 return "";
            }
        }
        public string GetChargeOffNotice(AccountsModel accountsModel)
        {

            try
            {
                String chargeOffNotice = string.Empty;

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
                {
                    chargeOffNotice = "print Charge Off message";
                }

                return chargeOffNotice;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetChargeOffNotice" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetCMSPartialClaim(AccountsModel accountsModel)
        {
            String chargeOffNotice = string.Empty;
            try
            {
                if (decimal.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C") { chargeOffNotice = "print CMS Partial Claim Message."; }

                return chargeOffNotice;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCMSPartialClaim" + ex.TargetSite.Name);
                 return "";
            }
        }

        public string GetHUDPartialClaim(AccountsModel accountsModel)
        {
            String hUDPartialClaim = string.Empty;
            try
            {
                if (decimal.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H") { hUDPartialClaim = "print HUD Partial Claim Message."; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetHUDPartialClaim" + ex.TargetSite.Name);
                 return "";
            }
            return hUDPartialClaim;
        }

        public string GetStateDisclosures(AccountsModel accountsModel)
        {
            string stateDisclosures = string.Empty;
            var RSSISTATE = "4, 6, 12, 22, 24, 33, 34, 43, 44 ";
            var MailingState = "AR, CO, HI, MA, MN, NC, NY, TN, TX ";

            try
            {
                if (RSSISTATE.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
                { stateDisclosures = ""; }
                else if (MailingState.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                { stateDisclosures = ""; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetStateDisclosures" + ex.TargetSite.Name);

                 return "";
            }
            return stateDisclosures;
        }

        public string GetPaymentInformationMessage(AccountsModel accountsModel)
        {
            String paymentInformationMessage = string.Empty;

            try
            {
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" ||
                      accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                      || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX") { paymentInformationMessage = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPaymentInformationMessage" + ex.TargetSite.Name);

                 return "";
            }
            return paymentInformationMessage;
        }




        public string GetRecentPayment6(AccountsModel accountModel)
        {

            String recentPayment6 = String.Empty;

            try
            {
                if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_5+" Fully paid on "+ accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_5; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4; }
           
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                { recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                { recentPayment6 = recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1; ; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date+"(1): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData +"(1)";
                 }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment6" + ex.TargetSite.Name);

                 return "";
            }

            return recentPayment6;
        }


        public string GetRecentPayment5(AccountsModel accountModel)
        {

            String recentPayment5 = String.Empty;

            try
            {
                if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    recentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3;
                }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { recentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                { recentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    recentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                     }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment5" + ex.TargetSite.Name);

                 return "";
            }

            return recentPayment5;
        }

        public string GetRecentPayment4(AccountsModel accountModel)
        {

            String recentPayment4 = String.Empty;

            try
            {
                if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { recentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { recentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)"; }


            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment4" + ex.TargetSite.Name);

                 return "";
            }
            return recentPayment4;
        }

        public string GetRecentPayment3(AccountsModel accountModel)
        {

            String recentPayment3 = String.Empty;

            try
            {
                if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { recentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment3" + ex.TargetSite.Name);

                 return "";
            }

            return recentPayment3;
        }

        public string GetRecentPayment2(AccountsModel accountModel)
        {

            String recentPayment2 = String.Empty;

            try
            {
                if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + " Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment2" + ex.TargetSite.Name);

                 return "";
            }

            return recentPayment2;
        }

        public string GetRecentPayment1(AccountsModel accountModel)
        {

            String recentPayment1 = String.Empty;

            try
            {
                if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)"; }
                else if (decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && decimal.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(6): Unpaid balance of $" + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(6)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment1" + ex.TargetSite.Name);
                 return "";
            }

            return recentPayment1;
        }




        #endregion
    }
}
