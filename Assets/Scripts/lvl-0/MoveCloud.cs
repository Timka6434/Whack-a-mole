using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public float Speed;
    public float PosY;
    


    void Start()
    {
       // MoveSpeed();
    }
     void Update()
    {
         transform.Translate( Speed * Time.deltaTime,PosY,0);

         if(transform.position.x < -5f )
         {
            Speed = -Speed;
         }
         if(transform.position.x > 5f )
         {
            Speed = -Speed;
         }
    }
}