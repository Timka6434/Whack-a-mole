using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Mole : MonoBehaviour
{
   
    public float VisibleY = 0.1f;
    public float HiddenY = 1f;
    private Vector3 NewXYPosition;
    public float speed = 5f;
    public float HideMoleTimer= 5.5f;
    public float TimeLineOfLife = 1.5f;
    public Button startButton;
    
    
    public void Start()
    {    
        HideMole();
        
        if (GameControl.sec < 0f)
        {
           HiddenY=-5f; 
           Example();
        }
    }
     
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, NewXYPosition, Time.deltaTime * speed);
        HideMoleTimer-=Time.deltaTime;
        if(HideMoleTimer<0){HideMole();} 
    }
   public void ShowMole()
    { 
        
       NewXYPosition =
        new Vector3(transform.localPosition.x, VisibleY, transform.localPosition.z);  
        HideMoleTimer=TimeLineOfLife;
    }
     public void HideMole()
    {
        NewXYPosition = 
        new Vector3(transform.localPosition.x, HiddenY, transform.localPosition.z);
        
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(10);
    }
}
