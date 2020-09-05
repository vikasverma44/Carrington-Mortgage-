using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class NCP17Model
{
    public string RemitAddressLine1 { get; set; }
	public string RemitAddressLine2 { get; set; }
	public string RemitAddressLine3 { get; set; }
	public string RemitAddressLine4 { get; set; }
	public string RemitAddressLine5 { get; set; }
    public int IMBBarcodeIDRemit { get; set; }
	public int IMBServiceTypeIDRemit { get; set; }
	public int IMBMailerIDRemit { get; set; }
	public int IMBSerialNumberRemit { get; set; }
	public int IMBZipRemit { get; set; }
	public int IMBZip4Remit { get; set; }
	public int IMBDeliveryPointRemit { get; set; }
    public string EncodedIMBRemit { get; set; }
    public NCP17Model()
	{
		
	}
}
