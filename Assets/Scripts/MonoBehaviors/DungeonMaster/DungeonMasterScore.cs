using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonMasterScore : MonoBehaviour
{

    private Text _textComponent;

    public void Start()
    {
        _textComponent = GetComponent<Text>();
    }

    void Update()
    {
        if (GameManager.instance)
        {
            _textComponent.text = GameManager.instance.dungeonMasterCurrency.ToString();
        }
    }
}
