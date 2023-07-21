using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class FadeAnimation : MonoBehaviour
{
    [SerializeField] private float _fadeSpeed;
    [SerializeField] private float _startFadeValue;
    [SerializeField] private float _startAlpha;
    [SerializeField] private float _delay;
    private Image[] _images;
    private Text[] _text;
    private float _fadeValue;
    private float _alpha;
    private bool _isCompleted;
    private void Awake()
    {
        _images = GetComponentsInChildren<Image>();
        _text = GetComponentsInChildren<Text>();
    }
    private void Start()
    {
        _alpha = _startAlpha;
        _fadeValue = _startAlpha;
        SetAlpha();
        ChangeFadeValue(_startFadeValue);
    }
    private void OnValidate()
    {
        if (_fadeSpeed < 0)
            _fadeSpeed = 0;
        if (_startFadeValue < 0 || _startFadeValue > 1)
            _startFadeValue = 0;
    }
    private void Update()
    {
        if (_alpha == _fadeValue)
        {
            _isCompleted = true;
        }
        else
        {
            _isCompleted = false;
            UpdateValue();
            SetAlpha();
        }
    }
    private void SetAlpha()
    {
        if (_images.Length != 0)
        {
            for (int i = 0; i < _images.Length; i++)
            {
                _images[i].color = new Color(_images[i].color.r, _images[i].color.g, _images[i].color.b, _alpha);
            }
        }
        if (_text.Length != 0)
        {
            for (int i = 0; i < _text.Length; i++)
            {
                _text[i].color = new Color(_text[i].color.r, _text[i].color.g, _text[i].color.b, _alpha);
            }
        }
    }
    private void UpdateValue()
    {
        _alpha = Mathf.MoveTowards(_alpha, _fadeValue, _fadeSpeed * Time.deltaTime);
    }
    public void ChangeFadeValue(float fadeValue)
    {
        StartCoroutine(DelayFade(fadeValue));
    }
    public bool IsCompleted()
    {
        return _isCompleted;
    }
    public float GetDelay()
    {
        return _delay; 
    }
    private IEnumerator DelayFade(float fadeValue)
    {
        yield return new WaitForSeconds(_delay);
        _fadeValue = Mathf.Clamp(fadeValue, 0f, 1f);
    }
}