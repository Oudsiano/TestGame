using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public bool isPlaying = true;

    public GameObject _canvas;
    public Enemy _enemy;
    
    public TextMeshProUGUI _enemyCurrentText;//Сколько осталось врагов
    
    
    public float _time = 0f;
    public Text _timerText;

    public RandomSpawn _randomSpawn;
    /// <summary>
    /// выход из игры для кнопки
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();//выходим из игры
    }
    /// <summary>
    /// рестарт игры для кнопки
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(0);//перезапускаем игру
        _canvas.SetActive(false);//выключаем канвас
    }
    private void Update()
    {
        if (isPlaying)//если булевая игры включена, то...
        {
            _time += Time.deltaTime;//считаем время
        }
        _enemyCurrentText.text = $"Осталось найти и уничтожить {_randomSpawn.enemyCount} бочек";
        //выводим в текстмеш количество оставшихся бочек
    }
}
