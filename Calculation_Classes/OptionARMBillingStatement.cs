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



        /* While Calculating Conditions must be applied*/

        public string GetTotalFeesChargedOption1(AccountsModel accountsModel)
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

            return TotalFeesChargedOption1;
        }
        public string GetDeferredBalance(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                    Convert.ToInt64(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
            }
        }
        public string GetTotalFeesChargedOption4(AccountsModel accountsModel)
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
            return TotalFeesChargedOption4;
        }
        public string GetAmountDueOption1(AccountsModel model)
        {

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
            }
        }
        public string GetAmountDueOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));
            }
        }
        public string GetAmountDueOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
            }
        }

        public string GetAmountDueOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
            }
        }
        public string GetPrincipalOption1(AccountsModel model)
        {

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
            {
                return null;
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
            {
                return null;
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return null;
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData) -
                                        Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
            }
        }

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

            else
            {
                //not found total fees paid
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
            }
            return OverduePaymentsOption1;
        }

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

            else
                TotalAmountDueOption1 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                               + Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));

            return TotalAmountDueOption1;
        }
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


            else
            {
                PrincipalOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
            }
            return PrincipalOption2;
        }
        public string GetAssistanceAmountOption2(AccountsModel model)
        {

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
            return AssistanceAmountOption2;
        }
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
                ReplacementReserveOption2 = "0.00";

            else
            {
                ReplacementReserveOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                            - Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                            - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                            + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

            }
            return ReplacementReserveOption2;
        }
        public string GetOverduePaymentsOption2(AccountsModel model)
        {
            //what is - Total Fees Paid

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
            return OverduePaymentsOption2;
        }

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

            else
                TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                               + Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));

            return TotalAmountDueOption2;
        }

        public string GetPrincipalOption3(AccountsModel model)
        {

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
            return PrincipalOption3;
        }
        public string GetAssistanceAmountOption3(AccountsModel model)
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
        public string GetReplacementReserveOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) -
                Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData) -
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
                return Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) -
                                         Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData) -
                                          Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                                         Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
            }
        }
        public string GetOverduePaymentsOption3(AccountsModel accountsModel)
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
            return OverduePaymentsOption3;
        }
        public string GetTotalFeesPaidOption3(AccountsModel accountsModel)
        {
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
            return TotalFeesPaidOption3;
        }
        public string GetTotalAmountDueOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
            {
                return "Option Not Available";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
            {
                return "Option Not Available";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "Option Not Available";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
            }
        }
        public string GetPrincipalOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData) - Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
            }
        }
        public string GetAssistanceAmountOption4(AccountsModel model)
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
                return Convert.ToString(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData);
            }
        }
        public string GetReplacementReserveOption4(AccountsModel model)
        {
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

            return ReplacementReserveOption4;
        }
        public string GetOverduePaymentsOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "0.00";
            }
            else
            {
                return
                Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                    Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
                    Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData) -
                 Convert.ToInt64(GetTotalFeesPaidOption3(model)));
            }

        }

        public string GetTotalFeesPaidOption4(AccountsModel model)
        {
            var TotalFeeCharged = Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return TotalFeesPaidOption4 = "0";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return TotalFeesPaidOption4 = "0";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                < Convert.ToInt64(TotalFeeCharged))
            {
                return TotalFeesPaidOption4 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                - Convert.ToInt64(GetTotalFeesChargedOption4(model)));
            }
            else
            {
                return TotalFeesPaidOption4 = "0";
            }
        }
        public string GetTotalAmountDueOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
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
    }
}
