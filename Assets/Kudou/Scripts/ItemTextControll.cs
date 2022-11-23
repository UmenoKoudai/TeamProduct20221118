using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTextControll : MonoBehaviour
{
    [SerializeField, Header("今カーソルの下にあるアイテムの表示Text")] Text _itemText;
    [SerializeField] GameObject _itemTextPanel;
    [SerializeField] float RaycastLength = 20;
    [SerializeField] LayerMask _layerMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition != null)
        {
            _itemTextPanel.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = _itemTextPanel.transform.position;
            pos.z = 0;
            pos.x += 1;
            pos.y += 0.2f;
            _itemTextPanel.transform.position = pos;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, RaycastLength, _layerMask);
            if (hit.collider != null)
            {
                string itemName = hit.collider.gameObject.GetComponent<Item>().ItemName;
                _itemText.text = itemName;
                _itemTextPanel.SetActive(true);
            }
            else
            {
                _itemTextPanel.SetActive(false);
            }
        }
    }
}