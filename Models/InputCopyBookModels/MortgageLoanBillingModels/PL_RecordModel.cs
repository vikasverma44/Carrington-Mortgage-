using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class PL_RecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string PL_Entity { get; set; }
        public string PLSSGroup { get; set; }
        public string PL_EntityStatus { get; set; }
        public string PLSSEntityBrandingName { get; set; }
        public string EntityBrandingAddressLine1  { get; set; }
        public string EntityBrandingAddressLine2 { get; set; }
        public string EntityBrandingCity { get; set; }
        public string EntityBrandingState { get; set; }

        public string EntityBrandingZipCode  { get; set; }
        public string EntityBrandingPhone { get; set; }
        public string PL_EntityTaxIdentificationNumber { get; set; }
        public string MERSOrganizationID { get; set; }
        public string HUDIDNumber { get; set; }
        public string VAID { get; set; }
        public string EntityRHSLenderBranchID { get; set; }
        public string EntityHUDContactNameFirst { get; set; }
        public string EntityHUDContactNameLast { get; set; }
        public string EntityHUDContactTelephone { get; set; }
        public string EntityHUDPrincipalServicingOfficeCity { get; set; }
        public string EntityHUDPrincipalServicingOfficeState { get; set; }

        public string EntityHUDPrincipalServicingOfficeZipCode { get; set; }
        public string EntityHUDCompanyHeadquartersStateCode { get; set; }
        public string EntityLockboxAddressLine1  { get; set; }
        public string EntityLockboxAddressLine2 { get; set; }
        public string EntityLockboxCity { get; set; }
        public string EntityLockboxState { get; set; }

        //

        public string EntityLockboxZipCode { get; set; }
        public string EntityAlternateAddress1 { get; set; }
        public string EntityAlternateAddress2 { get; set; }
        public string EntityAlternateCity { get; set; }
        public string EntityAlternateState { get; set; }
        public string EntityAlternateZipCode  { get; set; }
        public string EntityAlternatePhoneNumber1Desc { get; set; }
        public string EntityAlternatePhoneNumber1  { get; set; }
        public string EntityAlternatePhoneNumber2Desc { get; set; }
        public string EntityAlternatePhoneNumber2 { get; set; }
        public string EntityAlternatePhoneNumber3Desc { get; set; }
        public string EntityAlternatePhoneNumber3  { get; set; }
        public string EntityAlternatePhoneNumber4Desc { get; set; }
        public string EntityAlternatePhoneNumber4 { get; set; }
        public string EntityAlternatePhoneNumber5Desc { get; set; }
        public string EntityAlternatePhoneNumber5 { get; set; }
    }
}
