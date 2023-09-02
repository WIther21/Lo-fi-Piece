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
        public Sprite Planted { get { return _planted; } }
        public Sprite Grown { get { return _grown; } }
        public Sprite Rotten { get { return _rotten; } }
        public Sprite PlantedWatered { get { return _plantedWatered; } }
        public Sprite GrownWatered { get { return _grownWatered; } }
        public float GrowSpeed { get { return _growSpeed; } }
        public string CropKey { get { return _cropKey; } }
    }
}