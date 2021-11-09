using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    [SerializeField] private float tongueRange = 1f;
    private RaycastHit hitObj;
    void Start()
    {
        
    }

    void Update()
    {
        if( Physics.Raycast( transform.position, transform.right, out hitObj, tongueRange, LayerMask.GetMask("Enemy")) )
        {
            Destroy(hitObj.collider.gameObject);
            GameManager.instance._enemiesAmount--;
            GameManager.instance._seedPoints += 20;
        }
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x+tongueRange, transform.position.y, transform.position.z));
    }
}
