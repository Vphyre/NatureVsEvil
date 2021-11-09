using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ZombiBase : MonoBehaviour
{
    [SerializeField] protected ZombiData zombiData;
    [SerializeField] protected Animator animator;
    [SerializeField] protected RaycastHit hitObj;
    [SerializeField] protected GameObject attackObj;
    protected Rigidbody rb;
    protected bool sightTigger;
    private bool attackTrigger;
    [SerializeField] protected float life;
    protected virtual void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        life = zombiData._life;
        attackTrigger = false;
    }
    protected virtual void Update()
    {
        sightTigger = Physics.Raycast(transform.position, (transform.right*-1f), out hitObj, zombiData._range, LayerMask.GetMask("Player"));
        Walking();
    }
    protected virtual void Walking()
    {
        if(!sightTigger)
        {
            if(Mathf.Abs(rb.velocity.x)>zombiData._speed/2)
            {
                return;
            }
            rb.AddForce((transform.right*-1f)*zombiData._speed);
        }
        else
        {
            rb.velocity = Vector3.zero;
            SpecificAction();
        }
        
    }
    protected virtual void SpecificAction()
    {

    }
    protected virtual void Attack()
    {
        attackTrigger =! attackTrigger;
        attackObj.SetActive(attackTrigger);
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x-zombiData._range, transform.position.y, transform.position.z));
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.layer == LayerMask.NameToLayer("PlayerHit"))
        {
            GetDamage(10f);
            print("Life: "+life);
        }
    }
    private void GetDamage(float damage)
    {
        life -= damage;
        if(life<=0)
        {
            GameManager.instance._enemiesAmount--;
            GameManager.instance._seedPoints += 20;
            Destroy(gameObject);
        }
    }
}
