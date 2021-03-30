using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunAnimation : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void StopAnimate()
    {
        anim.SetTrigger("go");
    }

    public void StartAnimate()
    {
        anim.SetTrigger("go");
    }

    public void StartArms1()
    {
        anim.SetTrigger("Arms");
    }

    public void StartArms2()
    {
        anim.SetTrigger("Arms2");
    }
}
