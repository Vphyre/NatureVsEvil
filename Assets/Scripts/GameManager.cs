using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private int seedPoints = 50;
    public int _seedPoints
    {
        get{return this.seedPoints;}
        set{this.seedPoints = value;}
    }
    [SerializeField] private int enemiesAmount;
    public int _enemiesAmount
    {
        get{return this.enemiesAmount;}
        set{this.enemiesAmount = value;}
    }
    [SerializeField] private int seedsIncreaseRatio = 5;
    void Start()
    {
        instance = this;
        InvokeRepeating("SeedsGain",1f,1f);
    }
    void Update()
    {
        WinGame();
    }
    private void SeedsGain()
    {
        seedPoints += seedsIncreaseRatio;
    }
    private void WinGame()
    {
        if(enemiesAmount<=0)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
