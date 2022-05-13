using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KSHYWeb.Extensions
{
    public static class ImageExtensions
    {
        public static async Task ResizeImage(this Image image, string targetFile, int width=0, int height=0,Int64 ImgEnCode= 30L, int ResolutionRatio=2)
        {
            if (width <= 0)
                width = image.Width;
            if (height <= 0)
                height = image.Height;
            ImageCodecInfo jgpEncoder =await GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, ImgEnCode);
            myEncoderParameters.Param[0] = myEncoderParameter;

            var thumbnailBitmap = new Bitmap(width, height);
            var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            thumbnailBitmap.SetResolution(image.HorizontalResolution / ResolutionRatio, image.VerticalResolution / ResolutionRatio);
            var imageRectangle = new Rectangle(0, 0, width, height);
            thumbnailGraph.DrawImage(image, imageRectangle);
            thumbnailBitmap.Save(targetFile, jgpEncoder, myEncoderParameters);
            GC.Collect();
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
        }
        public static async Task ResizeImage(this IFormFile file, string targetFile, int width = 0, int height=0, Int64 ImgEnCode = 30L, int ResolutionRatio = 2)
        {
            var image = Image.FromStream(file.OpenReadStream());
            if (width <= 0)
                width = image.Width;
            if (height <= 0)
                height = image.Height;
            ImageCodecInfo jgpEncoder = await GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, ImgEnCode);
            myEncoderParameters.Param[0] = myEncoderParameter;

            var thumbnailBitmap = new Bitmap(width, height);
            var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            thumbnailBitmap.SetResolution(image.HorizontalResolution / ResolutionRatio, image.VerticalResolution / ResolutionRatio);
            var imageRectangle = new Rectangle(0, 0, width, height);
            thumbnailGraph.DrawImage(image, imageRectangle);
            thumbnailBitmap.Save(targetFile, jgpEncoder, myEncoderParameters);
            GC.Collect();
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
        }
        public static async Task<byte[]> ResizeImage(this IFormFile file, int width = 0, int height = 0, Int64 ImgEnCode = 30L, int ResolutionRatio = 2)
        {
            byte[] data;
            var image = Image.FromStream(file.OpenReadStream());
            if (width <= 0)
                width = image.Width;
            if (height <= 0)
                height = image.Height;
            ImageCodecInfo jgpEncoder = await GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, ImgEnCode);
            myEncoderParameters.Param[0] = myEncoderParameter;


            var thumbnailBitmap = new Bitmap(width, height);
            thumbnailBitmap.SetResolution(image.HorizontalResolution / ResolutionRatio, image.VerticalResolution / ResolutionRatio);
            var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, width, height);
            thumbnailGraph.DrawImage(image, imageRectangle);
            using (MemoryStream ms = new MemoryStream())
            {
                thumbnailBitmap.Save(ms, jgpEncoder, myEncoderParameters);
                data = ms.ToArray();
            }
            GC.Collect();
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            return data;
        }
        public static async Task<byte[]> PreviewThumnail(this Image image,int width=270,int height=180)
        {
            byte[] data;       
            ImageCodecInfo jgpEncoder = await GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
            myEncoderParameters.Param[0] = myEncoderParameter;


            var thumbnailBitmap = new Bitmap(width, height);
            thumbnailBitmap.SetResolution(image.HorizontalResolution / 2, image.VerticalResolution / 2);
            var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, width, height);
            thumbnailGraph.DrawImage(image, imageRectangle);
            using (MemoryStream ms = new MemoryStream())
            {
                thumbnailBitmap.Save(ms, jgpEncoder, myEncoderParameters);
                data= ms.ToArray();
            }
            GC.Collect();
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            return data;
        }
        public static async Task<byte[]> PreviewThumnail(this IFormFile file, int width = 270, int height = 180)
        {
            byte[] data;
            var image = Image.FromStream(file.OpenReadStream());
            ImageCodecInfo jgpEncoder = await GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
            myEncoderParameters.Param[0] = myEncoderParameter;


            var thumbnailBitmap = new Bitmap(width, height);
            thumbnailBitmap.SetResolution(image.HorizontalResolution / 2, image.VerticalResolution / 2);
            var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, width, height);
            thumbnailGraph.DrawImage(image, imageRectangle);
            using (MemoryStream ms = new MemoryStream())
            {
                thumbnailBitmap.Save(ms, jgpEncoder, myEncoderParameters);
                data = ms.ToArray();
            }
            GC.Collect();
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            return data;
        }       
        private static async Task<ImageCodecInfo> GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs =await Task.FromResult(ImageCodecInfo.GetImageDecoders());

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }     
        public static bool IsImage(string fileName,string ImageExtensions)
        {           
            var allowedExtensions = ImageExtensions.Split(',');
            var extension = Path.GetExtension(fileName);
            if (!string.IsNullOrEmpty(extension))
                return allowedExtensions.Any(e => e.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase));
            else
                return false;
        }
    }
}
