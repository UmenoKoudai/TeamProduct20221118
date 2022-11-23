using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InatatePlayer : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Juge _juge;
    [SerializeField] Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(_juge.I == 0)
        {
            Instantiate(prefab,this.transform.position,Quaternion.identity);
            _anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
            _anim.Play("Fade");
        }
    }
}