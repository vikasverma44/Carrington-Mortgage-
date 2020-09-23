using CarringtonMortgage.Models.InputCopyBookModels;
using System.Collections.Generic;

namespace CarringtonMortgage.FlexFields_Calculation
{
    public interface IStatementType
    {
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
        List<Borrower> GetOptionArmStmtArchiveOnly(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtArchiveOnlyNy(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtArchiveOnlyNyDvl(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtArchiveOnlyNyHello(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtArchiveOnlyNyHelloDvl(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtEDeliveryArchiveCopy1(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtNyandDVLLetter(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtNyandHelloDVLLetter(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtNyandHelloLetter(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtPrimary(AccountsModel accountModel);
        List<Borrower> GetOptionArmStmtPrimaryForeign(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13EDeliveryArchivePrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyNy(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtArchiveOnlyPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtNyAndDvlLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtNyAndHelloLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt13StmtPrimaryForeign(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7EDeliveryArchivePrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtArchiveOnlyNy(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtArchiveOnlyNY(AccountsModel accountsModel);
        List<Borrower> GetStdBkChpt7StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtArchiveOnlyNyPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtArchiveOnlyPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtNyAndDvlLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtNyAndHelloLetterPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtPrimary(AccountsModel accountModel);
        List<Borrower> GetStdBkChpt7StmtPrimaryForeign(AccountsModel accountModel);
        List<Borrower> GetStdStmtArchiveOnly(AccountsModel accountModel);
        List<Borrower> GetStdStmtArchiveOnlyNy(AccountsModel accountModel);
        List<Borrower> GetStdStmtArchiveOnlyNyDvl(AccountsModel accountModel);
        List<Borrower> GetStdStmtArchiveOnlyNyHello(AccountsModel accountModel);
        List<Borrower> GetStdStmtArchiveOnlyNyHelloDvl(AccountsModel accountModel);
        List<Borrower> GetStdStmtEDeliveryArchiveCopy1(AccountsModel accountModel);
        List<Borrower> GetStdStmtNyAndDvlLetter(AccountsModel accountModel);
        List<Borrower> GetStdStmtNyAndHelloDvlLetter(AccountsModel accountModel);
        List<Borrower> GetStdStmtNyAndHelloLetter(AccountsModel accountModel);
        List<Borrower> GetPrimaryStandardStatement(AccountsModel accountModel);
        List<Borrower> GetStdStmtPrimaryForeign(AccountsModel accountModel);
    }
}