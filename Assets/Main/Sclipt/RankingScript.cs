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
    public Dictionary<string, int> _dictionary 
        = new Dictionary<string, int>();
    List<scoredata> _rankingData;
    scoredata sco2 = new scoredata();

    void Start()
    {
        _inputfield = _inputfield.GetComponent<InputField>();
        _rankingtext = _rankingtext.GetComponent<Text>();
        _resultscore = FindObjectOfType<GameManager>().TotalScore;

        //�X�R�A���擾����
        //_resultscore = GameManager._totalscore;

        //JSON�`���ŕۑ������n�C�X�R�A�f�[�^���Ăяo��sco2�ϐ��ɑ��
        _rankingData = OnLoad();
        //sco2�ɑ�������O��̃X�R�A���X�R�A�̕ϐ��ɑ��
        //if(_rankingData != null)
        //{
        //    for(var i = 0;i < _rankingData.Count;i++)
        //    {
        //        _dictionary.Add(sco2.name, sco2.score);
        //    }
        //}
    }

    public void NameScore(string name, int score)
    {
        sco2.name = name;
        sco2.score = score;
        OnSave(sco2);
    }
    public void Score()
    {
        _dictionary.Add(_inputfield.text, _resultscore);
        foreach(var data in _rankingData)
        {
            _dictionary.Add(data.name, data.score);
        }
        foreach (var ans in _dictionary.OrderByDescending(c => c.Value))
        {
            _rankingtext.text = ans.Key + " " + ans.Value.ToString();
            NameScore(ans.Key, ans.Value);
        }
    }

    //�X�R�A��JSON�`���ŕۑ�
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
    //�X�R�A�̌Ăяo��
    public List<scoredata> OnLoad()
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savedata.json"))
            {
                //string datastr = "";
                //string datastr = "";
                string datastr = reader.ReadLine();
                reader.Close();
                return JsonUtility.FromJson<List<scoredata>>(datastr); ;
            }
        }
        catch
        {
            Debug.LogWarning("�f�[�^������܂���");
            return null;
        }
    } 
}
