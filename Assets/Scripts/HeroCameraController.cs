using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCameraController : MonoBehaviour
{
    public GameObject player;

    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // LateUpdate is guaranteed after all items have had Update() been run
    void LateUpdate()
    {
        var transformX = player.transform.position.x + offset.x;
        transform.position = new Vector3(transformX, transform.position.y, transform.position.z);
    }
}
