using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBzz : MonoBehaviour
{
  public float Speed;
    public float _MaxValue, _MinValue;
    void Start()
    {
        
    }

    
    void Update()
    {
       transform.Translate(0, Speed * Time.deltaTime,0);

         if(transform.position.y < _MinValue )
         {
            Speed = -Speed;
         }
         if(transform.position.y > _MaxValue )
         {
            Speed = -Speed;
         }
    }
}
