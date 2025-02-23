using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteUpdateBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spriteRenderer.sprite = sprites[count];
        count++;
        if(count == sprites.Length)
        {
            count = 0;
        }
    }
}
