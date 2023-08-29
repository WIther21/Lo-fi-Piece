namespace Game.Player
{
    using UnityEngine;
    public class PlayerManager : MonoBehaviour
    {
        private PlayerStats _stats;
        private PlayerMovement _movement;
        private PlayerAnimation _animation;
        private void Awake()
        {
            _stats = GetComponent<PlayerStats>();
            _movement = GetComponent<PlayerMovement>();
            _animation = GetComponent<PlayerAnimation>();
        }
        public PlayerStats GetStats() { return _stats; }
        public PlayerMovement GetMovement() { return _movement; }
        public PlayerAnimation GetAnimation() { return _animation; }
    }
}