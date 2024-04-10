using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 using UnityEngine.UI;
public class RestartGame : MonoBehaviour
{
bool fade;  //Не трогаем
float alphaColor; //Не трогаем
public Image fadeImage; //Черная картинка растянутая на весь экран, с 0 прозрачностью и выключенным рейкаст таргетом

 /*public void Restartlvl(){
      SceneManager.LoadScene(1);
  }*/
    public void ButtonStartGame() { //Вызывается из UI
        fade = true;
    }

    private void Update() {
        if(fade) {
            alphaColor = Mathf.Lerp(fadeImage.color.a, 1, Time.deltaTime * 2f);
            fadeImage.color = new Color(0, 0, 0, alphaColor);
        }
   
        if(alphaColor > 0.95 && fade) {
            fade = false;
            SceneManager.LoadScene(1);
        }
    }
}

