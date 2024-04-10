using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartTimer1 : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f; 
    }
    public void OnClick()
    {
        Time.timeScale = 1f;
    }
}
