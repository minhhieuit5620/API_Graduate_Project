using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ISCommon.Utility
{
    public static class ISZipper
    {
        public static byte[] Zip(List<ZipItem> files)
        {
            byte[] archiveFile;
            using (var archiveStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true, System.Text.Encoding.UTF8))
                {
                    foreach (var file in files)
                    {
                        if (string.IsNullOrEmpty(file.FileName) || file.Content == null)
                        {
                            archive.CreateEntry(file.DirectoryPathInZip + "\\"); // Create Folder
                        }
                        else if (file.Content != null && file.Content.Length > 0)
                        {
                            var zipArchiveEntry = archive.CreateEntry(Path.Combine(file.DirectoryPathInZip, file.FileName), CompressionLevel.Fastest);
                            using (var zipStream = zipArchiveEntry.Open())
                                zipStream.Write(file.Content, 0, file.Content.Length);
                        }
                    }
                }

                archiveFile = archiveStream.ToArray();
            }

            return archiveFile;
        }
    }
}
