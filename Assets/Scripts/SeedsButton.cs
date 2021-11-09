using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SeedsButton : MonoBehaviour
{
    [SerializeField] private int seedCost;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject plant;
    [SerializeField] Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(seedCost>GameManager.instance._seedPoints)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }
    public void GetSeed()
    {
        if(!SeedManager.instance._tranfer)
        {
            SeedManager.instance.SelectPlant(seedCost, plant, texture);
        }
    }
}
