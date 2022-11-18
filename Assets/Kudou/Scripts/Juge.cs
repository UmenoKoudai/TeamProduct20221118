using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Juge : MonoBehaviour
{
    Animator _patientAnim;
    [SerializeField] Button[] _buttons;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] string[] _answerItems;
    
    bool isComplet;
    bool isGame;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        ResetButton(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jugement()
    {
        Item item = eventSystem.currentSelectedGameObject.GetComponent<Item>();

        if(i == _answerItems.Length - 1)
        {
            ResetButton(false);
        }
        else if(item.ItemName == _answerItems[i])
        {
            Debug.Log("‚ ‚Á‚Ä‚¢‚Ü‚·");
            i++;
        }
        else
        {
            Debug.Log("ŠÔˆá‚¦‚Ä‚¢‚Ü‚·");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetButton(true);
        _answerItems = collision.GetComponent<PatientData>().ItemsName;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        i = 0;

    }

    private void ResetButton(bool TrueFalse)
    {
        for(var i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = TrueFalse;
        }
    }







}
