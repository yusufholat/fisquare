using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScpObjects/ElementType")]
public class ElementType : ScriptableObject {
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



