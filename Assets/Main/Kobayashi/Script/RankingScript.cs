using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class RankingScript : MonoBehaviour
{ 
    public InputField _inputfield;
    public Text _rankingtext;
    int _resultscore;
    public static Dictionary<string, int> _dictionary 
        = new Dictionary<string, int>();
    // ‘‚«‚İ
    string path = Application.persistentDataPath + "/test.txt";
    bool isAppend = true; // ã‘‚« or ’Ç‹L
     


void Start()
    {
       
        _inputfield = _inputfield.GetComponent<InputField>();
        _rankingtext = _rankingtext.GetComponent<Text>();
        //_resultscore = Total Score;
    }

    public void Score()
    {
        _dictionary.Add(_inputfield.text, _resultscore);
        foreach (var ans in _dictionary.OrderByDescending(c => c.Value))
        {
            _rankingtext.text = ans.Key + " " + ans.Value.ToString();
        }
        using (var fs = new StreamWriter(path, isAppend, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            fs.Write(_dictionary);
        }
        using (var fs = new StreamReader(path, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            string result = fs.ReadToEnd();
            Debug.Log(result);
        }
    }
    /*void Update()
    {
        
    }*/
}
