using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlant : PlantBase
{
    protected override void Start()
    {
        base.Start();
        animator.SetBool("Attack", false);
        animator.SetBool("Idle", true);
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void OnSight()
    {
        base.OnSight();
    }
    protected override void SpecificAction()
    {
        base.SpecificAction();
        animator.SetBool("Attack", true);
        animator.SetBool("Idle", false);
    }
}
