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
        public string GetTotalFeesChargedOption4(AccountsModel model)
        {

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }

            return TotalFeesChargedOption4;
        }
        public string GetAmountDueOption1(AccountsModel model)
        {

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4));
            }
        }
        public string GetAmountDueOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3));
            } 
        }
        public string GetAmountDueOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                return "N/A";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2));
            } 
        }

        public string GetAmountDueOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1));
            } 
        }
        public string GetPrincipalOption1()
        {

            return PrincipalOption1;
        }

        public string GetOverduePaymentsOption1()
        {
            return OverduePaymentsOption1;
        }

        public string GetTotalFeesPaidOption1()
        {

            return TotalFeesPaidOption1;
        }
        public string GetTotalAmountDueOption1()
        {

            return TotalAmountDueOption1;
        }
        public string GetPrincipalOption2()
        {

            return PrincipalOption2;
        }
        public string GetAssistanceAmountOption2()
        {

            return AssistanceAmountOption2;
        }
        public string GetReplacementReserveOption2()
        {

            return ReplacementReserveOption2;
        }
        public string GetOverduePaymentsOption2()
        {

            return OverduePaymentsOption2;
        }

        public string GetTotalFeesPaidOption2(AccountsModel model)
        {

            return TotalFeesPaidOption2;
        }
        public string GetTotalAmountDueOption2(AccountsModel model)
        {

            return TotalAmountDueOption2;
        }

        public string GetPrincipalOption3(AccountsModel model)
        {

            return PrincipalOption3;
        }
        public string GetAssistanceAmountOption3(AccountsModel model)
        {

            return AssistanceAmountOption3;
        }
        public string GetReplacementReserveOption3(AccountsModel model)
        {

            return ReplacementReserveOption3;
        }
        public string GetOverduePaymentsOption3(AccountsModel model)
        {

            return OverduePaymentsOption3;
        }
        public string GetTotalFeesPaidOption3(AccountsModel model)
        {

            return TotalFeesPaidOption3;
        }
        public string GetTotalAmountDueOption3(AccountsModel model)
        {
            return TotalAmountDueOption3;
        }
        public string GetPrincipalOption4(AccountsModel model)
        {

            return PrincipalOption4;
        }
        public string GetAssistanceAmountOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
            {
                // then do not print the Assistance Amount line.
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }
            return AssistanceAmountOption4;
        }
        public string GetReplacementReserveOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1) -
                Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount1) -
                Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment) +
                Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
            {
                // then do not print the Replacement Reserve line.
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }

            return ReplacementReserveOption4;
        }
        public string GetOverduePaymentsOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }
            else
            {
                return "0.00";
                //re  Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) -
                //  Convert.ToInt64(model.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement) -
                //  Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement) -



            }

//RSSI-BILL-TOTAL-DUE
 // minus
//RSSI-FEES-ASSESSED-SINCE-LST-STMT
//  minus
//RSSI-ACCR-LC
//minus
//Total Fees Paid"


            return OverduePaymentsOption4;
        }

        public string GetTotalFeesPaidOption4(AccountsModel model)
        {
            var TotalFeeCharged = Convert.ToInt64(model.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement);

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
             return   TotalFeesPaidOption4 = "0";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return TotalFeesPaidOption4 = "0";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)
                < Convert.ToInt64(TotalFeeCharged))
            {
                return TotalFeesPaidOption4 = Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)
                - Convert.ToInt64(TotalFeeCharged));
            }
            else
            {
                return TotalFeesPaidOption4 = "0";
            }
        }
        public string GetTotalAmountDueOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) +
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1));
            }
        }

        public string GeUnappliedFundsPaidLastMonth(AccountsModel model)
        {

            return UnappliedFundsPaidLastMonth;
        }

        public string GetFeesandChargesPaidYeartoDate(AccountsModel model)
        {

            return FeesandChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel model)
        {

            return UnappliedFundsPaidYearToDate;
        }
        public string GeSuspense(AccountsModel model)
        {
            return Convert.ToString(Convert.ToInt64(model.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds) +
                  Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds2) +
                  Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds3) +
                  Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds4) +
                  Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds5));
        }

        public string GetMiscellaneous(AccountsModel model)
        {
            return Convert.ToString(Convert.ToInt64(model.TransactionRecordModel.TransactionAmountConstructionBalance) +
               Convert.ToInt64(model.TransactionRecordModel.TransactionAmountOptionalInsurance) +
               Convert.ToInt64(model.TransactionRecordModel.TransactionAmountToP_IShortage) +
               Convert.ToInt64(model.TransactionRecordModel.TransactionAmountPostedToDeferredPrincipal) +
               Convert.ToInt64(model.TransactionRecordModel.TranAmountToDeferredInterest) +
               Convert.ToInt64(model.TransactionRecordModel.TranAmountToDeferredLateCharge) +
               Convert.ToInt64(model.TransactionRecordModel.TranAmountToDeferredEscrowAdv) +
               Convert.ToInt64(model.TransactionRecordModel.TranAmountToDeferredPaidExpensesAdv) +
               Convert.ToInt64(model.TransactionRecordModel.TranAmountToDeferredUnpaidExpenseAdv) +
               Convert.ToInt64(model.TransactionRecordModel.TranAmountToDeferredAdminFees) +
               Convert.ToInt64(model.TransactionRecordModel.OptionalDeferredAmount));
        }
        public string GetTotalDue(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                return "0.00";

            return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) + Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1));
        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel model)
        {

            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFunds(AccountsModel model)
        {

            return UnappliedFunds;
        }
        public string GetPastDueBalance(AccountsModel model)
        {

            return PastDueBalance;
        }
        public string GetTotalPaidYearToDate(AccountsModel model)
        {

            return TotalPaidYearToDate;
        }
        public string GetAssistanceAmountOption1(AccountsModel model)
        {

            return AssistanceAmountOption1;
        }
        public string GetReplacementReserveOption1(AccountsModel model)
        {

            return ReplacementReserveOption1;
        }
        public string GetMinimumLatePaymentAmount(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) +
                Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1) +
                Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeAmount));
            }
        }
        public string GetTotalFeesChargedOption3(AccountsModel model)
        {

            return TotalFeesChargedOption3;
        }
        public string GetTotalFeesChargedOption2(AccountsModel model)
        {

            return TotalFeesChargedOption2;
        }
    }
}
