using Carrington_Service.Infrastructure;
using CarringtonMortgage.Models.InputCopyBookModels;
using System;
using System.Text;
using CarringtonMortgage.Helpers;

namespace Carrington_Service.Calculation_Classes
{
    public class ChapterThirteenOptionARMStatement : IChapterThirteenOptionARMStatement
    {
        public string AmountDueOption1 { get; set; }
        public string AmountDueOption2 { get; set; }
        public string AmountDueOption3 { get; set; }
        public string AmountDueOption4 { get; set; }
        public string FeesandChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string FeesandChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
        public string PrincipalOption1 { get; set; }
        public string AssistanceAmountOption1 { get; set; }
        public string ReplacementReserveOption1 { get; set; }
        public string OverduePaymentsOption1 { get; set; }
        public string TotalFeesPaidOption1 { get; set; }
        public string TotalAmountDueOption1 { get; set; }
        public string PrincipalOption2 { get; set; }
        public string AssistanceAmountOption2 { get; set; }
        public string ReplacementReserveOption2 { get; set; }
        public string OverduePaymentsOption2 { get; set; }
        public string TotalFeesPaidOption2 { get; set; }
        public string TotalAmountDueOption2 { get; set; }
        public string PrincipalOption3 { get; set; }
        public string AssistanceAmountOption3 { get; set; }
        public string ReplacementReserveOption3 { get; set; }
        public string OverduePaymentsOption3 { get; set; }
        public string TotalFeesPaidOption3 { get; set; }
        public string TotalAmountDueOption3 { get; set; }
        public string PrincipalOption4 { get; set; }
        public string AssistanceAmountOption4 { get; set; }
        public string ReplacementReserveOption4 { get; set; }
        public string OverduePaymentsOption4 { get; set; }
        public string TotalFeesPaidOption4 { get; set; }
        public string TotalAmountDueOption4 { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string DeferredBalance { get; set; }



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
        public string TotalFeesChargedOption1 { get; set; }
        public string InterestOption2 { get; set; }
        public string EscrowOption2 { get; set; }
        public string RegularMonthlyPaymentOption2 { get; set; }
        public string TotalFeesChargedOption2 { get; set; }

        public string InterestOption3 { get; set; }
        public string EscrowOption3 { get; set; }
        public string RegularMonthlyPaymentOption3 { get; set; }
        public string TotalFeesChargedOption3 { get; set; }

        public string InterestOption4 { get; set; }
        public string EscrowOption4 { get; set; }
        public string RegularMonthlyPaymentOption4 { get; set; }
        public string TotalFeesChargedOption4 { get; set; }

        public string Option4MinimumDescription { get; set; }
        public string PostPetitonpastduemessage { get; set; }
        public string POBoxAddress { get; set; }
        public string PaymentDate1 { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
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

        public ChapterThirteenOptionARMStatement(ILogger logger)
        {
            Logger = logger;
        }

        public StringBuilder GetFinalChapterThirteenOptionARMStatement(AccountsModel accountModel)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();
            finalLine.Append("01" + "|");
            finalLine.Append("Option ARM BK CHPT 13 STMT" + "|");
            finalLine.Append(" " + "|");
            finalLine.Append("01" + "|");
            finalLine.Append(GetAmountDueOption1(accountModel) + "|");
            finalLine.Append(GetAmountDueOption2(accountModel) + "|");
            finalLine.Append(GetAmountDueOption3(accountModel) + "|");
            finalLine.Append(GetAmountDueOption4(accountModel) + "|");
            finalLine.Append(GetFeesandChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesandChargesPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetPrincipalOption1(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption1(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption1(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption1(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption1(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption1(accountModel) + "|");
            finalLine.Append(GetPrincipalOption2(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption2(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption2(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption2(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption2(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption2(accountModel) + "|");
            finalLine.Append(GetPrincipalOption3(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption3(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption3(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption3(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption3(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption3(accountModel) + "|");
            finalLine.Append(GetPrincipalOption4(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption4(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption4(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption4(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption4(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption4(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
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
            finalLine.Append(GetTotalFeesChargedOption1(accountModel) + "|");
            finalLine.Append(GetInterestOption2(accountModel) + "|");
            finalLine.Append(GetEscrowOption2(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption2(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption2(accountModel) + "|");
            finalLine.Append(GetInterestOption3(accountModel) + "|");
            finalLine.Append(GetEscrowOption3(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption3(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption3(accountModel) + "|");
            finalLine.Append(GetInterestOption4(accountModel) + "|");
            finalLine.Append(GetEscrowOption4(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption4(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption4(accountModel) + "|");
            finalLine.Append(GetOption4MinimumDescription(accountModel) + "|");
            finalLine.Append(GetPostPetitonpastduemessage(accountModel) + "|");
            finalLine.Append(GetPOBoxAddress(accountModel) + "|");
            finalLine.Append(GetDate(accountModel) + "|");
            finalLine.Append(GetAmount(accountModel) + "|");
            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            finalLine.Append(GetStateNSF(accountModel) + "|");
            finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            finalLine.Append(GetStateDisclosures(accountModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");
            return finalLine;
        }

        /* While Calculating Conditions must be applied*/
        /// <summary>
        /// 11
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAmountDueOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option1");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AmountDueOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    AmountDueOption1 = "N/A";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    AmountDueOption1 = "N/A";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AmountDueOption1 = "N/A";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    AmountDueOption1 = "N/A";
                else
                {
                    AmountDueOption1 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                     + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
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
        /// <summary>
        /// 12
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAmountDueOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option2");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AmountDueOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    AmountDueOption2 = "N/A";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    AmountDueOption2 = "N/A";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AmountDueOption2 = "N/A";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    AmountDueOption2 = "N/A";

                else
                {
                    AmountDueOption2 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                               + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                               + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
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
        /// <summary>
        /// 13
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAmountDueOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option3");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AmountDueOption3 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    AmountDueOption3 = "N/A";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    AmountDueOption3 = "N/A";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AmountDueOption3 = "N/A";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    AmountDueOption3 = "N/A";

                else
                {
                    AmountDueOption3 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                               + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                               + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
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
        /// <summary>
        /// 14
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAmountDueOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount Due Option4");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AmountDueOption3 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AmountDueOption3 = "N/A";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    AmountDueOption4 = Convert.ToString(Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                    + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                }
                else
                {
                    AmountDueOption4 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                              + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                              + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
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
        /// <summary>
        /// 19
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetFeesandChargesPaidLastMonth(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Fees and Charges Paid Last Month");

                if ((Convert.ToDecimal(model.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToDecimal(model.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    && (Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                {
                    FeesandChargesPaidLastMonth = Convert.ToString((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData))
                    - Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
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
        /// <summary>
        /// 20
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetUnappliedFundsPaidLastMonth(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Last Month");

                FeesandChargesPaidLastMonth = Convert.ToString(Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));

                Logger.Trace("ENDED:  To Get Unapplied Funds Paid Last Month");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return UnappliedFundsPaidLastMonth;
        }
        /// <summary>
        /// 25
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetFeesandChargesPaidYearToDate(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Fees and Charges Paid Year To Date");

                if ((Convert.ToDecimal(model.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToDecimal(model.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                  &&
                  (Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                {
                    FeesandChargesPaidLastMonth = Convert.ToString((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData))
                    - Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                Logger.Trace("STARTED:  To Get Fees and Charges Paid Year To Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return FeesandChargesPaidLastMonth;
        }
        /// <summary>
        /// 26
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetUnappliedFundsPaidYearToDate(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Year To Date");

                UnappliedFundsPaidYearToDate = Convert.ToString(model.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
               + model.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
               + model.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
               + model.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
               + model.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);

                Logger.Trace("ENDED:  To Get Unapplied Funds Paid Year To Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return UnappliedFundsPaidYearToDate;
        }
        /// <summary>
        /// 27
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalPaidYearToDate(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Paid Year To Date");

                if ((Convert.ToDecimal(model.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToDecimal(model.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                   && (Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                {
                    TotalPaidYearToDate = Convert.ToString((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                    + model.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                    + model.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                    + model.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                    + model.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                    + model.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0)
                    - Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }

                Logger.Trace("ENDED:  To Get Total Paid Year To Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalPaidYearToDate;
        }
        /// <summary>
        /// 28
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetPrincipalOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option1");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    PrincipalOption1 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption1 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption1 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    PrincipalOption1 = "null";
                else
                {
                    AmountDueOption1 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
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
        /// <summary>
        /// 31
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAssistanceAmountOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option1");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption1 = "do not print the Assistance Amount line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption1 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption1 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    AssistanceAmountOption1 = "null";
                else
                {
                    AssistanceAmountOption1 = model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
                }
                Logger.Trace("ENDED:  To Get Assistance Amount Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AssistanceAmountOption1;
        }
        /// <summary>
        /// 32
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetReplacementReserveOption1(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option1");

                if ((Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
               - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
               + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption1 = "do not print the Replacement Reserve line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption1 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption1 = "0.00";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    ReplacementReserveOption1 = "null";
                else
                {
                    ReplacementReserveOption1 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                                - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                              - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

                }
                Logger.Trace("ENDED:  To Get Replacement Reserve Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return ReplacementReserveOption1;
        }
        /// <summary>
        /// 34
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetOverduePaymentsOption1(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option1");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AmountDueOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    AmountDueOption1 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    AmountDueOption1 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AmountDueOption1 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    AmountDueOption1 = "null";
                else
                {
                    AmountDueOption1 = Convert.ToString(Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToDecimal(GetTotalFeesPaidOption1(model)));
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
        /// <summary>
        /// 36
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalFeesPaidOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option1");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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

                Logger.Trace("ENDED:  To Get Total Fees Paid Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption1;
        }
        /// <summary>
        /// 37
        /// </summary>
        /// <returns></returns>
        public string GetTotalAmountDueOption1(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option1");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "N/A";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "N/A";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "N/A";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    TotalFeesPaidOption1 = "null";

                else
                    TotalAmountDueOption1 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                   + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                Logger.Trace("ENDED:  To Get Total Amount Due Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption1;
        }
        /// <summary>
        /// 38
        /// </summary>
        /// <returns></returns>
        public string GetPrincipalOption2(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option2");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    PrincipalOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption2 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    PrincipalOption2 = "null";
                else
                {
                    PrincipalOption2 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:  To Get Principal Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrincipalOption2;
        }
        /// <summary>
        /// 41m
        /// </summary>
        /// <returns></returns>
        public string GetAssistanceAmountOption2(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option2");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "do not print the Assistance Amount line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption2 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    AssistanceAmountOption2 = "null";
                else
                {
                    AssistanceAmountOption2 = model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
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
        /// <summary>
        /// 42
        /// </summary>
        /// <returns></returns>
        public string GetReplacementReserveOption2(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option2");

                if ((Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
             - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
             - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
             + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption2 = "do not print the Replacement Reserve line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption2 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    ReplacementReserveOption2 = "null";
                else
                {
                    ReplacementReserveOption2 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                                - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                                - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

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
        /// <summary>
        /// 44
        /// </summary>
        /// <returns></returns>
        public string GetOverduePaymentsOption2(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option2");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    OverduePaymentsOption2 = "null";
                else
                {
                    OverduePaymentsOption2 = Convert.ToString(Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToDecimal(GetTotalFeesPaidOption2(model)));
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
        /// <summary>
        /// 46
        /// </summary>
        /// <returns></returns>
        public string GetTotalFeesPaidOption2(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option2");

                // need to check
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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
                Logger.Trace("ENDED:  To Get Total Fees Paid Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption2;
        }
        /// <summary>
        /// 47
        /// </summary>
        /// <returns></returns>
        public string GetTotalAmountDueOption2(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option2");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalAmountDueOption2 = "N/A";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption2 = "N/A";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption2 = "N/A";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    TotalAmountDueOption2 = "null";

                else
                    TotalAmountDueOption2 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                   + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                Logger.Trace("ENDED:  To Get Total Amount Due Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption2;
        }
        /// <summary>
        /// 48
        /// </summary>
        /// <returns></returns>
        public string GetPrincipalOption3(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option3");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption3 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    PrincipalOption3 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption3 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption3 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    PrincipalOption3 = "null";
                else
                {
                    PrincipalOption3 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
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
        /// <summary>
        /// 51
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAssistanceAmountOption3(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option3");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption3 = "do not print the Assistance Amount line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption3 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption3 = "0.00";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    AssistanceAmountOption3 = "null";
                else
                {
                    AssistanceAmountOption3 = model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
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
        /// <summary>
        /// 52
        /// </summary>
        /// <returns></returns>
        public string GetReplacementReserveOption3(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option3");

                if ((Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
             - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
             - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
             + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption3 = "do not print the Replacement Reserve line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption3 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption3 = "0.00";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    ReplacementReserveOption3 = "null";
                else
                {
                    ReplacementReserveOption3 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                                                - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                                - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

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
        /// <summary>
        /// 54
        /// </summary>
        /// <returns></returns>
        public string GetOverduePaymentsOption3(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option3");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    OverduePaymentsOption2 = "null";
                else
                {
                    OverduePaymentsOption2 = Convert.ToString(Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToDecimal(GetTotalFeesPaidOption3(model)));
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
        /// <summary>
        /// 56
        /// </summary>
        /// <returns></returns>
        public string GetTotalFeesPaidOption3(AccountsModel model)
        {

            try
            {
                // need to check
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option3");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption3 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    TotalFeesPaidOption3 = "null";

                else if ((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption3 = Convert.ToString((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
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
        /// <summary>
        /// 57
        /// </summary>
        /// <returns></returns>
        public string GetTotalAmountDueOption3(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option3");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption3 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    TotalAmountDueOption3 = "N/A";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption3 = "N/A";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption3 = "N/A";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    TotalAmountDueOption3 = "null";

                else
                    TotalAmountDueOption2 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                                   + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));

                Logger.Trace("ENDED:  To Get Total Amount Due Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return TotalAmountDueOption3;
        }
        /// <summary>
        /// 58
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetPrincipalOption4(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Principal Option4");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption4 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                    PrincipalOption4 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption4 = "0.00";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    PrincipalOption4 = "0.00";
                else
                {
                    PrincipalOption4 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
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
        /// <summary>
        /// 61
        /// </summary>
        /// <returns></returns>
        public string GetAssistanceAmountOption4(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Assistance Amount Option4");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption4 = "do not print the Assistance Amount line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption4 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption4 = "0.00";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    AssistanceAmountOption4 = "0.00";
                else
                {
                    AssistanceAmountOption4 = model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
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
        /// <summary>
        /// 62
        /// </summary>
        /// <returns></returns>
        public string GetReplacementReserveOption4(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option4");

                if ((Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
           - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
           - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
           + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption4 = "do not print the Replacement Reserve line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption4 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption4 = "0.00";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    ReplacementReserveOption4 = "0.00";
                else
                {
                    ReplacementReserveOption4 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                                                - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                                                 - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

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
        /// <summary>
        /// 64
        /// </summary>
        /// <returns></returns>
        public string GetOverduePaymentsOption4(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Overdue Payments Option4");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption4 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption4 = "0.00";
                else
                {
                    OverduePaymentsOption4 = Convert.ToString(Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                     - Convert.ToDecimal(GetTotalFeesPaidOption4(model)));
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
        /// <summary>
        /// 66
        /// </summary>
        /// <returns></returns>
        public string GetTotalFeesPaidOption4(AccountsModel model)
        {
            // need to check

            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option4");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption4 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption4 = "0.00";

                else if ((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {
                    TotalFeesPaidOption4 = Convert.ToString((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
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
        /// <summary>
        /// 67
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalAmountDueOption4(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Amount Due Option4");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption4 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption4 = "N/A";

                else if (CommonHelper.GetFormatedDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    TotalAmountDueOption4 = Convert.ToString(Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                }
                else
                    TotalAmountDueOption4 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                                   + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToDecimal(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));

                Logger.Trace("ENDED:  To Get Total Amount Due Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption4;
        }
        /// <summary>
        /// 89
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSuspense(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execuate To Get Suspense");

                Suspense = Convert.ToString(Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
                  + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                  + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3)
                  + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04)
                  + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));

                Logger.Trace("ENDED:  To Get Suspense");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return Suspense;
        }
        /// <summary>
        /// 90
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetMiscellaneous(AccountsModel model)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Miscellaneous");

                Miscellaneous = Convert.ToString(
               Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData)
               + Convert.ToDecimal(model.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
                Logger.Trace("ENDED:  To Get Miscellaneous");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Miscellaneous;
        }
        /// <summary>
        /// 95
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetDeferredBalance(AccountsModel model)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Deferred Balance");

                    if ((model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal == "\0\0\0\0\0.\0\f" ? 0 : Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal)
                    - Convert.ToInt32(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)) == 0)

                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToInt32(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal)
                        - Convert.ToInt32(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
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

        public string GetHold(AccountsModel accountsModel)
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
        public string GetPrimaryBorrowerBKAttorney(AccountsModel accountsModel)
        {
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
        public string GetSecondaryBorrower(AccountsModel accountsModel)
        {

            try
            {
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
        public string GetMailingBKAttorneyAddressLine1(AccountsModel accountsModel)
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
        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountsModel)
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
        public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel)
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
        public string GetMailingCountry(AccountsModel accountsModel)
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
        public string GetPaymentDate(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Mailing Country");

                PaymentDate = accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte;

                Logger.Trace("ENDED:  To Get Mailing Country");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentDate;
        }

        public string GetInterestOption1(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption1 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    InterestOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption1 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                   CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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
        public string GetEscrowOption1(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Escrow Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption1 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    EscrowOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption1 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                    CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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
        public string GetRegularMonthlyPaymentOption1(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                    CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption1 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData;
                }
                Logger.Trace("ENDED:  Execute to Get Regular Monthly Payment Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RegularMonthlyPaymentOption1;
        }
        public string GetTotalFeesChargedOption1(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    TotalFeesChargedOption1 = "null";
                }
                else
                {
                    TotalFeesChargedOption1 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;
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


        public string GetInterestOption2(AccountsModel accountsModel)
        {

            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    InterestOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption2 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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
        public string GetEscrowOption2(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Escrow Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    EscrowOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption2 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                 CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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
        public string GetRegularMonthlyPaymentOption2(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                  CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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
        public string GetTotalFeesChargedOption2(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                  CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    TotalFeesChargedOption2 = "null";
                }
                else
                {
                    TotalFeesChargedOption2 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;

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

        public string GetInterestOption3(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption3 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    InterestOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption3 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                   CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    InterestOption3 = "null";
                }
                else
                {
                    InterestOption3 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

                }
                Logger.Trace("ENDED:  To Get Interest Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestOption3;

        }
        public string GetEscrowOption3(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Escrow Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption3 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    EscrowOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption3 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                    CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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
        public string GetRegularMonthlyPaymentOption3(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                    CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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
        public string GetTotalFeesChargedOption3(AccountsModel accountsModel)
        {
            try
            {

                Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option3");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                    CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    TotalFeesChargedOption3 = "null";
                }
                else
                {
                    TotalFeesChargedOption3 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;

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

        public string GetInterestOption4(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption4 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date)
                    > CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    InterestOption4 = "null";
                }
                else
                {
                    InterestOption4 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

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
        public string GetEscrowOption4(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Escrow Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption4 = "null";
                }
                else if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date)
                    > CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    EscrowOption4 = "null";
                }
                else
                {
                    EscrowOption4 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData;

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


        public string GetRegularMonthlyPaymentOption4(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption4 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption4 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;
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
        public string GetTotalFeesChargedOption4(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption4 = "null";
                }
                else
                {
                    TotalFeesChargedOption4 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;
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
        public string GetOption4MinimumDescription(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option4 Minimum Description");

                if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                    - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > 0)
                {
                    Option4MinimumDescription = "Your principal balance will decrease and you will be closer to paying off your loan. ";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) == 0)
                {
                    Option4MinimumDescription = "Your principal balance will stay the same and you will not be closer to paying off your loan.";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) < 0)
                {
                    Option4MinimumDescription = "Your principal balance will increase.You will be borrowing more money and losing equity in your home.";
                }
                else
                {
                    Option4MinimumDescription = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
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
        public string GetPostPetitonpastduemessage(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Post Petiton past due message");

                if (CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    PostPetitonpastduemessage = "We have not received all of your mortgage payments due since you filed for bankruptcy.";
                }
                Logger.Trace("ENDED:  To Get Post Petiton past due message");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PostPetitonpastduemessage;
        }
        public string GetPOBoxAddress(AccountsModel accountsModel)
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
        public string GetDate(AccountsModel accountsModel)
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
        public string GetAmount(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Amount");

                if (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
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
        public string GetBuydownBalance(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Buy down Balance");

                if (Convert.ToDecimal(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                {
                    BuydownBalance = "N/A";
                }
                else
                {
                    BuydownBalance = accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                }
                Logger.Trace("ENDED:  Execute to Get Buy down Balance");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return BuydownBalance;
        }
        public string GetPartialClaim(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Partial Claim");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
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
        public string GetInterestRateUntil(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Rate Until");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000)
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
        public string GetPrepaymentPenalty(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Pre payment Penalty");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                {
                    PrepaymentPenalty = "Yes";
                }
                else
                {
                    PrepaymentPenalty = "No";
                }
                Logger.Trace("ENDED:  To Get Pre payment Penalty");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrepaymentPenalty;
        }
        public string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Lender Placed Insurance Message");

                if ((Convert.ToDecimal(accountsModel.EscrowRecordModel.Rssi_Esc_Type) == 20
                || Convert.ToDecimal(accountsModel.EscrowRecordModel.Rssi_Esc_Type) == 21)
                && Convert.ToDecimal(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 2450
                && (Convert.ToDecimal(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 29000
                || Convert.ToDecimal(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 29005
                || Convert.ToDecimal(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 43000
                || Convert.ToDecimal(accountsModel.EscrowRecordModel.Rssi_Ins_Ag) == 43001))
                {
                    LenderPlacedInsuranceMessage = "Lender Placed Insurance message";
                }

                Logger.Trace("ENDED:  To Get Lender Placed Insurance Message");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return LenderPlacedInsuranceMessage;
        }
        public string GetStateNSF(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get State NSF");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6
                || Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 16
                || Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 18
                || Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 42)
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
        public string GetAutodraftMessage(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Auto draft Message");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0
                && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    AutodraftMessage = "Autodraft message";
                }

                Logger.Trace("ENDED:  To Get Auto draft Message");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AutodraftMessage;
        }
        public string GetCMSPartialClaim(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get CMS Partial Claim");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
                && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                {
                    CMSPartialClaim = "CMS Partial Claim Message.";
                }
                Logger.Trace("ENDED:   To Get CMS Partial Claim");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return CMSPartialClaim;
        }
        public string GetHUDPartialClaim(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get HUD Partial Claim");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
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
        public string GetStateDisclosures(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get State Disclosures");

                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "4"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "6"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "12"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "22"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "24"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "33"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "34"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "38"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "43"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "44"
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
        public string GetPaymentInformationMessage(AccountsModel accountsModel)
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
