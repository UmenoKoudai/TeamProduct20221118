using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class ExpansionMethod
{
    /// <summary>
    /// �����ɐ��l��n��Json�`���ŕۑ�����
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
    /// ����������ϐ��������ɐݒ肷�邱�Ƃœ����^��Json�t�@�C�����琔�l��������
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
            Debug.LogWarning("�f�[�^������܂���B");
            return data = (T)(object)0;
        }
    }
    /// <summary>
    /// GameObject[]�^�̕����A�C�e���̔z��ň����ɃC���f�b�N�X��n������I�񂾕���ȊO��false�ɂ��đI�񂾕����true�ɂ���
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
    /// List<GameObject>�^�̕����A�C�e���̃��X�g�ň����ɃC���f�b�N�X��n������I�񂾕���ȊO��false�ɂ��đI�񂾕����true�ɂ���
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
