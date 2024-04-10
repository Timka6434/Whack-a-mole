using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
public class Score : MonoBehaviour, IPointerClickHandler
{
    
    public GameObject moles;  
    public Text AddScore;
    public static float point;
    public  AudioSource _deathSound;

private void Start() {
     
}
public void OnPointerClick(PointerEventData eventData)
    {     
        moles = eventData.pointerEnter.gameObject;
        Debug.Log("work is first step");
        point++;
        Debug.Log(point);       
        AddScore.text = "Счёт: " + point; 
        moles.GetComponent<Mole>().HideMole();
        _deathSound.Play(0);
        Debug.Log("Mole is Hide");
        
    }
    
    /*public void Speeded(){
        Mole vec = GetComponent<Mole>();
        if(point>=15)
        {
            vec.HideMoleTimer=1f; Debug.Log("Sir mole has been accelerated:)");
        }
        else
        {
            Debug.Log("Sir we can't do it:(");
        }
    }*/
}