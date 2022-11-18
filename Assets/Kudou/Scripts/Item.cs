using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField, Header("Item–¼")] string _itemName;
    

    

    public string ItemName { get => _itemName; }
    // Start is called before the first frame update
    

    void Start()
    {
        this.gameObject.name = _itemName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
