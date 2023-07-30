using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biteZones : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite swim;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            openWide();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            defaultSprite();
        }
    }

    void openWide()
    {
        spriteRenderer.sprite = newSprite;
    }
    void defaultSprite()
    {
        spriteRenderer.sprite = swim;
    }
}
