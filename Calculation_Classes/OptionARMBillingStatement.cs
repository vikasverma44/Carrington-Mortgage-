using Carrington_Service.Infrastructure;
using ODHS_EDelivery.Helpers;
using ODHS_EDelivery.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.Calculation_Classes
{
    public class OptionARMBillingStatement
    {
        #region Object Declaration  ==>
        public ILogger Logger;

        #endregion

        #region Public Property ==>
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

        public OptionARMBillingStatement(ILogger logger)
        {
            Logger = logger;
        }


        /* While Calculating Conditions must be applied*/

        #region Old Code ==>>
        public string GetTotalFeesChargedOption1(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to get Total Fees Charged Option1 operation.");
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
                Logger.Trace("ENDED:    Total Fees Charged Option1 operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption1;
        }
        public string GetDeferredBalance(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to get Deferred Balance operation.");
                if (Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                        Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                }
                Logger.Trace("ENDED:    To Deferred Balance operation.");
                return DeferredBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetTotalFeesChargedOption4(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to get Total Fees Charged Option4 operation.");
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
                Logger.Trace("ENDED:   Total Fees Charged Option4 operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption4;
        }
        public string GetAmountDueOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option 1 operation.");
                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption1 = "0.00";
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    AmountDueOption1 = "N/A";
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption1 = "N/A";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption1 = "N/A";
                }
                else
                {
                    AmountDueOption1 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
                }
                Logger.Trace("ENDED:   To Amount Due Option 1 operation.");
                return AmountDueOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

        }
        public string GetAmountDueOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option 2 operation.");
                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption2 = "0.00";
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else
                {
                    AmountDueOption2 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));
                }
                Logger.Trace("ENDED:   To Amount Due Option 2 operation.");
                return AmountDueOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

        }
        public string GetAmountDueOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option 3 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption3 = "0";
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else
                {
                    AmountDueOption3 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                Logger.Trace("ENDED:   To Amount Due Option 3 operation.");
                return AmountDueOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        public string GetAmountDueOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option 4 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption4 = "0";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption4 = "N/A";
                }
                else
                {
                    AmountDueOption4 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }

                Logger.Trace("ENDED:   To Amount Due Option 4 operation.");
                return AmountDueOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetPrincipalOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option 1 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PrincipalOption1 = "0.00";
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    PrincipalOption1 = null;
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    PrincipalOption1 = null;
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PrincipalOption1 = null;
                }
                else
                {
                    PrincipalOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData) -
                                            Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }

                Logger.Trace("ENDED:   To Principal Option 1 operation.");
                return PrincipalOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        public string GetOverduePaymentsOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 1 operation.");
                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption1 = "0.00";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption1 = "null";

                else
                {
                    //not found total fees paid
                    OverduePaymentsOption1 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                     - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
                }
                Logger.Trace("ENDED:   To Overdue Payments Option 1 operation.");
                return OverduePaymentsOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        public string GetTotalFeesPaidOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 1 operation.");
                // need to check
                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";


                else if ((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption1 = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
                }
                else
                    TotalFeesPaidOption1 = "0.00";
                Logger.Trace("ENDED:   Total Fees Paid Option 1 operation.");
                return TotalFeesPaidOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetTotalAmountDueOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total AmountDue Option 1 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "N/A";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "N/A";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "N/A";

                else
                    TotalAmountDueOption1 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                   + Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));

                Logger.Trace("ENDED:   Get Total AmountDue Option 1 operation.");
                return TotalAmountDueOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetPrincipalOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option2 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption2 = "0.00";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    PrincipalOption2 = "null";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption2 = "null";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption2 = "null";
                else
                {
                    PrincipalOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                     - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:   Get Principal Option2 operation.");
                return PrincipalOption2;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetAssistanceAmountOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option 2 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "do not print the Assistance Amount line";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption2 = "0.00";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "null";

                else
                {
                    AssistanceAmountOption2 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1);
                }
                Logger.Trace("ENDED:   Get Assistance Amount Option 2 operation.");
                return AssistanceAmountOption2;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetReplacementReserveOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option2 operation.");

                if ((Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                   - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                    - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                   + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption2 = "do not print the Replacement Reserve line";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else
                {
                    ReplacementReserveOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                                - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                                - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
                }

                Logger.Trace("ENDED:   Get Replacement Reserve Option2 operation.");
                return ReplacementReserveOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetOverduePaymentsOption2(AccountsModel model)
        {
            //what is - Total Fees Paid
            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 2 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption2 = "0.00";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption2 = "null";


                else
                {
                    OverduePaymentsOption2 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                     - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
                }
                Logger.Trace("ENDED:   Get Overdue Payments Option 2 operation.");
                return OverduePaymentsOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        public string GetTotalFeesPaidOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 2 operation.");

                // need to check
                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption2 = "0.00";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if ((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption2 = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
                }
                else
                    TotalFeesPaidOption2 = "0.00";
                Logger.Trace("ENDED:   Get Total Fees Paid Option 2 operation.");
                return TotalFeesPaidOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetTotalAmountDueOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option 2 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption2 = "0.00";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalAmountDueOption2 = "N/A";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption2 = "N/A";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption2 = "N/A";

                else
                    TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                   + Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));
                Logger.Trace("ENDED:   Get Total Amount Due Option 2 operation.");
                return TotalAmountDueOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        public string GetPrincipalOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option 3 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption3 = "0.00";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    PrincipalOption3 = "N/A";

                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption3 = "null";

                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption3 = "null";

                else
                {
                    PrincipalOption3 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                     - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:   Get Principal Option 3 operation.");
                return PrincipalOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetAssistanceAmountOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option 3 operation.");
                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption3 = "then do not print the Assistance Amount line.";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AssistanceAmountOption3 = "0.00";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption3 = "0.00";
                }
                else
                {
                    AssistanceAmountOption3 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
                }
                Logger.Trace("ENDED:   Get Assistance Amount Option 3 operation.");
                return AssistanceAmountOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetReplacementReserveOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option 3 operation.");

                if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) -
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData) -
                    Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                    Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption3 = "then do not print the Replacement Reserve line.";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    ReplacementReserveOption3 = "0.00";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption3 = "0.00";
                }
                else
                {
                    ReplacementReserveOption3 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) -
                                             Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData) -
                                              Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                                             Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
                }
                Logger.Trace("ENDED:   Get Replacement Reserve Option 3 operation.");
                return ReplacementReserveOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetOverduePaymentsOption3(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 3 operation.");

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

                Logger.Trace("ENDED:   Get Replacement Overdue Payments Option 3 operation.");
                return OverduePaymentsOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetTotalFeesPaidOption3(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 3 operation.");

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

                Logger.Trace("ENDED:   Get Total Fees Paid Option 3 operation.");
                return TotalFeesPaidOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetTotalAmountDueOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option 3 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalAmountDueOption3 = "0.00";
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    TotalAmountDueOption3 = "Option Not Available";
                }
                else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalAmountDueOption3 = "Option Not Available";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalAmountDueOption3 = "Option Not Available";
                }
                else
                {
                    TotalAmountDueOption3 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                        Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                Logger.Trace("ENDED:   Get Total Amount Due Option 3 operation.");
                return TotalAmountDueOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetPrincipalOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option 4 operation.");
                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PrincipalOption4 = "0.00";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                {
                    PrincipalOption4 = "0.00";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PrincipalOption4 = "0.00";
                }
                else
                {
                    PrincipalOption4 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData) - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:   Get Principal Option 4 operation.");
                return PrincipalOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetAssistanceAmountOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option 4 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption4 = "then do not print the Assistance Amount line.";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AssistanceAmountOption4 = "0.00";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
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
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetReplacementReserveOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement ReserveOption 4 operation.");

                if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData) -
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData) -
                    Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                    Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    return "then do not print the Replacement Reserve line.";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    return "0.00";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    return "0.00";
                }
                Logger.Trace("ENDED:   Get Replacement ReserveOption 4 operation.");
                return ReplacementReserveOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetOverduePaymentsOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 4 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    OverduePaymentsOption4 = "0.00";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    OverduePaymentsOption4 = "0.00";
                }
                else
                {
                    OverduePaymentsOption4 =
                    Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                        Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
                        Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData) -
                     Convert.ToInt64(GetTotalFeesPaidOption3(model)));
                }
                Logger.Trace("ENDED:   Get Overdue Payments Option 4 operation.");
                return OverduePaymentsOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        public string GetTotalFeesPaidOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 4 operation.");

                var TotalFeeCharged = Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesPaidOption4 = "0";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesPaidOption4 = "0";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                    + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                    < Convert.ToInt64(TotalFeeCharged))
                {
                    TotalFeesPaidOption4 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                   + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                   - Convert.ToInt64(GetTotalFeesChargedOption4(model)));
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
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        public string GetTotalAmountDueOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total AmountDue Option4 operation.");

                if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalAmountDueOption4 = "0.00";
                }
                else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalAmountDueOption4 = "0.00";
                }
                else
                {
                    TotalAmountDueOption4 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }
                Logger.Trace("ENDED:   Get  Total AmountDue Option4   operation.");
                return TotalAmountDueOption4;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        public string GeUnappliedFundsPaidLastMonth(AccountsModel model)
        {
            return "";


        }

        public string GetFeesandChargesPaidYeartoDate(AccountsModel model)
        {
            return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) +
                                    Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData));
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
            return UnappliedFundsPaidYearToDate;
        }
        public string GeSuspense(AccountsModel model)
        {
            return Convert.ToString(Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) +
                  Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2) +
                  Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3) +
                  Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04) +
                  Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
        }

        public string GetMiscellaneous(AccountsModel model)
        {
            return Convert.ToString(Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData) +
               Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
        }
        public string GetTotalDue(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                return "0.00";

            return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel model)
        {

            return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
              Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData));
        }
        public string GetUnappliedFunds(AccountsModel accountsModel)
        {
            UnappliedFunds = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
            return UnappliedFunds;
        }
        public string GetPastDueBalance(AccountsModel model)
        {
            return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
              Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
              Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
        }
        public string GetTotalPaidYearToDate(AccountsModel accountsModel)
        {


            TotalPaidYearToDate = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
                                   + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
                                   + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                                   + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                                   + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                                   + accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                                   + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                                   + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                                   + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                                   + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));


            return TotalPaidYearToDate;

        }
        public string GetAssistanceAmountOption1(AccountsModel model)
        {

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
            {
                return "then do not print the Assistance Amount line.";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
            }
        }
        public string GetReplacementReserveOption1(AccountsModel model)
        {
            if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) -
                Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData) -
                 Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
            {
                return "then do not print the Replacement Reserve line.";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) -
                                         Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData) -
                                    Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0);
            }
        }
        public string GetMinimumLatePaymentAmount(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData) +
                Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData));
            }
        }
        public string GetTotalFeesChargedOption3(AccountsModel accountsModel)
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
            return TotalFeesChargedOption3;
        }
        public string GetTotalFeesChargedOption2(AccountsModel accountsModel)
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
            return TotalFeesChargedOption2;
        }

        #endregion

        #region New Methods ==>

        public string GetHold(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                Hold = "Create image but do not mail.";
            return Hold;
        }

        public string GetAttention(AccountsModel accountsModel)
        {

            String attention = string.Empty;
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

        public string GetPrimaryBorrower(AccountsModel accountsModel)
        {

            String primaryBorrower = string.Empty;

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


        public string GetSecondaryBorrower(AccountsModel accountsModel)
        {

            String secondaryBorrower = string.Empty;

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

        public string GetMailingAddressLine1(AccountsModel accountsModel)
        {

            String mailingAddressLine1 = string.Empty;
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

        public string GetMailingAddressLine2(AccountsModel accountsModel)
        {

            String mailingAddressLine2 = string.Empty;
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

        public string GetMailingCityStateZip(AccountsModel accountsModel)
        {

            String mailingCityStateZip = string.Empty;

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

        public string GetMailingCountry(AccountsModel accountModel)
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
        public string GetPaymentIsReceivedAfter(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                PaymentIsReceivedAfter = "suppress Late Charge message";

            return PaymentIsReceivedAfter;
        }
        public string GetLateFee(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                LateFee = "suppress Late Charge message";

            return LateFee;
        }
        public string GetChargeOffNoticeNoticeMessage(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
                ChargeOffNoticeNoticeMessage = "Print he Charge Off Notice";
            else if ((Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30)
                    && (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0))
                ChargeOffNoticeNoticeMessage = "print the Delinquency Notice";
            else if ((Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) < 30)
                    && (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0))
                ChargeOffNoticeNoticeMessage = "print the Re-Finance Notice";
            return ChargeOffNoticeNoticeMessage;
        }

        public string GetNegativeAmortization(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData) == 0)
                NegativeAmortization = "N/A";
            else
                NegativeAmortization = accountModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData;
            return NegativeAmortization;
        }

        public string GetBuydownBalance(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                BuydownBalance = "N/A";
            else
                BuydownBalance = accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;

            return BuydownBalance;
        }
        public string GetPartialClaim(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                PartialClaim = "N/A";
            else
                PartialClaim = accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;

            return PartialClaim;
        }
        public string GetInterestOption1(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                InterestOption1 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0
                || Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                || Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                )
            {
                InterestOption1 = null;
            }
            return InterestOption1;
        }
        public string GetEscrowOption1(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                EscrowOption1 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0
                || Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                || Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                )
            {
                EscrowOption1 = null;
            }
            return EscrowOption1;
        }
        public string GetRegularMonthlyPaymentOption1(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                RegularMonthlyPaymentOption1 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0
                || Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                || Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                )
            {
                RegularMonthlyPaymentOption1 = null;
            }
            return RegularMonthlyPaymentOption1;
        }
        public string GetInterestOption2(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                InterestOption2 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0
                || Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                || Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                )
            {
                InterestOption2 = null;
            }
            return InterestOption2;
        }

        public string GetEscrowOption2(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                EscrowOption2 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0
                || Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                || Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                )
            {
                EscrowOption2 = null;
            }
            return EscrowOption2;
        }
        public string GetRegularMonthlyPaymentOption2(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                RegularMonthlyPaymentOption2 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0
                || Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                || Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                )
            {
                RegularMonthlyPaymentOption2 = null;
            }
            return RegularMonthlyPaymentOption2;
        }
        public string GetInterestOption3(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                InterestOption3 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0
                || Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                || Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                )
            {
                InterestOption3 = null;
            }
            return InterestOption3;
        }

        public string GetEscrowOption3(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                EscrowOption3 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0
                || Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                || Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                )
            {
                EscrowOption3 = null;
            }
            return EscrowOption3;
        }

        public string GetRegularMonthlyPaymentOption3(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                RegularMonthlyPaymentOption3 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0
                || Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                || Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0
                )
            {
                RegularMonthlyPaymentOption3 = null;
            }
            return RegularMonthlyPaymentOption3;
        }

        public string GetInterestOption4(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                InterestOption4 = "0.00";
            else if (Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData) == 0)
                InterestOption4 = "0.00";
            else if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                InterestOption4 = accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData;
            else
                InterestOption4 = accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

            return InterestOption4;
        }
        public string GetEscrowOption4(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                EscrowOption4 = "0.00";
            else if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                EscrowOption4 = "0.00";
            return EscrowOption4;
        }
        public string GetRegularMonthlyPaymentOption4(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                RegularMonthlyPaymentOption4 = "0.00";
            else if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                RegularMonthlyPaymentOption4 = "0.00";
            return RegularMonthlyPaymentOption4;
        }
        public string GetOption4MinimumDescription(AccountsModel accountModel)
        {
            if ((Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                - Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData)) > 0)
                Option4MinimumDescription = "Your principal balance will decrease and you will be closer to paying off your loan.";
            else if ((Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                - Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData)) == 0)
                Option4MinimumDescription = "Your principal balance will stay the same and you will not be closer to paying off your loan.";
            else if ((Convert.ToInt64(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                - Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData)) < 0)
                Option4MinimumDescription = "Your principal balance will increase.You will be borrowing more money and losing equity in your home.";

            return Option4MinimumDescription;
        }
        public string GetPOBoxAddress(AccountsModel accountModel)
        {
            var mailingState = "KS, LA, NM, OK, TX";
            if (mailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                POBoxAddress = "Dallas P.O.Box Address.";
            else
                POBoxAddress = "Pasadena P.O.Box  Address.";
            return POBoxAddress;

        }
        public string GetReceivedAfterDate(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                IfReceivedAfterDate = "suppress Late Charge message";

            return IfReceivedAfterDate;
        }
        public string GetLateChargeAmount(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                LateChargeAmount = "suppress Late Charge message";

            return LateChargeAmount;
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
        //    if (Convert.ToInt64(accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData;
        //    else if (accountModel.TransactionRecordModel.RSSI_FT_TYPE_CODE == "000")
        //        Amount = accountModel.TransactionRecordModel.RSSI_FEE_AMT_ASSESSED;
        //    else
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData;
        //    return Amount;

        //}

        public string GetInterestRateUntil(AccountsModel accountModel)
        {
            if (Convert.ToUInt64(Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
                InterestRateUntil = "Until RSSI-RATE-CHG-DATE";
            else
                InterestRateUntil = null;

            return InterestRateUntil;
        }

        public string GetPrepaymentPenalty(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                PrepaymentPenalty = "Yes";
            else
                PrepaymentPenalty = "No";

            return PrepaymentPenalty;
        }
        public string GetModificationDate(AccountsModel accountModel)
        {
            if (Convert.ToUInt64(Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Modify_Date).IncludeCenturyDate(true)) > 19000000)
                ModificationDate = accountModel.MasterFileDataPart_1Model.Rssi_Modify_Date;
            else
                ModificationDate = "N/A";

            return ModificationDate;
        }
        public string GetMaturityDate(AccountsModel accountModel)
        {
            if (Convert.ToUInt64(Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Balloon_Date).IncludeCenturyDate(true)) > 19000000)
                MaturityDate = accountModel.MasterFileDataPart_1Model.Rssi_Balloon_Date;
            else
                MaturityDate = accountModel.MasterFileDataPart_1Model.Rssi_Mat_Date;

            return MaturityDate;
        }
        public string GetDelinquencyNoticebox(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) > 30 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                DelinquencyNoticebox = "include the Delinquency Notice section";
            else
                DelinquencyNoticebox = "";

            return DelinquencyNoticebox;
        }

        public string GetLossMitigtationNotice(AccountsModel accountsModel)
        {

            String lossMitigtationNotice = string.Empty;

            if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (2 - 10) || int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (12 - 14))
            {
                lossMitigtationNotice = "PLEASE TAKE NOTICE that You have agreed to the following loss mitigation program: [Program Name].";
            }

            return lossMitigtationNotice;
        }

        public string GetForeclosureNotice(AccountsModel accountsModel)
        {
            //if (int.Parse(accountsModel.MasterFileDataPart_1Model.RSSI_FBR_F_ACT_START_DT) > 0)  Did not found "RSSI-FBR-F-ACT-START-DT" in copy book

            if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date) > 0)
            {
                ForeclosureNotice = "PLEASE TAKE NOTICE that Carrington Mortgage Services, LLC has made the first notice or filing required to start a foreclosure.";
            }

            return ForeclosureNotice;
        }
        public string GetACHMessage(AccountsModel accountsModel)
        {

            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0 &&
                Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0)
            {
                ACHMessage = "Autodraft message";
            }
            else
                ACHMessage = "print Direct Pay Soliciation message";

            return ACHMessage;
        }
        public string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel)
        {
            if (accountsModel.EscrowRecordModel.rssi_esc_type == "20" || accountsModel.EscrowRecordModel.rssi_esc_type == "21" &&
                accountsModel.EscrowRecordModel.Rssi_Ins_Co == "2450" && accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29000" ||
                accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29005" || accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43000" ||
                accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43001")
            { LenderPlacedInsuranceMessage = "then print Lender Placed Insurance message"; }

            return LenderPlacedInsuranceMessage;
        }
        public string GetBankruptcyMessage(AccountsModel accountsModel)
        {
            if (Convert.ToDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Dschg_Dt_PackedData) > Convert.ToDateTime("00/00/00") &&
                Convert.ToDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
            {
                BankruptcyMessage = "print Bankruptcy message.";
            }
            return BankruptcyMessage;
        }

        public string GetRepaymentPlanMessage(AccountsModel accountsModel)
        {
            // If (RSSI-REPY-REMAIN-BAL not = 00000C)
            //DOUBT
            //if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Repy_Remain_Bal_PackedData) !=00000C
            return RepaymentPlanMessage;
        }

        public string GetStateNSFMessage(AccountsModel accountsModel)
        {
            if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "6" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "16"
               || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "18" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "42")
            { StateNSFMessage = "print State NSF message"; }

            return StateNSFMessage;
        }
        public string GetChargeOffNotice(AccountsModel accountsModel)
        {

            String chargeOffNotice = string.Empty;

            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
            {
                chargeOffNotice = "print Charge Off message";
            }

            return chargeOffNotice;
        }

        public string GetCMSPartialClaim(AccountsModel accountsModel)
        {
            String chargeOffNotice = string.Empty;
            if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C") { chargeOffNotice = "print CMS Partial Claim Message."; }

            return chargeOffNotice;
        }

        public string GetHUDPartialClaim(AccountsModel accountsModel)
        {
            String hUDPartialClaim = string.Empty;
            if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H") { hUDPartialClaim = "print HUD Partial Claim Message."; }
            return hUDPartialClaim;
        }

        public string GetStateDisclosures(AccountsModel accountsModel)
        {
            string stateDisclosures = string.Empty;
            var RSSISTATE = "4, 6, 12, 22, 24, 33, 34, 43, 44 ";
            var MailingState = "AR, CO, HI, MA, MN, NC, NY, TN, TX ";

            if (RSSISTATE.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
            { stateDisclosures = ""; }
            else if (MailingState.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
            { stateDisclosures = ""; }

            return stateDisclosures;
        }

        public string GetPaymentInformationMessage(AccountsModel accountsModel)
        {
            String paymentInformationMessage = string.Empty;

            if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" ||
                accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX") { paymentInformationMessage = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

            return paymentInformationMessage;
        }




        public string GetRecentPayment6(AccountsModel accountModel)
        {

            String recentPayment6 = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
            { recentPayment6 = "RSSI-PMT-DUE-5-DATE: Fully paid on RSSI-PMT-PAID-5-DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
            { recentPayment6 = "RSSI - PMT - DUE - 4 - DATE: Fully paid on RSSI-PMT - PAID - 4 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
            { recentPayment6 = "RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
            { recentPayment6 = "RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
            { recentPayment6 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            { recentPayment6 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }


            return recentPayment6;
        }


        public string GetRecentPayment5(AccountsModel accountModel)
        {

            String recentPayment5 = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
            { recentPayment5 = "RSSI-PMT-DUE-4-DATE: Fully paid on RSSI-PMT-PAID-4-DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
            { recentPayment5 = "RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
            { recentPayment5 = "RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
            { recentPayment5 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment5 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            { recentPayment5 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }


            return recentPayment5;
        }

        public string GetRecentPayment4(AccountsModel accountModel)
        {

            String recentPayment4 = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
            { recentPayment4 = "RSSI-PMT-DUE-3-DATE: Fully paid on RSSI-PMT-PAID-3-DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
            { recentPayment4 = "RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
            { recentPayment4 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment4 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment4 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            { recentPayment4 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }


            return recentPayment4;
        }

        public string GetRecentPayment3(AccountsModel accountModel)
        {

            String recentPayment3 = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
            { recentPayment3 = "RSSI-PMT-DUE-2-DATE: Fully paid on RSSI-PMT-PAID-2-DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
            { recentPayment3 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment3 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment3 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment3 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            { recentPayment3 = "RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }


            return recentPayment3;
        }

        public string GetRecentPayment2(AccountsModel accountModel)
        {

            String recentPayment2 = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
            { recentPayment2 = "RSSI-PMT-DUE-1-DATE: Fully paid on RSSI-PMT-PAID-1-DATE"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment2 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment2 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment2 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment2 = "RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            { recentPayment2 = "RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }


            return recentPayment2;
        }

        public string GetRecentPayment1(AccountsModel accountModel)
        {

            String recentPayment1 = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment1 = "RSSI-PAST-DATE (1): Unpaid balance of $RSSI-REG-AMT (1)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment1 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment1 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment1 = "RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
            { recentPayment1 = "RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            { recentPayment1 = "RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }


            return recentPayment1;
        }




        #endregion
    }
}
