using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Juge : MonoBehaviour
{
    [SerializeField,Header("���҂������A�j���[�^�[")] Animator _patientAnim;
    [SerializeField,Header("�Q�[����ʂɂ���ItemButton")] Button[] _buttons;
    [SerializeField,Header("�V�[�����ɂ���EventSystem�̃I�u�W�F�N�g")] EventSystem eventSystem;
    [SerializeField,Header("��������Ȃ��Ă���(�m�F�p)")] string[] _answerItems;
    [SerializeField,Header("�J���e��ɂ��鐬����UI")] GameObject _successImage;
    [SerializeField, Header("�J���e��ɂ��鎸�s��UI")] GameObject _failureImage;
    [Tooltip("�ő剽��ԈႦ�Ă�������")]int noGoodCountMax;
    [Tooltip("���ԈႦ�Ă����")] int noGoodCountNow;
    [SerializeField] GameObject _result;
    int i = 0;
    GameObject destroyGO;
    public int I { get => i; }

    public GameObject DestroyGO { get => destroyGO; }

   
    // Start is called before the first frame update
    void Start()
    {
        ResetButton(false);
        _failureImage.SetActive(false);
        _successImage.SetActive(false);
    }

    public void Jugement()
    {
        if (FindObjectOfType<GameManager>().State == GameState.isGame)
        {
            //���{�^�����������I�u�W�F�N�g��Item�X�N���v�g������Ă���
            Item item = eventSystem.currentSelectedGameObject.GetComponent<Item>();

            if(_answerItems[0] == "���ÕK�v�Ȃ�") //���N�Ȋ��҂������Ă�����
            {
                FindObjectOfType<HeartBeat>().State = HeartBeat.HeatBeatState.Normal;
                if (Input.GetKey(KeyCode.F)) 
                {
                    _patientAnim.Play("Fade");
                }
            }
            
            if (i == _answerItems.Length - 1 && destroyGO != null) //�Ō�܂ŏ��Ԓʂ�Ƀ{�^������������
            {
                FindObjectOfType<HeartBeat>().State = HeartBeat.HeatBeatState.Normal;
                //������UI��\������
                _successImage.SetActive(true);
                //button�������Ȃ�����
                ResetButton(false);
                //���҂����ɓ������A�j���[�V�������Đ�
                _patientAnim.Play("Fade");
            }
            else if (item.ItemName == _answerItems[i])
            {
                Debug.Log("�����Ă��܂�");
                i++;
            }
            else�@�@//���N�Ȋ��҂������Ă��Ă�noGoogCountMax���P�Ȃ̂łǂ̃{�^������񉟂��Ă����s�ɂȂ�
            {
                noGoodCountNow++;
                Debug.Log("�ԈႦ�Ă��܂�");
                if (noGoodCountNow == noGoodCountMax)�@//�Q�[���I�[�o�[
                {
                    FindObjectOfType<HeartBeat>().State = HeartBeat.HeatBeatState.Stop;
                    //button�������Ȃ��悤�ɂ���
                    ResetButton(false);
                    //���sUI��\������
                    _failureImage.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //�������s��UI���\���ɂ���
            _successImage.SetActive(false);
            _failureImage.SetActive(false);
            //button��������悤�ɂ���
            ResetButton(true);
            //���҃I�u�W�F�N�g�̃X�N���v�g���̓����ƂȂ�ItemName�z����擾
            _answerItems = collision.GetComponent<PatientData>().ItemsName;
            //���҂ɂ���Ă͊ԈႦ�Ă����񐔂�ς���悤�ɂ���
            noGoodCountMax = collision.GetComponent<PatientData>().NoGoodCount;
            FindObjectOfType<HeartBeat>().State = HeartBeat.HeatBeatState.Danger;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetButton(false);
            i = 0;
            noGoodCountNow = 0;
            //��p���I��������҃I�u�W�F�N�g������
            destroyGO = collision.gameObject;
            
        }
    }

    private void ResetButton(bool TrueFalse)
    {
        for(var i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = TrueFalse;
        }
    }
}
