namespace Game.Dialogue
{
    using UnityEngine;
    public class GiveAction : DialogueAction
    {
        [SerializeField] private string _item;
        public override void Action()
        {
            if (_isDisabled == true)
                return;
            _isDisabled = true;
            Debug.Log(_item);
        }
    }
}