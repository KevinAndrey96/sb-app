using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace SocialBusinessApp.Services
{
    public interface IMediaService
    {
        Task OpenGallery();
        void ClearFiles(List<string> filePaths);
    }
}