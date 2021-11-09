using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IPointerDownHandler 
{
    protected bool hasPlant;
    protected GameObject plant;
    protected Texture2D texture;
    void Start()
    {
        hasPlant = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(SeedManager.instance._selected && !hasPlant)
        {
            plant = SeedManager.instance.SelectPrefab();
            texture = SeedManager.instance.SelectTexture();
            SeedManager.instance.SpawnPlant(new Vector2(eventData.pointerCurrentRaycast.gameObject.transform.position.x, eventData.pointerCurrentRaycast.gameObject.transform.position.z), eventData.pointerCurrentRaycast.gameObject.transform);
            hasPlant = true;
        }
        else if(!SeedManager.instance._selected && hasPlant)
        {
            SeedManager.instance.TransferPlant(plant, texture);
            hasPlant = false;
            plant = null;
            texture = null;
            Destroy(transform.GetChild(0).gameObject);
        }
        else
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        }
        
    }
}
