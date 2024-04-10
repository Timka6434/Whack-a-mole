using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartTimer : MonoBehaviour
{

    public GameObject UnVisMoleCon;
    
    void Start()
    {
        Time.timeScale = 0f; 
    }
    public void OnClick()
    {
        Time.timeScale = 1f;
        
      UnVisMoleCon.SetActive(!UnVisMoleCon.activeSelf);
    }
}
