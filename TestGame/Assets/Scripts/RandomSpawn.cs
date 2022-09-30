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
    /// ����� ��������� ����� ,� ��������� ����� �� �����
    /// </summary>
    private void Start()
    {         
        ColdObject = new GameObject[Random.Range(10,15)];//��������� ������ � �������� ���������� ���������� �����
       
        for(int i = 0; i < ColdObject.Length; i++)//���� ��� ������� �����
        {
            _randX = Random.Range(30, 170);//�������������� �������� � ������� ����� ���������� �����
            whereToSpawn = new Vector2(_randX, 29f);//��������� ���������� ��� ��� ������ ����������
            
            ColdObject[i] =obj;//��� ������������ �������� ������� ����������� ����������
            
            Instantiate(ColdObject[i], whereToSpawn, Quaternion.identity);//������� ���������� �� �����������
            
        }
        obj.SetActive(false);//��������� ������
        enemyCount = ColdObject.Length;//���������� � ���������� ����� ���������� �����
    }
       

}
