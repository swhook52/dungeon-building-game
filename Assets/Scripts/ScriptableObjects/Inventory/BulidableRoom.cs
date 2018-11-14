using UnityEngine;

[CreateAssetMenu]
public class BuildableRoom : ScriptableObject
{
    public Sprite InventorySprite;
    public GameObject InventorySlotPrefab;
    public GameObject RoomPrefab;
    public int Cost;
}