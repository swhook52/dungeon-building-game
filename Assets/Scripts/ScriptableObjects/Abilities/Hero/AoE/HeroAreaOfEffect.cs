using UnityEngine;

[CreateAssetMenu(fileName = "AreaOfEffect", menuName = "Hero Area of Effect")]
public class HeroAreaOfEffect : ScriptableObject
{
    public GameObject singleUnitSprite;
    public int durationInMilliseconds;
    public int pushBackForce;
    public int range;
    public int damage;
    public int cooldownInMilliseconds;
}
