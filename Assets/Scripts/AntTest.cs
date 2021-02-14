using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntTest : MonoBehaviour
{
    public float vx, vy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vx * Time.deltaTime, vy * Time.deltaTime, 0);
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.SendMessage("Dig");
    }
}
