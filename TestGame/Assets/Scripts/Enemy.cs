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

    private static readonly int IsDeadKey = Animator.StringToHash("IsDead");//���� �������� �����



    private void Start()
    {
        _animator = GetComponent<Animator>();
        currentHealthEnemy = maxHealth;//�������������� ���������� ������ � �����
    }
    /// <summary>
    /// ���� �� �����.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        currentHealthEnemy -= damage;//������� ���� �����
        /// <summary>
        /// ��������� ���������� ������ � �����
        /// </summary>
        /// <param name="damage"></param>
        if (currentHealthEnemy <= 0)//���� ������ 0, ��...
        {
            _animator.SetTrigger(IsDeadKey);//�������� ���� ��������
            Destroy(gameObject);//���������� ������
            --_rndSpawn.enemyCount;//�������� �� ������ ���������� ����� ������������ �����
            if (_rndSpawn.enemyCount == 0)//��������� ���������� �����, ���� 0, ��...
            {
                _logic.isPlaying = false;//��������� ������ �������
                _logic._canvas.SetActive(true);//�������� ������ ����� ����
                _logic._timerText.text = $"�� ������ ������� �� \n{Mathf.Floor(_logic._time)} ������.��� �������� ���������";
                //������� ����� � �����
            }
        }
            

        
    }
    
    

}
