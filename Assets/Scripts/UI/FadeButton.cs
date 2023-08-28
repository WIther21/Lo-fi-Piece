namespace Game.UI
{
    using UnityEngine;
    using UnityEngine.UI;
    public class FadeButton : MonoBehaviour
    {
        [SerializeField] private Fade _fade;
        private Image _image;
        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        public Fade GetFade() { return _fade; }
        public Image GetImage() { return _image; }
    }
}