using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.IsolatedStorage;

namespace Katrin.Win.Infrastructure.LayoutSerialize
{
    public class IsolatedFile : IStorgeFile
    {
        private IsolatedStorageFile _isolatedStorageFile;
        public IsolatedFile()
        {
            _isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
        }

        public bool DirectoryExists(string path)
        {
            return _isolatedStorageFile.DirectoryExists(path);
        }

        public bool FileExists(string path)
        {
            return _isolatedStorageFile.FileExists(path);
        }

        public Stream OpenFile(string path, FileMode mode)
        {
            return new IsolatedStorageFileStream(path, mode, _isolatedStorageFile);
        }

        public void CreateDirectory(string path)
        {
            _isolatedStorageFile.CreateDirectory(path);
        }


        public void DeleteDirectory(string path)
        {
            if (!DirectoryExists(path))
                return;
            string[] fileNames = _isolatedStorageFile.GetFileNames(path + "\\*");

            // Delete all the files currently in the Archive directory.

            if (fileNames.Length > 0)
            {
                for (int i = 0; i < fileNames.Length; ++i)
                {
                    // Delete the files.
                    _isolatedStorageFile.DeleteFile(path + "\\" + fileNames[i]);
                }
                // Confirm that no files remain.
                fileNames = _isolatedStorageFile.GetFileNames(path + "\\*");
            }
            _isolatedStorageFile.DeleteDirectory(path);
        }
    }
}
