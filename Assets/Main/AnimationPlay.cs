using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour
{
    [SerializeField] Animator _anim;
    public void Play(string name)
    {
        _anim.Play(name);
    }
}
