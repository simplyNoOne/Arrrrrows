using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveManager 
{
    
    public static void SaveData()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = System.IO.Path.Combine(Application.persistentDataPath, "save.arrows");
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();

        binaryFormatter.Serialize(stream, data);
        stream.Close();
    }


    public static PlayerData LoadData()
    {
        
        string path = Path.Combine(Application.persistentDataPath, "save.arrows");
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = binaryFormatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            stream.Close();
            return null;
        }
        
    }
}
