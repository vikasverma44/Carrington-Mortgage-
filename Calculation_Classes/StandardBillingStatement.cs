using ODHS_EDelivery.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.Calculation_Classes
{
    public class StandardBillingStatement
    {
        public string AmountDue { get; set; }
        public string Principal { get; set; }
        public string AssistanceAmount { get; set; }
        public string ReplacementReserveAmount { get; set; }
        public string OverduePayment { get; set; }
        public string TotalFeesAndCharges { get; set; }
        public string TotalFeesPaid { get; set; }
        public string TotalAmountDue { get; set; }
        public string PastDueBalance { get; set; }
        public string DeferredBalance { get; set; }
        public string UnappliedFunds { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string TotalPaidLastMonth { get; set; }
        public string FeesAndChargesPaidYearToDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
               
        public string LatePaymentAmount { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string TotalDue { get; set; }
       
        /* While Calculating Conditions must be applied*/
        public string GetAmountDue(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                AmountDue = "0";
            }
            else
            {
                AmountDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4));
            }
            return AmountDue;
        }
        public string GetPrincipal(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                Principal = "0.00";
            }

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
            {
                Principal = "null";
            }
            else
            {
                Principal = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount4)
                                 - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestOnPymtDue));
            }
            return Principal;
        }
        public string GetAssistanceAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0)
                AssistanceAmount = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                AssistanceAmount = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                AssistanceAmount = "0.00";
            else
            {
                AssistanceAmount = accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount;
            }
            return AssistanceAmount;
        }
        public string GetReplacementReserveAmount(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4)
               - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount4)
               - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
               + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount) == 0))
                ReplacementReserveAmount = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                ReplacementReserveAmount = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)
                ReplacementReserveAmount = "0.00";
            else
            {
                ReplacementReserveAmount = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativePaymentAmount4)
                                            - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.AlternativeChangeAmount4)
                                            - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPayment)
                                            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrecalculatedInterestAmount));

            }
            return ReplacementReserveAmount;
        }
        public string GetOverduePayment(AccountsModel accountsModel)
        {
            return OverduePayment = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                               - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement)
                               - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalPaidSinceLastStatement)
                               - Convert.ToInt64(GetTotalFeesAndCharges(accountsModel)));
        }
        public string GetTotalFeesAndCharges(AccountsModel accountsModel)
        {
            
            var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement)
            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement);

            if (Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67))
            {
                TotalFeesAndCharges = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }
            else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5605
                    || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {
                TotalFeesAndCharges = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }
            else
            {
                TotalFeesAndCharges = Convert.ToString(Total);
            }
          
            return TotalFeesAndCharges;
        }
        public string GetTotalFeesPaid(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                      + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)) <
                       Convert.ToInt64(GetTotalFeesAndCharges(accountsModel)))
            {
                TotalFeesPaid = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)
                    - Convert.ToInt64(GetTotalFeesAndCharges(accountsModel))));
            }
            else
                TotalFeesPaid = "0.00";

            return TotalFeesPaid;
        }
        public string GetTotalAmountDue(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalAmountDue = "0.00";
            else
                TotalAmountDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                               + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment));

            return TotalAmountDue;
        }

        public string GetPastDueBalance(AccountsModel accountsModel)
        {
            return Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue) -
             Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesAssessedSinceLastStatement) -
             Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesAccruedSinceLastStatement));
        }
        public string GetDeferredBalance(AccountsModel accountsModel)
        {
            if ((Convert.ToInt32(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance)
                - Convert.ToInt32(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance)) == 0)
            {
                DeferredBalance = "N/A";
            }
            else
            {
                DeferredBalance = Convert.ToString(Convert.ToInt32(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance)
                    - Convert.ToInt32(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance));
            }
            return DeferredBalance;
        }
        public string GetUnappliedFunds(AccountsModel accountsModel)
        {
            UnappliedFunds = Convert.ToString(accountsModel.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0);
            return UnappliedFunds;
        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
              &&
              (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {
                FeesAndChargesPaidLastMonth = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesPaidSinceLastStatement)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesPaidSinceLastStatement))
                - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }
            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {
            UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds)
          + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
          + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds3)
          + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds4)
          + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds5));

            return UnappliedFundsPaidLastMonth;
        }
        public string GetTotalPaidLastMonth()
        {
            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYearToDate(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
             &&(Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {
                FeesAndChargesPaidYearToDate = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesPaidYTD)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesPaidYTD))
                - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }
            return FeesAndChargesPaidYearToDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel)
        {
            UnappliedFundsPaidYearToDate = Convert.ToString(accountsModel.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0);

            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
                          &&
                          (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {
                TotalPaidYearToDate = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalPaidYTD)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestPaidYearToDate)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPaidYTD)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesPaidYTD)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesPaidYTD)
                                       + accountsModel.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0)
                                       - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }

            return TotalPaidYearToDate;
        }
        public string GetLatePaymentAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                LatePaymentAmount = "N/A";
            }
            else
            {
                LatePaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeAmount));
            }
            return LatePaymentAmount;
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
