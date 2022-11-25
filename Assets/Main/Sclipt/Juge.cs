using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Juge : MonoBehaviour
{
    [SerializeField,Header("患者が動くアニメーター")] Animator _patientAnim;
    [SerializeField,Header("ゲーム画面にあるItemButton")] Button[] _buttons;
    [SerializeField,Header("シーン内にあるEventSystemのオブジェクト")] EventSystem eventSystem;
    [SerializeField,Header("何も入れなくていい(確認用)")] string[] _answerItems;
    [SerializeField,Header("カルテ上にある成功のUI")] GameObject _successImage;
    [SerializeField, Header("カルテ上にある失敗のUI")] GameObject _failureImage;
    [Tooltip("最大何回間違えてもいいか")]int noGoodCountMax;
    [Tooltip("今間違えている回数")] int noGoodCountNow;
    [SerializeField] GameObject _result;
    int i = 0;
    bool _goodMan;
    GameObject destroyGO;
    public int I { get => i; }

    public GameObject DestroyGO { get => destroyGO; }

   
    // Start is called before the first frame update
    void Start()
    {
        ResetButton(false);
        //_failureImage.SetActive(false);
        //_successImage.SetActive(false);
    }

    private void Update()
    {
        if (_goodMan) //健康な患者が入ってきたら
        {
            FindObjectOfType<HeartBeat>().State = HeartBeat.HeatBeatState.Normal;
            if (Input.GetKey(KeyCode.F))
            {
                FindObjectOfType<GameManager>().AddScore();
                _patientAnim.Play("Fade");
            }
        }
    }
    public void Jugement()
    {
        if (FindObjectOfType<GameManager>().State == GameState.isGame)
        {
            //今ボタンを押したオブジェクトのItemスクリプトを取ってくる
            Item item = eventSystem.currentSelectedGameObject.GetComponent<Item>();
            if (item.ItemName == _answerItems[i])
            {
                Debug.Log("あっています");
                i++;
            }
            else　　//健康な患者が入ってきてもnoGoogCountMaxが１なのでどのボタンを一回押しても失敗になる
            {
                noGoodCountNow++;
                Debug.Log("間違えています");
                if (noGoodCountNow >= noGoodCountMax)　//ゲームオーバー
                {
                    FindObjectOfType<HeartBeat>().State = HeartBeat.HeatBeatState.Stop;
                    ////buttonを押せないようにする
                    ResetButton(false);
                    ////失敗UIを表示する
                    _failureImage.SetActive(true);
                    _result.SetActive(true);
                    //FindObjectOfType<GameManager>().State = GameState.gameOver;
                }
            }
            if (i == _answerItems.Length - 1) //最後まで順番通りにボタンをおせたら
            {
                FindObjectOfType<GameManager>().AddScore();
                FindObjectOfType<HeartBeat>().State = HeartBeat.HeatBeatState.Normal;
                //成功のUIを表示する
                StartCoroutine(InstantiateImage(_successImage));
               //_successImage.SetActive(true);
                //buttonを押せなくする
                ResetButton(false);
                //患者を左に動かすアニメーションを再生
                _patientAnim.Play("Fade");
            }
            //else if (item.ItemName == _answerItems[i])
            //{
            //    Debug.Log("あっています");
            //    i++;
            //}
            
        }
        //else if(FindObjectOfType<GameManager>().State == GameState.gameOver)
        //{
        //    FindObjectOfType<HeartBeat>().State = HeartBeat.HeatBeatState.Stop;
        //    //buttonを押せないようにする
        //    ResetButton(false);
        //    //失敗UIを表示する
        //    StartCoroutine(InstantiateImage(_failureImage));
        //    //_failureImage.SetActive(true);
        //    _result.SetActive(true);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //成功失敗のUIを非表示にする
            _successImage.SetActive(false);
            _failureImage.SetActive(false);
            //buttonを押せるようにする
            ResetButton(true);
            //患者オブジェクトのスクリプト内の答えとなるItemName配列を取得
            _answerItems = collision.GetComponent<PatientData>().ItemsName;
            if(_answerItems[0] == "健康")
            {
                _goodMan = true;
            }
            _patientAnim = collision.GetComponent<Animator>();
            //患者によっては間違えていい回数を変えるようにした
            noGoodCountMax = collision.GetComponent<PatientData>().NoGoodCount;
            FindObjectOfType<HeartBeat>().State = HeartBeat.HeatBeatState.Danger;
            FindObjectOfType<GameManager>()._timeStop = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _goodMan = false;
            ResetButton(false);
            i = 0;
            noGoodCountNow = 0;
            //手術が終わった患者オブジェクトを入れる
            destroyGO = collision.gameObject;
            FindObjectOfType<GameManager>()._timeStop = true;
            
        }
    }

    private void ResetButton(bool TrueFalse)
    {
        for(var i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = TrueFalse;
        }
    }

    IEnumerator InstantiateImage(GameObject item)
    {
        item.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        item.SetActive(false);
    }
}
