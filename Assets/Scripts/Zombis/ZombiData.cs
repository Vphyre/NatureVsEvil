using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Zombi", menuName = "ZombiStats")]
public class ZombiData : ScriptableObject
{
    [SerializeField] private int life;
    public int _life
    {
        get{ return this.life; }
    }
    [SerializeField] private float range;
    public float _range
    {
        get{ return this.range; }
    }
    [SerializeField] private float speed;
    public float _speed
    {
        get{ return this.speed; }
    }
    
}
