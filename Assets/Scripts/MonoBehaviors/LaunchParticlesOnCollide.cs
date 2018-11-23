using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchParticlesOnCollide : MonoBehaviour
{
    public ParticleSystem _psystem;

    void Awake()
    {
        _psystem = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _psystem.Play();
        // end/next level here
    }
}
