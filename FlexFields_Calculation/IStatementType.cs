using CarringtonMortgage.Models.InputCopyBookModels;
using System.Collections.Generic;

namespace CarringtonMortgage.FlexFields_Calculation
{
    public interface IStatementType
    {
        List<Borrower> GetArchiveOnlyNyDvlStandardStatement(AccountsModel accountModel);
        List<Borrower> GetArchiveOnlyNyHelloDvlStandardStatement(AccountsModel accountModel);
        List<Borrower> GetArchiveOnlyNyHelloStandardStatement(AccountsModel accountModel);
        List<Borrower> GetArchiveOnlyStandardStatement(AccountsModel accountModel);
        List<Borrower> GetArchiveOnlyNyStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt13ArchiveOnlyNyDvlPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt13EDeliveryArchiveCopy1StandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt13EDeliveryArchivePrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt13EDeliveryArchiveVendStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt13EDeliveryMailCopy2StandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt13NyAndDvlLetterPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt13NyAndHelloDvlLetterPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt13NyAndHelloLetterPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt13PrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7ArchiveOnlyNyandDvlLetterPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7ArchiveOnlyNyandHelloDvlLetterPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7ArchiveOnlyNyandHelloLetterPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7ArchiveOnlyNyCopy1HelloPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7ArchiveOnlyNyDVLPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7ArchiveOnlyNyHelloDVLPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7ArchiveOnlyNyHelloPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7ArchiveOnlyNyPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7ArchiveOnlyPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7EDeliveryArchivePrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7PrimaryForeignStandardStatement(AccountsModel accountModel);
        List<Borrower> GetBkChpt7PrimaryStandardStatement(AccountsModel accountModel);
             
        List<Borrower> GetEDeliveryArchiveStandardStatement(AccountsModel accountModel);
        List<Borrower> GetNyAndDvlLetterStandardStatement(AccountsModel accountModel);
        List<Borrower> GetNyAndHelloDvlLetterStandardStatement(AccountsModel accountModel);
        List<Borrower> GetNyAndHelloLetterStandardStatement(AccountsModel accountModel);
        List<Borrower> GetOptionArmArchiveOnlyNyHelloStandardStatement(AccountsModel accountModel);
        List<Borrower> GetOptionArmArchiveOnlyNyStandardStatement(AccountsModel accountModel);
        List<Borrower> GetOptionArmArchiveOnlyStandardStatement(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13EDeliveryArchivePrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtNyAndDvlLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtNyAndHelloLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt13StmtPrimaryForeign(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7EDeliveryArchivePrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtNyAndDvlLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtNyAndHelloLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmBkChpt7StmtPrimaryForeign(AccountsModel accountModel);
        List<Borrower> GetOptionArmPEDeliveryArchiveCopy1StandardStatement(AccountsModel accountModel);
        List<Borrower> GetOptionArmPrimaryForeignStandardStatement(AccountsModel accountModel);
        List<Borrower> GetOptionArmPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtArchiveOnlyNyDvl(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtArchiveOnlyNyHelloDvl(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtNyandDVLLetter(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtNyandHelloDVLLetter(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtNyandHelloLetter(AccountsModel accountModel);
        List<Borrower> GetPrimaryForeignStandardStatement(AccountsModel accountModel);
        List<Borrower> GetPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtPrimaryForeign(AccountsModel accountModel);
    }
}