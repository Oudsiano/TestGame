using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.EventSystems;

namespace GameTest
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        //��� ������� ����� �������� ��� � �.�.� input action-�
       /// <summary>
       /// ����� ����� �� ������ ��������� ����������� ������� �� ����������
       /// </summary>
       /// <param name="context"></param>
        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);//������ ����������� ������ �� ������� ������
        }
        /// <summary>
        /// ����� ����� �� Hero ��������� ������ �� ������ ����
        /// </summary>
        /// <param name="context"></param>
        public void OnAttack(InputAction.CallbackContext context)
        {
            _hero.Attack();//�������� ��������
        }
        
    }
}
