using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinzas : MonoBehaviour
{        
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetAxis("Fire1") != 0) collision.SendMessage("Dig");
    }
}
