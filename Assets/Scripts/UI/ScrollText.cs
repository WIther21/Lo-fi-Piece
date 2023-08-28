namespace Game.UI
{
    using UnityEngine;
    using TMPro;
    using System.Collections;
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScrollText : MonoBehaviour
    {
        [HideInInspector] public string Text;
        [HideInInspector] public float Speed;
        [HideInInspector] public Color Color;
        private TextMeshProUGUI _textHolder;
        private IEnumerator _scroll;
        private bool _isScroll;
        private void Awake()
        {
            _textHolder = GetComponent<TextMeshProUGUI>();
        }
        public void StartScroll()
        {
            _scroll = Scroll();
            _textHolder.color = Color;
            StartCoroutine(_scroll);
        }
        public void StopScroll()
        {
            StopCoroutine(_scroll);
            _textHolder.text = Text;
            _isScroll = false;
        }
        public bool IsScroll() { return _isScroll; }
        private IEnumerator Scroll()
        {
            _isScroll = true;
            for (int i = 0; i < Text.Length + 1; i++)
            {
                _textHolder.text = Text.Substring(0, i);
                yield return new WaitForSeconds(0.1f / Speed);
            }
            _isScroll = false;
        }
    }
}