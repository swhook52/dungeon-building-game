﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillHeroOnCollide : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance)
        {
            GameManager.instance.KillHero();
        }
    }
}
