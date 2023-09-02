namespace Game.Inventory
{
    using UnityEngine;
    public abstract class Cell : MonoBehaviour
    {
        public InventoryItem InventoryItem { get; private set; }
        protected virtual void Awake()
        {
            InventoryItem = GetComponentInChildren<InventoryItem>();
        }
    }
}