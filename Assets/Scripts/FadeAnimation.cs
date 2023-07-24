using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class FadeAnimation : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _startValueToChange;
    [SerializeField] private float _startValue;
    [SerializeField] private float _delay;
    private Image[] _images;
    private TextMeshProUGUI[] _text;
    private float _valueToChange;
    private float _value;
    private bool _isCompleted;
    private void Awake()
    {
        _images = GetComponentsInChildren<Image>();
        _text = GetComponentsInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        _value = _startValue;
        _valueToChange = _startValue;
        SetValues();
        ChangeValue(_startValueToChange);
    }
    private void OnValidate()
    {
        if (_speed < 0)
            _speed = 0;
        if (_startValueToChange < 0 || _startValueToChange > 1)
            _startValueToChange = 0;
    }
    private void Update()
    {
        if (_value == _valueToChange)
        {
            _isCompleted = true;
        }
        else
        {
            _isCompleted = false;
            UpdateValue();
            SetValues();
        }
    }
    private void SetValues()
    {
        if (_images.Length != 0)
        {
            for (int i = 0; i < _images.Length; i++)
            {
                _images[i].color = new Color(_images[i].color.r, _images[i].color.g, _images[i].color.b, _value);
            }
        }
        if (_text.Length != 0)
        {
            for (int i = 0; i < _text.Length; i++)
            {
                _text[i].color = new Color(_text[i].color.r, _text[i].color.g, _text[i].color.b, _value);
            }
        }
    }
    private void UpdateValue()
    {
        _value = Mathf.MoveTowards(_value, _valueToChange, _speed * Time.deltaTime);
    }
    public void ChangeValue(float fadeValue)
    {
        StartCoroutine(Delay(fadeValue));
    }
    private IEnumerator Delay(float fadeValue)
    {
        yield return new WaitForSeconds(_delay);
        _valueToChange = Mathf.Clamp(fadeValue, 0f, 1f);
    }
    public bool IsCompleted()
    {
        return _isCompleted;
    }
    public float GetDelay()
    {
        return _delay;
    }
}