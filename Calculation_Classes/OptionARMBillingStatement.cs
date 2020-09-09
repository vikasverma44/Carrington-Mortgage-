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

        public string GetTotalFeesChargedOption1(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)  //If RSSI-PRIN-BAL = 0, then ""0.00""
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0) //If RSSI-ALT-PYMT4 = 0, then null
            {
                return null;
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))   //If RSSI-ALT-PYMT4 < RSSI-ALT-PYMT1, then null
            {
                return null;
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)//If RSSI-BILL-PMT-AMT = 0, then null"
            {
                return null;
            }
            else
            {

            }
            //If RSSI-PRIN-BAL = 0, then ""0.00""
            //If RSSI-ALT-PYMT4 = 0, then null
            //If RSSI-ALT-PYMT4 < RSSI-ALT-PYMT1, then null
            //If RSSI-BILL-PMT-AMT = 0, then null"


            //RSSI-FEES-ASSESSED-SINCE-LST-STMT   Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidSinceLastStatement)
            // plus
            //RSSI-ACCR-LC          Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement)
            //minus
            //(RSSI-TR-AMT          Convert.ToInt64(model.TransactionRecordModel.TransactionAmount

            //where RSSI-LOG-TRAN = 5605 and  Convert.ToInt64(model.TransactionRecordModel.LogTransaction)
            //RSSI-TR-FEE-CODE = 67)          Convert.ToInt64(model.TransactionRecordModel.FeeCode)
            // minus
            //(RSSI-TR-AMT                    Convert.ToInt64(model.TransactionRecordModel.TransactionAmount)
            //where RSSI-LOG-TRAN = 5605 or 5707 and Convert.ToInt64(model.TransactionRecordModel.LogTransaction)
            //RSSI-TR-FEE-CODE = 198)         Convert.ToInt64(model.TransactionRecordModel.FeeCode)


            return "";
        }
        public string GetDeferredBalance(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart2Model.TotalDeferredItemsBalance) -
                Convert.ToInt64(model.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance) == 0)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart2Model.TotalDeferredItemsBalance) -
                    Convert.ToInt64(model.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance));
            }
        }
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
        public string GetPrincipalOption1(AccountsModel model)
        {

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
            {
                return null;
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                return null;
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return null;
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount4) -
                                        Convert.ToInt64(model.MasterFileDataPart_1Model.InterestOnPymtDue));
            }
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
            {
                return "then do not print the Assistance Amount line.";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount));
            }
        }
        public string GetReplacementReserveOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) -
                Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount2) -
                Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment) +
                Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
            {
                return "then do not print the Replacement Reserve line.";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) -
                                         Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount2) -
                                         Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment) +
                                         Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount));
            }
        }
        public string GetOverduePaymentsOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)  //If RSSI-PRIN-BAL = 0, then ""0.00""
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0) //RSSI-ALT-PYMT2
            {
                return null;
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1)) //RSSI-ALT-PYMT1
            {
                return null;
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return null;
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) -
                                        Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidSinceLastStatement) -
                                        Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement) -
                                        Convert.ToInt64(GetTotalFeesPaidOption3(model)));
            }
        }
        public string GetTotalFeesPaidOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)  //If RSSI-PRIN-BAL = 0, then ""0.00""
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0) //RSSI-ALT-PYMT2
            {
                return null;
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1)) //RSSI-ALT-PYMT1
            {
                return null;
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)//If RSSI-BILL-PMT-AMT = 0, then null"
            {
                return null;
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)+
                Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)
                    < Convert.ToInt64(GetTotalFeesChargedOption3(model)))
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable) +
                Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue) -
                Convert.ToInt64(GetTotalFeesChargedOption3(model)));
            }
            else
            {
                return "0.00";
            }
           // Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable) RSSI-FEES-NEW
       
            //If(RSSI-FEES-NEW(+) RSSI-LATE-CHG-DUE) < Total Fees Charged then
            //RSSI - FEES - NEW(+)  RSSI - LATE - CHG - DUE(-) Total Fees Charged 
            //else 0.00 ??

            //RSSI-FEES-NEW
            //RSSI - LATE - CHG - DUE
            //RSSI - FEES - ASSD - SINCE - LST - STMT
            //RSSI - ACCR - LC
            //Total Fees Charged 
        }
        public string GetTotalAmountDueOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
            {
                return "Option Not Available";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                return "Option Not Available";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "Option Not Available";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) -
                    Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2));
            }
        }
        public string GetPrincipalOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.InterestOnPymtDue) > Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount1))
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount1) - Convert.ToInt64(model.MasterFileDataPart_1Model.InterestOnPymtDue));
            }
        }
        public string GetAssistanceAmountOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
            {
                return "then do not print the Assistance Amount line.";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount);
            }
        }
        public string GetReplacementReserveOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1) -
                Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount1) -
                Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment) +
                Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
            {
                return "then do not print the Replacement Reserve line.";
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
                return 
                Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) -
                    Convert.ToInt64(model.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement) -
                    Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement) -
                 Convert.ToInt64(GetTotalFeesPaidOption3(model))); 
            }

        }

        public string GetTotalFeesPaidOption4(AccountsModel model)
        {
            var TotalFeeCharged = Convert.ToInt64(model.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement);

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return TotalFeesPaidOption4 = "0";
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
                - Convert.ToInt64(GetTotalFeesChargedOption4(model)));
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
            return "";


        }

        public string GetFeesandChargesPaidYeartoDate(AccountsModel model)
        {
            return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidYTD) +
                                    Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesPaidYTD));
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel model)
        {
            return GetUnappliedFunds(model);
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

            return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidSinceLastStatement) +
              Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesPaidSinceLastStatement));
        }
        public string GetUnappliedFunds(AccountsModel model)
        {


            //RSSI-ESC-VAR          (If RSSI-UNAP-FUND-CD <> ""L"")
            // plus
            //RSSI - UNAPL - BAL - 2(If RSSI-UNAP-CD -2 <> ""L"")
            // plus
            //RSSI - UNAPL - BAL - 3(If RSSI-UNAP-CD-3 <> ""L"")
            // plus
            //RSSI - UNAPL - BAL - 4(If RSSI-UNAP-CD-4 <> ""L"")
            // plus
            //RSSI-UNAP-BAL-5       (If RSSI-UNAP-CD-5 <> ""L"")"

            //   Convert.ToInt64(model.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) +   //RSSI-ESC-VAR 
            //   Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds2) +//RSSI-UNAP-BAL-2
            //   Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds3) +//RSSI-UNAP-BAL-3
            //   Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds4) +//RSSI-UNAP-BAL-4
            //   Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds5));//RSSI-UNAP-BAL-5
            //
            //  Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsCode5) //RSSI-UNAP-CD-5
            //  Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsCode4) //RSSI-UNAP-CD-4
            //  Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsCode3) //RSSI-UNAP-CD-3
            //  Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsCode2) //RSSI-UNAP-CD-2
            //
            //      Convert.ToInt64(model.MasterFileDataPart_1Model.UnappliedFundsCodeFirst //RSSI-UNAP-FUND-CD

            return UnappliedFunds;
        }
        public string GetPastDueBalance(AccountsModel model)
        {
            return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PastDueAmtTotalDue) -
              Convert.ToInt64(model.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement) -
              Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement));
        }
        public string GetTotalPaidYearToDate(AccountsModel model)
        {
            //RSSI-PRIN-PAID-YTD
            //plus
            //RSSI-INT-PD-YTD
            // plus
            //RSSI-ESC-PAID-YTD
            //plus
            //RSSI-FEES-PAID-YTD
            // plus
            //RSSI-LATE-CHG-PAID-YTD
            // plus
            //RSSI-ESC-VAR(If RSSI-UNAP-FUND-CD <> ""L"")
            // plus
            //RSSI-UNAPL-BAL-2(If RSSI-UNAP-CD-2 <> ""L"")
            // plu
            //RSSI-UNAPL-BAL-3(If RSSI-UNAP-CD-3 <> ""L"")
            //plus
            //RSSI-UNAPL-BAL-4(If RSSI-UNAP-CD-4 <> ""L"")
            //plu
            //RSSI-UNAPL-BAL-5(If RSSI-UNAP-CD-5 <> ""L"")"



            // Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalPaidYTD  //RSSI-PRIN-PAID-YTD
            // Convert.ToInt64(model.MasterFileDataPart_1Model.InterestPaidYearToDate  //RSSI-INT-PD-YTD
            // Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPaidYTD   //RSSI-ESC-PAID-YTD
            // Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidYTD //RSSI-FEES-PAID-YTD
            // Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesPaidYTD) //RSSI-LATE-CHG-PAID-YTD
            // Convert.ToInt64(model.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) +   //RSSI-ESC-VAR 
            // Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds2) +//RSSI-UNAP-BAL-2
            // Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds3) +//RSSI-UNAP-BAL-3
            // Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds4) +//RSSI-UNAP-BAL-4
            // Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds5));//RSSI-UNAP-BAL-5

            // Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsCode5) //RSSI-UNAP-CD-5
            // Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsCode4) //RSSI-UNAP-CD-4
            // Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsCode3) //RSSI-UNAP-CD-3
            // Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsCode2) //RSSI-UNAP-CD-2

            return TotalPaidYearToDate;
        }
        public string GetAssistanceAmountOption1(AccountsModel model)
        {

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
            {
                return "then do not print the Assistance Amount line.";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount));
            }
        }
        public string GetReplacementReserveOption1(AccountsModel model)
        {
            if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) -
                Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount4) -
                Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment) +
                Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
            {
                return "then do not print the Replacement Reserve line.";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) -
                                         Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount4) -
                                         Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment) +
                                         Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount));
            }
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)  //If RSSI-PRIN-BAL = 0, then ""0.00""
            {
                return "0.00";
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0) //RSSI-ALT-PYMT2
            {
                return null;
            }
            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1)) //RSSI-ALT-PYMT1
            {
                return null;
            }
            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                return null;
            }
            else
            {
                return Convert.ToString(
                        Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidSinceLastStatement) +
                        Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement) -
                         Convert.ToInt64(model.TransactionRecordModel.TransactionAmount));
                         // WHERE)
            }

             

            //where RSSI-LOG-TRAN = 5605 and  Convert.ToInt64(model.TransactionRecordModel.LogTransaction)
            //RSSI-TR-FEE-CODE = 67)          Convert.ToInt64(model.TransactionRecordModel.FeeCode)
            // minus
            //(RSSI-TR-AMT                    Convert.ToInt64(model.TransactionRecordModel.TransactionAmount)
            //where RSSI-LOG-TRAN = 5605 or 5707 and Convert.ToInt64(model.TransactionRecordModel.LogTransaction)
            //RSSI-TR-FEE-CODE = 198)         Convert.ToInt64(model.TransactionRecordModel.FeeCode)
        }
        public string GetTotalFeesChargedOption2(AccountsModel model)
        {

            return TotalFeesChargedOption2;
        }
    }
}
