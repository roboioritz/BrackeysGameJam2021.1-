using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }
    
    void Update()
    {
        Mover();
    }

    public void Mover()
    {
        if (Input.GetAxis("Vertical") > 0) transform.Translate(0, Time.deltaTime * speed, 0);
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * 5);
    }
}
