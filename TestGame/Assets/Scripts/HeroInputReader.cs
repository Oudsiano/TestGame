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

        //При желании можно добавить тач и т.д.в input action-е
       /// <summary>
       /// через ивент на игроке проверяем направление нажатия на клавиатуру
       /// </summary>
       /// <param name="context"></param>
        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);//задаем направление исходя из нажатой кнопки
        }
        /// <summary>
        /// через ивент на Hero проверяем нажали ли кнопку мыши
        /// </summary>
        /// <param name="context"></param>
        public void OnAttack(InputAction.CallbackContext context)
        {
            _hero.Attack();//включаем анимацию
        }
        
    }
}
