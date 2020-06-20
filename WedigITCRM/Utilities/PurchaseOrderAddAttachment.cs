using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.Utilities
{
    public class PurchaseOrderAddAttachment
    {
        private readonly IContentTypeRepository _contentTypeRepository;
        private readonly MiscUtility _miscUtility;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderAddAttachment(IContentTypeRepository contentTypeRepository, MiscUtility miscUtility, IPurchaseOrderRepository purchaseOrderRepository)
        {
            _contentTypeRepository = contentTypeRepository;
            _miscUtility = miscUtility;
            _purchaseOrderRepository = purchaseOrderRepository;
        }
        public void addAttacment( PurchaseOrder purchaseOrder, string uniquePDFFileName, string uniquePDFFilePathAndName, Attachment attachment)
        {
            List<string> fileNamesOnlyList = new List<string>();
            if (!string.IsNullOrEmpty(purchaseOrder.FileNamesOnly))
            {
                fileNamesOnlyList = purchaseOrder.FileNamesOnly.Split(",").ToList();
                fileNamesOnlyList.Add(uniquePDFFileName);
                purchaseOrder.FileNamesOnly = string.Join(",", fileNamesOnlyList);
            }
            else
            {
                purchaseOrder.FileNamesOnly = uniquePDFFileName;
            }

            List<string> attachmentIdList = new List<string>();
            if (!string.IsNullOrEmpty(purchaseOrder.AttachedmentIds))
            {
                attachmentIdList = purchaseOrder.AttachedmentIds.Split(",").ToList();
                attachmentIdList.Add(attachment.Id.ToString());
                purchaseOrder.AttachedmentIds = string.Join(",", attachmentIdList);
            }
            else
            {
                purchaseOrder.AttachedmentIds = attachment.Id.ToString();
            }

            List<string> AttachedFilesNameAndPathList = new List<string>();
            if (!string.IsNullOrEmpty(purchaseOrder.AttachedFilesNameAndPath))
            {
                AttachedFilesNameAndPathList = purchaseOrder.AttachedFilesNameAndPath.Split(",").ToList();
                AttachedFilesNameAndPathList.Add(uniquePDFFilePathAndName);
                purchaseOrder.AttachedFilesNameAndPath = string.Join(",", AttachedFilesNameAndPathList);
            }
            else
            {
                purchaseOrder.AttachedFilesNameAndPath = uniquePDFFilePathAndName;
            }

            string iconFilePathAndName = _miscUtility.getIconFilenameAndPath(attachment.ContentType, _contentTypeRepository);

            List<string> IconsFilePathAndNameList = new List<string>();
            if (!string.IsNullOrEmpty(purchaseOrder.IconsFilePathAndName))
            {
                IconsFilePathAndNameList = purchaseOrder.IconsFilePathAndName.Split(",").ToList();
                IconsFilePathAndNameList.Add(iconFilePathAndName);
                purchaseOrder.IconsFilePathAndName = string.Join(",", IconsFilePathAndNameList);
            }
            else
            {

                purchaseOrder.IconsFilePathAndName = iconFilePathAndName;
            }
            purchaseOrder.LastEditedDate = DateTime.Now;
            _purchaseOrderRepository.Update(purchaseOrder);
        }
    }
}
