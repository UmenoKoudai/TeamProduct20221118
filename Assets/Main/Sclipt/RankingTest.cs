using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;


public class RankingTest : MonoBehaviour
{
    [SerializeField] InputField _inputField;
    Dictionary<string, int> dic = new Dictionary<string, int>();
    int score;

    public void ScoreSave()
    {
        dic.Add(_inputField.text, score);
        score++;
        foreach (var a in dic)
        {
            Debug.Log($"名前：{a.Key} スコア：{a.Value}");
        }
    }
}
