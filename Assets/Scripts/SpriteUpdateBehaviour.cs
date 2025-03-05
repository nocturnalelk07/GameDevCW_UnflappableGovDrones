using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteUpdateBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int count = 0;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void nextSprite()
    {
        spriteRenderer.sprite = sprites[count];
        count++;
        if (count == sprites.Length)
        {
            count = 0;
        }
    }
}
