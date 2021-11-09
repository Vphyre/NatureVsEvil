using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantBase : MonoBehaviour
{
    [SerializeField] protected PlantData plantData;
    [SerializeField] protected Animator animator;
    [SerializeField] protected RaycastHit hitObj;
    protected bool sightTigger;
    [SerializeField] protected float life;
    protected virtual void Start()
    {
        life = (float)plantData._life;
        sightTigger = false;
    }

    protected virtual void Update()
    {
        OnSight();
    }
    protected virtual void OnSight()
    {
        sightTigger = Physics.Raycast(new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z), transform.right, out hitObj, plantData._maxReachPoint, LayerMask.GetMask("Enemy"));
        if( sightTigger )
        {
            SpecificAction();
        }
    }
    protected virtual void SpecificAction()
    {
        
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z), new Vector3(transform.position.x+plantData._maxReachPoint, transform.position.y, transform.position.z));
    }
    private void GetDamage(float damage)
    {
        life -= damage;
        if(life<=0)
        {
            gameObject.SetActive(false);
        }
    }
    protected void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.layer == LayerMask.NameToLayer("EnemyHit"))
        {
            GetDamage(10f);
        }        
    }
}
