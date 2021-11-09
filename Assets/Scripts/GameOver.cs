using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    private void Start()
    {
        gameOverScreen.SetActive(false);
    }
    protected void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }        
    }
}
