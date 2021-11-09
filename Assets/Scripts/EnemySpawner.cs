using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] enemies; 
    [SerializeField] private float sortTime;
    private float sortTimeOriginal;
    [SerializeField] private int waveQtd = 3;

    private void Start()
    {
        sortTimeOriginal = sortTime;
        sortTime = sortTime*2f;    
    }
    private void Update()
    {
        sortTime -= Time.deltaTime;
        InstanceEnemy();
    }
    private Vector3 SortPlace()
    {
        int sort = Random.Range(0, spawnPoints.Length);
        Vector3 pos = new Vector3(spawnPoints[sort].transform.position.x, spawnPoints[sort].transform.position.y, spawnPoints[sort].transform.position.z);
        return pos;              
    }
    private GameObject SortEnemy()
    {
        int sort = Random.Range(0, enemies.Length);
        return enemies[sort];
    }
    private void InstanceEnemy()
    {
        int aux = 0;
        if(sortTime<=0)
        {
            do
            {
                GameObject instance = (GameObject)Instantiate(SortEnemy(), new Vector3(SortPlace().x, SortEnemy().transform.position.y, SortPlace().z), SortEnemy().transform.rotation);
                aux++;
            } 
            while(waveQtd>aux);
            sortTime = sortTimeOriginal;      
        }
        
    }
}
