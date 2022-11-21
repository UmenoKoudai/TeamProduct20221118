using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class ExpansionMethod
{
    public static void OnSave<T>(T data)
    {
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/savedata.json"))
        {
            string json = JsonUtility.ToJson(data);
            writer.Write(json);
            //writer.Flush();
            writer.Close();
        }
    }
    public static T OnLoad<T>(T data)
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savedata.json"))
            {
                string read = "";
                read = reader.ReadLine();
                reader.Close();
                return data = JsonUtility.FromJson<T>(read);
            }
        }
        catch
        {
            Debug.LogWarning("データがありません。");
            return data = (T)(object)0;
        }
    }
    public static void WeaponChange(List<GameObject> weapons, int index)
    {
        for(int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[index].SetActive(true);
    }

}
