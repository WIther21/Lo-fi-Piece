namespace Game.Quest
{
    using Game.Interaction;
    public class InteractAction : QuestAction
    {
        public override void Action()
        {
            IInteractable interact = GetComponentInChildren<IInteractable>();
            if (interact == null)
                return;
            IncreaseAmount();
        }
    }
}