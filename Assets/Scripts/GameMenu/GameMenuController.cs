namespace Game.GameMenu
{
    using UnityEngine;
    public class GameMenuController : MonoBehaviour
    {
        private GameMenu _gameMenu;
        private void Awake()
        {
            _gameMenu = FindObjectOfType<GameMenu>();
        }
        private void OnGameMenu()
        {
            _gameMenu.Interact();
        }
    }
}