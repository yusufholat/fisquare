using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerChangeElement : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerSpriteColor;
    [SerializeField] PlayerData player;

    [SerializeField] ElementData[] elements; 
    void Start()
    {
        
    }

    void Update()
    {
        playerSpriteColor.color = player.element.color;
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Color temp = collision.gameObject.GetComponent<SpriteRenderer>().color;
            foreach(ElementData so in elements){
                if(so.color == temp){
                    player.element = so;
                    return;
                }

            }
            
        }
    }
}
