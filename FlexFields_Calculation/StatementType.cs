using Carrington_Service.Infrastructure;
using ODHS_EDelivery.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.FlexFields_Calculation
{
   public  class StatementType
    {
        #region Object Declaration ==>
        public ILogger Logger;
        #endregion
        public StatementType(ILogger logger)
        {
            Logger = logger;
        }
        public bool ClearedPrivousPrimaryStandardStatementCondition = false;
        public List<Borrower> GetPrimaryStandardStatement(AccountsModel accountModel)
        {
         List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get primary standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetPrimaryForeignStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                 Logger.Trace("ENDED:get primary standard statement.");

    }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }


            return lstBrw;

        }


        public static List<Borrower> GetPrimaryForeignStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            return lstBrw;
        }
        }
}
