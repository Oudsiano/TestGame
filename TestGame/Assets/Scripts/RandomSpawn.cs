using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject obj;
    public GameObject[] ColdObject;
    
    private int _random;
    private int _randX;
    private Vector2 whereToSpawn;
    public int enemyCount;
    /// <summary>
    /// —паун рандомных бочек ,в рандомном месте на карте
    /// </summary>
    private void Start()
    {         
        ColdObject = new GameObject[Random.Range(10,15)];//объ€вл€ем массив и рандомно выставл€ем количество бочек
       
        for(int i = 0; i < ColdObject.Length; i++)//цикл дл€ массива бочек
        {
            _randX = Random.Range(30, 170);//инициализируем диапазон в котором будут по€вл€тьс€ бочки
            whereToSpawn = new Vector2(_randX, 29f);//указываем координаты где они должны по€вл€тьс€
            
            ColdObject[i] =obj;//дл€ объ€вленного элемента массива присваиваем геймобжект
            
            Instantiate(ColdObject[i], whereToSpawn, Quaternion.identity);//создаем геймобжект по координатам
            
        }
        obj.SetActive(false);//выключаем префаб
        enemyCount = ColdObject.Length;//записываем в переменную общее количество бочек
    }
       

}
