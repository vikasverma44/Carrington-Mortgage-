using CarringtonMortgage.Models.InputCopyBookModels;

namespace CarritonMortgage.Calculation_Classes
{
    public static class RejectStatement
    {
        //public RejectStatement()
        //{

        //}

        /// <summary>
        /// This method check if an account needs to be rejected
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public static bool IsRejectAccount(AccountsModel accountModel)
        {
            bool isReject = false;

            //Rejection condition 1
            if ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData == "00/00/00" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11")
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "null"))
            {
                isReject = true;
            }
            //Rejection condition 2
            else if ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13")
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "null"))
            {
                isReject = true;
            }
            //Rejection condition 3
            else if ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "O"
              && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData == "00/00/00" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11")
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "O"
              && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "null"))
            {
                isReject = true;
            }
            //Rejection condition 4
            else if ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13")
            && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "O"
            && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "null"))
            {
                isReject = true;
            }

            return isReject;
        }
    }
}
