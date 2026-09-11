using System;
using System.IO;
using System.Text;

using UnityEngine;

public static class PersistentSaveLoad
{
    public static T Load<T>(string fileName, bool isFullPath = false)
    {
        string fileNameWithPath = isFullPath ? fileName : Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;
        if (!File.Exists(fileNameWithPath))
        {
#if DEBUG
            Debug.LogWarning(fileNameWithPath + " does not exist");
#endif
            return default;
        }

        try
        {
            using (StreamReader stream = new(fileNameWithPath, Encoding.UTF8))
            {
                string jsonData = stream.ReadToEnd();
#if DEBUG
                Debug.Log(jsonData);
#endif
                T data = JsonUtility.FromJson<T>(jsonData);
                stream.Close();
                return data;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("PersistentData.Load: " + fileNameWithPath + " " + e.Message);
        }

        return default;
    }

    public static void Save<T>(string fileName, T data, bool isFullPath = false)
    {
        string fileNameWithPath = isFullPath ? fileName : Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;
        try
        {
            string jsonData = JsonUtility.ToJson(data);

            using (StreamWriter stream = new(fileNameWithPath, false, Encoding.UTF8))
            {
                stream.Write(jsonData);
                stream.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogError("PersistentData.Save: " + fileNameWithPath + " " + e.Message);
        }
    }

    public static void Delete(string fileName, bool isFullPath = false)
    {
        string fileNameWithPath = isFullPath ? fileName : Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;
        File.Delete(fileNameWithPath);
    }
}
