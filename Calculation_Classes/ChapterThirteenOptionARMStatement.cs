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


        /* While Calculating Conditions must be applied*/
        /// <summary>
        /// 11
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 12
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 13
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 14
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 19
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetFeesandChargesPaidLastMonth(AccountsModel model)
        {
            if ((Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5707)
              &&
              (Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 198))
            {
                FeesandChargesPaidLastMonth = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidSinceLastStatement)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesPaidSinceLastStatement))
                - Convert.ToInt64(model.TransactionRecordModel.TransactionAmount));
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
            FeesandChargesPaidLastMonth = Convert.ToString(Convert.ToInt64(model.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds)
           + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds2)
           + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds3)
           + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds4)
           + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds5));

            return UnappliedFundsPaidLastMonth;
        }
        /// <summary>
        /// 25
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetFeesandChargesPaidYearToDate(AccountsModel model)
        {
            if ((Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5707)
              &&
              (Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 198))
            {
                FeesandChargesPaidLastMonth = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidYTD)
                + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesPaidYTD))
                - Convert.ToInt64(model.TransactionRecordModel.TransactionAmount));
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

            UnappliedFundsPaidYearToDate = Convert.ToString(model.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToInt64(model.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0);

            return UnappliedFundsPaidYearToDate;
        }
        /// <summary>
        /// 27
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalPaidYearToDate(AccountsModel model)
        {
            if ((Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(model.TransactionRecordModel.LogTransaction) == 5707)
               &&
               (Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(model.TransactionRecordModel.FeeDescription) == 198))
            {
                TotalPaidYearToDate = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalPaidYTD)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.InterestPaidYearToDate)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPaidYTD)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.FeesPaidYTD)
           + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargesPaidYTD)
           + model.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToInt64(model.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
           + model.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(model.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0)
           - Convert.ToInt64(model.TransactionRecordModel.TransactionAmount));
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
        /// <summary>
        /// 31
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 32
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        }
        /// <summary>
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
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
                TotalFeesPaidOption1 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalFeesPaidOption1 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption1 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                TotalFeesPaidOption1 = "null";

            else if ((Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                      + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)) <
                       Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
            {
                TotalFeesPaidOption1 = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                    + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)
                    - Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges)));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
                TotalFeesPaidOption1 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalFeesPaidOption1 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption1 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                TotalFeesPaidOption1 = "null";

            else
                TotalAmountDueOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount4)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));

            return TotalAmountDueOption1;
        }
        /// <summary>
        /// 38
        /// </summary>
        /// <returns></returns>
        public string GetPrincipalOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PrincipalOption1 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                PrincipalOption1 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                PrincipalOption1 = "null";
            else
            {
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount3)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.InterestOnPymtDue));
            }
            return PrincipalOption2;
        }
        /// <summary>
        /// 41m
        /// </summary>
        /// <returns></returns>
        public string GetAssistanceAmountOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
                AssistanceAmountOption2 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AssistanceAmountOption2 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AssistanceAmountOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                AssistanceAmountOption2 = "null";
            else
            {
                AssistanceAmountOption2 = model.MasterFileDataPart_1Model.PrecalculatedInterestAmount;
            }
            return AssistanceAmountOption2;
        }
        /// <summary>
        /// 42
        /// </summary>
        /// <returns></returns>
        public string GetReplacementReserveOption2(AccountsModel model)
        {
            if ((Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3)
              - Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount3)
              - Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment)
              + Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0))
                ReplacementReserveOption2 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                ReplacementReserveOption2 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                ReplacementReserveOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                ReplacementReserveOption2 = "null";
            else
            {
                ReplacementReserveOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3)
                                            - Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount3)
                                            - Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment)
                                            + Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount));

            }
            return ReplacementReserveOption2;
        }
        /// <summary>
        /// 44
        /// </summary>
        /// <returns></returns>
        public string GetOverduePaymentsOption2(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                OverduePaymentsOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                OverduePaymentsOption2 = "null";
            else
            {
                OverduePaymentsOption2 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
                TotalFeesPaidOption2 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalFeesPaidOption2 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                TotalFeesPaidOption2 = "null";

            else if ((Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                      + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)) <
                       Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
            {
                TotalFeesPaidOption2 = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                    + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)
                    - Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges)));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalAmountDueOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
                TotalAmountDueOption2 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalAmountDueOption2 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalAmountDueOption2 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                TotalAmountDueOption2 = "null";

            else
                TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount3)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));

            return TotalAmountDueOption2;
        }
        /// <summary>
        /// 48
        /// </summary>
        /// <returns></returns>
        public string GetPrincipalOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PrincipalOption3 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
                PrincipalOption3 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                PrincipalOption3 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                PrincipalOption3 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                PrincipalOption3 = "null";
            else
            {
                PrincipalOption3 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount2)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.InterestOnPymtDue));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
                AssistanceAmountOption3 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AssistanceAmountOption3 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AssistanceAmountOption3 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                AssistanceAmountOption3 = "null";
            else
            {
                AssistanceAmountOption3 = model.MasterFileDataPart_1Model.PrecalculatedInterestAmount;
            }
            return AssistanceAmountOption3;
        }
        /// <summary>
        /// 52
        /// </summary>
        /// <returns></returns>
        public string GetReplacementReserveOption3(AccountsModel model)
        {
            if ((Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2)
             - Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount2)
             - Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment)
             + Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0))
                ReplacementReserveOption3 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                ReplacementReserveOption3 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                ReplacementReserveOption3 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                ReplacementReserveOption3 = "null";
            else
            {
                ReplacementReserveOption3 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2)
                                            - Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount2)
                                            - Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment)
                                            + Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount));

            }
            return ReplacementReserveOption3;
        }
        /// <summary>
        /// 54
        /// </summary>
        /// <returns></returns>
        public string GetOverduePaymentsOption3(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                OverduePaymentsOption2 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                OverduePaymentsOption2 = "null";
            else
            {
                OverduePaymentsOption2 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption3 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
                TotalFeesPaidOption3 = "null";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalFeesPaidOption3 = "null";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption3 = "null";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                TotalFeesPaidOption3 = "null";

            else if ((Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                      + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)) <
                       Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
            {
                TotalFeesPaidOption3 = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                    + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)
                    - Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges)));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalAmountDueOption3 = "0.00";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
                TotalAmountDueOption3 = "N/A";

            else if (Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalAmountDueOption3 = "N/A";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalAmountDueOption3 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                TotalAmountDueOption3 = "null";

            else
                TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount2)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));

            return TotalAmountDueOption3;
        }
        /// <summary>
        /// 58
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetPrincipalOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PrincipalOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.InterestOnPymtDue) > Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount1))
                PrincipalOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                PrincipalOption4 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                PrincipalOption4 = "0.00";
            else
            {
                PrincipalOption4 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount1)
                                 - Convert.ToInt64(model.MasterFileDataPart_1Model.InterestOnPymtDue));
            }
            return PrincipalOption4;
        }
        /// <summary>
        /// 61
        /// </summary>
        /// <returns></returns>
        public string GetAssistanceAmountOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
                AssistanceAmountOption4 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AssistanceAmountOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AssistanceAmountOption4 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                AssistanceAmountOption4 = "0.00";
            else
            {
                AssistanceAmountOption4 = model.MasterFileDataPart_1Model.PrecalculatedInterestAmount;
            }
            return AssistanceAmountOption4;
        }
        /// <summary>
        /// 62
        /// </summary>
        /// <returns></returns>
        public string GetReplacementReserveOption4(AccountsModel model)
        {
            if ((Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1)
            - Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount1)
            - Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment)
            + Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0))
                ReplacementReserveOption4 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                ReplacementReserveOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                ReplacementReserveOption4 = "0.00";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
                ReplacementReserveOption4 = "0.00";
            else
            {
                ReplacementReserveOption4 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1)
                                            - Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativeChangeAmount1)
                                            - Convert.ToInt64(model.MasterFileDataPart_1Model.EscrowPayment)
                                            + Convert.ToInt64(model.MasterFileDataPart_1Model.PrecalculatedInterestAmount));

            }
            return ReplacementReserveOption4;
        }
        /// <summary>
        /// 64
        /// </summary>
        /// <returns></returns>
        public string GetOverduePaymentsOption4(AccountsModel model)
        {
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                OverduePaymentsOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                OverduePaymentsOption4 = "0.00";
            else
            {
                OverduePaymentsOption4 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption4 = "0.00";

            else if ((Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                      + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)) <
                       Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
            {
                TotalFeesPaidOption4 = Convert.ToString((Convert.ToInt64(model.MasterFileDataPart_1Model.FeeReceivable)
                    + Convert.ToInt64(model.MasterFileDataPart_1Model.LateChargeDue)
                    - Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges)));
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
            if (Convert.ToInt64(model.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalAmountDueOption4 = "0.00";

            else if (Convert.ToInt64(model.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalAmountDueOption4 = "N/A";

            else if (Convert.ToDateTime(model.ActiveBankruptcyInformationRecordModel.PostPetitionPaymentDate) > Convert.ToDateTime(model.MasterFileDataPart_1Model.CurrentDueDate))
            {
                TotalAmountDueOption4 = Convert.ToString(Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            }
            else
                TotalAmountDueOption4 = Convert.ToString(Convert.ToInt64(model.BlendedRateInformationRecordModel.AlternativePaymentAmount1)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                               + Convert.ToInt64(model.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            return TotalAmountDueOption4;
        }
        /// <summary>
        /// 89
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSuspense(AccountsModel model)
        {
            Suspense = Convert.ToString((Convert.ToInt64(model.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds)
                   + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds2)
                   + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds3)
                   + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds4)
                   + Convert.ToInt64(model.TransactionRecordModel.TransactionAmountUnappliedFunds5)));
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
                Convert.ToDecimal(model.TransactionRecordModel.TransactionAmountConstructionBalance)
                + Convert.ToDecimal(model.TransactionRecordModel.TransactionAmountOptionalInsurance)
                + Convert.ToDecimal(model.TransactionRecordModel.TransactionAmountToP_IShortage)
                + Convert.ToDecimal(model.TransactionRecordModel.TransactionAmountPostedToDeferredPrincipal)
                + Convert.ToDecimal(model.TransactionRecordModel.TranAmountToDeferredInterest)
                + Convert.ToDecimal(model.TransactionRecordModel.TranAmountToDeferredLateCharge)
                + Convert.ToDecimal(model.TransactionRecordModel.TranAmountToDeferredEscrowAdv)
                + Convert.ToDecimal(model.TransactionRecordModel.TranAmountToDeferredPaidExpensesAdv)
                + Convert.ToDecimal(model.TransactionRecordModel.TranAmountToDeferredUnpaidExpenseAdv)
                + Convert.ToDecimal(model.TransactionRecordModel.TranAmountToDeferredAdminFees)
                + Convert.ToDecimal(model.TransactionRecordModel.OptionalDeferredAmount));
            return Miscellaneous;
        }
        /// <summary>
        /// 95
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetDeferredBalance(AccountsModel model)
        {
            if ((Convert.ToInt32(model.MasterFileDataPart2Model.TotalDeferredItemsBalance)
                - Convert.ToInt32(model.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance)) == 0)
            {
                DeferredBalance = "N/A";
            }
            else
            {
                DeferredBalance = Convert.ToString(Convert.ToInt32(model.MasterFileDataPart2Model.TotalDeferredItemsBalance)
                    - Convert.ToInt32(model.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance));
            }
            return DeferredBalance;
        }

    }
}
