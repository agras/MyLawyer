using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.IO;

namespace MyLawyerGUI.Helpers
{
    public class ValidateFileAttribute : ValidationAttribute
    {

        public int MaxContentLength = int.MaxValue;
        public string[] AllowedFileExtensions;
        public string[] AllowedContentTypes;

        public override bool IsValid(object value)
        {
            int maxContent = 1024 * 1024; //1 MB
            string[] sAllowedExt = new string[] { ".jpg", ".gif", ".png" };


            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!sAllowedExt.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", sAllowedExt);
                return false;
            }
            else if (file.ContentLength > maxContent)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (maxContent / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }


        //public override bool IsValid(object value)
        //{
        //    var file = value as HttpPostedFileBase;
        //    var fileName = Path.GetFileName(file.FileName);
        //    var fileExtension = Path.GetExtension(file.FileName);

        //    var imgExtList = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
            
        //    if (file == null || !(file.ContentLength > 0))
        //    {
        //        return false;
        //    }

        //    if (file.ContentLength > 2 * 1024 * 1024)
        //    {
        //        return false;
        //    }

        //    if (imgExtList.Contains(fileExtension))
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        using (var img = Image.FromStream(file.InputStream))
        //        {
        //            return img.RawFormat.Equals(ImageFormat.Png);
        //        }
        //    }
        //    catch { }
        //    return false;
        //}
    }
}