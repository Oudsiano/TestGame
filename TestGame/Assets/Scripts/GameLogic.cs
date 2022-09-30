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
    
    public TextMeshProUGUI _enemyCurrentText;//������� �������� ������
    
    
    public float _time = 0f;
    public Text _timerText;

    public RandomSpawn _randomSpawn;
    /// <summary>
    /// ����� �� ���� ��� ������
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();//������� �� ����
    }
    /// <summary>
    /// ������� ���� ��� ������
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(0);//������������� ����
        _canvas.SetActive(false);//��������� ������
    }
    private void Update()
    {
        if (isPlaying)//���� ������� ���� ��������, ��...
        {
            _time += Time.deltaTime;//������� �����
        }
        _enemyCurrentText.text = $"�������� ����� � ���������� {_randomSpawn.enemyCount} �����";
        //������� � �������� ���������� ���������� �����
    }
}
