using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantBase : MonoBehaviour
{
    [SerializeField] protected PlantData plantData;
    [SerializeField] protected Animator animator;
    private int life;
    protected virtual void Start()
    {
        life = plantData._life;
    }

    protected virtual void Update()
    {
        OnSight();
    }
    protected virtual void OnSight()
    {
        if(Physics.Raycast(transform.position, transform.right, plantData._maxReachPoint))
        {
            SpecificAction();
            print("Entrou"+gameObject.name);
        }
    }
    protected virtual void SpecificAction()
    {
        
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x+plantData._maxReachPoint, transform.position.y, transform.position.z));
    }
    public void GetDamage(int damage)
    {
        if(life<=0)
        {
            gameObject.SetActive(false);
        }
    }
}
