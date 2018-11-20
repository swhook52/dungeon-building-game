using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float ZRotationSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newZ = transform.rotation.z + (ZRotationSpeed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.forward, ZRotationSpeed);
    }
}
