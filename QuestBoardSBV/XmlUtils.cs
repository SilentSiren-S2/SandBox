using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuestBoardSBV
{
    public static class XmlUtils
    {
        public enum StorageLocation
        {
            AppData,
            ProjectBin
        }

        private static readonly string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tempest", "Quests");
        private static readonly string projectBinFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tempest", "Quests");

        public static List<T> LoadData<T>(string fileName, StorageLocation location)
        {
            string filePath = GetFilePath(fileName, location);
            List<T> data = new List<T>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    data = (List<T>)serializer.Deserialize(fs);
                }
            }
            return data;
        }

        public static void SaveData<T>(List<T> data, string fileName, StorageLocation location)
        {
            string filePath = GetFilePath(fileName, location);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Create directory if not exists
            
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }
        }

        private static string GetFilePath(string fileName, StorageLocation location)
        {
            string baseDirectory = location switch
            {
                StorageLocation.AppData => appDataFolder,
                StorageLocation.ProjectBin => projectBinFolder,
                _ => throw new ArgumentException("Invalid storage location"),
            };

            return Path.Combine(baseDirectory, fileName);
        }
    }
}