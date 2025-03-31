using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteUpdateBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int count = 0;


    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void nextSprite()
    {
        Debug.Log("method called");
        spriteRenderer.sprite = sprites[count];
        count++;
        if (count == sprites.Length)
        {
            count = 0;
        }
    }

    public void setSprite(int index)
    {
        if (index < sprites.Length && index >= 0)
        {
            spriteRenderer.sprite = sprites[index];
        } else {
            Debug.Log("index out of bounds: " + index);
        }
        
    }

    public Sprite[] getSprites()
    {
        return sprites;
    }
}
