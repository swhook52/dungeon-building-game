using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMoveCamera : MonoBehaviour {
    public float MoveSpeed = 0.1f;
    public float ZoomSpeed = 0.02f;
    public float MaxCameraSize = 5;
    public float MinCameraSize = 0.5f;

    private Camera _camera;

    public void Start () {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        var xMove = Input.GetAxis("LookHorizontal") * MoveSpeed;
        var yMove = Input.GetAxis("LookVertical") * MoveSpeed;
        var zoomIn = Input.GetButton("ZoomIn");
        var zoomOut = Input.GetButton("ZoomOut");

        var movement = new Vector3(transform.position.x + xMove, transform.position.y + yMove, transform.position.z);

        if (Input.GetButton("ZoomIn"))
        {
            var newSize = _camera.orthographicSize - ZoomSpeed;
            _camera.orthographicSize = Mathf.Clamp(newSize, MinCameraSize, MaxCameraSize);
        }

        if (Input.GetButton("ZoomOut"))
        {
            var newSize = _camera.orthographicSize + ZoomSpeed;
            _camera.orthographicSize = Mathf.Clamp(newSize, MinCameraSize, MaxCameraSize);
        }

        transform.position = movement;
    }
}
