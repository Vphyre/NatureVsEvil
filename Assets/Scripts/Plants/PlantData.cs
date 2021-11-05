using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Plant", menuName = "PlantStats")]
public class PlantData : ScriptableObject
{
    [SerializeField] private int life;
    public int _life
    {
        get{ return this.life; }
        set{ this.life = value;}
    }
    [SerializeField] private float maxReachPoint;
    public float _maxReachPoint
    {
        get{ return this.maxReachPoint; }
    }
}
