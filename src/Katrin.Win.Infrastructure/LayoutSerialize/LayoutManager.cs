using System.Linq;
using System.Deployment.Application;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Forms;
using DevExpress.Utils.Serializing;

namespace Katrin.Win.Infrastructure.LayoutSerialize
{
    public class LayoutManager
    {
        private const string Layouts = "Layouts";

        private static IStorgeFile GetStorageFile()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                return new IsolatedFile();
            }
            return new RegularFile();
        }

        public static void Clear()
        {
            var isoStore = GetStorageFile();
            if (isoStore.DirectoryExists(Layouts))
            {
                isoStore.DeleteDirectory(Layouts);
            }
        }

        public static void SaveLayout(ISupportLayoutSerializer control, string fileNameWithoutExtension)
        {
            if (control != null && control.SerializableObjects.Any())
            {

                foreach (var serializableObject in control.SerializableObjects)
                {
                    var fileFullName = fileNameWithoutExtension + "." + serializableObject.Key + ".xml";
                    
                    Serialize(fileFullName, serializableObject.Value);
                }
            }
        }

        public static void Serialize(string fileFullName, ILayoutSerializer serializer)
        {
            var isoStore = GetStorageFile();

            if (!isoStore.DirectoryExists(Layouts))
            {
                isoStore.CreateDirectory(Layouts);
            }
            var fileFullPath = Path.Combine(Layouts, fileFullName);
            using (var stream = isoStore.OpenFile(fileFullPath, FileMode.Create))
            {
                serializer.SaveLayoutToStream(stream);
            }
        }

        public static void RestoreLayout(ISupportLayoutSerializer control, string fileNameWithoutExtension)
        {
            if (control != null && control.SerializableObjects.Any())
            {
                var isoStore = GetStorageFile();

                foreach (var serializableObject in control.SerializableObjects)
                {
                    var fileFullName = fileNameWithoutExtension + "." + serializableObject.Key + ".xml";
                    Deserialize(fileFullName, serializableObject.Value);
                }
            }
        }

        public static void Deserialize(string fileFullName, ILayoutSerializer serializer)
        {
            var fileFullPath = Path.Combine(Layouts, fileFullName);
            var isoStore = GetStorageFile();
            if (isoStore.FileExists(fileFullPath))
            {
                using (var stream = isoStore.OpenFile(fileFullPath, FileMode.Open))
                {
                    serializer.RestoreLayoutFromStream(stream);
                }
            }
        }
    }
}
