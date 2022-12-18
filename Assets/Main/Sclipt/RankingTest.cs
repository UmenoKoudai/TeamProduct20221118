using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;


public class RankingTest : MonoBehaviour
{
    //public class RankingData
    //{
    //    public Dictionary<string, int> rankingData;
    //    public RankingData(string name, int score)
    //    {
    //        rankingData.Add(name, score);
    //    }
    //}
    //[SerializeField] InputField _inputField;
    //[SerializeField] Text _rankingText;
    //RankingData _data = new RankingData("test", 0);
    //public static Dictionary<string, int> dic = new Dictionary<string, int>();
    //int score;


    //private void Start()
    //{
    //    _data = _data.OnLoad();
    //    if (_data != null)
    //    {
    //        dic = _data.rankingData;
    //    }
    //}

    //private void Update()
    //{
    //    _rankingText.text = string.Join("\n", dic);
    //}

    //public void ScoreSave()
    //{
    //    if(dic.Keys.Contains("test"))
    //    {
    //        dic.Remove("test");
    //    }
    //    dic.Add(_inputField.text, score);
    //    score++;
    //    _data.rankingData = dic;
    //    _data.OnSave();
    //}
}
