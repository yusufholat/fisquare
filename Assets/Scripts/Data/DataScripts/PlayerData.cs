using UnityEngine;

[CreateAssetMenu(menuName ="ScpObjects/Player")]
public class PlayerData : ScriptableObject
{
    public float hp;
    public ElementData element;
    public Weapon weapon;
}
