using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    //here we store references to the objects/vars we will need throughout the game 
    public int heroLives;
    public float heroLoot;
    public float dungeonMasterCurrency;  
    public string selectedHero;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); //keep the gameobject alive throughout scenes

        //here we would attach the references to our objects

        InitializeGame();
    }
    
    void InitializeGame()
    {
        Debug.Log("Game initialized from the loader/gamemanager script!");
        //do the work required to setup each level/instance of the game
        dungeonMasterCurrency = 1000; //just a placeholder
    }

    public void KillHero()
    {
        Debug.Log("Kill Hero");
    }

    void Update()
    {
       
    }
}
