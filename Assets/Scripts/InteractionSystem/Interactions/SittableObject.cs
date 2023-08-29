namespace Game.Interaction
{
    using UnityEngine;
    using System.Collections;
    using Game.Input;
    using Game.Player;
    public class SittableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private Orientation _orientation;
        [SerializeField] private float _sitSpeed = 1f;
        private InputManager _inputManager;
        private PlayerManager _playerManager;
        private bool _isInteracting;
        private bool _isSitting;
        private void Awake()
        {
            _inputManager = FindObjectOfType<InputManager>();
            _playerManager = FindObjectOfType<PlayerManager>();
        }
        private void OnValidate()
        {
            if (_sitSpeed < 0)
                _sitSpeed = 0;
        }
        public void Interact()
        {
            if (_isSitting)
                return;
            if (_isInteracting == false)
                StartCoroutine(SitDown());
            else
                StartCoroutine(StandUp());
        }
        private IEnumerator SitDown()
        {
            _isSitting = true;
            _isInteracting = true;
            _inputManager.SetActionMap("Sitting");
            _playerManager.GetComponent<Collider2D>().enabled = false;
            _playerManager.GetComponent<SpriteRenderer>().sortingOrder = 1;
            _playerManager.GetAnimation().SetSitting(_orientation);
            Transform playerTransform = _playerManager.transform;
            while (playerTransform.position != transform.position)
            {
                playerTransform.position = Vector2.MoveTowards(playerTransform.position, transform.position, Time.deltaTime * _sitSpeed);
                yield return null;
            }
            _isSitting = false;
        }
        private IEnumerator StandUp()
        {
            _isSitting = true;
            Transform playerTransform = _playerManager.transform;
            Vector3 standUpPosition = transform.position + StandUpDirection() * 0.2f;
            while (playerTransform.position != standUpPosition)
            {
                playerTransform.position = Vector2.MoveTowards(playerTransform.position, standUpPosition, Time.deltaTime * _sitSpeed);
                yield return null;
            }
            _inputManager.SetActionMap("Player");
            _playerManager.GetComponent<Collider2D>().enabled = true;
            _playerManager.GetComponent<SpriteRenderer>().sortingOrder = 0;
            _playerManager.GetAnimation().SetMoving(Vector2.zero);
            _isInteracting = false;
            _isSitting = false;
        }
        private Vector3 StandUpDirection()
        {
            if (_orientation == Orientation.Left)
                return Vector3.left;
            else if (_orientation == Orientation.Right)
                return Vector3.right;
            else if (_orientation == Orientation.Down)
                return Vector3.down;
            else
                return Vector3.up;
        }
    }
}