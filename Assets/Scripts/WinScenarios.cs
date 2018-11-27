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
        GameManager.instance.heroLives = (int)lives;

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
        GameManager.instance.heroLoot = loot;

        textComponent.text = "Hero needs " + loot.ToString() + " loot to win";
    }

    public void SaveWinScenarios()
    {
        FindObjectOfType<AudioManager>().StopSound("MenuMusic");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoBackToCharacterSelection()
    {
        GameManager.instance.heroLives = 0;
        GameManager.instance.heroLoot = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
