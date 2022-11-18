using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class HeartBeat : MonoBehaviour
{
    LineRenderer _heartBeat;
    int _interval = 5;
    float _timer;
    //BeatPosition[][] _beatPositions;
    //int d = 100;
    //float _theta;

    void Start()
    {
        _heartBeat = GetComponent<LineRenderer>();
        _heartBeat.positionCount = 9;
        //for (int i = 0; i < _heartBeat.positionCount; i++)
        //{
        //    for (int j = 0; j < _heartBeat.positionCount; j++)
        //    {
        //        var x = d * (i - (10 - 1) / 3.0f);
        //        var y = d * (j - (10 - 1) / 3.0f);
        //        var z = 0f;
        //        _beatPositions[i][j] = new BeatPosition(x, y, z);
        //    }
        //}
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _interval)
        {
            for(int i = 0; i < _heartBeat.positionCount; i++)
            {
                var r = Random.Range(-2, 2);
                _heartBeat.SetPosition(i, _heartBeat.GetPosition(i) + new Vector3(0.5f, r, 0));
            }
            //for (int i = 0; i < _heartBeat.positionCount; i++)
            //{
            //    _heartBeat.SetPosition(i, new Vector3(0, 0, 0));
            //}
            _timer = 0;
        }
        else
        {
            //for (int i = 0; i < _heartBeat.positionCount; i++)
            //{
            //    _heartBeat.SetPosition(i, _heartBeat.GetPosition(i) + new Vector3(0.5f, 0, 0));
            //}
            for (int i = 0; i < _heartBeat.positionCount; i++)
            {
                _heartBeat.SetPosition(i, new Vector3(0, 0, 0));
            }
        }
    }
}
