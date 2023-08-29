namespace Game.Input
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    public class InputManager : MonoBehaviour
    {
        private InputActionAsset _inputActions;
        private PlayerInput _playerInput;
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _inputActions = _playerInput.actions;
        }
        public void SetActionMap(string name)
        {
            for (int i = 0; i < _inputActions.actionMaps.Count; i++)
            {
                if (_inputActions.actionMaps[i].name.ToUpper() == name.ToUpper())
                    _playerInput.currentActionMap = _inputActions.actionMaps[i];
            }
        }
        public string GetActionMap() { return _playerInput.currentActionMap.name; }
    }
}