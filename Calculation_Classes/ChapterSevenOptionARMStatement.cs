using ODHS_EDelivery.Models.InputCopyBookModels;
using System;
using System.Runtime.CompilerServices;

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


        /* While Calculating Conditions must be applied*/
        public string GetAmountDueOption1(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                AmountDueOption1 = "0";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
            {
                AmountDueOption1 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                AmountDueOption1 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                AmountDueOption1 = "N/A";
            }
            else
            {
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4));
            }
            return AmountDueOption1;
        }
        public string GetAmountDueOption2(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                AmountDueOption2 = "0";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
            {
                AmountDueOption2 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                AmountDueOption2 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                AmountDueOption2 = "N/A";
            }
            else
            {
                AmountDueOption2 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3));
            }
            return AmountDueOption2;
        }
        public string GetAmountDueOption3(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                AmountDueOption3 = "0";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
            {
                AmountDueOption3 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                AmountDueOption3 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                AmountDueOption3 = "N/A";
            }
            else
            {
                AmountDueOption3 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2));
            }
            return AmountDueOption3;
        }
        public string GetAmountDueOption4(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                AmountDueOption4 = "0";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                AmountDueOption4 = "N/A";
            }
            else
            {
                AmountDueOption4 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1));
            }
            return AmountDueOption4;
        }


        public string GetPrincipalOption1(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PrincipalOption1 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                PrincipalOption1 = "null";


            else
            {
                PrincipalOption1 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount4)
                                 - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestOnPymtDue));
            }

            return PrincipalOption1;
        }
        public string GetAssistanceAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
                AssistanceAmount = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AssistanceAmount = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AssistanceAmount = "null";


            else
            {
                AssistanceAmount = accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount;
            }
            return AssistanceAmount;
        }
        public string GetReplacementReserve(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4)
               - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount4)
               - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
               + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0))
                ReplacementReserve = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                ReplacementReserve = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                ReplacementReserve = "0.00";


            else
            {
                ReplacementReserve = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4)
                                            - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount4)
                                            - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
                                            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount));

            }
            return ReplacementReserve;
        }
        public string GetOverduePaymentsOption1(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                OverduePaymentsOption1 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
                OverduePaymentsOption1 = "null";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                OverduePaymentsOption1 = "null";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                OverduePaymentsOption1 = "null";

    
            else
            {
                OverduePaymentsOption1 = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                                 - Convert.ToInt64(GetTotalFeesPaidOption1(accountsModel)));
            }
            return OverduePaymentsOption1;
        }
        public string GetTotalFeesChargedOption1(AccountsModel accountsModel)//Issue
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                TotalFeesChargedOption1 = "0";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                TotalFeesChargedOption1 = "0";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
            {
                TotalFeesChargedOption1 = "0";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                TotalFeesChargedOption1 = "null";
            }
            else
            {
                var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement);

                if (Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67))
                {
                    TotalFeesChargedOption1 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
                }
                else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                     || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
                     && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
                {
                    TotalFeesChargedOption1 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
                }
                else
                {
                    TotalFeesChargedOption1 = Convert.ToString(Total);
                }
            }

            return TotalFeesChargedOption1;
        }
        public string GetTotalFeesPaidOption1(AccountsModel accountsModel)// Issue
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption1 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
                TotalFeesPaidOption1 = "null";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalFeesPaidOption1 = "null";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption1 = "null";

            

            else if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                      + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)) <
                       Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
            {
                TotalFeesPaidOption1 = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)
                    - Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges)));
            }
            else
                TotalFeesPaidOption1 = "0.00";

            return TotalFeesPaidOption1;
        }
        public string GetTotalAmountDueOption1(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption1 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
                TotalFeesPaidOption1 = "N/A";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalFeesPaidOption1 = "N/A";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption1 = "N/A";


            else
                TotalAmountDueOption1 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4)
                               + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                               + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));

            return TotalAmountDueOption1;
        }


        public string GetPrincipalOption2(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PrincipalOption1 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                PrincipalOption1 = "null";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                PrincipalOption1 = "null";
            else
            {
                AmountDueOption1 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount3)
                                 - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestOnPymtDue));
            }
            return PrincipalOption2;
        }
        public string GetAssistanceAmountOption2(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
                AssistanceAmountOption2 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AssistanceAmountOption2 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AssistanceAmountOption2 = "null";
            else
            {
                AssistanceAmountOption2 = accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount;
            }
            return AssistanceAmountOption2;
        }
        public string GetReplacementReserveOption2(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3)
              - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount3)
              - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
              + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0))
                ReplacementReserveOption2 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                ReplacementReserveOption2 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                ReplacementReserveOption2 = "null";

            else
            {
                ReplacementReserveOption2 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3)
                                            - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount3)
                                            - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
                                            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount));

            }
            return ReplacementReserveOption2;
        }
        public string GetOverduePaymentsOption2(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                OverduePaymentsOption2 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                OverduePaymentsOption2 = "null";

            else
            {
                OverduePaymentsOption2 = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                                 - Convert.ToInt64(GetTotalFeesPaidOption2(accountsModel)));
            }
            return OverduePaymentsOption2;
        }
        public string GetTotalFeesChargedOption2(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                TotalFeesChargedOption2 = "0";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                TotalFeesChargedOption2 = "0";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
            {
                TotalFeesChargedOption2 = "0";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                TotalFeesChargedOption2 = "null";
            }
            else
            {
                var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement);

                if (Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67))
                {
                    TotalFeesChargedOption2 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
                }
                else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                     || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
                     && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
                {
                    TotalFeesChargedOption2 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
                }
                else
                {
                    TotalFeesChargedOption2 = Convert.ToString(Total);
                }
            }
            return TotalFeesChargedOption2;
        }
        public string GetTotalFeesPaidOption2(AccountsModel accountsModel)
        {
            // need to check
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption2 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
                TotalFeesPaidOption2 = "null";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalFeesPaidOption2 = "null";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption2 = "null";

            else if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                      + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)) <
                       Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
            {
                TotalFeesPaidOption2 = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)
                    - Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges)));
            }
            else
                TotalFeesPaidOption2 = "0.00";

            return TotalFeesPaidOption2;
        }
        public string GetTotalAmountDueOption2(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalAmountDueOption2 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
                TotalAmountDueOption2 = "N/A";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalAmountDueOption2 = "N/A";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalAmountDueOption2 = "N/A";

            else
                TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3)
                               + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                               + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));

            return TotalAmountDueOption2;
        }


        public string GetPrincipalOption3(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PrincipalOption3 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
                PrincipalOption3 = "null";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                PrincipalOption3 = "null";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                PrincipalOption3 = "null";
            else
            {
                PrincipalOption3 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount2)
                                 - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestOnPymtDue));
            }
            return PrincipalOption3;
        }
        public string GetAssistanceAmountOption3(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
                AssistanceAmountOption3 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AssistanceAmountOption3 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AssistanceAmountOption3 = "0.00";
            else
            {
                AssistanceAmountOption3 = accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount;
            }
            return AssistanceAmountOption3;
        }
        public string GetReplacementReserveOption3(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2)
             - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount2)
             - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
             + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0))
                ReplacementReserveOption3 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                ReplacementReserveOption3 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                ReplacementReserveOption3 = "0.00";
            else
            {
                ReplacementReserveOption3 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2)
                                            - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount2)
                                            - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
                                            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount));

            }
            return ReplacementReserveOption3;
        }
        public string GetOverduePaymentsOption3(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                OverduePaymentsOption2 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                OverduePaymentsOption2 = "null";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                OverduePaymentsOption2 = "null";
            else
            {
                OverduePaymentsOption2 = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                                 - Convert.ToInt64(GetTotalFeesPaidOption3(accountsModel)));
            }
            return OverduePaymentsOption3;
        }
        public string GetTotalFeesChargedOption3(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                TotalFeesChargedOption3 = "0";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                TotalFeesChargedOption3 = "0";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
            {
                TotalFeesChargedOption3 = "0";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                TotalFeesChargedOption3 = "null";
            }
            else
            {
                var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement);

                if (Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67))
                {
                    TotalFeesChargedOption3 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
                }
                else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                     || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
                     && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
                {
                    TotalFeesChargedOption3 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
                }
                else
                {
                    TotalFeesChargedOption3 = Convert.ToString(Total);
                }
            }
            return TotalFeesChargedOption3;
        }
        public string GetTotalFeesPaidOption3(AccountsModel accountsModel)
        {
            // need to check
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption3 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
                TotalFeesPaidOption3 = "null";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalFeesPaidOption3 = "null";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption3 = "null";


            else if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                      + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)) <
                       Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
            {
                TotalFeesPaidOption3 = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)
                    - Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges)));
            }
            else
                TotalFeesPaidOption3 = "0.00";
            return TotalFeesPaidOption3;
        }
        public string GetTotalAmountDueOption3(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalAmountDueOption3 = "0.00";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
                TotalAmountDueOption3 = "N/A";

            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
                TotalAmountDueOption3 = "N/A";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalAmountDueOption3 = "N/A";


            else
                TotalAmountDueOption2 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2)
                               + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                               + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));

            return TotalAmountDueOption3;
        }


        public string GetPrincipalOption4(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PrincipalOption4 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestOnPymtDue) > Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount1))
                PrincipalOption4 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                PrincipalOption4 = "0.00";


            else
            {
                PrincipalOption4 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount1)
                                 - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestOnPymtDue));
            }
            return PrincipalOption4;
        }
        public string GetAssistanceAmountOption4(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
                AssistanceAmountOption4 = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AssistanceAmountOption4 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AssistanceAmountOption4 = "0.00";

            else
            {
                AssistanceAmountOption4 = accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount;
            }
            return AssistanceAmountOption4;
        }
        public string GetReplacementReserveOption4(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1)
            - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount1)
            - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0))
                ReplacementReserveOption4 = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                ReplacementReserveOption4 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                ReplacementReserveOption4 = "0.00";


            else
            {
                ReplacementReserveOption4 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1)
                                            - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount1)
                                            - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
                                            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount));

            }
            return ReplacementReserveOption4;
        }
        public string GetOverduePaymentsOption4(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                OverduePaymentsOption4 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                OverduePaymentsOption4 = "0.00";
            else
            {
                OverduePaymentsOption4 = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                                 - Convert.ToInt64(GetTotalFeesPaidOption4(accountsModel)));
            }
            return OverduePaymentsOption4;
        }
        public string GetTotalFeesChargedOption4(AccountsModel accountsModel)// issue
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                TotalFeesChargedOption4 = "0";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                TotalFeesChargedOption4 = "0";
            }
            else
            {
                var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement);

                if (Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67))
                {
                    TotalFeesChargedOption4 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
                }
                else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                     || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
                     && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
                {
                    TotalFeesChargedOption4 = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
                }
                else
                {
                    TotalFeesChargedOption4 = Convert.ToString(Total);
                }
            }
            return TotalFeesChargedOption4;
        }
        public string GetTotalFeesPaidOption4(AccountsModel accountsModel)
        {
            // need to check
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalFeesPaidOption4 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalFeesPaidOption4 = "0.00";

            else if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                      + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)) <
                       Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges))
            {
                TotalFeesPaidOption4 = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)
                    - Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges)));
            }
            else
                TotalFeesPaidOption4 = "0.00";
            return TotalFeesPaidOption4;
        }
        public string GetTotalAmountDueOption4(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalAmountDueOption4 = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                TotalAmountDueOption4 = "N/A";


            else
                TotalAmountDueOption4 = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1)
                               + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PastUnpaidPostPetitionAmounts)
                               + Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.PostPetitionFeesAndCharges));
            return TotalAmountDueOption4;
        }


        public string GetFeesandChargesPaidLastMonth(AccountsModel accountsModel)//Issue
        {
            var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesPaidSinceLastStatement)
               + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesPaidSinceLastStatement);

            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705
                || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
                &&
                (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67
                || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {
                FeesandChargesPaidLastMonth = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }
            else
            {
                FeesandChargesPaidLastMonth = Convert.ToString(Total);
            }
            return FeesandChargesPaidLastMonth;
        }
        public string GeUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {
            UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
               + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2));

            return UnappliedFundsPaidLastMonth;
        }
        public string GetFeesandChargesPaidYeartoDate(AccountsModel accountsModel)//Issue
        {
            var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesPaidYTD)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesPaidYTD);

            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705
                || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
                &&
                (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67
                || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {
                FeesandChargesPaidYeartoDate = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }
            else
            {
                FeesandChargesPaidYeartoDate = Convert.ToString(Total);
            }
            return FeesandChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel)//Issue
        {
            UnappliedFundsPaidYearToDate = Convert.ToString(accountsModel.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0
          + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
          + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
          + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
          + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0);

            return UnappliedFundsPaidYearToDate;

        }
        public string GetPaymentAmountOption1(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                PaymentAmountOption1 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) == 0)
            {
                PaymentAmountOption1 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                PaymentAmountOption1 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                PaymentAmountOption1 = "N/A";
            }
            else
            {
                PaymentAmountOption1 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4));
            }
            return PaymentAmountOption1;
        }
        public string GetPaymentAmountOption2(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                PaymentAmountOption2 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) == 0)
            {
                PaymentAmountOption2 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                PaymentAmountOption2 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                PaymentAmountOption2 = "N/A";
            }
            else
            {
                PaymentAmountOption2 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount3));
            }
            return PaymentAmountOption2;
        }
        public string GetPaymentAmountOption3(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                PaymentAmountOption4 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) == 0)
            {
                PaymentAmountOption3 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2) < Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1))
            {
                PaymentAmountOption3 = "N/A";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                PaymentAmountOption3 = "N/A";
            }
            else
            {
                PaymentAmountOption3 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount2));
            }
            return PaymentAmountOption3;
        }
        public string GetPaymentAmountOption4(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                PaymentAmountOption4 = "0.00";
            }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                PaymentAmountOption4 = "N/A";
            }
            else
            {
                PaymentAmountOption4 = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount1));
            }

            return PaymentAmountOption4;
        }
        public string GetSuspense(AccountsModel accountsModel)
        {
            Suspense = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2));

            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountsModel)
        {
            Miscellaneous = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountConstructionBalance)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountOptionalInsurance)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountToP_IShortage)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountPostedToDeferredPrincipal)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TranAmountToDeferredInterest)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountLateCharge)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountEscrow)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TranAmountToDeferredPaidExpensesAdv)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TranAmountToDeferredUnpaidExpenseAdv)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TranAmountToDeferredAdminFees)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.OptionalDeferredAmount)
                );
            return Miscellaneous;
        }
        public string GetDeferredBalance(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance)
                - Convert.ToInt64(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance) == 0)
            {
                DeferredBalance = "N/A";
            }
            else
            {
                DeferredBalance = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance)
                - Convert.ToInt64(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance));
            }
            return DeferredBalance;
        }
        public string GetTotalDue(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                TotalDue = "0";
            }
            else
            {
                TotalDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment));
            }
            return TotalDue;
        }
    }
}
