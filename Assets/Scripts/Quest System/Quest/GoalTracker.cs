namespace Game.Quest
{
    public class GoalTracker
    {
        private Goal _goal;
        private int _currentAmount;
        public GoalTracker(Goal goal) { _goal = goal; }
        public Goal GetGoal() { return _goal; }
        public int GetCurrentAmount() { return _currentAmount; }
        public void IncreaseAmount()
        {
            if(IsReached() == false)
                _currentAmount++;
        }
        public bool IsReached() { return _currentAmount >= _goal.GetRequiredAmount(); }
    }
}