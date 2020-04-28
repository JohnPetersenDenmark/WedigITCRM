using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.Utilities
{
    public class MiscUtility
    {
        public static string formatPhoneNumber(string phoneNum)
        {
            if (phoneNum == null)
            {
                return null;
            }
            string phoneFormat = "";

            if (phoneFormat == "")
            {
                // If phone format is empty, code will use default format (###) ###-####
                phoneFormat = "(###) ###-####";
            }

            // First, remove everything except of numbers
            Regex regexObj = new Regex(@"[^\d]");
            phoneNum = regexObj.Replace(phoneNum, "");

            switch (phoneNum.Length)
            {
                case 10:
                    phoneFormat = "+## #### ####";
                    break;
                case 8:
                    phoneFormat = "#### ####";
                    break;
                default:
                    phoneFormat = "########";
                    break;
            }


            // Second, format numbers to phone string 
            if (phoneNum.Length > 0)
            {
                phoneNum = Convert.ToInt64(phoneNum).ToString(phoneFormat);
            }

            return phoneNum;

        }

        public static DateTime roundUpToNearest15minutes (DateTime dateTimetoRoundUp)
        {

            int minutesToAdd = 0;

           
            if (dateTimetoRoundUp.Minute > 0 && dateTimetoRoundUp.Minute <= 15)
            {
                minutesToAdd = 15 - dateTimetoRoundUp.Minute;
            }

            if (dateTimetoRoundUp.Minute > 15 && dateTimetoRoundUp.Minute <= 30)
            {
                minutesToAdd = 30 - dateTimetoRoundUp.Minute;
            }


            if (dateTimetoRoundUp.Minute > 30 && dateTimetoRoundUp.Minute <= 45)
            {
                minutesToAdd = 45 - dateTimetoRoundUp.Minute;
            }

            if (dateTimetoRoundUp.Minute > 45 && dateTimetoRoundUp.Minute <= 60)
            {
                minutesToAdd = 60 - dateTimetoRoundUp.Minute;
            }

            if ( minutesToAdd == 0)
            {
                return dateTimetoRoundUp;
            }


            DateTime tmpDateTime = dateTimetoRoundUp.AddMinutes(minutesToAdd);
            return tmpDateTime;
        }

        
        public string GetFieldRelatedIdentityUserError(IdentityError error)
        {
            switch (error.Code)
            {
                // password related errors
                case "PasswordMismatch":
                    return "password";

                case "PasswordTooShort":
                    return "password";

                case "PasswordRequiresNonAlphanumeric":
                    return "password";

                case "PasswordRequiresDigit":
                    return "password";

                case "PasswordRequiresLower":
                    return "password";

                case "PasswordRequiresUpper":
                    return "password";


                // email related errors
                case "InvalidEmail":
                    return "email";

                case "DuplicateEmail":
                    return "email";

                case "DuplicateUserName":
                    return "email";

                // role related errors

                case "InvalidRoleName":
                    return "name";

                case "DuplicateRoleName":
                    return "name";

            }



            return "";
        }

        public string getIconFilenameAndPath(string contentTypeString, IContentTypeRepository _contentTypeRepository)
        {
            string iconFileName = null;
            string iconFilePathAndName = null;

            string fileTypeIconFolder = "/" + "Images/Icons-filtypes";

            EntitityModels.ContentType contentType = _contentTypeRepository.GetContentType(contentTypeString);

            if (contentType != null)
            {
                iconFileName = contentType.IconFileName;
            }
            else
            {
                iconFileName = "tmp.svg";
            }


            iconFilePathAndName = fileTypeIconFolder + "/" + iconFileName;

            return iconFilePathAndName;

        }
    }
}
