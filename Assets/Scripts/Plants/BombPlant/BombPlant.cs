using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlant : PlantBase
{
    [SerializeField] private float timeToEnable = 15f;

    protected override void Start()
    {
        base.Start();

    }
    protected override void Update()
    {
        base.Update();
        timeToEnable -= Time.deltaTime;

        if(timeToEnable <=0 )
        {
            animator.SetBool("Idle", true);
        }
    }
    protected override void OnSight()
    {
        if(timeToEnable<=0)
        {
            base.OnSight();
        }
    }
    protected override void SpecificAction()
    {
        base.SpecificAction();
        Destroy(hitObj.collider.gameObject);
        GameManager.instance._enemiesAmount--;
        GameManager.instance._seedPoints += 20;
        Destroy(gameObject);
    }
}
