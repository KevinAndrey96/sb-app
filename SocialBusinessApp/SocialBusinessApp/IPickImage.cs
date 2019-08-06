using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp
{
    public interface IPickImage
    {
        void getImage();
        void ClearFiles(List<string> filePaths);
    }
}
