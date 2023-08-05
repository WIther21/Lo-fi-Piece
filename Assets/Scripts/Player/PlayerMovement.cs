namespace Game.Player
{
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody;
        private PlayerAnimation _playerAnimation;
        private Vector2 _direction;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerAnimation = GetComponent<PlayerAnimation>();
        }
        private void OnValidate()
        {
            if (_speed < 0)
                _speed = 0;
        }
        private void Update()
        {
            if (_playerAnimation == null)
                return;
            SetMoving();
            SetOrientation();
        }
        private void FixedUpdate()
        {
            _rigidbody.velocity = _direction * _speed;
        }
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
        private void SetMoving()
        {
            if (_direction.x != 0 || _direction.y != 0)
                _playerAnimation.SetMoving(true);
            else
                _playerAnimation.SetMoving(false);
        }
        private void SetOrientation()
        {
            if (_direction.x == 0)
            {
                if (_direction.y > 0)
                    _playerAnimation.SetOrientation(Orientation.upper);
                else if (_direction.y < 0)
                    _playerAnimation.SetOrientation(Orientation.lower);
            }
            else
            {
                if (_direction.x > 0)
                    _playerAnimation.SetOrientation(Orientation.right);
                else if (_direction.x < 0)
                    _playerAnimation.SetOrientation(Orientation.left);
            }
        }
        private void OnDisable()
        {
            _rigidbody.velocity = Vector2.zero;
            _playerAnimation.SetMoving(false);
        }
    }
}