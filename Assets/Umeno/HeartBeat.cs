using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    [SerializeField] LineRenderer _heartBeat;
    // Start is called before the first frame update
    void Start()
    {
        _heartBeat = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //_heartBeat.SetVertexCount
        //_heartBeat.SetPosition = 3;
    }
}
