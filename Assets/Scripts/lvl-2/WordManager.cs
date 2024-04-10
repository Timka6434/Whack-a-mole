using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public Text mainText;      // текстовое поле самого верхнего облака
    public Text[] answersList; // текстовые поля остальных облак
 
    [Space]
    public static WordManager instance;
 
    public float updateTimeInSeconds = 5f; // время которое дано на поиск буквы пользотелем
    
    // приватные данные таймера
    private float _currentTime = 0;
    private bool _timerIsEnable = false;
 
    // массив символов, которые будут загадываться.
    private char[] _chars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЮЯ".ToCharArray();
    public Text _score;
   public Text _timer;

   public Text _endScore;
   public Text _bestscore;
    private float _point;
    public float _SecondLeft;
    public GameObject _boardScore;
    private float _bscore;
    private float i;
    public GameObject btn;
 
    // ИНИЦИАЛИЗАЦИЯ

     private void Awake() 
    {
        _point = 0;
        instance = this;
        btn.SetActive(false);
        _boardScore.SetActive(false);
        if(PlayerPrefs.HasKey("SaveScore"))
        {
           
         _bscore = PlayerPrefs.GetFloat("SaveScore");
        }
    }
    private void Start()
    {
        // для каждого текста добавляем компонент кнопки, чтобы ловить клики по нему.
        foreach (var text in answersList)
        {
            Button button = text.gameObject.AddComponent<Button>();
            button.onClick.AddListener(() => onCloudClick(text));
        }
       
        // запускаем игру
        updateTask();
        resetTimer();
        enableTimer();
 
    }
 
    // если таймер включён, то через заданный интервал - задание и время обновляются.
    private void Update()
    {
       
        if (_timerIsEnable)
        {
            _currentTime -= Time.deltaTime;
            _SecondLeft -= Time.deltaTime;
            _timer.text =Mathf.Floor(_SecondLeft).ToString();
            
            if(_SecondLeft < 0)
            {
            _timer.text = "Время вышло";
            _boardScore.SetActive(true);
            _timerIsEnable = false;
            Debug.Log(Score.point + _point);
            i = Score.point + _point;
            _endScore.text = "Твой счёт \n" + i + " очков";
            if(_bscore < i)
            {
               _bscore = i;
                _bestscore.text = "Твой лучший счёт \n" + _bscore+ " очков";
            }
            else
            {
                _bestscore.text = "Твой лучший счёт \n" + _bscore+ " очков";
            }
            PlayerPrefs.SetFloat("SaveScore", _bscore);
            Invoke("btnTF", 3f);
            
            Debug.Log("Save complete...");

            
            }
            if (_currentTime <= 0)
            {
                resetTimer();
                updateTask();
            }
            
        }
    }
    private void btnTF(){
        btn.SetActive(true);
    }
    // включает таймер
    private void enableTimer()
    {
        _timerIsEnable = true;
    }
 
    // сбросить значения таймера в начальные, то-есть он не останавливается, а отсчёт начинается заново
    private void resetTimer()
    {
        _currentTime = updateTimeInSeconds;
    }
 
    // остановить таймер
    private void disableTimer()
    {
        _timerIsEnable = false;
    }
 
 
    // при клике по любому из шести облак:
    private void onCloudClick(Text textUI)
    {
        if(_SecondLeft<0f){

        }
        //  если текст облака совпадает с текстом верхнего облака
        if (textUI.text == mainText.text)
        {
            
            _point += 2f;
            // добавляем очки
        _score.text = "Score: " + Mathf.Floor(_point);
            Debug.Log("+2 points!!!");
 
            // сбрасываем таймер и обновляем задание
            resetTimer();
            updateTask();
        }
        else
        {
            
            Debug.Log("wrong");
             
        }

    }
 
    // обновление задания
    private void updateTask()
    {
        
        // копируем массив всех символов и выбираем случайный
        List<char> randChars = new List<char>(_chars);
        int randIndex = Random.Range(0, randChars.Count);
 
 
        // случайный символ назначаем верхнему облаку 
        // и удаляем этот символ из копии массива (чтобы его больше нельзя было выбрать)
        mainText.text = randChars[randIndex].ToString();
        randChars.RemoveAt(randIndex);
 
        // проходим по всем шести облакам и так же назначаем им случайный символ
        // из тех символов, которые остались в копии
        foreach (var textUI in answersList)
        {
            randIndex = Random.Range(0, randChars.Count);
            textUI.text = randChars[randIndex].ToString();
            randChars.RemoveAt(randIndex);
        }
 
        // в самом конце назначаем случайному (из шести) облаку тот символ,
        // который в главном верхнем облаке. Чтобы одно облако содержало правильный ответ.
        int randTextUI = Random.Range(0, answersList.Length);
        answersList[randTextUI].text = mainText.text;
 
    }
 
    // это просто для тестов, можно безболезненно удалить
    private void OnGUI()
    {
      //  GUILayout.Label($"Игра включена: {_timerIsEnable}");
      //  GUILayout.Label(_currentTime.ToString("0.00"));
    }
    public void Restartlvl()
    {
       SceneManager.LoadScene(1);
    }
    public void ResetBestScore()
    {
       PlayerPrefs.DeleteKey("SaveScore");
    }
     public void GoToMainMenu()
    {
       SceneManager.LoadScene(0);
    }
}

/*{
    
   public Text texts;

    public Text texts1;
    public Text texts2;
    public Text texts3;
    public Text texts4;
    public Text texts5;
    public Text texts6;
    public float timer = 60f; 
    private float hidetimer = 60f;

   char[] rw = {'а','б','в','г','д','е','ё','ж','з','и','к','л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я'};
    void Start()
    {
      
    }
    void Update()
    {
        timer -= Time.deltaTime;
        hidetimer -= Time.deltaTime;
        Randoming();
    }
    void Randoming()
    { 
      if(hidetimer == 60.0f || hidetimer == 50.0f || hidetimer == 40.0f || hidetimer == 30.0f)
      {
        hidetimer = timer;
        texts.text  = rw[Random.Range(0, rw.Length)].ToString();
        texts1.text = rw[Random.Range(0, rw.Length)].ToString();
        texts2.text = rw[Random.Range(0, rw.Length)].ToString();
        texts3.text = rw[Random.Range(0, rw.Length)].ToString();
        texts4.text = rw[Random.Range(0, rw.Length)].ToString();
        texts5.text = rw[Random.Range(0, rw.Length)].ToString();
        texts6.text = rw[Random.Range(0, rw.Length)].ToString();
      }
      else if(hidetimer != 60.0f || hidetimer != 50.0f || hidetimer != 40.0f || hidetimer != 30.0f)
      {
        hidetimer += Time.deltaTime;
          Debug.Log("Bruh");
          Debug.Log(hidetimer);
          }
      
        //string stringFromChar = rw[Random.Range(0, rw.Length)].ToString();
        //Debug.Log(rw[Random.Range(0, rw.Length)]);
        
    }
}*/