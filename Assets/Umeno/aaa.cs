using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class aaa : MonoBehaviour
{
    HeartBeat _heatBeatState;
    public class Data
    {
        public int score = 100;
    }
    //int score = 100;
    Data sco = new Data();
    Data agoScore;

    void Start()
    {
        agoScore = OnLoad();
        var n = 1;
        _heatBeatState = GameObject.FindObjectOfType<HeartBeat>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            _heatBeatState.State = HeartBeat.HeatBeatState.Normal;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _heatBeatState.State = HeartBeat.HeatBeatState.Danger;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _heatBeatState.State = HeartBeat.HeatBeatState.Stop;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            sco.score++;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Save");
            OnSave(sco);
        }
        Debug.Log($"Score:{sco.score}");
        Debug.Log($"AgoScore:{agoScore}");
    }
    public void OnSave(Data sco)
    {
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/savedata.json"))
        {
            string json = JsonUtility.ToJson(sco);
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }
    }
    public Data OnLoad()
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savedata.json"))
            {
                string datastr = "";
                datastr = reader.ReadLine();
                reader.Close();
                return JsonUtility.FromJson<Data>(datastr);
            }
        }
        catch
        {
            Debug.LogWarning("ÉfÅ[É^Ç™Ç†ÇËÇ‹ÇπÇÒ");
            return null;
        }

    }
}
