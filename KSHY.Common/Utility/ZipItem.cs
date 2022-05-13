using System;
using System.IO;
using System.Text;

namespace ISCommon.Utility
{
    public class ZipItem
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string DirectoryPathInZip { get; set; }

        public ZipItem(string name, Stream content)
        {
            _ZipItem(name, content, "");
        }

        public ZipItem(string name, Stream content, string directoryPathInZip)
        {
            _ZipItem(name, content, directoryPathInZip);
        }

        private void _ZipItem(string name, Stream content, string directoryPathInZip)
        {
            content.Position = 0;
            byte[] buffer = new byte[content.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < content.Length;)
                totalBytesCopied += content.Read(buffer, totalBytesCopied, Convert.ToInt32(content.Length) - totalBytesCopied);
            this.FileName = name;
            this.DirectoryPathInZip = directoryPathInZip;
            this.Content = buffer;
        }

        public ZipItem(string name, byte[] content)
        {
            _ZipItem(name, content, "");
        }

        public ZipItem(string name, byte[] content, string directoryPathInZip)
        {
            _ZipItem(name, content, directoryPathInZip);
        }

        private void _ZipItem(string name, byte[] content, string directoryPathInZip)
        {
            this.FileName = name;
            this.DirectoryPathInZip = directoryPathInZip;
            this.Content = content;
        }

        public ZipItem(string name, string contentStr, Encoding encoding)
        {
            _ZipItem(name, contentStr, encoding, "");
        }

        public ZipItem(string name, string contentStr, Encoding encoding, string directoryPathInZip)
        {
            _ZipItem(name, contentStr, encoding, directoryPathInZip);
        }

        private void _ZipItem(string name, string contentStr, Encoding encoding, string directoryPathInZip)
        {
            this.FileName = name;
            this.DirectoryPathInZip = directoryPathInZip;
            this.Content = encoding.GetBytes(contentStr);
        }


        public ZipItem(string name, string path)
        {
            _ZipItem(name, path, "");
        }

        public ZipItem(string name, string path, string directoryPathInZip)
        {
            _ZipItem(name, path, directoryPathInZip);
        }

        private void _ZipItem(string name, string path, string directoryPathInZip)
        {
            if (!string.IsNullOrEmpty(path))
            {
                using (var content = new FileStream(path, FileMode.Open))
                {
                    byte[] buffer = new byte[content.Length];
                    for (int totalBytesCopied = 0; totalBytesCopied < content.Length;)
                        totalBytesCopied += content.Read(buffer, totalBytesCopied, Convert.ToInt32(content.Length) - totalBytesCopied);

                    this.Content = buffer;
                }
            }

            this.FileName = name;
            this.DirectoryPathInZip = directoryPathInZip;
        }
    }
}
