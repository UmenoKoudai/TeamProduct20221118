using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class RankingScript : MonoBehaviour
{
    [System.Serializable]
    public class scoredata
    {
        public string name;
        public int score;
    }
    public InputField _inputfield;
    public Text _rankingtext;
    int _resultscore;
    public static Dictionary<string, int> _dictionary 
        = new Dictionary<string, int>();

    scoredata sco2 = new scoredata();

    void Start()
    {
        _inputfield = _inputfield.GetComponent<InputField>();
        _rankingtext = _rankingtext.GetComponent<Text>();

        //スコアを取得する
        //_resultscore = GameManager._totalscore;

        //JSON形式で保存したハイスコアデータを呼び出しsco2変数に代入
        sco2 = OnLoad();
        //sco2に代入した前回のスコアをスコアの変数に代入
        if(sco2 != null)
        {
            for(var i = 0;i < sco2.name.Length;i++)
            {
                _dictionary.Add(sco2.name, sco2.score);
            }
        }
    }
    void Update()
   {

   }

    public void NameScore()
    {
        sco2.name = _inputfield.text;
        sco2.score = _resultscore;
        OnSave(sco2);
    }
    public void Score()
    {
        _dictionary.Add(_inputfield.text, _resultscore);
        foreach (var ans in _dictionary.OrderByDescending(c => c.Value))
        {
            _rankingtext.text = ans.Key + " " + ans.Value.ToString();
        }
       
    }

    //スコアをJSON形式で保存
    public void OnSave(scoredata sco)
    {
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/savedata.json"))
        {
            string json = JsonUtility.ToJson(sco);
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }
    }
    //スコアの呼び出し
    public scoredata OnLoad()
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savedata.json"))
            {
                //string datastr = "";
                //string datastr = "";
                string datastr = reader.ReadLine();
                reader.Close();
                return JsonUtility.FromJson<scoredata>(datastr); ;
            }
        }
        catch
        {
            Debug.LogWarning("データがありません");
            return null;
        }

    }
   
}
