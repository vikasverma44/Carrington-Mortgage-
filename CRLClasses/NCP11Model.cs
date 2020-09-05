using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class NCP11Model
{

    public int DocID { get; set; }
    public int TrackingId { get; set; }
    public string PullType { get; set; }
    public int OriginalTrackingId { get; set; }
    public int JobNumber { get; set; }
    public int SequenceNumber { get; set; }
    public string ProductNumber { get; set; }
    public int OptionNumber { get; set; }
    public bool UseFeedAssurance { get; set; }
   
    public string FeedAssuranceBarcode { get; set; }
    public string OrderType { get; set; }
    public int PrintDelivery { get; set; }
    public int ElectronicDelivery { get; set; }
    public string ElectronicDeliveryMethod { get; set; }
    public string AddressCorrectionIndicator { get; set; }
    public string IMBIndicator { get; set; }
    public int ParentHouseholdGroupNumber { get; set; }
    public int HouseholdingGroup { get; set; }
    public int HouseholdingSequence { get; set; }
    public string PrintProgramName { get; set; }
    public string OnlineViewProductNumber { get; set; }
    public int IsReject { get; set; }
    public int PhysicalPageCount { get; set; }
    public int LogicalPageCount { get; set; }
    public int TotalSheetsAdded { get; set; }
    public int SheetCountThreshold { get; set; }
    public int TotalBillableSheets { get; set; }
    public NCP11Model()
	{
	
	}
}
