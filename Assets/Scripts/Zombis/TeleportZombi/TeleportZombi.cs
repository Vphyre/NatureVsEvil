using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZombi : ZombiBase
{
    private bool teleportTrigger;
    private float teleportTime;
    protected override void Start()
    {
        base.Start();
        animator.SetFloat("Walk", rb.velocity.x);
        animator.SetBool("Attack", false);
        teleportTrigger = false;
        teleportTime = 0f;
    }
    protected override void Update()
    {
        base.Update();
        teleportTime -= Time.deltaTime;
        if( teleportTime <= 0 )
        {
            animator.SetBool("Attack", sightTigger);
            animator.SetFloat("Walk", Mathf.Abs(rb.velocity.x));
        }

    }
    protected override void Walking()
    {
        base.Walking();
    }
    protected override void SpecificAction()
    {
        base.SpecificAction();

        if( !teleportTrigger )
        {
            teleportTime = 2f;
            animator.SetBool("Teleport", true);
            animator.SetBool("TeleportEnd", false);
            animator.SetBool("Attack", false);
            animator.SetFloat("Walk", 0f);
            teleportTrigger = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            print("entrou");
        }
    }
    public void Teleport()
    {
        transform.position = new Vector3(transform.position.x-0.7f,transform.position.y,transform.position.z);
        animator.SetBool("Teleport", false);
        animator.SetBool("Attack", false);
        animator.SetFloat("Walk", Mathf.Abs(rb.velocity.x));
    }
}
