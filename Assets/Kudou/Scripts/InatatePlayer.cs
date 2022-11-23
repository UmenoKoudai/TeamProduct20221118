using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InatatePlayer : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Juge _juge;
    [SerializeField] Animator _anim;
    [SerializeField] bool isInstance;

    public bool IsInstance { get => isInstance; set => IsInstance = isInstance; }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(isInstance)
        {
            Instantiate(prefab,this.transform.position,Quaternion.identity);
            _anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
            _anim.Play("Fade");
            isInstance = false;
        }
    }
}