using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class NCP10Model
{
    public int AccountNumber { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string AddressLine4 { get; set; }
    public string AddressLine5 { get; set; }
    public string AddressLine6 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Zip5 { get; set; }
    public int Zip4 { get; set; }
    public int OriginalDPBC { get; set; }
    public string FlexField1 { get; set; }
    public string FlexField2 { get; set; }
    public string FlexField3 { get; set; }
    public string FlexField4 { get; set; }
    public string FlexField5 { get; set; }
    public string FlexField6 { get; set; }
    public int SSN { get; set; }
    public string StatementDate { get; set; }
    public string PaymentDueDate { get; set; }
    public string PaymentAmount { get; set; }
    public string LatePaymentDueDate { get; set; }
    public string LatePaymentAmount { get; set; }
    public string EmailAddress { get; set; }
    public string FormattedAccount { get; set; }
    public int OrigCszOffset { get; set; }
    public int OrigCszLength { get; set; }
    public int DRecordCode { get; set; }
    public string DCustomArea { get; set; }
    
    public NCP10Model()
	{
	}
}
