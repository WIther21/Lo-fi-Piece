using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class FadeAnimation : MonoBehaviour
{
    [SerializeField] private float _fadeSpeed = 1f;
    [SerializeField] private float _fadeDelay = 0.15f;
    [SerializeField] private bool _fadeOutOnAwake;
    [SerializeField] private bool _disablePlayer;
    private Image[] _images;
    private TextMeshProUGUI[] _text;
    private PlayerInputReader _playerInputReader;
    private bool _canFade = true;
    private void Awake()
    {
        _images = GetComponentsInChildren<Image>();
        _text = GetComponentsInChildren<TextMeshProUGUI>();
        _playerInputReader = FindObjectOfType<PlayerInputReader>();
    }
    private void Start()
    {
        if (_fadeOutOnAwake == false)
            return;
        if (_disablePlayer)
            _playerInputReader.SetActive(false);
        SetAlpha(1);
        StartCoroutine(FadeOutCoroutine());
    }
    private void OnValidate()
    {
        if (_fadeSpeed < 0)
            _fadeSpeed = 0;
    }
    public void FadeIn()
    {
        if (_canFade == false)
            return;
        StartCoroutine(FadeInCoroutine());
    }
    public void FadeOut()
    {
        if (_canFade == false)
            return;
        StartCoroutine(FadeOutCoroutine());
    }
    public bool GetCompleted()
    {
        return _canFade;
    }
    private IEnumerator FadeInCoroutine()
    {
        _canFade = false;
        if (_disablePlayer)
            _playerInputReader.SetActive(false);
        yield return new WaitForSeconds(_fadeDelay);
        float alpha = 0f;
        while (alpha != 1f)
        {
            alpha = Mathf.MoveTowards(alpha, 1f, Time.deltaTime * _fadeSpeed);
            SetAlpha(alpha);
            yield return null;
        }
        _canFade = true;
    }
    private IEnumerator FadeOutCoroutine()
    {
        _canFade = false;
        yield return new WaitForSeconds(_fadeDelay);
        float alpha = 1f;
        while (alpha != 0f)
        {
            alpha = Mathf.MoveTowards(alpha, 0f, Time.deltaTime * _fadeSpeed);
            SetAlpha(alpha);
            yield return null;
        }
        if (_disablePlayer)
            _playerInputReader.SetActive(true);
        _canFade = true;
    }
    private void SetAlpha(float alpha)
    {
        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].color = new Color(_images[i].color.r, _images[i].color.g, _images[i].color.b, alpha);
        }
        for (int i = 0; i < _text.Length; i++)
        {
            _text[i].color = new Color(_text[i].color.r, _text[i].color.g, _text[i].color.b, alpha);
        }
    }
}