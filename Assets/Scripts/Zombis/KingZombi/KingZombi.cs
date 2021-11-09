using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingZombi : ZombiBase
{
    [SerializeField] private GameObject[] zombis;
    [SerializeField] private float spawnTime = 5f;
    private float spawnTimeOriginal;
    [SerializeField] private int spawnLimit = 3;
    protected override void Start()
    {
        base.Start();
        animator.SetFloat("Walk", rb.velocity.x);
        animator.SetBool("Attack", false);
        spawnTimeOriginal = spawnTime;  
    }
    protected override void Update()
    {
        base.Update();
        animator.SetBool("Attack", sightTigger);
        animator.SetFloat("Walk", Mathf.Abs(rb.velocity.x));
        spawnTime -= Time.deltaTime;
        SpawnAllies();
    }
    protected override void Walking()
    {
        base.Walking();
    }
    protected override void SpecificAction()
    {
        base.SpecificAction();
    }
    private void SpawnAllies()
    {
        Vector3 aux;
        if(spawnTime<=0 && spawnLimit>0)
        {
           aux = new Vector3(transform.position.x+1f, transform.position.y, transform.position.z);
           GameObject instance = (GameObject)Instantiate(zombis[Random.Range(0,zombis.Length)], aux, transform.rotation);
           spawnTime = spawnTimeOriginal;
           spawnLimit--;
        }
    }
}
