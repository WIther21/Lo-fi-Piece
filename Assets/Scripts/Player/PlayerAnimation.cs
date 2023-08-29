namespace Game.Player
{
    using UnityEngine;
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void SetMoving(Vector2 direction)
        {
            if (direction.x == 0 && direction.y == 0)
            {
                SetAnimatorStay();
                return;
            }
            SetAnimatorMoving();
            if (direction.x == 0)
            {
                if (direction.y > 0)
                    SetOrientation(Orientation.Up);
                else
                    SetOrientation(Orientation.Down);
            }
            else
            {
                if (direction.x > 0)
                    SetOrientation(Orientation.Right);
                else
                    SetOrientation(Orientation.Left);
            }
        }
        public void SetSitting(Orientation orientation)
        {
            SetAnimatorSitting();
            SetOrientation(orientation);
        }
        private void SetAnimatorStay()
        {
            _animator.SetBool("IsMoving", false);
            _animator.SetBool("IsSitting", false);
        }
        private void SetAnimatorMoving()
        {
            _animator.SetBool("IsMoving", true);
            _animator.SetBool("IsSitting", false);
        }
        private void SetAnimatorSitting()
        {
            _animator.SetBool("IsMoving", false);
            _animator.SetBool("IsSitting", true);
        }
        private void SetOrientation(Orientation orientation)
        {
            if (orientation == Orientation.Left)
            {
                SetLayer(1);
                if (IsRight())
                    Flip();
            }
            else if (orientation == Orientation.Right)
            {
                SetLayer(1);
                if (IsLeft())
                    Flip();
            }
            else if (orientation == Orientation.Down)
                SetLayer(2);
            else
                SetLayer(3);
        }
        private void Flip()
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        private void SetLayer(int index)
        {
            index = Mathf.Clamp(index, 0, _animator.layerCount - 1);
            for (int i = 0; i < _animator.layerCount; i++)
            {
                if (i == index)
                    _animator.SetLayerWeight(i, 1);
                else
                    _animator.SetLayerWeight(i, 0);
            }
        }
        private bool IsRight() { return transform.localScale.x > 0; }
        private bool IsLeft() { return transform.localScale.x < 0; }
    }
    public enum Orientation { Left, Right, Down, Up }
}