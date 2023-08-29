namespace Game.Player
{
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void OnValidate()
        {
            if (_speed < 0)
                _speed = 0;
        }
        private void FixedUpdate()
        {
            Move();
        }
        public void SetDirection(Vector2 direction) { _direction = direction; }
        private void Move()
        {
            _rigidbody.velocity = _direction * _speed;
        }
    }
}