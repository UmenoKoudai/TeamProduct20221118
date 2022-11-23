using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Juge : MonoBehaviour
{
    [SerializeField] Animator _patientAnim;
    [SerializeField] Button[] _buttons;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] string[] _answerItems;
    [SerializeField] GameObject _successImage;
    [SerializeField] GameObject _failureImage;
    int noGoodCountMax;
    int noGoodCountNow;
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
        Item item = eventSystem.currentSelectedGameObject.GetComponent<Item>();

        if(i == _answerItems.Length - 1)
        {
            _successImage.SetActive(true);
            ResetButton(false);
            _patientAnim.Play("Fade");
            
            
        }
        else if(item.ItemName == _answerItems[i])
        {
            Debug.Log("‚ ‚Á‚Ä‚¢‚Ü‚·");
            i++;
        }
        else
        {
            noGoodCountNow++;
            Debug.Log("ŠÔˆá‚¦‚Ä‚¢‚Ü‚·");
            if(noGoodCountNow == noGoodCountMax)
            {
                ResetButton(false);
                _failureImage.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _successImage.SetActive(false);
            _failureImage.SetActive(false);
            ResetButton(true);
            _answerItems = collision.GetComponent<PatientData>().ItemsName;
            noGoodCountMax = collision.GetComponent<PatientData>().NoGoodCount;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetButton(false);
            i = 0;
            noGoodCountNow = 0;
            
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
