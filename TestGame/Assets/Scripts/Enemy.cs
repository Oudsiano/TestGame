using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Enemy : MonoBehaviour
{
    public RandomSpawn _rndSpawn;
    public GameLogic _logic;
    public int maxHealth;
    int currentHealthEnemy;
    public Animator _animator;

    private static readonly int IsDeadKey = Animator.StringToHash("IsDead");//ключ анимации бочки



    private void Start()
    {
        _animator = GetComponent<Animator>();
        currentHealthEnemy = maxHealth;//инициализируем количество жизней у бочек
    }
    /// <summary>
    /// Урон по бочке.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        currentHealthEnemy -= damage;//наносим урон бочке
        /// <summary>
        /// проверяем количество жизней у бочки
        /// </summary>
        /// <param name="damage"></param>
        if (currentHealthEnemy <= 0)//если меньше 0, то...
        {
            _animator.SetTrigger(IsDeadKey);//включаем ключ анимации
            Destroy(gameObject);//уничтожаем объект
            --_rndSpawn.enemyCount;//вычитаем из общего количество бочек уничтоженную бочку
            if (_rndSpawn.enemyCount == 0)//проверяем оставшиеся бочки, если 0, то...
            {
                _logic.isPlaying = false;//выключаем отсчет таймера
                _logic._canvas.SetActive(true);//включаем панель конца игры
                _logic._timerText.text = $"Вы прошли уровень за \n{Mathf.Floor(_logic._time)} секунд.Это отличный результат";
                //выводим время в текст
            }
        }
            

        
    }
    
    

}
