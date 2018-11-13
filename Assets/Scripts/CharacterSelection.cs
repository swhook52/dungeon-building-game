using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button Char1, Char2, Char3;

    void Start()
    {
        Char1.onClick.AddListener(() => TaskOnClick(Char1));
        Char2.onClick.AddListener(() => TaskOnClick(Char2));
        Char3.onClick.AddListener(() => TaskOnClick(Char3));
    }

    void TaskOnClick(Button pressed)
    {
        Debug.Log("You have selected the character: " + pressed.GetComponentInChildren<Text>().text);

        /*
         * Set character to selected
         * Setup game
         * Hide UI
         * Play game
         */
    }
}

