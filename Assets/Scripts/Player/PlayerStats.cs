namespace Game.Player
{
    using UnityEngine;
    public class PlayerStats : MonoBehaviour
    {
        private string _name;
        private int _health;
        private int _money;
        private void OnValidate()
        {
            if (_health < 0)
                _health = 0;
            if (_money < 0)
                _money = 0;
        }
        public string GetName() { return _name; }
        public int GetHealth() { return _health; }
        public int GetMoney() { return _money; }
        public void AddMoney(int money) { _money += money; }
    }
}