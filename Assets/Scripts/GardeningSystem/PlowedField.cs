namespace Game.Gardening
{
    using UnityEngine;
    using System.Collections;
    using Game.Interaction;
    using Game.Inventory;
    public class PlowedField : MonoBehaviour, IInteractable
    {
        [SerializeField] private GardenItemSO[] _seeds;
        [SerializeField] private GardenItemSO[] _crops;
        [SerializeField] private GardenBedSO[] _beds;
        [SerializeField] private ItemSO _wateringCan;
        [SerializeField] private Sprite _emptyBed;
        private ToolbarManager _toolbarManager;
        private GardenBedSO _currentBed;
        private SpriteRenderer _spriteRenderer;
        private GardenBedState _currentState;
        private bool _isWatered;
        private bool _isWaiting;
        private void Awake()
        {
            _toolbarManager = FindObjectOfType<ToolbarManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public void Interact()
        {
            if (_currentState == GardenBedState.Empty)
                Plant();
            else if (_currentState != GardenBedState.Rotten && _toolbarManager.GetCurrentItem().GetItem() == _wateringCan)
                Water();
            else
            {
                if (_currentState == GardenBedState.Grown)
                    Pickup();
                else if (_currentState == GardenBedState.Rotten)
                    Remove();
            }
        }
        private void SetSprite()
        {
            if (_currentState == GardenBedState.Empty)
                _spriteRenderer.sprite = _emptyBed;
            else if (_currentState == GardenBedState.Planted)
            {
                if (_isWatered)
                    _spriteRenderer.sprite = _currentBed.GetPlantedWatered();
                else
                    _spriteRenderer.sprite = _currentBed.GetPlanted();
            }
            else if (_currentState == GardenBedState.Grown)
            {
                if (_isWatered)
                    _spriteRenderer.sprite = _currentBed.GetGrownWatered();
                else
                    _spriteRenderer.sprite = _currentBed.GetGrown();
            }
            else if (_currentState == GardenBedState.Rotten)
                _spriteRenderer.sprite = _currentBed.GetRotten();
        }
        private void Water()
        {
            _isWatered = true;
            SetSprite();
            if(_isWaiting == false)
                StartCoroutine(WaitDelay());
        }
        private void Plant()
        {
            foreach (var seed in _seeds)
            {
                if (_toolbarManager.GetCurrentItem().GetItem() != seed)
                    continue;
                foreach (var bed in _beds)
                {
                    if (bed.GetCropKey() != seed.GetCropKey())
                        continue;
                    _currentBed = bed;
                    UpdateState();
                    SetSprite();
                    return;
                }
            }
        }
        private void Pickup()
        {
            foreach (var crop in _crops)
            {
                foreach (var bed in _beds)
                {
                    if (crop.GetCropKey() != bed.GetCropKey())
                        continue;
                    _toolbarManager.GiveItem(crop);
                    Remove();
                    return;
                }
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
            _isWatered = false;
            UpdateState();
            SetSprite();
            _isWaiting = false;
        }
    }
    public enum GardenBedState { Empty, Planted, Grown, Rotten }
}