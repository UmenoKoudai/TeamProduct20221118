using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    //LineRenderer _heartBeat;
    [SerializeField] LayerMask _leyer;
    Rigidbody2D _rb;
    Vector2 _startVector = new Vector2(1, 0);
    Vector3 _isGround = new Vector3(1, -1, 0);
    int _moveSpeed = 2;
    //BeatPosition[][] _beatPositions;
    //int d = 100;
    //float _theta;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_heartBeat = GetComponent<LineRenderer>();
        //_heartBeat.positionCount = 9;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position + _isGround, 1f,_leyer);
        Debug.DrawRay(transform.position, transform.position + _isGround);
        if(!hit.collider)
        {
            _rb.velocity = _startVector * _moveSpeed;
        }
        else
        {
            if(_isGround == new Vector3(1, -1, 0))
            {
                _startVector = Vector2.left;
                _isGround = new Vector2(-1, -1);
                FlipX(-1);
            }
            else if(_isGround == new Vector3(-1, -1, 0))
            {
                _startVector = Vector2.right;
                _isGround = new Vector2(1, -1);
                FlipX(1);
            }
        }
        //for(int i = 0; i < _heartBeat.positionCount; i++)
        //{
        //    for(int j = 0; j < _heartBeat.positionCount; j++)
        //    {
        //        _beatPositions[i][j].y = 10 * (float)Mathf.Cos(_theta + 0.1f * i + 0.2f * j);
        //    }
        //}

        //for(int i = 0; i < _heartBeat.positionCount; i++)
        //{
        //    for(int j = 0; j < _heartBeat.positionCount; j++)
        //    {
        //        _heartBeat.SetPosition(j, new Vector3(_beatPositions[i][j].x, _beatPositions[i][j].y, _beatPositions[i][j].z));
        //    }
        //}
    }

    void FlipX(float n)
    {
        var t = transform.localScale;
        t.x = n;
        transform.localScale = t;
    }
}
