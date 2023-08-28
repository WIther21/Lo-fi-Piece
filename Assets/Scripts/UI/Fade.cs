namespace Game.UI
{
    using UnityEngine;
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Animator))]
    public class Fade : MonoBehaviour
    {
        public float Speed;
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void FadeIn()
        {
            _animator.speed = Speed;
            _animator.SetBool("Fade", true);
        }
        public void FadeOut()
        {
            _animator.speed = Speed;
            _animator.SetBool("Fade", false);
        }
    }
}