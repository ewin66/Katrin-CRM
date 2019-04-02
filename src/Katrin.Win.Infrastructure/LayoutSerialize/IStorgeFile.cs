using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Katrin.Win.Infrastructure.LayoutSerialize
{
    public interface IStorgeFile
    {
        bool DirectoryExists(string path);
        void DeleteDirectory(string path);
        bool FileExists(string path);
        Stream OpenFile(string path, FileMode mode);
        void CreateDirectory(string path);
    }
}
