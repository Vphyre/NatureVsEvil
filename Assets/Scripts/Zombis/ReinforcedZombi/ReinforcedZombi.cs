using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinforcedZombi : ZombiBase
{
   [SerializeField] private GameObject bucket;
   protected override void Start()
   {
        base.Start();
        animator.SetFloat("Walk", rb.velocity.x);
        animator.SetBool("Attack", false);
        life += zombiData._life/3f;
   }
   protected override void Update()
   {
       base.Update();
       animator.SetBool("Attack", sightTigger);
       animator.SetFloat("Walk", Mathf.Abs(rb.velocity.x));
       BucketBehaviour();
   }
   protected override void Walking()
   {
       base.Walking();
   }
   protected override void SpecificAction()
   {
       base.SpecificAction();
   }
   private void BucketBehaviour()
   {
       if(life<zombiData._life)
       {
           bucket.SetActive(false);
       }
       else
       {
           bucket.SetActive(true);
       }
   }
}
