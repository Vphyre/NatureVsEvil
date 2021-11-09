using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    public static SeedManager instance;
    private GameObject plant;
    private Texture2D texture;
    private int cost;
    private bool selected;
    public bool _selected
    {
        get{return this.selected;}
        set{this.selected = value;}
    }
    private bool tranfer;
    public bool _tranfer
    {
        get{return this.tranfer;}
        set{this.tranfer = value;}
    }

    private string selectedPlant;
    private void Start()
    {
        selected = false;
        tranfer = false;
        instance = this;
        addPhysicsRaycaster();
    }
    private void Update()
    {
        
    }

    private void addPhysicsRaycaster()
    {
        PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    }
    /// <summary>
    /// Select a seet to respawn a plant.
    /// </summary>
    /// <param name="plantCost">The cost to respawn.</param>
    /// <param name="prefab">The plant's prefabs that will respawn</param>
    /// <param name="plantTexture">The Plant's cursor Texture</param>
    public void SelectPlant(int plantCost, GameObject prefab, Texture2D plantTexture)
    {
        _selected = true;
        plant = prefab;
        texture = plantTexture;
        ChangeCursor(plantTexture);
        cost = plantCost;
    }
    /// <summary>
    /// Transfer a plant to another node.
    /// </summary>
    /// <param name="prefab">The Plant in the node.</param>
    /// <param name="plantTexture">The Plant's cursor Texture</param>
    public void TransferPlant(GameObject prefab, Texture2D plantTexture)
    {
        _selected = true;
        _tranfer = true;
        plant = prefab;
        texture = plantTexture;
        ChangeCursor(plantTexture);
    }
    /// <summary>
    /// Create a instance of a plant in a node.
    /// </summary>
    /// <param name="position">Only X and Z values.</param>
    /// <param name="parent">The node parent.</param>
    public void SpawnPlant(Vector2 position, Transform parent)
    {
        if(!selected)
            return;
        Vector3 aux = new Vector3(position.x, plant.transform.position.y, position.y);    
        Instantiate(plant, aux, plant.transform.rotation, parent);
        _selected = false;
        _tranfer = false;
        plant = null;
        texture = null;
        ChangeCursor(null);
        GameManager.instance._seedPoints -= cost;
        cost = 0;
    }
    private void ChangeCursor(Texture2D plantTexture)
    {
       Cursor.SetCursor(plantTexture, Vector2.zero, CursorMode.Auto);
    }
    /// <summary>
    /// Returns the select plant's gameObject that will be respawned
    /// </summary>
    /// <returns></returns>
    public GameObject SelectPrefab()
    {
        if(plant == null)
            return null;
        else
        {
            return plant;
        }
    }
    /// <summary>
    /// Returns the select plant's cursor texture that will be respawned
    /// </summary>
    /// <returns></returns>
    public Texture2D SelectTexture()
    {
        if(texture == null)
            return null;
        else
        {
            return texture;
        }
    }

}
