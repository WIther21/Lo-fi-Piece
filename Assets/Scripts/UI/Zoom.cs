namespace Game.UI
{
    using UnityEngine;
    [RequireComponent(typeof(Animator))]
    public class Zoom : MonoBehaviour
    {
        public float Speed;
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void ZoomIn()
        {
            _animator.speed = Speed;
            _animator.SetBool("Zoom", true);
        }
        public void ZoomOut()
        {
            _animator.speed = Speed;
            _animator.SetBool("Zoom", false);
        }
    }
}