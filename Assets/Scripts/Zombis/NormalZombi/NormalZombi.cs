using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombi : ZombiBase
{
    protected override void Start()
    {
        base.Start();
        animator.SetFloat("Walk", rb.velocity.x);
        animator.SetBool("Attack", false);
    }
    protected override void Update()
    {
        base.Update();
        animator.SetBool("Attack", sightTigger);
        animator.SetFloat("Walk", Mathf.Abs(rb.velocity.x));
    }
    protected override void Walking()
    {
        base.Walking();
    }
    protected override void SpecificAction()
    {
        base.SpecificAction();
    }
    
    
}
