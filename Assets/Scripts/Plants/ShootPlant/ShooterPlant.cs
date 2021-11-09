using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlant : PlantBase
{
    [SerializeField] private float shootForce;
    [SerializeField] private float damage;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Pooling bulletPool;
    private GameObject bullet;

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
    public void ShootAttack()
    {
        bullet = bulletPool.GetPooledObject();
        bullet.SetActive(true);
        bullet.transform.position = bulletPool.transform.position;
        bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullet.GetComponent<Rigidbody>().AddForce(transform.right*shootForce);
        animator.SetBool("Attack", false);
        animator.SetBool("Idle", true);
    }
}
