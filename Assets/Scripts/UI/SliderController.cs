namespace Game.UI
{
    using UnityEngine;
    using UnityEngine.UI;
    public class SliderController : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        private Slider _slider;
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
        public void ChangeValue()
        {
            _scrollRect.verticalNormalizedPosition = Mathf.Lerp(1, 0, _slider.value);
        }
        public void CheckRectSize()
        {
            RectTransform parent = _scrollRect.GetComponent<RectTransform>();
            RectTransform child = _scrollRect.content.GetComponent<RectTransform>();
            LayoutRebuilder.ForceRebuildLayoutImmediate(child);
            _slider.gameObject.SetActive(parent.sizeDelta.y < child.sizeDelta.y);
        }
    }
}