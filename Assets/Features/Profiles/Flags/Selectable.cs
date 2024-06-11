using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles.Flags
{
    public class Selectable<T> : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        public EventHandler<T> Selected;
        private T _data;
        public void Set(T data, Sprite sprite)
        {
            _data = data;
            image.sprite = sprite;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            Selected?.Invoke(this, _data);
        }
    }
}