namespace Game.Interact
{
    using UnityEngine;
    using Game.Inventory;
    using Game.Quest;
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private Vector3 _interactionOffset;
        [SerializeField] private float _interactionRadius;
        private ToolbarManager _inventoryManager;
        private InteractableObject _currentObject;
        private ItemSO _currentItem;
        private void Awake()
        {
            _inventoryManager = FindObjectOfType<ToolbarManager>();
        }
        public virtual void Interact()
        {
            if (_currentObject)
                InteractCurrent();
            else
                InteractAny();
        }
        public void SetCrurrentInteractableObject(InteractableObject interact)
        {
            _currentObject = interact;
        }
        public void RemoveCrurrentInteractableObject()
        {
            _currentObject = null;
        }
        public ItemSO GetCurrentItem() { return _currentItem; }
        private void InteractCurrent()
        {
            _currentItem = _inventoryManager.GetCurrentItem().GetItem();
            _currentObject.Interact(this);
        }
        private void InteractAny()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + _interactionOffset, _interactionRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                InteractableObject interaction = colliders[i].GetComponent<InteractableObject>();
                if (interaction != null)
                {
                    _currentItem = _inventoryManager.GetCurrentItem().GetItem();
                    interaction.Interact(this);
                    QuestAction action = interaction.GetComponent<QuestAction>();
                    if (action != null)
                        action.Action();
                    break;
                }
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position + _interactionOffset, _interactionRadius);
        }
    }
}