using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataSave
{
    private const string FileType = ".txt";

    private static int SaveCount;
    public static void SaveData<T>(T data, string fileName)
    {
        Save();

        void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, data);
            string dataToSave = Convert.ToBase64String(memoryStream.ToArray());
            PlayerPrefs.SetString(fileName + FileType, dataToSave);
        }
    }

    public static T LoadData<T>(string fileName)
    {
        T dataToReturn = default;

        Load();

        return dataToReturn;

        void Load()
        {
            string dataToLoad = PlayerPrefs.GetString(fileName + FileType, "");
            if (!string.IsNullOrEmpty(dataToLoad))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(dataToLoad));
                try
                {
                    dataToReturn = (T)formatter.Deserialize(memoryStream);
                }
                catch
                {
                    dataToReturn = default;
                }
            }
            else
            {
                dataToReturn = default;
            }
        }
    }

    public static bool SaveExists(string fileName)
    {
        return PlayerPrefs.HasKey(fileName + FileType);
    }
}
