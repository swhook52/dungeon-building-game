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
        GameManager.instance.selectedHero = pressed.name;
        SetUpGame();
    }

    void SetUpGame()
    {
        //do setup here or maybe another script is needed?
        PlayGame();
    }

    void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoBackToMainMenu()
    {
        GameManager.instance.selectedHero = String.Empty;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

