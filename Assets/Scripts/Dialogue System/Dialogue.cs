using UnityEngine;
[System.Serializable]
public struct Dialogue
{
    [SerializeField] private string _name;
    [SerializeField] [TextArea(1, 3)] private string _text;
    [SerializeField] private Color _color;
    public string GetName() { return _name; }
    public string GetText() { return _text; }
    public Color GetColor() { return _color; }
}