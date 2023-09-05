using UnityEngine;

[CreateAssetMenu(menuName ="ScpObjects/ElementType")]
public class ElementData : ScriptableObject {
    public Type type;
    public Color color;
}

public enum Type {
    None,
    Fire,
    Ice,
    Shock,
    Earth,
}



