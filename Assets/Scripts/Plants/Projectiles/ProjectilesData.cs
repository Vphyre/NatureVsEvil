using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Projectile", menuName = "ProjectileStats")]
public class ProjectilesData : ScriptableObject
{
    [SerializeField] private float timeToDespawn = 2f;
    public float _timeToDespawn
    {
        get{return timeToDespawn;}
    }
    [SerializeField] private int enemyLayer = 6;
    public float _enemyLayer
    {
        get{return enemyLayer;}
    }
}
