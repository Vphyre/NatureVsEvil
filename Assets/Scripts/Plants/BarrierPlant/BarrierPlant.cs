using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPlant : PlantBase
{
    [SerializeField] private float healingRatio = 2;
    [SerializeField] private GameObject plantBody;
    private Vector3 orginalScale;
    protected override void Start()
    {
        base.Start();
        orginalScale = plantBody.transform.localScale;
    }
    protected override void Update()
    {
        HealDamageScale();
        this.OnSight();
    }
    protected override void OnSight()
    {
        sightTigger = Physics.Raycast(transform.position, transform.right, out hitObj, plantData._maxReachPoint, LayerMask.GetMask("Enemy"));
        if( !sightTigger )
        {
           SpecificAction();
        }
    }
    protected override void SpecificAction()
    {
        base.SpecificAction();
        if(life<plantData._life)
        {
            life += Time.deltaTime*healingRatio;
        }
    }
    private void HealDamageScale()
    {
        float aux = plantData._life;
        aux = life/aux;
        plantBody.transform.localScale = new Vector3(orginalScale.x*aux, orginalScale.y*aux, orginalScale.z*aux);
    }

}
