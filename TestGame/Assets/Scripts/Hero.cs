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
        public Vector2 _direction;//����������� �������� ������
        private Animator _animator;
        private SpriteRenderer _sprite;
        public Transform _attackPoint;
        public LayerMask _enemy;
        
        public float _attackRange;//�������� ����� 
        public int _attackDamage = 40;//���������� ������ ���������� ��� 1 �����
        



        /// <summary>
        /// ����� �������� ��������� � ����������
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
            _direction = direction;//����������� ����������� �� ������
        }
        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

            var isJumping = _direction.y > 0;//��������� ����������� ������� �� ������ �� ������
            var isGrounded = IsGrounded();
            if (isJumping && isGrounded)//���� �� �� ����� � ����������� ������������� ��,
            {
                _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);//������������ ���� � ������ ��� ������
            }
            //�������� ��������
            _animator.SetBool(IsGroundKey, isGrounded);
            _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);
            _animator.SetBool(IsRunningKey, _direction.x != 0);


            UpdateSpriteDirection();
            
        }
        /// <summary>
        /// ������� ������� ������
        /// </summary>
        private void UpdateSpriteDirection()
        {
            if (_direction.x > 0)//���� ����������� ������...

            {
                _sprite.flipX = false;//������������ ������ ������
                
            }
            else if (_direction.x < 0)//���� ����������� �����...
            {
                _sprite.flipX = true;//������������ �������
                
                
            }
            
        }
        /// <summary>
        /// �������� �� �����
        /// </summary>
        /// <returns></returns>
        private bool IsGrounded()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down, 1, _groundLayer);
            //������ ������� � ��������� ������������� �� � ������
            return hit.collider != null;
        }
        /// <summary>
        /// ����������� ���������� � ������� ������������� ����� �����
        /// </summary>
        public void Attack()
        {
            _animator.SetTrigger(AttackKey);//�������� �������� �����
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position,_attackRange, _enemy);
            //� ������ ���������� ���������� � �������� ������������� ����� ����� 
            foreach(Collider2D enemy in hitEnemies)//���������� ��� ����������
            {
                enemy.GetComponent<Enemy>().TakeDamage(_attackDamage);//�������))
            }
        }
        /// <summary>
        /// ������� ����� ��� ���� ������
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            if (_attackPoint == null) 
                return;
            Gizmos.DrawSphere(_attackPoint.position, _attackRange);
        }
        
    }
}

