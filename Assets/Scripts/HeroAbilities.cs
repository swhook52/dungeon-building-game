using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class HeroAbilities : MonoBehaviour
{
    public HeroAreaOfEffect areaOfEffect;
    public GameObject hero;

    double areaOfEffectCooldownRemaining;
    List<GameObject> areaOfEffectGameObjects;
    Stopwatch areaOfEffectStopwatch;

    Timer cooldownTimer;
    CircleCollider2D heroCollider;

    void Start()
    {
        heroCollider = hero.GetComponent<CircleCollider2D>();
        areaOfEffectGameObjects = new List<GameObject>();
        areaOfEffectStopwatch = new Stopwatch();

        cooldownTimer = new Timer(100);
        cooldownTimer.Elapsed += OnCooldownTimerElapsed;
        cooldownTimer.Start();
    }

    void Update()
    {
        // If the aoe ability has been "active" for its duration length, destroy it
        if (areaOfEffectStopwatch.ElapsedMilliseconds >= areaOfEffect.durationInMilliseconds)
        {
            areaOfEffectStopwatch.Stop();
            areaOfEffectStopwatch.Reset();

            areaOfEffectGameObjects.ForEach((obj) =>
            {
                Destroy(obj);
            });
            areaOfEffectGameObjects.Clear();
        }
    }

    void FixedUpdate()
    {
        // Not all heroes have to have an AoE
        if (areaOfEffect != null)
        {
            // See if the aoe key is pressed
            bool keyIsDown = Input.GetButtonDown("AoE");

            // See if the cooldown is complete
            bool cooldownComplete = System.Math.Abs(areaOfEffectCooldownRemaining) < Mathf.Epsilon;

            if (keyIsDown && cooldownComplete)
            {
                areaOfEffectCooldownRemaining = areaOfEffect.cooldownInMilliseconds;

                // Get the right-most edge of the hero
                var rightEdge = hero.transform.position.x + hero.GetComponent<SpriteRenderer>().bounds.size.x;

                // Get the width of the single unit sprite
                var width = areaOfEffect.singleUnitSprite.GetComponent<SpriteRenderer>().bounds.size.x;

                // Create the number of sprites to the right of the character
                for (int i = 0; i < areaOfEffect.range; i++)
                {
                    // Place a aoe unit
                    var go = Instantiate(areaOfEffect.singleUnitSprite,
                                         new Vector3(rightEdge + (.5f * width * i),
                                                     hero.transform.position.y,
                                                     hero.transform.position.z),
                                         hero.transform.rotation);
                    areaOfEffectGameObjects.Add(go);
                }

                // Get the left-most edge of the hero
                var leftEdge = hero.transform.position.x - hero.GetComponent<SpriteRenderer>().bounds.size.x;

                // Create the number of sprites to the left of the character
                for (int i = 0; i < areaOfEffect.range; i++)
                {
                    // Place a aoe unit
                    var go = Instantiate(areaOfEffect.singleUnitSprite,
                                         new Vector3(leftEdge - (.5f * width * i),
                                                     hero.transform.position.y,
                                                     hero.transform.position.z),
                                         hero.transform.rotation);
                    areaOfEffectGameObjects.Add(go);
                }

                areaOfEffectStopwatch.Start();
            }
        }
    }

    void OnCooldownTimerElapsed(object sender, ElapsedEventArgs args)
    {
        if (areaOfEffectCooldownRemaining > 0)
            areaOfEffectCooldownRemaining -= cooldownTimer.Interval;
    }
}
