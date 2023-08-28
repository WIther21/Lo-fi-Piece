namespace Game.Inventory
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    public class DraggableCell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        private InventoryManager _inventoryManager;
        private void Awake()
        {
            _inventoryManager = FindObjectOfType<InventoryManager>();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            _inventoryManager.StartDrag(transform);
        }
        public void OnDrag(PointerEventData eventData)
        {
            _inventoryManager.Drag();
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _inventoryManager.StopDrag(transform);
        }
        public void OnDrop(PointerEventData eventData)
        {
            _inventoryManager.StopDrag(transform);
        }
    }
}