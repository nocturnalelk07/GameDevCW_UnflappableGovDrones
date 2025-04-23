using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Overlays;
//save game system provided by sean

public static class saveGameSystem
{
    public static bool SaveGame (saveDataClass saveGame, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(GetSavePath(name), FileMode.Create))
        {
            try
            {
                formatter.Serialize(stream, saveGame);
            } catch (Exception)
            {
                return false;
            }
        }

        return true;
    }

    public static saveDataClass LoadGame (string name)
    {
        if (!doesSaveGameExist(name))
        {
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(GetSavePath(name), FileMode.Open))
        {
            try
            {
                saveDataClass myData;
                myData = formatter.Deserialize(stream) as saveDataClass;
                return myData;
            } catch (Exception)
            {
                return null;
            }
        }
    }

    public static bool DeleteSaveGame (string name)
    {
        try
        {
            File.Delete(GetSavePath(name));
        } catch (Exception)
        {
            return false;
        }

        return true;
    }

    public static bool doesSaveGameExist (string name)
    {
        return File.Exists(GetSavePath(name));
    }

    private static string GetSavePath (string name)
    {
        return Path.Combine(Application.persistentDataPath, name + ".sav");
    }
}
