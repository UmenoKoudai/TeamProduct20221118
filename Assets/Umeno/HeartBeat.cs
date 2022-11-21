using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class HeartBeat : MonoBehaviour
{
    [SerializeField] float _normalInterval;
    [SerializeField] float _dangerInterval;
    [SerializeField] float _stopInterval;
    [SerializeField] HeatBeatState _state = HeatBeatState.Normal;
    [SerializeField] GameObject _clearRed;
    LineRenderer _heartBeat;
    float _timeResetinterval;
    float _timer;
    float _beatTime;
    float _interval;

    public HeatBeatState State { get => _state; set => _state = value; }

    void Start()
    {
        _heartBeat = GetComponent<LineRenderer>();
        _heartBeat.positionCount = 9;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _interval)
        {
            if (_state == HeatBeatState.Normal)
            {
                _clearRed.SetActive(false);
                _timeResetinterval = _normalInterval;
                _interval = 2;
                for (int i = 0; i < _heartBeat.positionCount; i++)
                {
                    _beatTime += Time.deltaTime;
                    switch (i)
                    {
                        case 0:
                            _heartBeat.SetPosition(i, new Vector3(4, 3, 0));
                            break;
                        case 1:
                            _heartBeat.SetPosition(i, new Vector3(5.5f, 3, 0));
                            break;
                        case 2:
                            _heartBeat.SetPosition(i, new Vector3(5.8f, 4, 0));
                            break;
                        case 3:
                            _heartBeat.SetPosition(i, new Vector3(6f, 3, 0));
                            break;
                        case 4:
                            _heartBeat.SetPosition(i, new Vector3(6.2f, 3, 0));
                            break;
                        case 5:
                            _heartBeat.SetPosition(i, new Vector3(6.4f, 2, 0));
                            break;
                        case 6:
                            _heartBeat.SetPosition(i, new Vector3(6.6f, 3.5f, 0));
                            break;
                        case 7:
                            _heartBeat.SetPosition(i, new Vector3(6.7f, 3, 0));
                            break;
                        case 8:
                            _heartBeat.SetPosition(i, new Vector3(8f, 3, 0));
                            break;
                    }
                }
            }
            else if(_state == HeatBeatState.Danger)
            {
                _clearRed.SetActive(true);
                _timeResetinterval = _dangerInterval;
                _interval = 0.6f;
                for (int i = 0; i < _heartBeat.positionCount; i++)
                {
                    _beatTime += Time.deltaTime;
                    switch (i)
                    {
                        case 0:
                            _heartBeat.SetPosition(i, new Vector3(4, 3, 0));
                            break;
                        case 1:
                            _heartBeat.SetPosition(i, new Vector3(4.8f, 3, 0));
                            break;
                        case 2:
                            _heartBeat.SetPosition(i, new Vector3(5.2f, 4, 0));
                            break;
                        case 3:
                            _heartBeat.SetPosition(i, new Vector3(5.2f, 2.3f, 0));
                            break;
                        case 4:
                            _heartBeat.SetPosition(i, new Vector3(6f, 3.5f, 0));
                            break;
                        case 5:
                            _heartBeat.SetPosition(i, new Vector3(6.2f, 2.8f, 0));
                            break;
                        case 6:
                            _heartBeat.SetPosition(i, new Vector3(6.6f, 3.8f, 0));
                            break;
                        case 7:
                            _heartBeat.SetPosition(i, new Vector3(6.7f, 3, 0));
                            break;
                        case 8:
                            _heartBeat.SetPosition(i, new Vector3(8f, 3, 0));
                            break;
                    }
                }
            }
            else
            {
                _clearRed.SetActive(false);
                _timeResetinterval = _stopInterval;
                for (int i = 0; i < _heartBeat.positionCount; i++)
                {
                    switch (i)
                    {
                        case 0:
                            _heartBeat.SetPosition(i, new Vector3(4, 3, 0));
                            break;
                        case 1:
                            _heartBeat.SetPosition(i, new Vector3(5.5f, 3, 0));
                            break;
                        case 2:
                            _heartBeat.SetPosition(i, new Vector3(5.8f, 3, 0));
                            break;
                        case 3:
                            _heartBeat.SetPosition(i, new Vector3(6f, 3, 0));
                            break;
                        case 4:
                            _heartBeat.SetPosition(i, new Vector3(6.2f, 3, 0));
                            break;
                        case 5:
                            _heartBeat.SetPosition(i, new Vector3(6.4f, 3, 0));
                            break;
                        case 6:
                            _heartBeat.SetPosition(i, new Vector3(6.6f, 3, 0));
                            break;
                        case 7:
                            _heartBeat.SetPosition(i, new Vector3(6.7f, 3, 0));
                            break;
                        case 8:
                            _heartBeat.SetPosition(i, new Vector3(8f, 3, 0));
                            break;
                    }
                }
            }
            if (_beatTime > _timeResetinterval)
            {
                _timer = 0;
                _beatTime = 0;
            }
        }
        else
        {
            for (int i = 0; i < _heartBeat.positionCount; i++)
            {
                switch (i)
                {
                    case 0:
                        _heartBeat.SetPosition(i, new Vector3(4, 3, 0));
                        break;
                    case 1:
                        _heartBeat.SetPosition(i, new Vector3(5.5f, 3, 0));
                        break;
                    case 2:
                        _heartBeat.SetPosition(i, new Vector3(5.8f, 3, 0));
                        break;
                    case 3:
                        _heartBeat.SetPosition(i, new Vector3(6f, 3, 0));
                        break;
                    case 4:
                        _heartBeat.SetPosition(i, new Vector3(6.2f, 3, 0));
                        break;
                    case 5:
                        _heartBeat.SetPosition(i, new Vector3(6.4f, 3, 0));
                        break;
                    case 6:
                        _heartBeat.SetPosition(i, new Vector3(6.6f, 3, 0));
                        break;
                    case 7:
                        _heartBeat.SetPosition(i, new Vector3(6.7f, 3, 0));
                        break;
                    case 8:
                        _heartBeat.SetPosition(i, new Vector3(8f, 3, 0));
                        break;
                }
            }
        }
    }
    public enum HeatBeatState
    {
        Normal,
        Danger,
        Stop,
    }
}
