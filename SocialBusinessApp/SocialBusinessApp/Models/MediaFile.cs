using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp.Models
{
    public enum MediaFileType

    {

        Image,

        Video

    }



    public class MediaFile

    {

        public string PreviewPath { get; set; }

        public string Path { get; set; }

        public MediaFileType Type { get; set; }

    }
}
