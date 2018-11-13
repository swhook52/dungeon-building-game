using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button Char1, Char2, Char3, Char4;

    void Start()
    {
        Char1.onClick.AddListener(() => TaskOnClick(Char1));
        Char2.onClick.AddListener(() => TaskOnClick(Char2));
        Char3.onClick.AddListener(() => TaskOnClick(Char3));
        Char4.onClick.AddListener(() => TaskOnClick(Char4));
    }

    void TaskOnClick(Button pressed)
    {
        Debug.Log("You have selected the button: " + pressed.name);

        /*
         * Set character to selected
         * Setup game
         * Hide UI
         * Play game
         */
    }
}

