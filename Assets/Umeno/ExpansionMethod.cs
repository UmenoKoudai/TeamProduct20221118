using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class ExpansionMethod
{
    /// <summary>
    /// 引数に数値を渡しJson形式で保存する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
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
    /// <summary>
    /// 代入したい変数を引数に設定することで同じ型でJsonファイルあら数値を代入する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
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
    /// <summary>
    /// GameObject[]型の武器やアイテムの配列で引数にインデックスを渡したら選んだ武器以外をfalseにして選んだ武器をtrueにする
    /// </summary>
    /// <param name="weapons"></param>
    /// <param name="index"></param>
    public static void WeaponChange(this GameObject[] weapons, int index)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[index].SetActive(true);
    }
    /// <summary>
    /// List<GameObject>型の武器やアイテムのリストで引数にインデックスを渡したら選んだ武器以外をfalseにして選んだ武器をtrueにする
    /// </summary>
    /// <param name="weapons"></param>
    /// <param name="index"></param>
    public static void WeaponChange(this List<GameObject> weapons, int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[index].SetActive(true);
    }
}
