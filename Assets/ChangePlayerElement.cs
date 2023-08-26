using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerElement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer currentColor;
    [SerializeField] PlayerData currentPlayer;
    void Start()
    {
        currentColor.color = currentPlayer.currentElement.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
