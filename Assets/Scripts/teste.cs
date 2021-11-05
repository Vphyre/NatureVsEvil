using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    public Animator anim;
    public float time;
    public bool test;

    void Start()
    {
        time = 0;
        test = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(test)
        {
           anim.PlayInFixedTime("GetDamage1",-1, time);
        }
        else
        {
            anim.Play("idle");
        }
        
        
    }
}
