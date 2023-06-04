using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Tools.FileSaves
{
    public static class BinarySaves
    {
        private const string _SAVE_FOLDER_NAME = "Saves";
        private static readonly Encryption _encryption;
        private static readonly string _savePath;

        static BinarySaves()
        {
            _encryption = new Encryption();
            _savePath = $"{Application.persistentDataPath}/{_SAVE_FOLDER_NAME}/";

            if (!Directory.Exists(_savePath)) Directory.CreateDirectory(_savePath);
        }

#if UNITY_EDITOR
        [MenuItem("SUF/ClearSaves")]
#endif
        public static void ClearAllSaves()
        {
            DirectoryInfo directoryInfo = new(_savePath);

            if (!directoryInfo.Exists) return;

            FileInfo[] files = directoryInfo.GetFiles();
            for (int fileIndex = 0; fileIndex < files.Length; fileIndex++)
            {
                FileInfo file = files[fileIndex];
                file.Delete();
            }
        }

        public static void CreateAndInitFileIfNotExist(string fileName)
        {
            string filePath = _savePath + fileName;

            if (File.Exists(filePath)) return;

            using FileStream fileStream = File.Create(filePath);
            using BinaryWriter binaryWriter = new(fileStream, Encoding.UTF8, false);
            binaryWriter.Write(_encryption.Encrypt(SaveFile.GetDefaultData()));
        }

        public static void Save(SaveFile saveFile)
        {
            string filePath = _savePath + saveFile.fileName;

            using FileStream fileStream = File.Open(filePath, FileMode.Open);
            using BinaryWriter binaryWriter = new(fileStream, Encoding.UTF8, false);
            binaryWriter.Write(_encryption.Encrypt(saveFile.GetData()));
        }

        public static string Load(string fileName)
        {
            string filePath = _savePath + fileName;

            using FileStream fileStream = File.Open(filePath, FileMode.Open);
            using BinaryReader binaryReader = new(fileStream, Encoding.UTF8, false);
            string fileData = _encryption.Decrypt(binaryReader.ReadString());

            return fileData;
        }
    }
}