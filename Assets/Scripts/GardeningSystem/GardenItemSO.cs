namespace Game.Gardening
{
    using UnityEngine;
    using Game.Inventory;
    [CreateAssetMenu(fileName = "New Garden Item", menuName = "Game/Garden Item")]
    public class GardenItemSO : ItemSO
    {
        [SerializeField] private string _cropKey;
        public string CropKey { get { return _cropKey; } }
    }
}