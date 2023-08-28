namespace Game.Interact
{
    using UnityEngine;
    using System.Collections;
    using Game.Inventory;
    public class PlowedField : InteractableObject
    {
        [SerializeField] private Sprite _emptyBed;
        [SerializeField] private ItemSO _onionSeeds;
        [SerializeField] private ItemSO _wheatSeeds;
        [SerializeField] private ItemSO _pumpkinSeeds;
        [SerializeField] private ItemSO _wateringCan;
        [SerializeField] private GardenBedSO _onionBed;
        [SerializeField] private GardenBedSO _wheatBed;
        [SerializeField] private GardenBedSO _pumpkinBed;
        [SerializeField] private ItemSO _onion;
        [SerializeField] private ItemSO _wheat;
        [SerializeField] private ItemSO _pumpkin;
        private ToolbarManager _inventoryManager;
        private GardenBedSO _currentBed;
        private SpriteRenderer _spriteRenderer;
        private GardenBedState _currentState;
        private bool _watered;
        private bool _isWaiting;
        private void Awake()
        {
            _inventoryManager = FindObjectOfType<ToolbarManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public override void Interact(PlayerInteract player)
        {
            if (_currentState == GardenBedState.Empty)
            {
                if (player.GetCurrentItem() == _onionSeeds)
                {
                    _currentBed = _onionBed;
                    UpdateState();
                    SetSprite();
                }
                else if (player.GetCurrentItem() == _wheatSeeds)
                {
                    _currentBed = _wheatBed;
                    UpdateState();
                    SetSprite();
                }
                else if (player.GetCurrentItem() == _pumpkinSeeds)
                {
                    _currentBed = _pumpkinBed;
                    UpdateState();
                    SetSprite();
                }
            }
            else if (player.GetCurrentItem() == null)
            {
                if (_currentState == GardenBedState.Grown)
                    Pickup();
                else if (_currentState == GardenBedState.Rotten)
                    Remove();
            }
            else if (player.GetCurrentItem() == _wateringCan)
            {
                if (_currentState != GardenBedState.Rotten)
                    Water();
            }
        }
        private void SetSprite()
        {
            if (_currentState == GardenBedState.Empty)
                _spriteRenderer.sprite = _emptyBed;
            else if (_currentState == GardenBedState.Planted)
            {
                if (_watered)
                    _spriteRenderer.sprite = _currentBed.GetPlantedWatered();
                else
                    _spriteRenderer.sprite = _currentBed.GetPlanted();
            }
            else if (_currentState == GardenBedState.Grown)
            {
                if (_watered)
                    _spriteRenderer.sprite = _currentBed.GetGrownWatered();
                else
                    _spriteRenderer.sprite = _currentBed.GetGrown();
            }
            else if (_currentState == GardenBedState.Rotten)
                _spriteRenderer.sprite = _currentBed.GetRotten();
        }
        private void Water()
        {
            _watered = true;
            SetSprite();
            if(_isWaiting == false)
                StartCoroutine(WaitDelay());
        }
        private void Pickup()
        {
            if (_currentBed == _onionBed)
            {
                _inventoryManager.GiveItem(_onion);
                Remove();
            }
            else if (_currentBed == _wheatBed)
            {
                _inventoryManager.GiveItem(_wheat);
                Remove();
            }
            else if (_currentBed == _pumpkinBed)
            {
                _inventoryManager.GiveItem(_pumpkin);
                Remove();
            }
        }
        private void Remove()
        {
            _currentBed = null;
            _currentState = GardenBedState.Empty;
            SetSprite();
        }
        private void UpdateState()
        {
            if (_currentState == GardenBedState.Empty)
                _currentState = GardenBedState.Planted;
            else if (_currentState == GardenBedState.Planted)
                _currentState = GardenBedState.Grown;
            else if (_currentState == GardenBedState.Grown)
                _currentState = GardenBedState.Rotten;
        }
        private IEnumerator WaitDelay()
        {
            _isWaiting = true;
            yield return new WaitForSeconds(_currentBed.GetGrowSpeed());
            _watered = false;
            UpdateState();
            SetSprite();
            _isWaiting = false;
        }
    }
    public enum GardenBedState { Empty, Planted, Grown, Rotten }
}