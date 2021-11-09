using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BittingPlant : PlantBase
{
    [SerializeField] private float bittingTime = 15f;
    [SerializeField] private GameObject tongue;
    private float originalBittingTime;
    protected override void Start()
    {
        base.Start();
        originalBittingTime = bittingTime;
        bittingTime = 0f;
        animator.SetBool("Idle", true);
        animator.SetBool("Bitting", false);
        animator.SetBool("Attack", false);
    }
    protected override void Update()
    {
        base.Update();
        bittingTime -= Time.deltaTime;
        if(bittingTime<=0)
        {
            tongue.SetActive(true);
            animator.SetBool("Idle", true);
            animator.SetBool("Bitting", false);
            animator.SetBool("Attack", false);
        }
    }
    protected override void OnSight()
    {
        base.OnSight();
        if(bittingTime<=0)
        {
            bittingTime = originalBittingTime;
        }
    }
    protected override void SpecificAction()
    {
        base.SpecificAction();
        animator.SetBool("Idle", false);
        animator.SetBool("Bitting", false);
        animator.SetBool("Attack", true);
    }
    public void Bitting()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Bitting", true);
        animator.SetBool("Attack", false);
        tongue.SetActive(false);
    }

}
