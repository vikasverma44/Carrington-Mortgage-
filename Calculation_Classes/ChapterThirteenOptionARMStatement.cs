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



        /* While Calculating Conditions must be applied*/
        public string GetAmountDueOption1(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AmountDueOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
                AmountDueOption1 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                AmountDueOption1 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AmountDueOption1 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                AmountDueOption1 = "N/A";
            else
            {
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4)
                                 + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                                 + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            }
            return AmountDueOption1;
        }
        public string GetAmountDueOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AmountDueOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
                AmountDueOption2 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                AmountDueOption2 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AmountDueOption2 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                AmountDueOption2 = "N/A";

            else
            {
                AmountDueOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3)
                           + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                           + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            }
            return AmountDueOption2;
        }
        public string GetAmountDueOption3(AccountsModel model)
        {

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AmountDueOption3 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
                AmountDueOption3 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                AmountDueOption3 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AmountDueOption3 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                AmountDueOption3 = "N/A";

            else
            {
                AmountDueOption3 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2)
                           + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                           + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            }
            return AmountDueOption3;
        }

        public string GetAmountDueOption4(AccountsModel model)
        {

            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AmountDueOption3 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AmountDueOption3 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
            {
                AmountDueOption4 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                            + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            }

            else
            {
                AmountDueOption4 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1)
                          + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                          + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            }
            return AmountDueOption4;

        }
        public string GetFeesandChargesPaidLastMonth(AccountsModel model)
        {
            //need to check calculaiton logic

            var total = Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidSinceLastStatement)
            + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesPaidSinceLastStatement);

            if ((Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5707)
              &&
              (Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 198))
            {
                FeesandChargesPaidLastMonth = Convert.ToString(total - Convert.ToInt64(model.TransactionRecordModel.TransactionAmount));
            }
            else
            {
                FeesandChargesPaidLastMonth = Convert.ToString(total);
            }
            return FeesandChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel model)
        {
            FeesandChargesPaidLastMonth = Convert.ToString(Convert.ToInt64(model.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds)
           + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds2)
           + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds3)
           + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds4)
           + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds5));

            return UnappliedFundsPaidLastMonth;
        }
        public string GetFeesandChargesPaidYearToDate(AccountsModel model)
        {
            //need to check calculaiton logic
            var total = Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidYTD)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesPaidYTD);

            if ((Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5707)
              &&
              (Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 198))
            {
                FeesandChargesPaidLastMonth = Convert.ToString(total - Convert.ToInt64(model.TransactionRecordModel.TransactionAmount));
            }
            else
            {
                FeesandChargesPaidLastMonth = Convert.ToString(total);
            }
            return FeesandChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel model)
        {
            //need to check logic

            UnappliedFundsPaidYearToDate = Convert.ToString(model.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToInt64(model.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0);

            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel model)
        {
            //need to check logic

            var total = Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalPaidYTD)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.InterestPaidYearToDate)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPaidYTD)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidYTD)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesPaidYTD)
           + model.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToInt64(model.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0;
            if ((Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5707)
               &&
               (Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 198))
            {
                TotalPaidYearToDate = Convert.ToString(total - Convert.ToInt64(model.TransactionRecordModel.TransactionAmount));
            }
            else
            {
                TotalPaidYearToDate = Convert.ToString(total);
            }
            return TotalPaidYearToDate;
        }
        public string GetPrincipalOption1(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PrincipalOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                PrincipalOption1 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                PrincipalOption1 = "null";
            else
            {
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount4)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.InterestOnPymtDue));
            }

            return PrincipalOption1;
        }

        public string GetAssistanceAmountOption1(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
                AssistanceAmountOption1 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AssistanceAmountOption1 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AssistanceAmountOption1 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                AssistanceAmountOption1 = "null";
            else
            {
                AssistanceAmountOption1 = model.MasterFileDataPart_1Model.PrecalculatedInterestAmount;
            }
            return AssistanceAmountOption1;
        }
        public string GetReplacementReserveOption1(AccountsModel model)
        {
            if ((Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4)
               - Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount4)
               - Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment)
               + Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0))
                ReplacementReserveOption1 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                ReplacementReserveOption1 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                ReplacementReserveOption1 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                ReplacementReserveOption1 = "null";
            else
            {
                ReplacementReserveOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4)
                                            - Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount4)
                                            - Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment)
                                            + Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount));

            }
            return ReplacementReserveOption1;
        }/// <summary>
        /// 34
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetOverduePaymentsOption1(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AmountDueOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
                AmountDueOption1 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                AmountDueOption1 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AmountDueOption1 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                AmountDueOption1 = "null";
            else
            {
                //AmountDueOption1 = Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                //                 + Convert.ToInt64(GetTotalFeesPaidOption1(model));
            }
            return OverduePaymentsOption1;
        }

        public string GetTotalFeesPaidOption1(AccountsModel model)
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

        public string GetTotalFeesPaidOption2()
        {

            return TotalFeesPaidOption2;
        }
        public string GetTotalAmountDueOption2()
        {

            return TotalAmountDueOption2;
        }

        public string GetPrincipalOption3()
        {

            return PrincipalOption3;
        }
        public string GetAssistanceAmountOption3()
        {

            return AssistanceAmountOption3;
        }
        public string GetReplacementReserveOption3()
        {

            return ReplacementReserveOption3;
        }
        public string GetOverduePaymentsOption3()
        {

            return OverduePaymentsOption3;
        }
        public string GetTotalFeesPaidOption3()
        {

            return TotalFeesPaidOption3;
        }
        public string GetTotalAmountDueOption3()
        {
            return TotalAmountDueOption3;
        }
        public string GetPrincipalOption4()
        {
            return PrincipalOption4;
        }
        public string GetAssistanceAmountOption4()
        {
            return AssistanceAmountOption4;
        }
        public string GetReplacementReserveOption4()
        {
            return ReplacementReserveOption4;
        }
        public string GetOverduePaymentsOption4()
        {
            return OverduePaymentsOption4;
        }

        public string GetTotalFeesPaidOption4()
        {

            return TotalFeesPaidOption4;
        }
        public string GetTotalAmountDueOption4()
        {

            return TotalAmountDueOption4;
        }

        public string GetFeesandChargesPaidLastMonth()
        {

            return FeesandChargesPaidLastMonth;
        }
        public string GeUnappliedFundsPaidLastMonth()
        {

            return UnappliedFundsPaidLastMonth;
        }

        public string GetFeesandChargesPaidYeartoDate()
        {

            return FeesandChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate()
        {

            return UnappliedFundsPaidYearToDate;
        }
        public string GeSuspense()
        {

            return Suspense;
        }

        public string GetMiscellaneous()
        {

            return Miscellaneous;
        }

    }
}
