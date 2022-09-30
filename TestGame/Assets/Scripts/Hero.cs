using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameTest
{
    public class Hero : MonoBehaviour
    {


        [SerializeField] public float _speed;
        public float _jumpSpeed;
        [SerializeField] private LayerMask _groundLayer;

        

        public Rigidbody2D _rigidbody;
        public Vector2 _direction;//направление движения игрока
        private Animator _animator;
        private SpriteRenderer _sprite;
        public Transform _attackPoint;
        public LayerMask _enemy;
        
        public float _attackRange;//диапазон атаки 
        public int _attackDamage = 40;//количество жизней отнимаемое при 1 атаке
        



        /// <summary>
        /// ключи анимаций переводим в переменные
        /// </summary>
        private static readonly int IsGroundKey = Animator.StringToHash("IsGround");
        private static readonly int IsRunningKey = Animator.StringToHash("IsRunning");
        private static readonly int VerticalVelocityKey = Animator.StringToHash("vertical-velocity");
        private static readonly int AttackKey = Animator.StringToHash("Attack");

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponent<SpriteRenderer>();
            
        }


        public void SetDirection(Vector2 direction)
        {
            _direction = direction;//присваеваем направление из ивента
        }
        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

            var isJumping = _direction.y > 0;//проверяем направление нажатия из ивента на игроке
            var isGrounded = IsGrounded();
            if (isJumping && isGrounded)//если мы на земле и направление положительное то,
            {
                _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);//прикладываем силу к игроку для прыжка
            }
            //проперти анимаций
            _animator.SetBool(IsGroundKey, isGrounded);
            _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);
            _animator.SetBool(IsRunningKey, _direction.x != 0);


            UpdateSpriteDirection();
            
        }
        /// <summary>
        /// поворот спрайта игрока
        /// </summary>
        private void UpdateSpriteDirection()
        {
            if (_direction.x > 0)//если направление вправо...

            {
                _sprite.flipX = false;//поворачиваем спрайт вправо
                
            }
            else if (_direction.x < 0)//если направление влево...
            {
                _sprite.flipX = true;//поворачиваем справйт
                
                
            }
            
        }
        /// <summary>
        /// проверка на землю
        /// </summary>
        /// <returns></returns>
        private bool IsGrounded()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down, 1, _groundLayer);
            //делаем райкаст и проверяем соприкасаемся ли с землей
            return hit.collider != null;
        }
        /// <summary>
        /// отслеживаем коллайдеры с которым соприкасается рендж атаки
        /// </summary>
        public void Attack()
        {
            _animator.SetTrigger(AttackKey);//включаем анимацию атаки
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position,_attackRange, _enemy);
            //в массив записываем коллайдеры с которыми соприкаснулся рендж атаки 
            foreach(Collider2D enemy in hitEnemies)//перебираем все коллайдеры
            {
                enemy.GetComponent<Enemy>().TakeDamage(_attackDamage);//атакуем))
            }
        }
        /// <summary>
        /// создаем сферу для атак ренджа
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            if (_attackPoint == null) 
                return;
            Gizmos.DrawSphere(_attackPoint.position, _attackRange);
        }
        
    }
}

