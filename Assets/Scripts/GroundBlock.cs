using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlock : MonoBehaviour
{
    public int state;
    public int durability;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Sprite sprite;
    public BoxCollider2D BC2D;
    public int X;
    public int Y;
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (state != 0) spriteRenderer.sprite = sprites[state];
        else spriteRenderer.sprite = sprite;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        state = 0;
        BC2D.enabled = false;
        //TerrainScipt.i.UpdateBlocksArround((int)transform.position.x, (int)transform.position.y);
    }*/


    public void Breakblock()
    {
        state = 0;
        BC2D.enabled = false;
    }
    public void Dig()
    {
        if(state > 0)durability--;
        if (durability <= 0) Breakblock();
    }

    /*void UpdateState()
    {
        spriteRenderer.sprite = sprites[state];
    }*/
}
