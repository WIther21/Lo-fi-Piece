namespace Game.UI
{
    using UnityEngine;
    using Game.Input;
    using Game.Quest;
    using Game.Inventory;
    public class GameMenu : MonoBehaviour
    {
        private InputManager _inputManager;
        private FadeManager _fadeManager;
        private QuestManager _questManager;
        private InventoryManager _inventoryManager;
        private Fade _fade;
        private string _currentActionMap;
        private bool _isOpened;
        private void Awake()
        {
            _inputManager = FindObjectOfType<InputManager>();
            _fadeManager = GetComponent<FadeManager>();
            _questManager = GetComponentInChildren<QuestManager>();
            _inventoryManager = GetComponentInChildren<InventoryManager>();
            _fade = GetComponent<Fade>();
        }
        public void Interact()
        {
            if (_isOpened == false)
                Open();
            else
                Close();
        }
        private void Open()
        {
            _isOpened = true;
            _currentActionMap = _inputManager.GetActionMap();
            _inputManager.SetActionMap("GameMenu");
            _fade.FadeIn();
            _fadeManager.Open();
            _questManager.LoadButtons();
            _inventoryManager.Open();
            Time.timeScale = 0;
        }
        private void Close()
        {
            _isOpened = false;
            _inputManager.SetActionMap(_currentActionMap);
            _fade.FadeOut();
            _fadeManager.Close();
            _inventoryManager.Close();
            Time.timeScale = 1;
        }
    }
}