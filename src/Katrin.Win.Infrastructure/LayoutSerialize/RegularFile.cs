using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Katrin.Win.Infrastructure.LayoutSerialize
{
    public class RegularFile : IStorgeFile
    {
        public RegularFile()
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public Stream OpenFile(string path, FileMode mode)
        {
            return File.Open(path, mode);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }


        public void DeleteDirectory(string path)
        {
            Directory.Delete(path,true);
        }
    }
}
