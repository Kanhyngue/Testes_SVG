using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData (InventorySystem inventory)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.cag";
        FileStream stream = new FileStream(path, FileMode.Create);
        AllData data = new AllData(inventory);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static AllData LoadData()
    {
         string path = Application.persistentDataPath + "/data.cag";
         if(File.Exists(path))
         {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AllData data = formatter.Deserialize(stream) as AllData;
            stream.Close();

            return data;
         }
         else
         {
             Debug.LogError("Salvamento não encontrado no " + path);
             return null;
         }
    }
}
