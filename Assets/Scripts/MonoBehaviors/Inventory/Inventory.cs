using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public BuildableRoom[] AllBuildableRooms;

    public void Start()
    {
        var transform = GetComponent<Transform>();

        for (int i = 0; i < AllBuildableRooms.Length; i++)
        {
            var room = AllBuildableRooms[i];
            var slot = Instantiate(room.InventorySlotPrefab, transform);

            var slotSettings = slot.GetComponent<InventoryItemSlot>();
            slotSettings.RoomPrefab = room.RoomPrefab;
            slotSettings.Cost = room.Cost;
        }
    }
}
