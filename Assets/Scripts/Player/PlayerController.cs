using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private string _name;
    private int _health;
    private int _money;
    public string GetName()
    { 
        return _name; 
    }
    public int GetHealth()
    {
        return _health;
    }
    public int GetMoney()
    {
        return _money; 
    }
}