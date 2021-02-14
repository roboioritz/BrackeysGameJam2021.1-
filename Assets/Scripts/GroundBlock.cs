using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlock : MonoBehaviour
{
    public int state;
    public int durability;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public BoxCollider2D BC2D;
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
        spriteRenderer.sprite = sprites[state];
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
