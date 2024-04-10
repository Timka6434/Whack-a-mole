using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMole : MonoBehaviour
{
  public float Speed;
    public float UpY=-1.7f;
  public float DownY=-1.832f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   transform.Translate(0, Speed * Time.deltaTime,0);

         if(transform.position.y < DownY )
         {
            Speed = -Speed;
         }
         if(transform.position.y > UpY )
         {
            Speed = -Speed;
         }
}
}



