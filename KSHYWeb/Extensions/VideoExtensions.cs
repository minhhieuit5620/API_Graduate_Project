using Google.GData.Client;
//using Google.YouTube;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace KSHYWeb.Extensions
{
    public static class VideoExtensions
    {
       
        //public static async Task<string> UploadVideo(this IFormFile file,string AppName, string Key, string UserName, string Password, string Title, string Description)
        //{
        //    YouTubeRequestSettings settings;
        //    YouTubeRequest request;
        //    settings = new YouTubeRequestSettings(AppName, Key, UserName, Password) { Timeout = -1 };
        //    request = new YouTubeRequest(settings);
        //    Video newVideo = new Video();
        //    newVideo.Title = Title;
        //    newVideo.Description = Description;
        //    newVideo.Private = true;
        //    newVideo.YouTubeEntry.Private = false;
        //    //newVideo.Tags.Add(new MediaCategory("Autos", YouTubeNameTable.CategorySchema));

        //    //newVideo.Tags.Add(new MediaCategory("mydevtag, anotherdevtag", YouTubeNameTable.DeveloperTagSchema));
        //    newVideo.YouTubeEntry.MediaSource = new MediaFileSource(file.OpenReadStream(), file.FileName, "video/"+ Path.GetExtension(file.FileName).Replace(".",""));
        //    Video createdVideo =await Task.FromResult(request.Upload(newVideo));

        //    return createdVideo.VideoId;
        //}
     
    }
}
