using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button Char1, Char2, Char3, Char4;

    void Start()
    {
        Char1.onClick.AddListener(() => CharacterSelectedHandler(Char1));
        Char2.onClick.AddListener(() => CharacterSelectedHandler(Char2));
        Char3.onClick.AddListener(() => CharacterSelectedHandler(Char3));
        Char4.onClick.AddListener(() => CharacterSelectedHandler(Char4));
    }

    void CharacterSelectedHandler(Button pressed)
    {
        Debug.Log("You have selected the button: " + pressed.name);
        //set character to selected
        SetUpGame();
    }

    void SetUpGame()
    {
        //do setup here or maybe another script is needed?
        PlayGame();
    }

    void PlayGame()
    {
        //we don't have this ATM, so ignore for now
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

