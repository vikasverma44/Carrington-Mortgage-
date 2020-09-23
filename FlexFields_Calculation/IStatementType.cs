﻿using CarringtonMortgage.Models.InputCopyBookModels;
using System.Collections.Generic;

namespace CarringtonMortgage.FlexFields_Calculation
{
    public interface IStatementType
    {
        List<BorrowerModel> GetOptionArmBkChpt13EDeliveryArchivePrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtArchiveOnlyNy(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtArchiveOnlyNyPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtArchiveOnlyPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtNyAndDvlLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtNyAndHelloLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt13StmtPrimaryForeign(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7EDeliveryArchivePrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtArchiveOnlyNy(AccountsModel accountsModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtArchiveOnlyNyPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtArchiveOnlyPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtNyAndDvlLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtNyAndHelloLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmBkChpt7StmtPrimaryForeign(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtArchiveOnly(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtArchiveOnlyNy(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtArchiveOnlyNyDvl(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtArchiveOnlyNyHello(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtArchiveOnlyNyHelloDvl(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtEDeliveryArchiveCopy1(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtNyandDVLLetter(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtNyandHelloDVLLetter(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtNyandHelloLetter(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetOptionArmStmtPrimaryForeign(AccountsModel accountModel);
        List<BorrowerModel> GetPrimaryStandardStatement(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13EDeliveryArchivePrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtArchiveOnlyNy(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtArchiveOnlyNyPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtArchiveOnlyPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtNyAndDvlLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtNyAndHelloLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt13StmtPrimaryForeign(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7EDeliveryArchivePrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtArchiveOnlyNy(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtArchiveOnlyNyPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtArchiveOnlyPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtNyAndDvlLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtNyAndHelloLetterPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtPrimary(AccountsModel accountModel);
        List<BorrowerModel> GetStdBkChpt7StmtPrimaryForeign(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtArchiveOnly(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtArchiveOnlyNy(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtArchiveOnlyNyDvl(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtArchiveOnlyNyHello(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtArchiveOnlyNyHelloDvl(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtEDeliveryArchiveCopy1(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtNyAndDvlLetter(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtNyAndHelloDvlLetter(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtNyAndHelloLetter(AccountsModel accountModel);
        List<BorrowerModel> GetStdStmtPrimaryForeign(AccountsModel accountModel);
    }
}