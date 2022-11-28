using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;


public class RankingTest : MonoBehaviour
{
    public class RankingData
    {
        public Dictionary<string, int> rankingData;
    }
    [SerializeField] InputField _inputField;
    [SerializeField] Text _rankingText;
    RankingData _data = new RankingData();
    public static Dictionary<string, int> dic = new Dictionary<string, int>();
    int score;


    private void Start()
    {
        _data = OnLoad();
        if (_data != null)
        {
            dic = _data.rankingData;
        }
    }

    private void Update()
    {
        //if (!dic.Any())
        //{
        //    _rankingText.text = string.Join("\n", dic);
        //}
    }

    public void ScoreSave()
    {
        dic.Add(_inputField.text, score);
        score++;
        _data.rankingData = dic;
        OnSave(_data);
    }
    //スコアをJSON形式で保存
    public void OnSave(RankingData data)
    {
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/savedata.json"))
        {
            string json = JsonUtility.ToJson(data);
            writer.Write(json);
            //writer.Flush();
            writer.Close();
        }
    }
    //スコアの呼び出し
    public RankingData OnLoad()
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savedata.json"))
            {
                string datastr = reader.ReadLine();
                reader.Close();
                return JsonUtility.FromJson<RankingData>(datastr); ;
            }
        }
        catch
        {
            Debug.LogWarning("データがありません");
            return null;
        }
    }
}
