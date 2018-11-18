using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyRegen : MonoBehaviour {

    public short RegenRate = 1;
    public short RegenAmount = 1;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("Regen", RegenRate, RegenRate);
    }

    private void Regen()
    {
        if (GameManager.instance)
        {
            GameManager.instance.dungeonMasterCurrency += RegenAmount;
        }
    }
}
