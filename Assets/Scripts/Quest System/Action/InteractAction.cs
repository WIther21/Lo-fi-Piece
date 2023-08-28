namespace Game.Quest
{
    using Game.Interact;
    public class InteractAction : QuestAction
    {
        public override void Action()
        {
            InteractableObject interact = GetComponentInChildren<InteractableObject>();
            if (interact == null)
                return;
            IncreaseAmount();
        }
    }
}