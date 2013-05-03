using ImageResizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLawyerGUI.Helpers
{
    public class ImageHelper
    {
        public void Resize(string ImagePath)
        {
            ImageResizer.ImageBuilder.Current.Build(ImagePath, "", new ResizeSettings(""));
        }
    }
}