namespace Game.Gardening
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "New Garden Bed", menuName = "Game/Garden Bed")]
    public class GardenBedSO : ScriptableObject
    {
        [SerializeField] private Sprite _planted;
        [SerializeField] private Sprite _grown;
        [SerializeField] private Sprite _rotten;
        [SerializeField] private Sprite _plantedWatered;
        [SerializeField] private Sprite _grownWatered;
        [SerializeField] private float _growSpeed;
        [SerializeField] private string _cropKey;
        public Sprite GetPlanted() { return _planted; }
        public Sprite GetGrown() { return _grown; }
        public Sprite GetRotten() { return _rotten; }
        public Sprite GetPlantedWatered() { return _plantedWatered; }
        public Sprite GetGrownWatered() { return _grownWatered; }
        public float GetGrowSpeed() { return _growSpeed; }
        public string GetCropKey() { return _cropKey; }
    }
}