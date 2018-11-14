using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour {

    private Transform _dungeonTransform;
    private List<GameObject> _rooms = new List<GameObject>();
    private Vector2 _nextRoomStart;

    public void Start()
    {
        _dungeonTransform = GetComponent<Transform>();
        _nextRoomStart = new Vector2(transform.position.x, transform.position.y);
    }

    public void AddRoom(Object roomPrefab)
    {
        var room = (GameObject)Instantiate(roomPrefab, _nextRoomStart, Quaternion.LookRotation(Vector3.forward), _dungeonTransform);
        _rooms.Add(room);

        UpdateNextRoomStartPosition(room);
    }

    private void UpdateNextRoomStartPosition(GameObject room)
    {
        // Not sure how to do this yet but we should calculate the width of the room from the start position
        // Because the rooms could all be different widths

        _nextRoomStart.x -= 1;
    }
}
