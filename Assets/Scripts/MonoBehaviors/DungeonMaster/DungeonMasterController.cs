using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMasterController : MonoBehaviour {

    public int Currency;

    public GameObject DungeonGameObject;
    private Dungeon _dungeon;

    public void Start ()
    {
        _dungeon = DungeonGameObject.GetComponent<Dungeon>();
    }

    public void BuildRoom(Object roomPrefab, int cost)
    {
        if (!PayForRoom(cost)) {
            Debug.Log("You don't have enough currency.");
            return;
        }

        Debug.Log("Room purchased");
        _dungeon.AddRoom(roomPrefab);
    }

    private bool PayForRoom(int cost)
    {
        if (Currency < cost)
        {
            return false;
        }

        Currency -= cost;
        return true;
    }
}
