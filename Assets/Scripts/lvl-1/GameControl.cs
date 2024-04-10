using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{   
    public Text timerText;
    public float gameTimer=15f;
    public GameObject MoleContainer; 
    private Mole[] moles;
    public float ShowMoleTimer=1f;
    public Text seconder;
    static public float sec=31f;
    
    
    void Awake() {
        sec = 31f;
        Score.point = 0;
    }  
    void Start()
    {     
        moles = MoleContainer.GetComponentsInChildren<Mole>();
        Debug.Log("well done " + moles.Length);     
    }
    public void Update()
    {      
        gameTimer -= Time.deltaTime;   
        if(gameTimer>0f)
        {
            ShowMoleTimer -= Time.deltaTime;
            if(ShowMoleTimer<0f)
            {           
                moles[Random.Range(0, moles.Length)].ShowMole();
                            
                Debug.Log("point is: " + Score.point);
                 ShowMoleTimer= 1.5f;
                 
                 if(Score.point > 3f)
                 {
                    ShowMoleTimer= 0.8f;
                 }
                 if(Score.point > 7f)
                 {
                    ShowMoleTimer= 0.5f;
                 }
                 if(Score.point > 13f)
                 {
                    ShowMoleTimer= 0.2f;
                 }    
                    
            }
        }else{
    
        }
       TimeLeft();
        }
     public void TimeLeft(){
        if(sec >= 0f)
        {sec -= Time.deltaTime;
        seconder.text = "У тебя " + Mathf.Floor(sec) + " секунд!";
        }
        else
        {
        Example();
        seconder.text = "Время вышло!";
        MoleContainer.SetActive(false);
        Debug.Log("Timeout...");
        Invoke("NextScene", 4f);
        }
   }
    void NextScene()
    {
        SceneManager.LoadScene(2);
    }
 IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
    }
}

