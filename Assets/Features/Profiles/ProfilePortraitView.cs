using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Profiles
{
    public class ProfilePortraitView : MonoBehaviour
    {
        public event EventHandler<PortraitData> Selected;
        [SerializeField] private Button button;
        [SerializeField] private Image profileImage;
        private PortraitData _portraitPortraitData;

        public void SetData(PortraitData data)
        {
            _portraitPortraitData = data;
            profileImage.sprite = data.Image;
        }

        private void OnEnable() => button.onClick.AddListener(Clicked);
        private void OnDisable() => button.onClick.RemoveListener(Clicked);
        private void Clicked() => Selected?.Invoke(this, _portraitPortraitData);
    }
}