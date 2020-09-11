using ODHS_EDelivery.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.Calculation_Classes
{
    public class ChapterThirteenOptionARMStatement
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

/* While Calculating Conditions must be applied*/
/// <summary>
/// 11
/// </summary>
/// <param name="model"></param>
/// <returns></returns>
public string GetAmountDueOption1(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AmountDueOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                AmountDueOption1 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                AmountDueOption1 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AmountDueOption1 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                AmountDueOption1 = "N/A";
            else
            {
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                 + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                 + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AmountDueOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                AmountDueOption2 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                AmountDueOption2 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AmountDueOption2 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                AmountDueOption2 = "N/A";

            else
            {
                AmountDueOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                           + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                           + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
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

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AmountDueOption3 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                AmountDueOption3 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                AmountDueOption3 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AmountDueOption3 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                AmountDueOption3 = "N/A";

            else
            {
                AmountDueOption3 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                           + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                           + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
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

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AmountDueOption3 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AmountDueOption3 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                AmountDueOption4 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                            + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
            }

            else
            {
                AmountDueOption4 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                          + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                          + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
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
            if ((Convert.ToInt64(model.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(model.TransactionRecordModel.Rssi_Log_Tran) == 5707)
              &&
              (Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {
                FeesandChargesPaidLastMonth = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData))
                - Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
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
            FeesandChargesPaidLastMonth = Convert.ToString(Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
           + Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
           + Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3)
           + Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04)
           + Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));

            return UnappliedFundsPaidLastMonth;
        }
        /// <summary>
        /// 25
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetFeesandChargesPaidYearToDate(AccountsModel model)
        {
            if ((Convert.ToInt64(model.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(model.TransactionRecordModel.Rssi_Log_Tran) == 5707)
              &&
              (Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {
                FeesandChargesPaidLastMonth = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData))
                - Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
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
            //need to check logic

            UnappliedFundsPaidYearToDate = Convert.ToString(model.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
           + model.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
           + model.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
           + model.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
           + model.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);

            return UnappliedFundsPaidYearToDate;
        }
        /// <summary>
        /// 27
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalPaidYearToDate(AccountsModel model)
        {
            if ((Convert.ToInt64(model.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(model.TransactionRecordModel.Rssi_Log_Tran) == 5707)
               &&
               (Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {
                TotalPaidYearToDate = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
           + model.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
           + model.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
           + model.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
           + model.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
           + model.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0)
           - Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                PrincipalOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                PrincipalOption1 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                PrincipalOption1 = "null";
            else
            {
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                AssistanceAmountOption1 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AssistanceAmountOption1 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AssistanceAmountOption1 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                AssistanceAmountOption1 = "null";
            else
            {
                AssistanceAmountOption1 = model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
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
            if ((Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
               - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
               + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                ReplacementReserveOption1 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                ReplacementReserveOption1 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                ReplacementReserveOption1 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                ReplacementReserveOption1 = "null";
            else
            {
                ReplacementReserveOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                            - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                          - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                            + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AmountDueOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                AmountDueOption1 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                AmountDueOption1 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AmountDueOption1 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                AmountDueOption1 = "null";
            else
            {
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                 - Convert.ToInt64(GetTotalFeesPaidOption1(model)));
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
            // need to check
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                TotalFeesPaidOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                TotalFeesPaidOption1 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                TotalFeesPaidOption1 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                TotalFeesPaidOption1 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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

            return TotalFeesPaidOption1;
        }
        /// <summary>
        /// 37
        /// </summary>
        /// <returns></returns>
        public string GetTotalAmountDueOption1(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                TotalFeesPaidOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                TotalFeesPaidOption1 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                TotalFeesPaidOption1 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                TotalFeesPaidOption1 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                TotalFeesPaidOption1 = "null";

            else
                TotalAmountDueOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));

            return TotalAmountDueOption1;
        }
        /// <summary>
        /// 38
        /// </summary>
        /// <returns></returns>
        public string GetPrincipalOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                PrincipalOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                PrincipalOption2 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                PrincipalOption2 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                PrincipalOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                PrincipalOption2 = "null";
            else
            {
                PrincipalOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
            }
            return PrincipalOption2;
        }
        /// <summary>
        /// 41m
        /// </summary>
        /// <returns></returns>
        public string GetAssistanceAmountOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                AssistanceAmountOption2 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AssistanceAmountOption2 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AssistanceAmountOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                AssistanceAmountOption2 = "null";
            else
            {
                AssistanceAmountOption2 = model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
            }
            return AssistanceAmountOption2;
        }
        /// <summary>
        /// 42
        /// </summary>
        /// <returns></returns>
        public string GetReplacementReserveOption2(AccountsModel model)
        {
            if ((Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
              - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
              - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
              + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                ReplacementReserveOption2 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                ReplacementReserveOption2 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                ReplacementReserveOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                ReplacementReserveOption2 = "null";
            else
            {
                ReplacementReserveOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                            - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                            - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                            + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

            }
            return ReplacementReserveOption2;
        }
        /// <summary>
        /// 44
        /// </summary>
        /// <returns></returns>
        public string GetOverduePaymentsOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                OverduePaymentsOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                OverduePaymentsOption2 = "null";
            else
            {
                OverduePaymentsOption2 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                 - Convert.ToInt64(GetTotalFeesPaidOption2(model)));
            }
            return OverduePaymentsOption2;
        }
        /// <summary>
        /// 46
        /// </summary>
        /// <returns></returns>
        public string GetTotalFeesPaidOption2(AccountsModel model)
        {
            // need to check
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                TotalFeesPaidOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                TotalFeesPaidOption2 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                TotalFeesPaidOption2 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                TotalFeesPaidOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
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

            return TotalFeesPaidOption2;
        }
        /// <summary>
        /// 47
        /// </summary>
        /// <returns></returns>
        public string GetTotalAmountDueOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                TotalAmountDueOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                TotalAmountDueOption2 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                TotalAmountDueOption2 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                TotalAmountDueOption2 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                TotalAmountDueOption2 = "null";

            else
                TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));

            return TotalAmountDueOption2;
        }
        /// <summary>
        /// 48
        /// </summary>
        /// <returns></returns>
        public string GetPrincipalOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                PrincipalOption3 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                PrincipalOption3 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                PrincipalOption3 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                PrincipalOption3 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                PrincipalOption3 = "null";
            else
            {
                PrincipalOption3 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                AssistanceAmountOption3 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AssistanceAmountOption3 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AssistanceAmountOption3 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                AssistanceAmountOption3 = "null";
            else
            {
                AssistanceAmountOption3 = model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
            }
            return AssistanceAmountOption3;
        }
        /// <summary>
        /// 52
        /// </summary>
        /// <returns></returns>
        public string GetReplacementReserveOption3(AccountsModel model)
        {
            if ((Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
             - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
             - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
             + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                ReplacementReserveOption3 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                ReplacementReserveOption3 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                ReplacementReserveOption3 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                ReplacementReserveOption3 = "null";
            else
            {
                ReplacementReserveOption3 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                                            - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                            - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                            + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

            }
            return ReplacementReserveOption3;
        }
        /// <summary>
        /// 54
        /// </summary>
        /// <returns></returns>
        public string GetOverduePaymentsOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                OverduePaymentsOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                OverduePaymentsOption2 = "null";
            else
            {
                OverduePaymentsOption2 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                 - Convert.ToInt64(GetTotalFeesPaidOption3(model)));
            }
            return OverduePaymentsOption3;
        }
        /// <summary>
        /// 56
        /// </summary>
        /// <returns></returns>
        public string GetTotalFeesPaidOption3(AccountsModel model)
        {
            // need to check
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                TotalFeesPaidOption3 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                TotalFeesPaidOption3 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                TotalFeesPaidOption3 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                TotalFeesPaidOption3 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                TotalFeesPaidOption3 = "null";

            else if ((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                      + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                       Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
            {
                TotalFeesPaidOption3 = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                    + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                    - Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
            }
            else
                TotalFeesPaidOption3 = "0.00";
            return TotalFeesPaidOption3;
        }
        /// <summary>
        /// 57
        /// </summary>
        /// <returns></returns>
        public string GetTotalAmountDueOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                TotalAmountDueOption3 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                TotalAmountDueOption3 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                TotalAmountDueOption3 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                TotalAmountDueOption3 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                TotalAmountDueOption3 = "null";

            else
                TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));

            return TotalAmountDueOption3;
        }
        /// <summary>
        /// 58
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetPrincipalOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                PrincipalOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                PrincipalOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                PrincipalOption4 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                PrincipalOption4 = "0.00";
            else
            {
                PrincipalOption4 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
            }
            return PrincipalOption4;
        }
        /// <summary>
        /// 61
        /// </summary>
        /// <returns></returns>
        public string GetAssistanceAmountOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                AssistanceAmountOption4 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AssistanceAmountOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AssistanceAmountOption4 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                AssistanceAmountOption4 = "0.00";
            else
            {
                AssistanceAmountOption4 = model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
            }
            return AssistanceAmountOption4;
        }
        /// <summary>
        /// 62
        /// </summary>
        /// <returns></returns>
        public string GetReplacementReserveOption4(AccountsModel model)
        {
            if ((Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
            - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
            - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
            + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                ReplacementReserveOption4 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                ReplacementReserveOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                ReplacementReserveOption4 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                ReplacementReserveOption4 = "0.00";
            else
            {
                ReplacementReserveOption4 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                                            - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                                             - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                            + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

            }
            return ReplacementReserveOption4;
        }
        /// <summary>
        /// 64
        /// </summary>
        /// <returns></returns>
        public string GetOverduePaymentsOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                OverduePaymentsOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                OverduePaymentsOption4 = "0.00";
            else
            {
                OverduePaymentsOption4 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                 - Convert.ToInt64(GetTotalFeesPaidOption4(model)));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                TotalFeesPaidOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                TotalFeesPaidOption4 = "0.00";

            else if ((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                      + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                       Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
            {
                TotalFeesPaidOption4 = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                    + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                    - Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData)));
            }
            else
                TotalFeesPaidOption4 = "0.00";
            return TotalFeesPaidOption4;
        }
        /// <summary>
        /// 67
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalAmountDueOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                TotalAmountDueOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                TotalAmountDueOption4 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(model.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                TotalAmountDueOption4 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
            }
            else
                TotalAmountDueOption4 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
            return TotalAmountDueOption4;
        }
        /// <summary>
        /// 89
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSuspense(AccountsModel model)
        {
            Suspense = Convert.ToString((Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
                   + Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                   + Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3)
                   + Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04)
                   + Convert.ToInt64(model.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05)));
            return Suspense;
        }
        /// <summary>
        /// 90
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetMiscellaneous(AccountsModel model)
        {
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
            return Miscellaneous;
        }
        /// <summary>
        /// 95
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetDeferredBalance(AccountsModel model)
        {
            if ((Convert.ToInt32(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal)
                - Convert.ToInt32(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)) == 0)
            {
                DeferredBalance = "N/A";
            }
            else
            {
                DeferredBalance = Convert.ToString(Convert.ToInt32(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal)
                    - Convert.ToInt32(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
            }
            return DeferredBalance;
        }

        public string GetHold(AccountsModel accountsModel)
        {
            if (accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
            {
                Hold = "create image but do not mail";
            }
            else
            {
                Hold = accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt;
            }
            return Hold;
        }
        public string GetPrimaryBorrowerBKAttorney(AccountsModel accountsModel)
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

            //If RSSI-POC - STATEMENT - FLAG = Y, then copy 1 to RSSI-PRIMARY - NAME and copy 2 to
            //RSSI - VEND - NAME1"

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
            return MailingBKAttorneyAddressLine1;
        }
        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountsModel)
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
            return MailingBKAttorneyAddressLine2;
        }
        public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel)
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
            return BorrowerAttorneyMailingCityStateZip;
        }
        public string GetMailingCountry(AccountsModel accountsModel)
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
            return MailingCountry;
        }
        public string GetPaymentDate(AccountsModel accountsModel)
        {

            PaymentDate = accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte;
            return PaymentDate;
        }

        public string GetInterestOption1(AccountsModel accountsModel)
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
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
               Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                InterestOption1 = "null";
            }
            else
            {
                InterestOption1 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;
            }
            return InterestOption1;
        }
        public string GetEscrowOption1(AccountsModel accountsModel)
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
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                EscrowOption1 = "null";
            }
            else
            {
                EscrowOption1 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

            }
            return EscrowOption1;
        }
        public string GetRegularMonthlyPaymentOption1(AccountsModel accountsModel)
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
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
          Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                RegularMonthlyPaymentOption1 = "null";
            }
            else
            {
                RegularMonthlyPaymentOption1 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData;
            }
            return RegularMonthlyPaymentOption1;
        }
        public string GetTotalFeesChargedOption1(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                TotalFeesChargedOption1 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
            {
                TotalFeesChargedOption1 = "null";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
            {
                TotalFeesChargedOption1 = "null";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                TotalFeesChargedOption1 = "null";
            }
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
          Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                TotalFeesChargedOption1 = "null";
            }
            else
            {
                TotalFeesChargedOption1 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;
            }
            return TotalFeesChargedOption1;
        }


        public string GetInterestOption2(AccountsModel accountsModel)
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
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
            Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                InterestOption2 = "null";
            }
            else
            {
                InterestOption2 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

            }
            return InterestOption2;
        }
        public string GetEscrowOption2(AccountsModel accountsModel)
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
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
             Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                EscrowOption2 = "null";
            }
            else
            {
                EscrowOption2 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

            }
            return EscrowOption2;
        }
        public string GetRegularMonthlyPaymentOption2(AccountsModel accountsModel)
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
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
              Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                RegularMonthlyPaymentOption2 = "null";
            }
            else
            {
                RegularMonthlyPaymentOption2 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData;

            }
            return RegularMonthlyPaymentOption2;
        }
        public string GetTotalFeesChargedOption2(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                TotalFeesChargedOption2 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
            {
                TotalFeesChargedOption2 = "null";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
            {
                TotalFeesChargedOption2 = "null";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                TotalFeesChargedOption2 = "null";
            }
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
              Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                TotalFeesChargedOption2 = "null";
            }
            else
            {
                TotalFeesChargedOption2 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;

            }
            return TotalFeesChargedOption2;
        }

        public string GetInterestOption3(AccountsModel accountsModel)
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
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
               Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                InterestOption3 = "null";
            }
            else
            {
                InterestOption3 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

            }
            return InterestOption3;

        }
        public string GetEscrowOption3(AccountsModel accountsModel)
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
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                EscrowOption3 = "null";
            }
            else
            {
                EscrowOption3 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

            }
            return EscrowOption3;
        }
        public string GetRegularMonthlyPaymentOption3(AccountsModel accountsModel)
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
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                RegularMonthlyPaymentOption3 = "null";
            }
            else
            {
                RegularMonthlyPaymentOption3 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData;

            }
            return RegularMonthlyPaymentOption3;
        }
        public string GetTotalFeesChargedOption3(AccountsModel accountsModel) {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                TotalFeesChargedOption3 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
            {
                TotalFeesChargedOption3 = "null";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
            {
                TotalFeesChargedOption3 = "null";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                TotalFeesChargedOption3 = "null";
            }
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                TotalFeesChargedOption3 = "null";
            }
            else
            {
                TotalFeesChargedOption3 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;

            }
            return TotalFeesChargedOption3; 
        }

        public string GetInterestOption4(AccountsModel accountsModel) {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                InterestOption4 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                InterestOption4 = "null";
            }
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
           Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                InterestOption4 = "null";
            }
            else
            {
                InterestOption4 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

            }
            return InterestOption4; 
        }
        public string GetEscrowOption4(AccountsModel accountsModel) {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                EscrowOption4 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                EscrowOption4 = "null";
            }
            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
           Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                EscrowOption4 = "null";
            }
            else
            {
                EscrowOption4 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData;

            }
            return EscrowOption4; 
        }
        public string GetRegularMonthlyPaymentOption4(AccountsModel accountsModel) {

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
                RegularMonthlyPaymentOption4 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;

            }
            return RegularMonthlyPaymentOption4;
        }
        public string GetTotalFeesChargedOption4(AccountsModel accountsModel) {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                TotalFeesChargedOption4 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                TotalFeesChargedOption4 = "null";
            }
            else
            {
                TotalFeesChargedOption4 = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData;

            }
            return TotalFeesChargedOption4; 
        }

        public string GetOption4MinimumDescription(AccountsModel accountsModel) {
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
            return Option4MinimumDescription;
        }
        public string GetPostPetitonpastduemessage(AccountsModel accountsModel) {
            if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
            {
                PostPetitonpastduemessage = "We have not received all of your mortgage payments due since you filed for bankruptcy.";
            }
            return PostPetitonpastduemessage; 
        }
        public string GetPOBoxAddress(AccountsModel accountsModel) {
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
            return POBoxAddress;
        }
        public string GetDate(AccountsModel accountsModel)
        {

            if (accountsModel.FeeRecordModel.Rssi_Fd_Fee_Type == "000")
            {
                Date = accountsModel.FeeRecordModel.Rssi_Fd_Assess_Date;
            }
            else
            {
                Date = accountsModel.TransactionRecordModel.Rssi_Tr_Date_PackedData;
            }
            return Date;
        }
        public string GetAmount(AccountsModel accountsModel)
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
            return Amount;
        }
        public string GetBuydownBalance(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
            {
                BuydownBalance = "N/A";
            }
            else
            {
                BuydownBalance = accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
            }
            return BuydownBalance;
        }
        public string GetPartialClaim(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
            {
                PartialClaim = "N/A";
            }
            else
            {
                PartialClaim = accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;
            }
            return PartialClaim;
        }
        public string GetInterestRateUntil(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000)
            {
                InterestRateUntil = "(Until RSSI-RATE-CHG-DATE)";
            }
            else
            {
                InterestRateUntil = "null";
            }
            return InterestRateUntil;
        }
        public string GetPrepaymentPenalty(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
            {
                PrepaymentPenalty = "Yes";
            }
            else
            {
                PrepaymentPenalty = "No";
            }
            return PrepaymentPenalty;
        }
        public string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel)
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
            return LenderPlacedInsuranceMessage;
        }
        public string GetStateNSF(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6
                || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 16
                || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 18
                || Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 42
                )
            {
                StateNSF = "State NSF message";
            }
            return StateNSF;
        }
        public string GetAutodraftMessage(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0
                && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
            {
                AutodraftMessage = "Autodraft message";
            }
            return AutodraftMessage;
        }
        public string GetCMSPartialClaim(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
                && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
            {
                CMSPartialClaim = "CMS Partial Claim Message.";
            }
            return CMSPartialClaim;
        }
        public string GetHUDPartialClaim(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
             && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
            {
                HUDPartialClaim = "HUD Partial Claim Message.";
            }
            return HUDPartialClaim;
        }
        public string GetStateDisclosures(AccountsModel accountsModel)
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
            return StateDisclosures;
        }
        public string GetPaymentInformationMessage(AccountsModel accountsModel)
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
            return PaymentInformationMessage;
        }
    }
}
