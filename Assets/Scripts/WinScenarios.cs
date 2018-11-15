using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScenarios : MonoBehaviour
{
    Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    public void SetLivesLabelText(float sliderValue)
    {
        var lives = Mathf.Round(sliderValue);
        PlayerPrefs.SetFloat("lives", lives);

        if (lives == 1)
        {
            textComponent.text = "Hero starts with " + lives.ToString() + " life";
        }
        else
        {
            textComponent.text = "Hero starts with " + lives.ToString() + " lives";
        }
    }

    public void SetLootLabelText(float sliderValue)
    {
        var loot = Mathf.Round(sliderValue);
        PlayerPrefs.SetFloat("loot", loot);

        textComponent.text = "Hero needs " + loot.ToString() + " loot to win";
    }

    public void SaveWinScenarios()
    {
        //save win scenario vars to "local storage"
        PlayerPrefs.Save();

        Debug.Log("Lives is now set to: " + PlayerPrefs.GetFloat("lives").ToString());
        Debug.Log("Loot is now set to: " + PlayerPrefs.GetFloat("loot").ToString());

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoBackToCharacterSelection()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
