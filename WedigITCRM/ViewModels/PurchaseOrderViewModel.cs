﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewModels
{
    public class PurchaseOrderViewModel
    {
        public string PurchaseOrderId { get; set; }
        public string PurchaseOrderDocumentNumber { get; set; }

        [Required(ErrorMessage = "Der skal vælges en leverandør")]
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorStreet { get; set; }
        public string VendorCity { get; set; }
        public string VendorZip { get; set; }
        public string VendorCountryCode { get; set; }
        public string VendorCurrencyCode { get; set; }
        public string VendorPhoneNumber { get; set; }
        public string VendorHomePage { get; set; }
        public string VendorEmail { get; set; }
        public string VendorReference { get; set; }

        public string VendorPaymentConditionId { get; set; }

        public string VendorPaymentCondition { get; set; }

        public string VendorDeliveryConditionId { get; set; }

        public string VendorDeliveryCondition { get; set; }
        public string Note { get; set; }
        public string OurWantedDeliveryDate { get; set; }
        public string OurOrderingDate { get; set; }
        public string OurReference { get; set; }

        public string AttachedFilesNameAndPath { get; set; }
        public string AttachedmentIds { get; set; }
        public string FileNamesOnly { get; set; }
        public string IconsFilePathAndName { get; set; }
    }
}
