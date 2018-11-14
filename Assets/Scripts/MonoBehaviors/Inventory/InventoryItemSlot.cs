using UnityEngine;

public class InventoryItemSlot : MonoBehaviour {
    public GameObject RoomPrefab;
    public int Cost;

    private DungeonMasterController _dmController;

    public void Start()
    {
        _dmController = FindObjectOfType<DungeonMasterController>();
    }

    public void BuildRoom()
    {
        _dmController.BuildRoom(RoomPrefab, Cost);
    }
}
